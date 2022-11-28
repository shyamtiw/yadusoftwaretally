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
    public class TallyProfitandloss
    {

		public static ProfitAndLoss readProfitAndLoss(string GodwnName, string FromDate,string  toDate)
		{

            try
            {
                ProfitAndLoss myDeserializedClass = new ProfitAndLoss();
                var SendScript = "<ENVELOPE><HEADER><TALLYREQUEST>Export Data</TALLYREQUEST> </HEADER><BODY> <EXPORTDATA> <REQUESTDESC> <STATICVARIABLES><SVEXPORTFORMAT>$$SysName:XML</SVEXPORTFORMAT><SVCURRENTCOMPANY>" + GodwnName + "</SVCURRENTCOMPANY><SVFROMDATE TYPE='Date'>" + FromDate + "</SVFROMDATE><SVTODATE TYPE='Date'>" + toDate + "</SVTODATE></STATICVARIABLES><REPORTNAME>Profit and Loss</REPORTNAME></REQUESTDESC></EXPORTDATA></BODY></ENVELOPE>";
                var DataStrGet = ReadTallyWebhost.readTallyDataXMLNode(SendScript);

                string text = JsonConvert.SerializeXmlNode(DataStrGet);
                text = text.Replace(".LIST", "LIST");
                myDeserializedClass = JsonConvert.DeserializeObject<ProfitAndLoss>(text.Replace("@NAME", "NAMEMA"));
                int DSP = 1;
                myDeserializedClass.ENVELOPE.DSPACCNAME.ForEach(p => { p.number = (DSP++); });
                DSP = 1;
                myDeserializedClass.ENVELOPE.PLAMT.ForEach(p => { p.number = (DSP++); });
                return myDeserializedClass;


            }
            catch { return new  ProfitAndLoss(); }
        }
    }
}

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
public class DSPACCNAME
{
    public string DSPDISPNAME { get; set; }
    public int number { get; set; }
}


public class PLAMT
{
    public string PLSUBAMT { get; set; }
    public string BSMAINAMT { get; set; }
    public int number { get; set; }
    
}

public class ENVELOPE
{
    public List<DSPACCNAME> DSPACCNAME { get; set; }
    public List<PLAMT> PLAMT { get; set; }
}

public class ProfitAndLoss
{
    public ENVELOPE ENVELOPE { get; set; }
}

