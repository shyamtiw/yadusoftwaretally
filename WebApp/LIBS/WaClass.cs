using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace WebApp.LIBS
{
    public  class WaClass
    {

        public static WaRoot SendMessageWa(string MobNo, string Message)
        {


            MessageBody body = new MessageBody();
            body.text = Message;
            body.sendLinkPreview = false;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var request = WebRequest.Create("http://.:3000/91" + MobNo + "/sendText") as HttpWebRequest;


            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";


            string responseContent = null;
            var result = new WaRoot();
            try
            {
                var param = JsonConvert.SerializeObject(body);
                byte[] byteArray = Encoding.UTF8.GetBytes(param);

                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                        result = JsonConvert.DeserializeObject<WaRoot>(responseContent);
                     
                    }
                }

            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    responseContent = reader.ReadToEnd();

                    result = JsonConvert.DeserializeObject<WaRoot>(responseContent);
                   
                }




            }
            return result;
            //System.Diagnostics.Debug.WriteLine(responseContent);
        }

        public static WaRoot SendMedia(string MobNo, MediaBody body)
        {


           
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var request = WebRequest.Create("http://.:3000/91" + MobNo + "/sendMedia") as HttpWebRequest;


            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";


            string responseContent = null;
            var result = new WaRoot();
            try
            {
                var param = JsonConvert.SerializeObject(body);
                byte[] byteArray = Encoding.UTF8.GetBytes(param);

                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                        result = JsonConvert.DeserializeObject<WaRoot>(responseContent);

                    }
                }

            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    responseContent = reader.ReadToEnd();

                    result = JsonConvert.DeserializeObject<WaRoot>(responseContent);

                }




            }
            return result;
            //System.Diagnostics.Debug.WriteLine(responseContent);
        }

    }
}



public class DataWa
{
    public string id { get; set; }
    public string senderPhoneNumber { get; set; }
    public string fromMe { get; set; }
    public string timestamp { get; set; }
    public string type { get; set; }
    public string body { get; set; }
    public string base64data { get; set; }
    public string mimeType { get; set; }
    public string filename { get; set; }


    public int statusCode { get; set; }
    public string error { get; set; }
    public List<string> message { get; set; }


}

public class WaRoot
{
    public bool success { get; set; }
    public DataWa data { get; set; }
}


public class MessageBody
{
    public string text { get; set; }
    public bool sendLinkPreview { get; set; }
}



public class MediaBody
{
    public string base64data { get; set; }
    public string mimeType { get; set; }
    public string caption { get; set; }
    public string filename { get; set; }
}

