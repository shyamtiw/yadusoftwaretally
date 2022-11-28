using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net.Mail;

namespace Emailer
{
    /// <summary>
    /// Summary description for FlexiMail
    /// </summary>
    public class FlexiMail
    {
        #region Constructors-Destructors
        public FlexiMail()
        {
            //set defaults 

            myEmail = new MailMessage();
            _MailBodyManualSupply = false;
        }
        //public void Dispose()
        //{
        //    base.Finalize();
        //    myEmail.Dispose();
        //}
        #endregion

        #region  Class Data
        private string _From;
        private string _FromName;
        private string _To;
        private string _ToList;
        private string _Subject;
        private string _CC;
        private string _CCList;
        private string _BCC;
        private string _TemplateDoc;
        private string[] _ArrValues;
        private string _BCCList;
        private bool _MailBodyManualSupply;
        private string _MailBody;
        //private string _Attachment;
        private string[] _Attachment;

        private List<AttachmentStream> _AttachmentStream;

        private System.Net.Mail.MailMessage myEmail;

        #endregion

        #region Propertie
        public string From
        {
            set { _From = value; }
        }
        public string FromName
        {
            set { _FromName = value; }
        }
        public string To
        {
            set { _To = value; }
        }
        public string Subject
        {
            set { _Subject = value; }
        }
        public string CC
        {
            set { _CC = value; }
        }
        public string BCC
        {

            set { _BCC = value; }
        }
        public bool MailBodyManualSupply
        {

            set { _MailBodyManualSupply = value; }
        }
        public string MailBody
        {
            set { _MailBody = value; }
        }
        public string EmailTemplateFileName
        {
            //FILE NAME OF TEMPLATE ( MUST RESIDE IN ../EMAILTEMPLAES/ FOLDER ) 
            set { _TemplateDoc = value; }
        }
        public string[] ValueArray
        {
            //ARRAY OF VALUES TO REPLACE VARS IN TEMPLATE 
            set { _ArrValues = value; }
        }

        public string[] AttachFile
        {
            set { _Attachment = value; }
        }
        public List<AttachmentStream> AttachFileStream
        {
            set { _AttachmentStream = value; }
        }

        #endregion

        #region SEND EMAIL

        public void Send()
        {
            myEmail.IsBodyHtml = true;

            //set mandatory properties 
            if (_FromName == "")
                _FromName = _From;
            myEmail.From = new MailAddress(_From, _FromName);
            myEmail.Subject = _Subject;

            //---Set recipients in To List 
            _ToList = _To.Replace(";", ",");
            if (_ToList != "")
            {
                string[] arr = _ToList.Split(',');
                myEmail.To.Clear();
                if (arr.Length > 0)
                {
                    foreach (string address in arr)
                    {
                        myEmail.To.Add(new MailAddress(address));
                    }
                }
                else
                {
                    myEmail.To.Add(new MailAddress(_ToList));
                }
            }

            //---Set recipients in CC List 
            _CCList = _CC.Replace(";", ",");
            if (_CCList != "")
            {
                string[] arr = _CCList.Split(',');
                myEmail.CC.Clear();
                if (arr.Length > 0)
                {
                    foreach (string address in arr)
                    {
                        myEmail.CC.Add(new MailAddress(address));
                    }
                }
                else
                {
                    myEmail.CC.Add(new MailAddress(_CCList));
                }
            }

            //---Set recipients in BCC List 
            _BCCList = _BCC.Replace(";", ",");
            if (_BCCList != "")
            {
                string[] arr = _BCCList.Split(',');
                myEmail.Bcc.Clear();
                if (arr.Length > 0)
                {
                    foreach (string address in arr)
                    {
                        myEmail.Bcc.Add(new MailAddress(address));
                    }
                }
                else
                {
                    myEmail.Bcc.Add(new MailAddress(_BCCList));
                }
            }

            //set mail body 
            if (_MailBodyManualSupply == false)
            {
                myEmail.Body = _MailBody;
            }
            else
            {
                myEmail.Body = _TemplateDoc;
                //& GetHtml("EML_Footer.htm") 
            }

            // set attachment 
            if (_Attachment != null)
            {
                for (int i = 0; i < _Attachment.Length; i++)
                {
                    if (_Attachment[i] != null)
                        myEmail.Attachments.Add(new Attachment(_Attachment[i]));
                }

            }
            if (_AttachmentStream != null)
            {
                _AttachmentStream.ForEach(x =>
                {

                    myEmail.Attachments.Add(new Attachment(x.File, (x.FileName + "." + x.Extranson + ""), "application/" + x.subExtranson + ""));

                });


            }
            //Send mail 
            SmtpClient client = new SmtpClient();
            client.Host = ConfigurationSettings.AppSettings["SMTPServer"];
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;

            if (client.Host != "localhost")
            {
                client.Port = Convert.ToInt32(ConfigurationSettings.AppSettings["SMTPUserPort"]);
                //client.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                client.Host = ConfigurationSettings.AppSettings["SMTPServer"];
                client.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["SMTPUserName"], ConfigurationSettings.AppSettings["SMTPUserPassword"]);
            }
            client.Timeout = 10;
            client.Send(myEmail);

        }

        #endregion

        #region GetHtml

        public string GetHtml(string argTemplateDocument)
        {
            return argTemplateDocument;
            //int i;
            //StreamReader filePtr;
            //string fileData = "";

            //filePtr = File.OpenText(ConfigurationSettings.AppSettings["EmailTemplate"] + "/EmailTemplate/" + argTemplateDocument);
            //fileData = filePtr.ReadToEnd();

            //if ((_ArrValues == null))
            //{
            //    fileData = fileData.Replace("@copyrightyear@", DateTime.Now.Year.ToString());
            //    return fileData;
            //}
            //else
            //{
            //    for (i = _ArrValues.GetLowerBound(0); i <= _ArrValues.GetUpperBound(0); i++)
            //    {
            //        fileData = fileData.Replace("@v" + i.ToString() + "@", (string)_ArrValues[i]);
            //    }
            //    fileData = fileData.Replace("@copyrightyear@", DateTime.Now.Year.ToString());
            //    return fileData;
            //}
        }

        #endregion

    }
}
