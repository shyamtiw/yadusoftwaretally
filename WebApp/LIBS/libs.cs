using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sendsms;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace WebApp.LIBS
{
    public class SMZP
    {
      
      public static RootData GenerateIRN(string json,string ASP_Userid  ,string  ASP_Pwd ,string  API_Usrname ,string API_Pwd ,string GST_No,string ASP_TockenId            )
        {
            
            var request = WebRequest.Create("http://api.taxprogsp.co.in/eicore/dec/v1.03/Invoice?aspid="+ ASP_Userid + "&password="+ASP_Pwd+"&Gstin="+GST_No+"&AuthToken="+ASP_TockenId+"&user_name="+ API_Usrname + "") as HttpWebRequest;
            //var request = WebRequest.Create("https://testapi.taxprogsp.co.in/eicore/dec/v1.03/Invoice?aspid=" + ASP_Userid + "&password=**********&Gstin=************&AuthToken=************&user_name=************") as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            var param =json;
            byte[] byteArray = Encoding.UTF8.GetBytes(param);

            string responseContent = null;
            var result = new RootData();
            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                         result = JsonConvert.DeserializeObject<RootData>(responseContent);
                        result.Responce = responseContent;
                        if (result.Data != null && result.InfoDtls == null)
                        {
                            List<InfoDtl> Delta = new List<InfoDtl>();
                             Delta.Add( new InfoDtl() { Desc= JsonConvert.DeserializeObject<Desc>(result.Data.ToString()) });
                            result.InfoDtls = Delta;
                        }
                        if (result.ErrorDetails == null)
                        {
                            result.ErrorDetails = new List<ErrorDetail>();
                        }
                    }
                }
             
            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    responseContent = reader.ReadToEnd();

                     result = JsonConvert.DeserializeObject<RootData>(responseContent);
                    result.Responce = responseContent;
                }


            

            }
            return result;
            //System.Diagnostics.Debug.WriteLine(responseContent);
        }


        public static RootData IRNNotoGetDeatils(string IRN,string ASP_Userid,string ASP_Pwd,string API_Usrname,string API_Pwd,string GST_No,string ASP_TockenId       )
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var request = WebRequest.Create("https://api.taxprogsp.co.in/eicore/dec/v1.03/Invoice/irn/"+ IRN + "?aspid=" + ASP_Userid + "&password=" + ASP_Pwd + "&Gstin=" + GST_No + "&AuthToken=" + ASP_TockenId + "&user_name=" + API_Usrname + "") as HttpWebRequest;
            //var request = WebRequest.Create("https://testapi.taxprogsp.co.in/eicore/dec/v1.03/Invoice?aspid=" + ASP_Userid + "&password=**********&Gstin=************&AuthToken=************&user_name=************") as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";


            string responseContent = null;
            var result = new RootData();
            try
            {
              
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                        result = JsonConvert.DeserializeObject<RootData>(responseContent);
                        result.Responce = responseContent;
                        if (result.Data != null && result.InfoDtls == null)
                        {
                            List<InfoDtl> delta = new List<InfoDtl>();
                            delta.Add(new InfoDtl() { Desc = JsonConvert.DeserializeObject<Desc>(result.Data.ToString()) });
                            result.InfoDtls = delta;
                        }
                    }
                }

            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    responseContent = reader.ReadToEnd();

                    result = JsonConvert.DeserializeObject<RootData>(responseContent);
                    result.Responce = responseContent;
                }




            }
            return result;
            //System.Diagnostics.Debug.WriteLine(responseContent);
        }

        public static RootData CancelIrn(string json,string ASP_Userid,string ASP_Pwd,string API_Usrname,string API_Pwd,string GST_No,string ASP_TockenId)
        {

            var request = WebRequest.Create("http://api.taxprogsp.co.in/eicore/dec/v1.03/Invoice/Cancel?aspid=" + ASP_Userid + "&password=" + ASP_Pwd + "&Gstin=" + GST_No + "&AuthToken=" + ASP_TockenId + "&user_name=" + API_Usrname + "") as HttpWebRequest;
                                            

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            var param = json;
            byte[] byteArray = Encoding.UTF8.GetBytes(param);

            string responseContent = null;
            var result = new RootData();
            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                        result = JsonConvert.DeserializeObject<RootData>(responseContent);
                        result.Responce = responseContent;
                        if (result.Data != null && result.InfoDtls == null)
                        {
                            List<InfoDtl> delta = new List<InfoDtl>();
                            delta.Add(new InfoDtl() { Desc = JsonConvert.DeserializeObject<Desc>(result.Data.ToString()) });
                            result.InfoDtls = delta;
                        }
                    }
                }

            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    responseContent = reader.ReadToEnd();

                    result = JsonConvert.DeserializeObject<RootData>(responseContent);
                    result.Responce = responseContent;
                }




            }
            return result;
            //System.Diagnostics.Debug.WriteLine(responseContent);
        }




        public static RootDataTokenGenrate AuthenticationTokenGenerate(string ASP_Userid,string ASP_Pwd,string API_Usrname,string API_Pwd,string GST_No           )
        {
ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var request = WebRequest.Create("https://api.taxprogsp.co.in/eivital/dec/v1.03/auth?&aspid="+ASP_Userid+"&password="+ASP_Pwd+"&Gstin="+GST_No+"&user_name="+API_Usrname+"&eInvPwd="+API_Pwd+"") as HttpWebRequest;
                                       
            request.KeepAlive = true;
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";

            string responseContent = null;
            var result = new RootDataTokenGenrate();
            try
            {

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                        result = JsonConvert.DeserializeObject<RootDataTokenGenrate>(responseContent);
                        result.Responce = responseContent;
                    }
                }

            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    responseContent = reader.ReadToEnd();

                    result = JsonConvert.DeserializeObject<RootDataTokenGenrate>(responseContent);
                    result.Responce = responseContent;
                }




            }
            return result;
            //System.Diagnostics.Debug.WriteLine(responseContent);
        }








    }
}

