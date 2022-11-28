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
    public class trialbalance
    {

		public static datatrialbalance readPTallytrialbalance(string GodwnName, string FromDate,string  toDate)
		{

            try
            {
                datatrialbalance myDeserializedClass = new datatrialbalance();
                var SendScript = "<ENVELOPE><HEADER><VERSION>1</VERSION><TALLYREQUEST>Export</TALLYREQUEST><TYPE>Data</TYPE><ID>Trial Balance</ID></HEADER><BODY><DESC><STATICVARIABLES><SVCURRENTCOMPANY>"+ GodwnName + "</SVCURRENTCOMPANY><EXPLODEFLAG>Yes</EXPLODEFLAG><SVEXPORTFORMAT>$$SysName:XML</SVEXPORTFORMAT><SVFROMDATE TYPE='Date'>"+FromDate+"</SVFROMDATE><SVTODATE TYPE='Date'>"+toDate+"</SVTODATE></STATICVARIABLES></DESC></BODY></ENVELOPE>";
                var DataStrGet = ReadTallyWebhost.readTallyDataXMLNode(SendScript);

                string text = JsonConvert.SerializeXmlNode(DataStrGet);
                text = text.Replace(".LIST", "LIST").Replace("ENVELOPE", "ENVELOPEtrialbalance");
                myDeserializedClass = JsonConvert.DeserializeObject<datatrialbalance>(text.Replace("@NAME", "NAMEMA"));
                int DSP = 1;
                myDeserializedClass.ENVELOPEtrialbalance.DSPACCNAME.ForEach(p => { p.number = (DSP++); });
                DSP = 1;
                myDeserializedClass.ENVELOPEtrialbalance.DSPACCINFO.ForEach(p => { p.number = (DSP++); });
                return myDeserializedClass;


            }
            catch { return new datatrialbalance(); }
        }
    }
}


public class DSPCLDRAMT
{
    public string DSPCLDRAMTA { get; set; }
}

public class DSPCLCRAMT
{
    public string DSPCLCRAMTA { get; set; }
}

public class DSPACCINFO
{
    public DSPCLDRAMT DSPCLDRAMT { get; set; }
    public DSPCLCRAMT DSPCLCRAMT { get; set; }
    public int number { get; set; }

}

public class ENVELOPEtrialbalance
{
    public List<DSPACCNAME> DSPACCNAME { get; set; }
    public List<DSPACCINFO> DSPACCINFO { get; set; }
}

public class datatrialbalance
{
    public ENVELOPEtrialbalance ENVELOPEtrialbalance { get; set; }
}

