using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class CreateQRCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string SellerName = "Navy-GEN CONSULTANCY ,(OPC) PVT LTD";
            string bankAccNo = "019705010392" + Environment.NewLine;
            string BankIfscNo = "ICIC0000197" + Environment.NewLine;
            string SupplierUPIID = "805879794043@paytm" + Environment.NewLine;
            string SupplierGSTIn = "23AAUCA5965F1ZC"+ Environment.NewLine;
            string InvoiceNo = "27/VSL/20000765" + Environment.NewLine;
            string InvoiceDate = "03/03/2021" + Environment.NewLine;
            string InvoiceValue = "1180.00" + Environment.NewLine;
            string GSTAmount = "180.00" + Environment.NewLine;
            string CGSTAmount = "90.00" + Environment.NewLine;
            string SGSTAmount = "90.00" + Environment.NewLine;
            string IGSTAmount = "0.00" + Environment.NewLine;
            string CessAmount = "0.00" + Environment.NewLine;

            string B2cInfo = Environment.NewLine+ "Inv No.:-"+ InvoiceNo+ " Inv Amt.:-" + InvoiceValue+ "Supplier GSTIN:-" + SupplierGSTIn+" UPIID:-"+ SupplierUPIID.ToString()+ " bankAccNo:-"+ bankAccNo+ " BankIFSCNo.:-"+ BankIfscNo+ "  InvoiceDate"+ InvoiceDate+ " GSTAmount:-"+ GSTAmount+ " CGSTAmount:-"+ CGSTAmount + " SGSTAmount:-" + SGSTAmount + " IGSTAmount:-" + IGSTAmount + " CessAmount:-" + CessAmount;
            

            //string Srt = "Supplier GSTIN number:98282852dsds88/n/r upi://pay?pa=9251261774@paytm&pn=Sagar%20Bhardwaj&tn=undefined&am=undefined/ /n/rPayee’s Bank A/C number and IFSC:HDFC,dsadsada";

            string Srsst = "upi://pay?cu=INR&pa=9251261774@paytm&pn=Santanu%20Sinha";
            string WithDataStr = "upi://pay?cu=INR&pa="+ SupplierUPIID + "&pn="+ SellerName + "&tn=" + B2cInfo + "";
            GenerateMyQCCode(WithDataStr);

            //am=" + InvoiceValue.ToString() + "&
        }

        private void GenerateMyQCCode(string QCText)
        {
            string code = QCText;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);

            QRCode qrCode = new QRCode(qrCodeData);

            using (Bitmap bitMap = qrCode.GetGraphic(50))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                    byte[] byteImage = ms.ToArray();

                    qr.Text = "<img src ='data:image/gif;base64," + Convert.ToBase64String(byteImage) + "' width='500' height='500'>";
                }

            }
        }
    }
}