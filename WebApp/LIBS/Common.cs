using Business;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using WebApp.admin.ReportModal;

namespace WebApp.LIBS
{


    public static class Common
    {

        public static int RoundF(decimal value)
        {
            decimal decimalpoint = Math.Abs(value - Math.Floor(value));
            if (decimalpoint > 0.5m)
            {
                return (int)Math.Round(value);
            }
            else
            { return (int)Math.Floor(value); }
        }
        public static decimal RoundMath(decimal value)
        {

            double pow = Math.Pow(10, 2);
            return Convert.ToDecimal((Math.Truncate(Convert.ToDouble(value) * pow + Math.Sign(Convert.ToDouble(value)) * 0.5) / pow));
        }
        public static string ReplaceChar(string oldstring)
        {
            if (oldstring.Trim() != "" && oldstring != null)
            {
                Dictionary<string, string> xmlEntityReplacements = new Dictionary<string, string>
                {
                     
                    {
                        "&amp;",
                        "&"
                    },
                    {
                        "amp;",
                        "&"
                    },
                    {
                        "&apos;",
                        "'"
                    },
                    {
                        "&lt;",
                        "<"
                    },
                    {
                        "&gt;",
                        ">"
                    },
                    {
                        "quot;",
                        "\""
                    },
                    {
                        "apos;",
                        "'"
                    },
                    {
                        "\t",
                        " "
                    },
                    {
                        "lt;",
                        "<"
                    },
                    {
                        "gt;",
                        ">"
                    },
                    {
                        "#13;#10;",
                        "\n"
                    },
                   
                };
                oldstring = Regex.Replace(oldstring, string.Join("|", (from k in xmlEntityReplacements.Keys
                                                                       select k.ToString()).ToArray<string>()), (Match m) => xmlEntityReplacements[m.Value]);
            }
            return oldstring;
        }
        public static string AddSpacesToSentence(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                    newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        public static void SendOTPEMAIL(string BodyCondande, string ToEmail, string FromEmail)

        {
            try
            {

                var objs = Emailer.Mailer.SendMail(ToEmail, ConfigurationSettings.AppSettings["SMTPUserName"], "", BodyCondande, "Auto VYN OTP", null, true,"", FromEmail, null, null);
            }
            catch (Exception ex)
            {
                string ss = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }


        public static void SendOTPEMAILCompanyname(string BodyCondande, string ToEmail, string FromEmail,string Companyname, int  UserId)

        {
            try
            {

                var objs = Emailer.Mailer.SendMail(ToEmail, ConfigurationSettings.AppSettings["SMTPUserName"], "", BodyCondande, Companyname, null, true, "", FromEmail, null, null);

                if (objs == "Send")
                {
                    string str = "insert into WaMassge(MessageType,Message,UserId,datetime,Status,Responce,MobileNo,TransNo) values ('Email','"+Companyname +"'," + UserId + ",'" + Common.DateTimeNow().ToString("dd-MMM-yyyy hh:mm tt") + "',1,'','" + ToEmail + "','successfully Send')";
                    ConnModal.ExequteQuey(str);
                }
                else
                {
                    string str = "insert into WaMassge(MessageType,Message,UserId,datetime,Status,Responce,MobileNo,TransNo) values ('Email','"+ Companyname + "'," + UserId + ",'" + Common.DateTimeNow().ToString("dd-MMM-yyyy hh:mm tt") + "',0,'','" + ToEmail + "','" + objs.Replace("'", "''") + "')";
                    ConnModal.ExequteQuey(str);
                }


            }
            catch (Exception ex)
            {
                string ss = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }


        public static string SendMessage(string BodyCondande, string ToEmail, string FromEmail)

        {
            try
            {

                return 
                    Emailer.Mailer.SendMail(ToEmail, ConfigurationSettings.AppSettings["SMTPUserName"], "", BodyCondande, "Auto VYN OTP", null, true, FromEmail, "", null, null);
            }
            catch (Exception ex)
            {
                return  (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }



        internal static void Createdblog(string RecoredId, string Type)
        {



            string clientIp = (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ??
                    System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim();

            var objins = new Business.dblog();
            objins.PageName = System.Web.HttpContext.Current.Request.RawUrl;
            objins.RecoredId = RecoredId.ToString();
            objins.Userid = SiteSession.LoginUser.User_Code;
            objins.DateTime = Common.DateTimeNow();
            objins.Type = Type;
            objins.Comp_Code = SiteSession.Comp_MstSession.Comp_Code;
            objins.LocalIP = clientIp;
            objins.Save();
        }
        public static string DataForSQL(string Date)
        {
            try
            {
                Date= Date.Split(' ')[0];
                    }
            catch { }
            string[] formats = {
    "d/M/yyyy",
    "d.M.yyyy",
    "d-M-yyyy",
    "d/MM/yyyy",
    "d.MM.yyyy",
    "d-MM-yyyy",
    "dd/MM/yyyy",
    "dd.MM.yyyy",
    "dd-MM-yyyy",
    "d/MMM/yyyy",
    "d.MMM.yyyy",
    "d-MMM-yyyy",
    "dd/MMM/yyyy",
    "dd.MMM.yyyy",
    "dd-MMM-yyyy",
    "d/M/yy",
    "d.M.yy",
    "d-M-yy",
    "d/MM/yy",
    "d.MM.yy",
    "d-MM-yy",
    "dd/MM/yy",
    "dd.MM.yy",
    "dd-MM-yy",
    "d/MMM/yy",
    "d.MMM.yy",
    "d-MMM-yy",
    "dd/MMM/yy",
    "dd.MMM.yy",
    "dd-MMM-yy",
    "MM/dd/yyyy",
    "M/dd/yyyy",
     "M/d/yyyy",
     "MM/d/yyyy"

            };

            DateTime date;
            if (!DateTime.TryParseExact(Date, formats, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.AdjustToUniversal, out date))
            {
                return string.Empty;
            }
            return date.ToString("dd-MMM-yyyy");

        }

        public static string DataForSQLwITHtIMEDPS(string Date)
        {
            string[] formats = {
    "dd/MM/yyyy HH:mm:ss",
     "dd/MM/yyyy HH:mm",
    "dd/MM/yyyy hh:mm:ss tt",
    "dd/MM/yyyy  hh:mm tt",
    "dd-MM-yyyy HH:mm:ss",
     "dd-MM-yyyy HH:mm",
    "dd-MM-yyyy hh:mm:ss tt",
    "dd-MM-yyyy  hh:mm tt",
    
                "MM/dd/yyyy HH:mm:ss",
     "MM/dd/yyyy HH:mm",
    "MM/dd/yyyy hh:mm:ss tt",
    "MM/dd/yyyy  hh:mm tt",
    "MM-dd-yyyy HH:mm:ss",
   "MM-dd-yyyy HH:mm",
    "MM-dd-yyyy hh:mm:ss tt",
    "MM-dd-yyyy  hh:mm tt",

    "dd/MMM/yyyy HH:mm:ss",
     "dd/MMM/yyyy HH:mm",
    "dd/MMM/yyyy hh:mm:ss tt",
    "dd/MMM/yyyy  hh:mm tt",
    "dd-MMM-yyyy HH:mm:ss",
     "dd-MMM-yyyy HH:mm",
    "dd-MMM-yyyy hh:mm:ss tt",
    "dd-MMM-yyyy  hh:mm tt",

                "MMM/dd/yyyy HH:mm:ss",
     "MMM/dd/yyyy HH:mm",
    "MMM/dd/yyyy hh:mm:ss tt",
    "MMM/dd/yyyy  hh:mm tt",
    "MMM-dd-yyyy HH:mm:ss",
   "MMM-dd-yyyy HH:mm",
    "MMM-dd-yyyy hh:mm:ss tt",
    "MMM-dd-yyyy  hh:mm tt",



            };

            DateTime date;
            if (!DateTime.TryParseExact(Date, formats, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.AdjustToUniversal, out date))
            {
                return string.Empty;
            }
            return date.ToString("dd-MMM-yyyy HH:mm");

        }



        public static string DataForSQLwITHtIME(string Date)
        {
            string[] formats = {
    "MM/dd/yyyy hh:mm:ss tt",
    "M/dd/yyyy hh:mm:ss tt",
    "M/dd/yyyy hh:mm:ss tt",
    "MM/d/yyyy hh:mm:ss tt",
    "M/d/yyyy hh:mm:ss tt",
      "M/d/yyyy h:mm:ss tt",

       "MM/dd/yyyy h:mm:ss tt",
    "M/dd/yyyy h:mm:ss tt",
    "M/dd/yyyy h:mm:ss tt",
    "MM/d/yyyy h:mm:ss tt",
       "dd-MM-yyyy HH:mm:ss",
       "dd/MM/yyyy HH:mm:ss",
       "dd/MM/yyyy HH:mm",
       "dd-MM-yyyy HH:mm"

            };

            DateTime date;
            if (!DateTime.TryParseExact(Date, formats, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.AdjustToUniversal, out date))
            {
                return string.Empty;
            }
            return date.ToString("dd-MMM-yyyy hh:mm:ss tt");

        }







        public static void BindControl(Control CT, IEnumerable<dynamic> collection)
        {

            PropertyInfo propertyInfo = CT.GetType().GetProperty("DataSource");
            propertyInfo.SetValue(CT, collection, null);
            CT.DataBind();
        }




        public static bool IsNegative(this decimal number)
        {
            return number < 0m;
        }



        public static void UserLogsInsert(string Title, string Description, int UserId, DateTime Date)
        {
            //var obj = new Business.UserLog();
            //obj.Title = Title;
            //obj.Description = Description;
            //obj.UserId = UserId;
            //obj.Date = Date;
            //obj.Save();
        }


        public static string YouTubeUrlToGetTutubeId(string url)
        {

            var uri = new Uri(url);

            // you can check host here => uri.Host <= "www.youtube.com"

            var query = HttpUtility.ParseQueryString(uri.Query);

            var videoId = string.Empty;

            if (query.AllKeys.Contains("v"))
            {
                return query["v"];
            }
            else
            {
                return uri.Segments.Last();
            }
        }



        public static string SeduleType(int @SeduleType)
        {
            string @ReturnValue = "";
            if (@SeduleType == 1)
            {
                @ReturnValue = "Monthly";
            }
            else if (@SeduleType == 2)
            {
                @ReturnValue = "Quarterly";
            }
            else if (@SeduleType == 3)
            {
                @ReturnValue = "HalfYearly";
            }

            else if (@SeduleType == 4)
            {
                @ReturnValue = "Yearly";
            }
            else if (@SeduleType == 5)
            {
                @ReturnValue = "Hourly";
            }
            return @ReturnValue;

        }


        public static decimal TruncateDecimal(decimal value, int decimalPlaces)
        {
            decimal integralValue = Math.Truncate(value);

            decimal fraction = value - integralValue;

            decimal factor = (decimal)Math.Pow(10, decimalPlaces);

            decimal truncatedFraction = Math.Truncate(fraction * factor) / factor;

            decimal result = integralValue + truncatedFraction;

            return result;
        }

        public static void BindControldt(Control CT, DataTable dt)
        {
            PropertyInfo propertyInfo = CT.GetType().GetProperty("DataSource");
            propertyInfo.SetValue(CT, dt, null);
            CT.DataBind();
        }


        public static bool DeletePath(string path)
        {
            try
            {
                FileInfo finfo = new FileInfo(path);
                if (finfo.Attributes == FileAttributes.Directory)
                {
                    //recursively delete directory
                    Directory.Delete(path, true);
                    return true;
                }
                else if (finfo.Attributes == FileAttributes.Normal)
                {
                    File.Delete(path);
                    return true;
                }
                else

                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static string PopulateBody(string userName, string title, string url, string description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/admin/emailtemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", userName);
            body = body.Replace("{Title}", title);
            body = body.Replace("{Description}", description);
            return body;
        }

        public static DateTime DateConvert(string str)
        {
            return DateTime.ParseExact(str, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }
        public static DateTime DateConvert(string str, string Format)
        {

            try
            {

                return DateTime.ParseExact(str, Format, CultureInfo.InvariantCulture);
            }
            catch
            {
                return DateTime.ParseExact(str, "M" + Format.TrimStart('M'), CultureInfo.InvariantCulture);
            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {

                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static List<int> IntArrayWithSize(int Main, int Max, int Count)
        {
            Random rand = new Random();
            List<int> result = new List<int>();
            HashSet<int> check = new HashSet<int>();
            for (Int32 i = 0; i < Count; i++)
            {
                int curValue = rand.Next(Main, Max);
                while (check.Contains(curValue))
                {
                    curValue = rand.Next(Main, Max);
                }
                result.Add(curValue);
                check.Add(curValue);
            }

            return result;
        }

        public static void BindControl(Control CT, IEnumerable<dynamic> collection, string DataTextField, string DataValueField, string DefaultValue)
        {
            PropertyInfo propertyInfo = CT.GetType().GetProperty("DataSource");
            propertyInfo.SetValue(CT, collection, null);

            propertyInfo = CT.GetType().GetProperty("DataTextField");
            if (propertyInfo != null) { propertyInfo.SetValue(CT, DataTextField, null); }

            propertyInfo = CT.GetType().GetProperty("DataValueField");
            if (propertyInfo != null) { propertyInfo.SetValue(CT, DataValueField, null); }

            CT.DataBind();

            if (!String.IsNullOrEmpty(DefaultValue))
            {
                propertyInfo = CT.GetType().GetProperty("Items");
                MethodInfo methodInfo = propertyInfo.PropertyType.GetMethod("Insert", new Type[] { typeof(int), typeof(string) });
                methodInfo.Invoke(propertyInfo.GetValue(CT, null), new object[] { 0, DefaultValue });
            }
        }

        public static void BindControldt(Control CT, DataTable collection, string DataTextField, string DataValueField, string DefaultValue)
        {
            PropertyInfo propertyInfo = CT.GetType().GetProperty("DataSource");
            propertyInfo.SetValue(CT, collection, null);

            propertyInfo = CT.GetType().GetProperty("DataTextField");
            if (propertyInfo != null) { propertyInfo.SetValue(CT, DataTextField, null); }

            propertyInfo = CT.GetType().GetProperty("DataValueField");
            if (propertyInfo != null) { propertyInfo.SetValue(CT, DataValueField, null); }

            CT.DataBind();

            if (!String.IsNullOrEmpty(DefaultValue))
            {
                propertyInfo = CT.GetType().GetProperty("Items");
                MethodInfo methodInfo = propertyInfo.PropertyType.GetMethod("Insert", new Type[] { typeof(int), typeof(string) });
                methodInfo.Invoke(propertyInfo.GetValue(CT, null), new object[] { 0, DefaultValue });
            }
        }
        public static void ASPxComboBoxReadOnlyProperty(DevExpress.Web.ASPxEditors.ASPxComboBox CT)
        {
            PropertyInfo propertyInfo = CT.GetType().GetProperty("ReadOnly");
            propertyInfo.SetValue(CT, true, null);
            propertyInfo = CT.GetType().GetProperty("BackColor");
            propertyInfo.SetValue(CT, System.Drawing.Color.WhiteSmoke, null);
            CT.DropDownButton.Visible = false;


        }


        public static void ASPxComboBoxunReadOnlyProperty(DevExpress.Web.ASPxEditors.ASPxComboBox CT)
        {
            PropertyInfo propertyInfo = CT.GetType().GetProperty("ReadOnly");
            propertyInfo.SetValue(CT, false, null);
            propertyInfo = CT.GetType().GetProperty("BackColor");
            propertyInfo.SetValue(CT, System.Drawing.Color.White, null);
            CT.DropDownButton.Visible = true;

        }
        public static void DeveXpressBindControl(DevExpress.Web.ASPxEditors.ASPxComboBox CT, IEnumerable<dynamic> collection, string DataTextField, string DataValueField, string DefaultValue)
        {


            PropertyInfo propertyInfo = CT.GetType().GetProperty("DataSource");
            propertyInfo.SetValue(CT, collection, null);

            propertyInfo = CT.GetType().GetProperty("TextField");
            if (propertyInfo != null) { propertyInfo.SetValue(CT, DataTextField, null); }

            propertyInfo = CT.GetType().GetProperty("ValueField");
            if (propertyInfo != null) { propertyInfo.SetValue(CT, DataValueField, null); }

            CT.DataBind();


            if (!String.IsNullOrEmpty(DefaultValue))
            {
                CT.Items.Insert(0, new DevExpress.Web.ASPxEditors.ListEditItem(DefaultValue, DefaultValue));
                CT.Value = DefaultValue;

            }
        }



        public static void SendCouponOnWa(int Id)
        {
            var obj = Global.Context.InsuranceCoupons.AsEnumerable().SingleOrDefault(p => p.InsuranceCouponId == Id);
            string CompName = SiteSession.Comp_MstSession.Comp_Name;
            int UserId = SiteSession.LoginUser.User_Code;
            Thread ThProcessSendDataOracle = new Thread(() =>
                 CallFun(obj, CompName, UserId)
            );
            ThProcessSendDataOracle.IsBackground = true;
            ThProcessSendDataOracle.Start();
        }



        public static void SendCouponOnWaMultipal(string MultipalId)
        {
          
            string CompName = SiteSession.Comp_MstSession.Comp_Name;
            int UserId = SiteSession.LoginUser.User_Code;
            int[] ID = MultipalId.Split(',').Select(p => Convert.ToInt32(p)).ToArray();
            var obj = Global.Context.InsuranceCoupons.AsEnumerable().Where(p => ID.Contains(p.InsuranceCouponId)).ToList();
            Thread ThProcessSendDataOracle = new Thread(() =>

             voidMultiSelection(obj, CompName, UserId)

            );
            ThProcessSendDataOracle.IsBackground = true;
            ThProcessSendDataOracle.Start();
        }


        public static void voidMultiSelection(List<InsuranceCoupon> obj,  string CompName, int  UserId)
        {
           
            if (obj.Count() > 0)
            {
                obj.ForEach(x =>
                {
                    CallFun(x, CompName, UserId);
                });
            }
        }


        public static void CallFun(InsuranceCoupon obj, string CompName, int UserId)
        {
            string Name = obj.Master.Code + "_" + obj.InsuranceIndividual.PolicyNo;
            try
            {

                MediaBody body = new MediaBody();
                body.base64data = CreatePDF(obj.InsuranceCouponId, CompName);
                body.mimeType = "application/pdf";
                body.filename = Name + ".pdf";
                body.caption = Name;

                var Responce = WaClass.SendMedia(obj.MobNo, body);
                if (Responce.success)
                {
                    string str = "insert into WaMassge(MessageType,Message,UserId,datetime,Status,Responce,MobileNo,TransNo) values ('Send Coupon','" + Name.Replace("'", "''") + "'," + UserId + ",'" + Common.DateTimeNow().ToString("dd-MMM-yyyy hh:mm tt") + "',1,'','" + obj.MobNo + "','" + Responce.data.id + "')";
                    getdata(str);
                }
                else
                {
                    string str = "insert into WaMassge(MessageType,Message,UserId,datetime,Status,Responce,MobileNo,TransNo) values ('Send Coupon','" + Name.Replace("'", "''") + "'," + UserId + ",'" + Common.DateTimeNow().ToString("dd-MMM-yyyy hh:mm tt") + "',0,'" + Common.Convertstring(Responce.data.error).Replace("'", "''") + "','" + obj.MobNo + "','')";
                    getdata(str);
                }
            }
            catch (Exception ex)
            {

                string str = "insert into WaMassge(MessageType,Message,UserId,datetime,Status,Responce,MobileNo,TransNo) values ('Send Coupon','" + Name.Replace("'", "''") + "'," + UserId + ",'" + Common.DateTimeNow().ToString("dd-MMM-yyyy hh:mm tt") + "',0,'" + ex.Message.Replace("'", "''") + "','" + obj.MobNo + "','')";
                getdata(str);
            }

        }

        public static void getdata(string dtDetails)
        {



            string constr = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;


            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("ExecuteQuery"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@str", dtDetails);

                    cmd.ExecuteNonQuery();

                }
            }

        }


        public static string CreatePDF(int Id, string CompName)
        {


            string base64string = "";
            var retunr = new MemoryStream();
            try
            {
                string url = string.Format("https://cloud.autovyn.in/admin/print/couponprint.aspx?Id=" + Id + "&&CompName=" + CompName + "");
                string pdf_page_size = "A4";
                PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                    pdf_page_size, true);

                string pdf_orientation = "Portrait";
                PdfPageOrientation pdfOrientation =
                    (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                    pdf_orientation, true);







                // instantiate a html to pdf converter object
                HtmlToPdf converter = new HtmlToPdf();

                // set converter options
                converter.Options.PdfPageSize = PdfPageSize.A4;
                converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;

                converter.Options.WebPageWidth = 1024;
                converter.Options.WebPageHeight = 0;
                converter.Options.WebPageFixedSize = false;

                converter.Options.AutoFitWidth = HtmlToPdfPageFitMode.ShrinkOnly;
                converter.Options.AutoFitHeight = HtmlToPdfPageFitMode.NoAdjustment;




                // create a new pdf document converting an url
                SelectPdf.PdfDocument doc = converter.ConvertUrl(url);


                retunr = new MemoryStream(doc.Save());

                byte[] bytes = new Byte[(int)retunr.Length];

                retunr.Seek(0, SeekOrigin.Begin);
                retunr.Read(bytes, 0, (int)retunr.Length);

                base64string = Convert.ToBase64String(bytes);



            }
            catch (Exception ex) { }


            return base64string;

        }
        public static void ResetForm(Control Container)
        {
            foreach (Control CT in Container.Controls)
            {
                PropertyInfo propertyInfo = null;

                if (CT.GetType().Name == "TextBox" || CT.GetType().Name == "UserControl")
                {
                    propertyInfo = CT.GetType().GetProperty("Text");
                    if (propertyInfo != null) { propertyInfo.SetValue(CT, String.Empty, null); }
                }

                propertyInfo = CT.GetType().GetProperty("SelectedIndex");
                if (propertyInfo != null) { propertyInfo.SetValue(CT, 0, null); }

                propertyInfo = CT.GetType().GetProperty("Checked");
                if (propertyInfo != null) { propertyInfo.SetValue(CT, false, null); }
            }
        }

        public static DateTime DateTimeNow()
        {

            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

            return indianTime;
        }



        public static  int FinYear(DateTime dt)
        {
            
            if (dt.Month > 3)
            {

                return dt.Year;
            }

            else
            {
                 return (dt.Year - 1);
            }
        }

        
       
public static void AllResetForm(Control[] objects)
        {


            foreach (var Container in objects)
            {
                foreach (Control CT in Container.Controls)
                {
                    PropertyInfo propertyInfo = null;

                    if (CT.GetType().Name == "TextBox" || CT.GetType().Name == "UserControl")
                    {
                        propertyInfo = CT.GetType().GetProperty("Text");
                        if (propertyInfo != null) { propertyInfo.SetValue(CT, String.Empty, null); }
                    }

                    propertyInfo = CT.GetType().GetProperty("SelectedIndex");
                    if (propertyInfo != null) { propertyInfo.SetValue(CT, 0, null); }

                    propertyInfo = CT.GetType().GetProperty("Checked");
                    if (propertyInfo != null) { propertyInfo.SetValue(CT, false, null); }
                }
            }
        }


        public static string StripTagsCharArray(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        public static string CreateSefUrl(string inputStr)
        {
            string outputStr = "";
            outputStr = inputStr.Trim().Replace(":", "").Replace("&", "").Replace(" ", "-").Replace("'", "").Replace(",", "").Replace("(", "").Replace(")", "").Replace("--", "").Replace(".", "");
            return Regex.Replace(outputStr.Trim().ToLower().Replace("--", ""), "[^a-zA-Z0-9_-]+", "", RegexOptions.Compiled);
        }

        public static string UrlBuilder(params string[] _Url)
        {
            if (_Url.Length > 0)
                return String.Join("/", _Url);
            else
                return String.Empty;
        }


        public static string GetFirstParagraph(string _data)
        {
            if (String.IsNullOrEmpty(_data) == false)
            {
                Match m = Regex.Match(_data, @"<p.*>\s*(.+?)\s*</p>");
                if (m.Success)
                    return m.Groups[1].Value;
                else
                    return GetDataByLength(_data, 200);
            }
            else
            {
                return String.Empty;
            }
        }

        public static string GetDataByLength(string _data, int _length)
        {
            return (_data.Length < _length ? _data : _data.Substring(0, _length) + "....");
        }

        public static string GetExactDataByLength(string _data, int _length)
        {
            return (_data.Length < _length ? _data : _data.Substring(0, _length));
        }

        public static MemoryStream CreatePDF(string NoticeId, string CompName)
        {
            var retunr = new MemoryStream();
            try
            {

               string url = string.Format("https://cloud.autovyn.in/admin/print/multipalcouponprint.aspx?Id=" + NoticeId + "&&CompName=" + CompName + "");
                //string url = string.Format("http://localhost:18000/admin/print/multipalcouponprint.aspx?Id=" + NoticeId + "&&CompName=" + CompName + "");

                string pdf_page_size = "A4";
                PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), pdf_page_size, true);
                string pdf_orientation = "Portrait";
                PdfPageOrientation pdfOrientation =
                    (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                    pdf_orientation, true);



                // instantiate a html to pdf converter object
                HtmlToPdf converter = new HtmlToPdf();

                // set converter options
                converter.Options.PdfPageSize = pageSize;
                converter.Options.PdfPageOrientation = pdfOrientation;
                converter.Options.AutoFitHeight = HtmlToPdfPageFitMode.NoAdjustment;
                converter.Options.CssMediaType = HtmlToPdfCssMediaType.Print;
                converter.Options.AutoFitWidth = HtmlToPdfPageFitMode.NoAdjustment;
                converter.Options.EmbedFonts = true;
                converter.Options.MarginLeft = 5;



                // create a new pdf document converting an url
                SelectPdf.PdfDocument doc = converter.ConvertUrl(url);


                retunr = new MemoryStream(doc.Save());
                //doc.Save((Response, false, "_Certificate.pdf");
            }
            catch (Exception ex) { }

            return retunr;
        }

        public static MemoryStream CreatePDFMultipalhred(string NoticeId, string CompName)
        {
            var retunr = new MemoryStream();
            try
            {

               string url = string.Format("https://cloud.autovyn.in/admin/print/MultipalSendUsingWithoutLinq.aspx?Id=" + NoticeId + "&&CompName=" + CompName + "");
                //string url = string.Format("http://localhost:18000/admin/print/MultipalSendUsingWithoutLinq.aspx?Id=" + NoticeId + "&&CompName=" + CompName + "");

                string pdf_page_size = "A4";
                PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), pdf_page_size, true);
                string pdf_orientation = "Portrait";
                PdfPageOrientation pdfOrientation =
                    (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                    pdf_orientation, true);



                // instantiate a html to pdf converter object
                HtmlToPdf converter = new HtmlToPdf();

                // set converter options
                converter.Options.PdfPageSize = pageSize;
                converter.Options.PdfPageOrientation = pdfOrientation;
                converter.Options.AutoFitHeight = HtmlToPdfPageFitMode.NoAdjustment;
                converter.Options.CssMediaType = HtmlToPdfCssMediaType.Print;
                converter.Options.AutoFitWidth = HtmlToPdfPageFitMode.NoAdjustment;
                converter.Options.EmbedFonts = true;
                converter.Options.MarginLeft = 5;



                // create a new pdf document converting an url
                SelectPdf.PdfDocument doc = converter.ConvertUrl(url);


                retunr = new MemoryStream(doc.Save());
                //doc.Save((Response, false, "_Certificate.pdf");
            }
            catch (Exception ex) { }

            return retunr;
        }




        public static MemoryStream E_CreatePDF(string NoticeId, string CompName)
        {
            var retunr = new MemoryStream();
            try
            {

               string url = string.Format("https://cloud.autovyn.in/admin/print/E_multipalcouponprint.aspx?Id=" + NoticeId + "&&CompName=" + CompName + "");
                //string url = string.Format("http://localhost:18000/admin/print/multipalcouponprint.aspx?Id=" + NoticeId + "&&CompName=" + CompName + "");

                string pdf_page_size = "A4";
                PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), pdf_page_size, true);
                string pdf_orientation = "Portrait";
                PdfPageOrientation pdfOrientation =
                    (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                    pdf_orientation, true);



                // instantiate a html to pdf converter object
                HtmlToPdf converter = new HtmlToPdf();

                // set converter options
                converter.Options.PdfPageSize = pageSize;
                converter.Options.PdfPageOrientation = pdfOrientation;
                converter.Options.AutoFitHeight = HtmlToPdfPageFitMode.NoAdjustment;
                converter.Options.CssMediaType = HtmlToPdfCssMediaType.Print;
                converter.Options.AutoFitWidth = HtmlToPdfPageFitMode.NoAdjustment;
                converter.Options.EmbedFonts = true;
                converter.Options.MarginLeft = 5;



                // create a new pdf document converting an url
                SelectPdf.PdfDocument doc = converter.ConvertUrl(url);


                retunr = new MemoryStream(doc.Save());
                //doc.Save((Response, false, "_Certificate.pdf");
            }
            catch (Exception ex) { }

            return retunr;
        }

        public static MemoryStream E_CreatePDFMultipalhred(string NoticeId, string CompName)
        {
            var retunr = new MemoryStream();
            try
            {

                string url = string.Format("https://cloud.autovyn.in/admin/print/E_MultipalSendUsingWithoutLinq.aspx?Id=" + NoticeId + "&&CompName=" + CompName + "");
               //string url = string.Format("http://localhost:18000/admin/print/MultipalSendUsingWithoutLinq.aspx?Id=" + NoticeId + "&&CompName=" + CompName + "");

                string pdf_page_size = "A4";
                PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), pdf_page_size, true);
                string pdf_orientation = "Portrait";
                PdfPageOrientation pdfOrientation =
                    (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                    pdf_orientation, true);



                // instantiate a html to pdf converter object
                HtmlToPdf converter = new HtmlToPdf();

                // set converter options
                converter.Options.PdfPageSize = pageSize;
                converter.Options.PdfPageOrientation = pdfOrientation;
                converter.Options.AutoFitHeight = HtmlToPdfPageFitMode.NoAdjustment;
                converter.Options.CssMediaType = HtmlToPdfCssMediaType.Print;
                converter.Options.AutoFitWidth = HtmlToPdfPageFitMode.NoAdjustment;
                converter.Options.EmbedFonts = true;
                converter.Options.MarginLeft = 5;



                // create a new pdf document converting an url
                SelectPdf.PdfDocument doc = converter.ConvertUrl(url);


                retunr = new MemoryStream(doc.Save());
                //doc.Save((Response, false, "_Certificate.pdf");
            }
            catch (Exception ex) { }

            return retunr;
        }



        public static int threadManageId()
        {

            string _numbers = "0123456789";
            Random random = new Random();
            StringBuilder builder = new StringBuilder(6);
            string numberAsString = "";


            for (var i = 0; i < 4; i++)
            {
                builder.Append(_numbers[random.Next(0, _numbers.Length)]);
            }

            numberAsString = builder.ToString();
            return int.Parse(numberAsString);

        }



        public static string Otp()
        {

            string _numbers = "0123456789";
            Random random = new Random();
            StringBuilder builder = new StringBuilder(6);
            string numberAsString = "";


            for (var i = 0; i < 6; i++)
            {
                builder.Append(_numbers[random.Next(0, _numbers.Length)]);
            }

            numberAsString = builder.ToString();
            return int.Parse(numberAsString).ToString();

        }

        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random((int)Common.DateTimeNow().Ticks);
            char ch;

            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public static string NumbersToWords(int inputNumber)
        {
            int inputNo = inputNumber;

            if (inputNo == 0)
                return "Zero";

            int[] numbers = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (inputNo < 0)
            {
                sb.Append("Minus ");
                inputNo = -inputNo;
            }

            string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ",
            "Five " ,"Six ", "Seven ", "Eight ", "Nine "};
            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ",
            "Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};
            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ",
            "Seventy ","Eighty ", "Ninety "};
            string[] words3 = { "Thousand ", "Lakh ", "Crore " };

            numbers[0] = inputNo % 1000; // units
            numbers[1] = inputNo / 1000;
            numbers[2] = inputNo / 100000;
            numbers[1] = numbers[1] - 100 * numbers[2]; // thousands
            numbers[3] = inputNo / 10000000; // crores
            numbers[2] = numbers[2] - 100 * numbers[3]; // lakhs

            for (int i = 3; i > 0; i--)
            {
                if (numbers[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (numbers[i] == 0) continue;
                u = numbers[i] % 10; // ones
                t = numbers[i] / 10;
                h = numbers[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i == 0) sb.Append("and ");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd() + " Only";
        }

        public static string GetMonthName(int Month)
        {
            return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Month);
        }




        public static int RankNodeCount(int rank)
        {
            int total = 0;
            for (int i = rank; i >= 1; i--)
            {
                total += i;
            }

            return total;

        }
        public static int GetPercentRange(decimal range)
        {
            if (range >= 100)
                return 100;
            else if (range >= 75)
                return 75;
            else if (range >= 50)
                return 50;
            else if (range >= 25)
                return 25;
            else
                return 0;
        }

        public static int CalculateAge(DateTime bday)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;
            if (bday > today.AddYears(-age)) age--;

            return age;
        }



       
        public static int ConvertInt(object value)
        {
            try
            {
              return   Convert.ToInt32(value);
            }

            catch { return 0; }
            
        }

        public static byte Convertbyte(object value)
        {
            try
            {
                Convert.ToByte(value);
            }

            catch { value = 0; }
            return Convert.ToByte(value);
        }

        public static short ConvertInt16(object value)
        {
            try
            {
                Convert.ToInt16(value);
            }

            catch { value = 0; }
            return Convert.ToInt16(value);
        }
        public static Int64 ConvertInt64(object value)
        {
            try
            {
              return   Convert.ToInt64(value);
            }

            catch { return 0; }
            
        }

        public static string Convertstring(object value)
        {
            string retunvalu;
            try
            {
                retunvalu = value.ToString();
            }

            catch { retunvalu = ""; }
            return retunvalu;
        }
        public static decimal ConvertDecimal(object value)
        {
            try
            {
                return Convert.ToDecimal(String.Format("{0:0.00}", value.ToString().ToUpper().Replace("CR","").Replace("DR","")));
            }

            catch { return  0m; }
      
        }
        public static decimal XMLToDecimal(object value)
        {
            try
            {
                
            return    -1m*Convert.ToDecimal(((System.Xml.XmlNode[])value)[0].Value);
            }

            catch { return  0m; }
            
        }
        public static bool ConvertBool(object value)
        {
            try
            {
                Convert.ToBoolean(value);
            }

            catch { value = false; }
            return Convert.ToBoolean(value);
        }
        //private void CerateTree(int userID)
        //{
        //    var obj = Global.Context.UserLogins.SingleOrDefault(c => c.UserID == userID);
        //    List<TreeMake> obmakelist = new List<TreeMake>();
        //    if (SiteSession.RoleId ==(int) SiteKey.UserRoleEnum.BDO)
        //    {
        //        var objList = Global.Context.UserLogins.Where(C => C.SateID == obj.SateID && obj.DesignationId == (int)SiteKey.UserRoleEnum.BDO && C.DistrictID == obj.DistrictID).ToList();

        //    }



        //}


        public static string GetTitle(string url)
        {
            var api = $"http://youtube.com/get_video_info?video_id={GetArgs(url, "v", '?')}";
            return GetArgs(new WebClient().DownloadString(api), "title", '&');
        }

        private static string GetArgs(string args, string key, char query)
        {
            var iqs = args.IndexOf(query);
            return iqs == -1
                ? string.Empty
                : HttpUtility.ParseQueryString(iqs < args.Length - 1
                    ? args.Substring(iqs + 1) : string.Empty)[key];
        }
    }
}

public partial class TreeMake
{

    public int DesignationId { get; set; }
    public int UserId { get; set; }

}