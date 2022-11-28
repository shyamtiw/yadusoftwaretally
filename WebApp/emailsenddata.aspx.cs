using System;
using System.Collections.Generic;
using System.Linq;


using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace WebApp
{
    public partial class emailsenddata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
         



            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty;
            try
            {





                string BodyCondande = "<!DOCTYPE html><html><body><h1>My First Heading</h1><p>My first paragraph.</p></body></html>";


                

                       

                    lblConfirmationMessage.Text = LIBS.Common.SendMessage(BodyCondande, txtEmailTo.Text, "");
            }
            catch (Exception ex)
            {
                lblConfirmationMessage.Text = ex.Message;
            }
        }

        
    }
}