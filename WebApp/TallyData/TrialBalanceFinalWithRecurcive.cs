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
    public class TrialBalanceFinalWithRecurcive
    {
        public static List<FinalClass> readPTallyBalanceSheet(string GodwnName,string TallyURL, string FromDate, string toDate,int COmpId,int GOdwCode)
        {

            try
            {
                RootENVELOPEFinalTuch myDeserializedClass = new RootENVELOPEFinalTuch();
                var SendScript = "<ENVELOPE><HEADER><VERSION>1</VERSION><TALLYREQUEST>Export</TALLYREQUEST><TYPE>Data</TYPE><ID>Trial Balance</ID></HEADER><BODY><DESC><STATICVARIABLES><SVCURRENTCOMPANY>" + GodwnName + "</SVCURRENTCOMPANY><EXPLODEALLLEVELS>YES</EXPLODEALLLEVELS><DSPSHOWOPENING>YES</DSPSHOWOPENING><DSPSHOWTRANS>Yes</DSPSHOWTRANS><ISLEDGERWISE>YES</ISLEDGERWISE><EXPLODEFLAG>Yes</EXPLODEFLAG><SVEXPORTFORMAT>$$SysName:XML</SVEXPORTFORMAT><SVFROMDATE TYPE='Date'>" + FromDate + "</SVFROMDATE><SVTODATE TYPE='Date'>" + toDate + "</SVTODATE></STATICVARIABLES></DESC></BODY></ENVELOPE>";
                var DataStrGet = ReadTallyWebhost.readTallyDataXMLNode(SendScript, TallyURL);

                string text = JsonConvert.SerializeXmlNode(DataStrGet);
                text = text.Replace(".LIST", "LIST").Replace("ENVELOPE", "ENVELOPEFinalTuch").Replace("DSPACCINFO", "DSPACCINFOFinalTuch");
                myDeserializedClass = JsonConvert.DeserializeObject<RootENVELOPEFinalTuch>(text.Replace("@NAME", "NAMEMA"));
                int DSP = 1;
                myDeserializedClass.ENVELOPEFinalTuch.DSPACCINFOFinalTuch.ForEach(p => { p.DSPCLAMT.Number = (DSP++); p.DSPCRAMT.Number = p.DSPCLAMT.Number; p.DSPDRAMT.Number = p.DSPCLAMT.Number; p.DSPOPAMT.Number = p.DSPCLAMT.Number; });
                DSP = 1;
                myDeserializedClass.ENVELOPEFinalTuch.DSPACCINFOFinalTuch.ToList().ForEach(p => { p.Number = (DSP++); });
                DSP = 1;
                myDeserializedClass.ENVELOPEFinalTuch.DSPACCNAME.ToList().ForEach(p => { p.number = (DSP++); });
                List<FinalClass> returnlist = myDeserializedClass.ENVELOPEFinalTuch.DSPACCINFOFinalTuch.Select(p => new FinalClass() { companyId= COmpId, GodwnId= GOdwCode, LedgerName = LedgerNameGate(myDeserializedClass.ENVELOPEFinalTuch.DSPACCNAME.ToList(), p.Number), OPENINGBALANCE = p.DSPOPAMT.DSPOPAMTA, DEBITBALANCE = p.DSPDRAMT.DSPDRAMTA, CREDITBALANCE = p.DSPCRAMT.DSPCRAMTA, CLOSINGBALANCE = p.DSPCLAMT.DSPCLAMTA }).ToList();

                return returnlist;


            }
            catch { return new List<FinalClass>(); }
        }

        private static string LedgerNameGate(List<DSPACCNAME> listdata, int Number)
        {
            return WebApp.LIBS.Common.ReplaceChar(listdata.Where(p => p.number == Number).FirstOrDefault().DSPDISPNAME);



        }
    }


}
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

public class DSPOPAMT
{
    public string DSPOPAMTA { get; set; }
    public int Number { get; set; }
}

public class DSPDRAMT
{
    public string DSPDRAMTA { get; set; }
    public int Number { get; set; }
}

public class DSPCRAMT
{
    public string DSPCRAMTA { get; set; }
    public int Number { get; set; }
}

public class DSPCLAMT
{
    public string DSPCLAMTA { get; set; }
    public int Number { get; set; }
}

public class DSPACCINFOFinalTuch
{
    public DSPOPAMT DSPOPAMT { get; set; }
    public DSPDRAMT DSPDRAMT { get; set; }
    public DSPCRAMT DSPCRAMT { get; set; }
    public DSPCLAMT DSPCLAMT { get; set; }
    public int Number { get; set; }
}

public class ENVELOPEFinalTuch
{
    public List<DSPACCNAME> DSPACCNAME { get; set; }
    public List<DSPACCINFOFinalTuch> DSPACCINFOFinalTuch { get; set; }
}

public class RootENVELOPEFinalTuch
{
    public ENVELOPEFinalTuch ENVELOPEFinalTuch { get; set; }
}



public partial class FinalClass
{

    public int companyId { get; set; }
    public int GodwnId { get; set; }
    public string LedgerName { get; set; }
    public string OPENINGBALANCE { get; set; }
    public string DEBITBALANCE { get; set; }
    public string CREDITBALANCE { get; set; }
    public string CLOSINGBALANCE { get; set; }
}