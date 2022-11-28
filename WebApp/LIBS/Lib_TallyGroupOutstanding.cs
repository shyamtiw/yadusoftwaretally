using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;
using WebApp.admin.ReportModal;
using WebApp.TallyLibs;

namespace WebApp.LIBS
{
    public class Lib_TallyGroupOutstanding
    {

        public static DataSet GetDGetDataFromDataTableTally(DateTime FromDate, DateTime ToDate, string GodwnName, string TallyUrl, string GroupName)
        {

           
            DataSet ds = new DataSet();
            try
            {
                TallyBalanceSheeet myDeserializedClass = new TallyBalanceSheeet();
                var SendScript = "<ENVELOPE><HEADER><TALLYREQUEST>Export Data</TALLYREQUEST></HEADER><BODY><EXPORTDATA><REQUESTDESC><STATICVARIABLES><SVEXPORTFORMAT>$$SysName:XML</SVEXPORTFORMAT><DSPSHOWOPENING>Yes</DSPSHOWOPENING> <DSPSHOWTRANS>Yes</DSPSHOWTRANS><SVCURRENTCOMPANY>" + GodwnName + "</SVCURRENTCOMPANY><SVFROMDATE TYPE='Date'>" + FromDate.ToString("yyyyMMdd") + "</SVFROMDATE><SVTODATE TYPE='Date'>" + ToDate.ToString("yyyyMMdd") + "</SVTODATE><ISLEDGERWISE>YES</ISLEDGERWISE><GROUPNAME>" + GroupName + "</GROUPNAME></STATICVARIABLES><REPORTNAME>Group Summary</REPORTNAME></REQUESTDESC></EXPORTDATA></BODY></ENVELOPE>";
                var DataStrGet = ReadTallyWebhost.readTallyDataXMLNode(SendScript, TallyUrl);

                string text = JsonConvert.SerializeXmlNode(DataStrGet);
                text = text.Replace(".LIST", "LIST").Replace("ENVELOPE", "ENTallyGroupOutstanding");
                 ds= jsonToDataSet(text);

            }
            catch { }
            return ds;
        }


        public static DataSet GetDGetDataFromDataTableTallyBillwise(DateTime FromDate, DateTime ToDate, string GodwnName, string TallyUrl, string GroupName)
        {


            DataSet ds = new DataSet();
            try
            {
                TallyBalanceSheeet myDeserializedClass = new TallyBalanceSheeet();
                var SendScript = "<ENVELOPE><HEADER><TALLYREQUEST>Export Data</TALLYREQUEST></HEADER><BODY><EXPORTDATA><REQUESTDESC><STATICVARIABLES><SVFROMDATE>" + FromDate.ToString("yyyyMMdd") + "</SVFROMDATE><SVTODATE>" + ToDate.ToString("yyyyMMdd") + "</SVTODATE><SVCURRENTCOMPANY>" + GodwnName + "</SVCURRENTCOMPANY><GROUPNAME>" + GroupName + "</GROUPNAME><SHOWBYBILL>YES</SHOWBYBILL><EXPLODEFLAG>Yes</EXPLODEFLAG><SHOWBILLTYPE>$$SysName:AllBills</SHOWBILLTYPE><SVEXPORTFORMAT>$$SysName:XML</SVEXPORTFORMAT></STATICVARIABLES><REPORTNAME>Group Outstandings</REPORTNAME></REQUESTDESC></EXPORTDATA></BODY></ENVELOPE>";
                var DataStrGet = ReadTallyWebhost.readTallyDataXMLNode(SendScript, TallyUrl);

                string text = JsonConvert.SerializeXmlNode(DataStrGet);
                text = text.Replace(".LIST", "LIST").Replace("ENVELOPE", "ENTallyGroupOutstanding");
                ds = jsonToDataSet(text);

            }
            catch { }
            return ds;
        }



        public static DataSet jsonToDataSet(string jsonString)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                jsonString = "{ \"rootNode\": {" + jsonString.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xd = (XmlDocument)JsonConvert.DeserializeXmlNode(jsonString);
                DataSet ds = new DataSet();
                ds.ReadXml(new XmlNodeReader(xd));
                return ds;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
 