public class ErrorDetail
{
    public string ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
}

public class Desc
{
    public long AckNo { get; set; }
    public string AckDt { get; set; }
    public string Irn { get; set; }
    public string CancelDate { get; set; }
    public string SignedInvoice { get; set; }
    public string SignedQRCode { get; set; }
    
}

public class InfoDtl
{
    public string InfCd { get; set; }
    public Desc Desc { get; set; }
}


public class Error
{
    public string error_cd { get; set; }
    public string message { get; set; }
}

public class RootData
{
    public string status_cd { get; set; }
    public string Status { get; set; }
    public string Responce { get; set; }
    public Error error { get; set; }
    
    public object Data { get; set; }
    public List<ErrorDetail> ErrorDetails { get; set; }
    public List<InfoDtl> InfoDtls { get; set; }
}



public class RootDataTokenGenrate
{
    public string status_cd { get; set; }
    public string Responce { get; set; }
    public string Status { get; set; }
    public Error error { get; set; }

    public   Data Data { get; set; }
    public List<ErrorDetails> ErrorDetails { get; set; }
    public List<InfoDtl> InfoDtls { get; set; }
}

public class ErrorDetails
{
    public string ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
}

public class Data
{
    public string ClientId { get; set; }
    public string UserName { get; set; }
    public string AuthToken { get; set; }
    public string Sek { get; set; }
    public DateTime TokenExpiry { get; set; }
}
//public partial class JsonErrorHeldaler {
//  public  string status { get; set; }
//    public string Data { get; set; }
//    public List<error> ErrorDetails { get; set; }
//    public List<InfoDtls> InfoDtls { get; set; }
//}

//public partial class error
//{
//    public string error_cd { get; set; }
//    public string message { get; set; }
//}



//public partial class InfoDtls
//{
//    public string InfCd { get; set; }

//    public List<Desc> Desc { get; set; }
//}


//public partial class Desc
//{
//    public string AckNo { get; set; }
//    public string AckDt { get; set; }
//    public string Irn { get; set; }
//}

