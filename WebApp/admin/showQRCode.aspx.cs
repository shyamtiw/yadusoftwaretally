using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


using WebApp.LIBS;
using Business;
using QRCoder;

namespace WebApp.admin
{
    public partial class showQRCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GenerateMyQCCode(SiteSession.FilterKeyHolderResponce.Where(p => p.Key == Request.QueryString["id"].ToString()).FirstOrDefault().Value);
            }
        }

        private void GenerateMyQCCode(string QCText)
        {


            string code = QCText;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);

            QRCode qrCode = new QRCode(qrCodeData);

            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    imgageQRCodedata.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
                
            }



            //var QCwriter = new BarcodeWriter();
            //QCwriter.Format = BarcodeFormat.QR_CODE;
            //var result = QCwriter.Write(QCText);

            //var barcodeBitmap = new Bitmap(result);



            //MemoryStream memoryStream = new MemoryStream();
            //barcodeBitmap.Save(memoryStream, ImageFormat.Jpeg);


            //memoryStream.Position = 0;
            //byte[] byteBuffer = memoryStream.ToArray();


            //memoryStream.Close();


            //var base64String = "data:image/jpg;base64," + Convert.ToBase64String(byteBuffer);
            //byteBuffer = null;





            //imgageQRCode.ImageUrl = base64String;

        }

    }
}