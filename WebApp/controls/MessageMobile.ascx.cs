using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;

namespace WebApp.controls
{
    public partial class MessageMobile : System.Web.UI.UserControl
    {
        protected string MessageClass = "hide";
        public void ShowMessage(string Title, string Description, SiteKey.MessageType MessageType)
        {

            MessageClass = MessageType.ToString().ToLower() == "danger" ? "danger" : MessageType.ToString().ToLower();
            ltHeading.Text = Title;
            ltDescription.Text = Description;
         //   string[] str = { "ban", "info", "warning", "check" };
            
         //StringBuilder sb=new StringBuilder();
         //sb.Append("<div class='box-body' ><div class='alert alert-" + MessageType.ToString().ToLower() + " alert-dismissable'>");
         //sb.Append("<i class='fa fa-" + ReturnIcon(MessageType.ToString()) + "'></i><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button><b>" + Title + " ! </b>" + Description + "</div></div>");
         //messs.Visible = true;
         //messs.Text = sb.ToString();
        }

        private string ReturnIcon(string message)
        { 
         

            if (message == "info")
            {
                return "info";
            }
            else if (message == "warning")
            {
                return "warning";
            }
            else if (message == "danger")
            {
                return "ban";
            }
            else if (message == "success")
            {
                return "check";
            }
            else
            {
                return "";
            }
        
        }
    }
}

