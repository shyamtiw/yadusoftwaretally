using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

namespace WebApp.TallyLibs
{
    public partial class ReadTallyWebhost
    {
      
        public static string  readTallyData(string RequestXML)
        {
           
            try
            {
               var   TallyRequest = WebRequest.Create(LIBS.SiteKey.TallyURL);
                ((HttpWebRequest)TallyRequest).UserAgent = ".NET Framework Example Client";
                TallyRequest.Method = "POST";
                byte[] bytes = Encoding.UTF8.GetBytes(RequestXML);
                TallyRequest.ContentType = "application/x-www-form-urlencoded";
                TallyRequest.ContentLength = (long)bytes.Length;
                Stream stream = TallyRequest.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
                WebResponse response = TallyRequest.GetResponse();
                ((HttpWebResponse)response).StatusDescription.ToString();
                stream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream);
                string text = streamReader.ReadToEnd().ToString();
                string pattern = "[\0-\b\v\f\u000e-\u001f&]";
                text = Regex.Replace(text, pattern, "", RegexOptions.Compiled);
                XmlReaderSettings xmlReaderSettings = new XmlReaderSettings
                {
                    NameTable = new NameTable()
                };
                XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlReaderSettings.NameTable);
                xmlNamespaceManager.AddNamespace("UDF", "http://www.w3.org/2001/XMLSchema-instance");
                XmlParserContext inputContext = new XmlParserContext(null, xmlNamespaceManager, "", XmlSpace.Default);
                string s = text;
             
                streamReader.Close();
                stream.Close();
                response.Close();
                return s;
            }
            catch (Exception)
            {
                return "";
            }
            
        }
        
               public static XmlDocument readTallyDataXMLNode(string RequestXML, string TallyURL)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlDocument result;
            try
            {
                var TallyRequest = WebRequest.Create(TallyURL);
                ((HttpWebRequest)TallyRequest).UserAgent = ".NET Framework Example Client";
                TallyRequest.Method = "POST";
                byte[] bytes = Encoding.UTF8.GetBytes(RequestXML);
                TallyRequest.ContentType = "application/x-www-form-urlencoded";
                TallyRequest.ContentLength = (long)bytes.Length;
                Stream stream = TallyRequest.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
                WebResponse response = TallyRequest.GetResponse();
                ((HttpWebResponse)response).StatusDescription.ToString();
                stream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream);
                string text = streamReader.ReadToEnd().ToString();
                string pattern = "[\0-\b\v\f\u000e-\u001f&]";
                text = Regex.Replace(text, pattern, "", RegexOptions.Compiled);
                XmlReaderSettings xmlReaderSettings = new XmlReaderSettings
                {
                    NameTable = new NameTable()
                };
                XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlReaderSettings.NameTable);
                xmlNamespaceManager.AddNamespace("UDF", "http://www.w3.org/2001/XMLSchema-instance");
                XmlParserContext inputContext = new XmlParserContext(null, xmlNamespaceManager, "", XmlSpace.Default);
                string s = text;
                TextReader textReader = new StringReader(s);
                XmlReader xmlReader = XmlReader.Create(textReader, xmlReaderSettings, inputContext);
                xmlDocument.Load(xmlReader);
                streamReader.Close();
                stream.Close();
                response.Close();
                xmlReader.Close();
                textReader.Close();
                result = xmlDocument;
            }
            catch (Exception)
            {
                result = xmlDocument;
            }
            return result;
        }

        public static XmlDocument readTallyDataXMLNode(string RequestXML)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlDocument result;
            try
            {
              var   TallyRequest = WebRequest.Create(LIBS.SiteKey.TallyURL);
                ((HttpWebRequest)TallyRequest).UserAgent = ".NET Framework Example Client";
                TallyRequest.Method = "POST";
                byte[] bytes = Encoding.UTF8.GetBytes(RequestXML);
                TallyRequest.ContentType = "application/x-www-form-urlencoded";
                TallyRequest.ContentLength = (long)bytes.Length;
                Stream stream = TallyRequest.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
                WebResponse response = TallyRequest.GetResponse();
                ((HttpWebResponse)response).StatusDescription.ToString();
                stream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream);
                string text = streamReader.ReadToEnd().ToString();
                string pattern = "[\0-\b\v\f\u000e-\u001f&]";
                text = Regex.Replace(text, pattern, "", RegexOptions.Compiled);
                XmlReaderSettings xmlReaderSettings = new XmlReaderSettings
                {
                    NameTable = new NameTable()
                };
                XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlReaderSettings.NameTable);
                xmlNamespaceManager.AddNamespace("UDF", "http://www.w3.org/2001/XMLSchema-instance");
                XmlParserContext inputContext = new XmlParserContext(null, xmlNamespaceManager, "", XmlSpace.Default);
                string s = text;
                TextReader textReader = new StringReader(s);
                XmlReader xmlReader = XmlReader.Create(textReader, xmlReaderSettings, inputContext);
                xmlDocument.Load(xmlReader);
                streamReader.Close();
                stream.Close();
                response.Close();
                xmlReader.Close();
                textReader.Close();
                result = xmlDocument;
            }
            catch (Exception)
            {
                result = xmlDocument;
            }
            return result;
        }


    }
}