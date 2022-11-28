using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.controls
{
    public partial class validText : System.Web.UI.UserControl
    {
        public bool readOnly
        {
            set 
            {
                if (value == true)
                    txtdata.Attributes.Add("readonly", "readonly");
                else
                    txtdata.Attributes.Remove("readonly");
            }
        }
        public bool enableREV
        {
            set { REV.Enabled = value; }
        }
        public bool enableRFV
        {
            set { RFV.Enabled = value; }
        }
        public bool enableDOB
        {
            set { CV.Enabled = value; }
        }
        public string ErrorMsgForExpression
        {
            set { REV.ErrorMessage = value; }
        }
        public string ErrorMsgForRequired
        {
            set { RFV.ErrorMessage = value; }
        }

        public string ErrorMsgForDate
        {
            set { CV.ErrorMessage = value; }
        }
        public string regExpress
        {
            set { REV.ValidationExpression = value; }
        }
        public string validGroup
        {
            set
            {
                REV.ValidationGroup = value;
                RFV.ValidationGroup = value;
                CV.ValidationGroup = value;
            }
        }
        public string CssClass
        {
            set { txtdata.CssClass = value; }
        }
        public string PlaceHolder
        {
            set { txtdata.Attributes.Add("placeholder", value); }
        }
        public string Text
        {
            get { return txtdata.Text; }
            set { txtdata.Text = value; }
        }
        public TextBoxMode txtMode
        {
            set { txtdata.TextMode = value; }
        }
        public Unit Width
        {
            set { txtdata.Width = value; }
        }

        public Int32 maxLength
        {
            set { txtdata.MaxLength = value; }
        }
        public int Rows
        {
            set
            {
                if (txtdata.TextMode == TextBoxMode.MultiLine)
                    txtdata.Rows = value;
            }
        }
    }
}