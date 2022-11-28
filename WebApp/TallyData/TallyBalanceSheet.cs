using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Serialization;
using WebApp.TallyLibs;

namespace WebApp.TallyData
{
    public class TallyBalanceSheet
    {

		public static TallyBalanceSheeet readPTallyBalanceSheet(string GodwnName, string FromDate,string  toDate)
		{

            try
            {
                TallyBalanceSheeet myDeserializedClass = new TallyBalanceSheeet();
                var SendScript = "<ENVELOPE><HEADER><TALLYREQUEST>Export Data</TALLYREQUEST></HEADER><BODY><EXPORTDATA><REQUESTDESC><STATICVARIABLES><SVEXPORTFORMAT>$$SysName:XML</SVEXPORTFORMAT><SVCURRENTCOMPANY>"+GodwnName+"</SVCURRENTCOMPANY><SVFROMDATE TYPE='Date'>"+FromDate+"</SVFROMDATE><SVTODATE TYPE='Date'>"+toDate+"</SVTODATE></STATICVARIABLES><REPORTNAME>Balance Sheet</REPORTNAME></REQUESTDESC></EXPORTDATA></BODY></ENVELOPE>";
                var DataStrGet = ReadTallyWebhost.readTallyDataXMLNode(SendScript);

                string text = JsonConvert.SerializeXmlNode(DataStrGet);
                text = text.Replace(".LIST", "LIST").Replace("ENVELOPE", "ENVELOPEBalanceSheeet");
                myDeserializedClass = JsonConvert.DeserializeObject<TallyBalanceSheeet>(text.Replace("@NAME", "NAMEMA"));
                int DSP = 1;
                myDeserializedClass.ENVELOPEBalanceSheeet.BSNAME.ForEach(p => { p.number = (DSP++); });
                DSP = 1;
                myDeserializedClass.ENVELOPEBalanceSheeet.BSAMT.ForEach(p => { p.number = (DSP++); });
                return myDeserializedClass;


            }
            catch { return new TallyBalanceSheeet(); }
        }
    }
}


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 


public class BSNAME
{
    public DSPACCNAME DSPACCNAME { get; set; }
    public int number { get; set; }
}

public class BSAMT
{
    public string BSSUBAMT { get; set; }
    public string BSMAINAMT { get; set; }
    public int number { get; set; }
}

public class ENVELOPEBalanceSheeet
{
    public List<BSNAME> BSNAME { get; set; }
    public List<BSAMT> BSAMT { get; set; }
}

public class TallyBalanceSheeet
{
    public ENVELOPEBalanceSheeet ENVELOPEBalanceSheeet { get; set; }
}

