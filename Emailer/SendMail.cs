using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emailer
{
    public class Mailer
    {
        public static string SendMail(string MailTo, string MailFrom, string MailBody, string EmailTemplate, string Subject, string[] values, bool IsmanualbodySupply, string Mailcc, string MailBcc= "vikas@autovyn.in", String[] AttachFile = null, List<AttachmentStream> AttachStream=null, string FromName = "Auto VYN OTP Verfication")
        {
            int count = 0;
        X:
            try
            {
                FlexiMail ObjMail = new FlexiMail();
                ObjMail.FromName = FromName;
                ObjMail.To = (MailTo == null ? "" : MailTo);
                ObjMail.MailBody = MailBody;
                ObjMail.From = MailFrom;
                ObjMail.CC = Mailcc;
                ObjMail.BCC = MailBcc;
                ObjMail.Subject = Subject;
                ObjMail.EmailTemplateFileName = EmailTemplate;
                ObjMail.ValueArray = values;
                ObjMail.MailBodyManualSupply = IsmanualbodySupply;
                ObjMail.AttachFile = AttachFile;
                ObjMail.AttachFileStream = AttachStream;
                ObjMail.Send();
                return "Send";
            }
            catch(Exception ex)
            {
                //if (count == 0)
                //{
                //    count++;
                //    goto X;
                //}

                return ex.Message;
            }
        }
    }
}
