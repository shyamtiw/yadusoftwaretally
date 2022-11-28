using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;
using WebApp.admin.ReportModal;
using WebApp.LIBS;
using WebApp.TallyLibs;

namespace WebApp.TallyData
{
    public class TrialBalanceWithGUID
    {
        public static DataTable readPTallyBalanceSheet(string GodwnName, string TallyURL, string FromDate, string toDate, int COmpId, int GOdwCode,string FilterData="")
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("guid", Type.GetType("System.String"));
            dt.Columns.Add("ledgerName", Type.GetType("System.String"));
        
            dt.Columns.Add("openingBalance", Type.GetType("System.Decimal"));
            dt.Columns.Add("closingBalance", Type.GetType("System.Decimal"));
            dt.Columns.Add("balance", Type.GetType("System.Decimal"));
            dt.Columns.Add("syncDate", Type.GetType("System.String"));
            dt.Columns.Add("synctime", Type.GetType("System.String"));
            dt.Columns.Add("alterid", Type.GetType("System.Int32"));
            


            try
            {

               

                var RequestXML = string.Concat(new string[]
                    {
                    "<ENVELOPE><HEADER><TALLYREQUEST>Export Data</TALLYREQUEST></HEADER><BODY><EXPORTDATA><REQUESTDESC><REPORTNAME>ODBC Report</REPORTNAME><SQLREQUEST TYPE='General' METHOD='SQLExecute'>SELECT $Guid,$Openingbalance, $ClosingBalance,$Name,$Alterid FROM Ledger "+FilterData+" </SQLREQUEST><STATICVARIABLES><SVCURRENTCOMPANY>",
                   GodwnName,
                    "</SVCURRENTCOMPANY><SVFROMDATE Type='Date'>",
                    FromDate,
                    "</SVFROMDATE><SVTODATE Type='Date'>",
                    toDate,
                    "</SVTODATE><SVEXPORTFORMAT>$$SysName:XML</SVEXPORTFORMAT></STATICVARIABLES></REQUESTDESC><REQUESTDATA></REQUESTDATA></EXPORTDATA></BODY></ENVELOPE>"
                    });

                var xmlDocument = ReadTallyWebhost.readTallyDataXMLNode(RequestXML, TallyURL);

                if (xmlDocument.InnerXml != "")
                {


                    XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("RESULTDATA");
                    foreach (object obj in elementsByTagName)
                    {
                        XmlNode xmlNode = (XmlNode)obj;
                        string innerXml = xmlNode.InnerXml;
                        if (innerXml != "")
                        {
                            foreach (object obj2 in xmlNode)
                            {
                                XmlNode xmlNode2 = (XmlNode)obj2;
                                if (xmlNode2.Name == "ROW")
                                {
                                    try
                                    {
                                        string text = JsonConvert.SerializeXmlNode(xmlNode2);
                                        text = text.Replace(".LIST", "LIST");


                                        DataRow objLedger = dt.NewRow();



                                        objLedger["guid"] = xmlNode2.ChildNodes[0].InnerText;
                                        objLedger["ledgerName"] = Common.ReplaceChar( xmlNode2.ChildNodes[3].InnerText);
                                        objLedger["syncDate"] = DateTime.Now.ToString("dd-MMM-yyyy");
                                        objLedger["synctime"] = DateTime.Now.ToString("hh:mm tt");

                                        objLedger["openingBalance"] = convertAmountToDecimal(xmlNode2.ChildNodes[1].InnerText.ToString());
                                        objLedger["closingBalance"] = convertAmountToDecimal(xmlNode2.ChildNodes[2].InnerText.ToString());
                                        objLedger["AlterId"] = xmlNode2.ChildNodes[4].InnerText.ToString().ConvertInt();
                                        objLedger["balance"] = objLedger["closingBalance"];
                                        dt.Rows.Add(objLedger);
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                }
            }
            catch { }



            return dt;


        


}



        public  static decimal convertAmountToDecimal(string text)
        {
            text = text.Trim();
            decimal num = 0m;
            decimal result;
            try
            {
                try
                {
                    if (text.Trim() == "")
                    {
                        num = 0m;
                    }
                    else
                    {
                        num = Convert.ToDecimal(text);
                    }
                }

                catch (Exception)
                {
                    text = text.Replace('/', ' ');
                    text = text.Replace("? ", "");
                    int num2 = 0;
                   
                    string[] array = text.Trim().Split(new char[]
                    {
                        ' '
                    });
                    string text2;
                    if (array.Length > 0)
                    {
                        text2 = new string((from c in array[0].ToCharArray()
                                            where char.IsDigit(c) || c == '.' || c == '-'
                                            select c).ToArray<char>());
                        if (text2 == "" && array.Length > 1)
                        {
                            text2 = new string((from c in array[1].ToCharArray()
                                                where char.IsDigit(c) || c == '.' || c == '-'
                                                select c).ToArray<char>());
                        }
                    }
                    else
                    {
                        text2 = "0";
                    }
                    num = Convert.ToDecimal(text2);
                }
                result = num;
            }
            catch (Exception)
            {
                result = num;
            }
            return result;
        }


        public static List<string> GetCompnay(string TallyURL)
        {
            var RequestXML = "<ENVELOPE><HEADER><TALLYREQUEST>Export Data</TALLYREQUEST></HEADER><BODY><EXPORTDATA><REQUESTDESC><REPORTNAME>ODBC Report</REPORTNAME><SQLREQUEST TYPE='General' METHOD='SQLExecute'>SELECT $Name FROM Company order by $Name </SQLREQUEST><STATICVARIABLES><SVEXPORTFORMAT>$$SysName:XML</SVEXPORTFORMAT></STATICVARIABLES></REQUESTDESC><REQUESTDATA></REQUESTDATA></EXPORTDATA></BODY></ENVELOPE>";


            List<string> data = new List<string>();

           XmlDocument tallyOpenCompany = ReadTallyWebhost.readTallyDataXMLNode(RequestXML, TallyURL);
            XmlNodeList elementsByTagName = tallyOpenCompany.GetElementsByTagName("RESULTDATA");
            foreach (object obj in elementsByTagName)
            {
                XmlNode xmlNode = (XmlNode)obj;
                string innerXml = xmlNode.InnerXml;
                if (innerXml != "")
                {
                    foreach (object obj2 in xmlNode)
                    {
                        XmlNode xmlNode2 = (XmlNode)obj2;
                        if (xmlNode2.Name == "ROW")
                        {
                            string item = Common.ReplaceChar(xmlNode2.ChildNodes[0].InnerText.ToString());
                            data.Add(item);
                            
                        }
                    }
                }
            }

            return data;
        }
    

    }



    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class COL
{
    public string NAME { get; set; }
    public string ALIAS { get; set; }
    public string TYPE { get; set; }
    public string LENGTH { get; set; }
    public string PRECISION { get; set; }
    public string NULLABLE { get; set; }
}

public class ROWDESC
{
    public List<COL> COL { get; set; }
}

public class RESULTDESC
{
    public ROWDESC ROWDESC { get; set; }
}

public class ROW
{
    public List<string> COL { get; set; }
}

public class RESULTDATA
{
    public List<ROW> ROW { get; set; }
}

public class EXPORTDATARESPONSE
{
    [JsonProperty("@ResultType")]
    public string ResultType { get; set; }
    public RESULTDESC RESULTDESC { get; set; }
    public RESULTDATA RESULTDATA { get; set; }
}

public class BODY
{
    public EXPORTDATARESPONSE EXPORTDATARESPONSE { get; set; }
}

public class ENVELOPBalanceSheet
{
    public string HEADER { get; set; }
    public BODY BODY { get; set; }
}

public class Root
{
    public ENVELOPBalanceSheet ENVELOPBalanceSheet { get; set; }
}




}
