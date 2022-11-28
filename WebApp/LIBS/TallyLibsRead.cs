using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace WebApp.LIBS
{
    public class TallyLibsRead
    {

        public static ENVELOPE ReadCashFlow(string XMLString, string SERVER, string PORT)
        {
            ENVELOPE listAllEntries = new ENVELOPE();
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(SERVER + ":" + PORT);
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentLength = (long)XMLString.Length;
                httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-32, ISO-8859-1, UTF-8";
                httpWebRequest.Timeout = -1;
                streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
                streamWriter.Write(XMLString);
                streamWriter.Close();
                string xml = "";
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    xml = streamReader.ReadToEnd();


                 


                    XmlSerializer serializer = new XmlSerializer(typeof(ENVELOPE));
                    using (TextReader reader = new StringReader(xml))
                    {
                        listAllEntries = (ENVELOPE)serializer.Deserialize(reader);
                       
                    }




                    //var productList = (List<ENVELOPE>)serializer.Deserialize((streamReader);
                    streamReader.Close();
                }
              

            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            return listAllEntries;
        }
        private static StreamWriter streamWriter = null;


        // Token: 0x060002DD RID: 733 RVA: 0x0000A248 File Offset: 0x00008448

        //[STAThread]
        //public static List<ENVELOPE> ReadCashFlow(string XMLString, string SERVER, string PORT)
        //{
        //    List<ENVELOPE> productList = null;
        //    try
        //    {

        //        //var client = new RestClient("http://localhost:9000/");
        //        //client.Timeout = -1;
        //        //var request = new RestRequest(Method.GET);
        //        //request.AddHeader("Content-Type", "application/xml");
        //        ////request.AddParameter("application/xml", "<!--Gateway of Tally @Display @Statement of Accounts..contd-->\r\n<!--@Account Books @Cash/Bank summary-->\r\n\r\n<ENVELOPE>\r\n<HEADER>\r\n<TALLYREQUEST>Export Data</TALLYREQUEST>\r\n</HEADER>\r\n<BODY>\r\n<EXPORTDATA>\r\n<REQUESTDESC>\r\n<STATICVARIABLES>\r\n\r\n<!--Specify the period here-->\r\n<SVFROMDATE>20070401</SVFROMDATE>\r\n<SVTODATE>20220331</SVTODATE>\r\n\r\n<!--Specify the Export format here  HTML or XML or SDF-->\r\n<SVEXPORTFORMAT>$$SysName:xml</SVEXPORTFORMAT>\r\n</STATICVARIABLES>\r\n\r\n<!--Specify the Report Name here-->\r\n<REPORTNAME>Bank Group summary</REPORTNAME>\r\n\r\n</REQUESTDESC>\r\n</EXPORTDATA>\r\n</BODY>\r\n</ENVELOPE>\r\n", ParameterType.RequestBody);
        //        //IRestResponse response = client.Execute(request);
        //        //Console.WriteLine(response.Content);


        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:9000/");
        //    byte[] bytes;
        //    bytes = System.Text.Encoding.ASCII.GetBytes(XMLString);
        //    request.ContentType = "text/xml; encoding='utf-8'";
        //    request.ContentLength = bytes.Length;

        //        request.KeepAlive = true;
        //        request.Method = "GET";
        //    Stream requestStream = request.GetRequestStream();
        //    requestStream.Write(bytes, 0, bytes.Length);
        //    requestStream.Close();



        //        HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse();
        //        using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
        //        {


        //            XmlSerializer serializer = new XmlSerializer(typeof(List<ENVELOPE>), new XmlRootAttribute("ENVELOPE"));
        //           productList = (List<ENVELOPE>)serializer.Deserialize(streamReader);
        //            streamReader.Close();
        //        }
        //        //xmlDocument.LoadXml(xml);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return productList;
        //}


    }


    #region CashAndbankBook
    [XmlRoot(ElementName = "DSPACCNAME")]
    public class DSPACCNAME
    {

        [XmlElement(ElementName = "DSPDISPNAME")]
        public string DSPDISPNAME { get; set; }
    }

    [XmlRoot(ElementName = "DSPCLDRAMT")]
    public class DSPCLDRAMT
    {

        [XmlElement(ElementName = "DSPCLDRAMTA")]
        public object DSPCLDRAMTA { get; set; }
    }

    [XmlRoot(ElementName = "DSPCLCRAMT")]
    public class DSPCLCRAMT
    {

        [XmlElement(ElementName = "DSPCLCRAMTA")]
        public object DSPCLCRAMTA { get; set; }
    }

    [XmlRoot(ElementName = "DSPACCINFO")]
    public class DSPACCINFO
    {

        [XmlElement(ElementName = "DSPCLDRAMT")]
        public DSPCLDRAMT DSPCLDRAMT { get; set; }

        [XmlElement(ElementName = "DSPCLCRAMT")]
        public DSPCLCRAMT DSPCLCRAMT { get; set; }
    }

    [XmlRoot(ElementName = "ENVELOPE")]
    public class ENVELOPE
    {

        [XmlElement(ElementName = "DSPACCNAME")]
        public List<DSPACCNAME> DSPACCNAME { get; set; }

        [XmlElement(ElementName = "DSPACCINFO")]
        public List<DSPACCINFO> DSPACCINFO { get; set; }
    }



    #endregion
}