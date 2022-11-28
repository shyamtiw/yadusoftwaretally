using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using WebApp.LIBS;
using System.IO;
using QRCoder;
using System.Drawing;
using Newtonsoft.Json;

namespace WebApp.admin.print
{
    public partial class printinvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Request.QueryString["id"].ConvertInt();

           var obj=     Global.Context.EInvoiceDataExcels.SingleOrDefault(p => p.EInvoiceDataExcelId == ID);
                var State= StateLevel.GetList();

                //string strpos=State.Where(p=> p.SateCode==obj.BuyerPOS)
                var godown = Business.UserLogin.GodwwnListGetUserWise(SiteSession.Comp_MstSession.Comp_Code.Value, obj.GodownCode.Value).FirstOrDefault();
                compnaynameGst.Text = godown.GST_No + "<br/>" + SiteSession.Comp_MstSession.Comp_Name;
                SellerGSTNNO.Text = godown.GST_No;
                SelllerCompanyName.Text = SiteSession.Comp_MstSession.Comp_Name;
                SellerAddress.Text = godown.Godw_Add1;
                SellerAddress2.Text = godown.Godw_Add1;
                SelllerCompanyName2.Text = SiteSession.Comp_MstSession.Comp_Name;

                commstgst2.Text = godown.GST_No;


                BuyerGSTN.Text = obj.BuyerGSTN;
                BuyerLegalName.Text = obj.BuyerLegalName;
                BuyerAddr1.Text = obj.BuyerAddr1 +" "+ obj.BuyerPINCode+ " Place of Supply:" + obj.BuyerPOS;
                BuyerGSTN2.Text = obj.BuyerGSTN;
                BuyerLegalName2.Text = obj.BuyerLegalName;
                BuyerAddr2.Text = obj.BuyerAddr1 +" "+ obj.BuyerPINCode+ " Place of Supply:" + obj.BuyerPOS;


                IRN.Text = obj.Irn;
                AckNo.Text = obj.AckNo.Value.ToString();

                AckDt.Text = Common.DateConvert( obj.AckDt,"yyyy-MM-dd HH:mm:ss").ToString("dd-MM-yyyy HH:mm:ss");
                AckDt2.Text = Common.DateConvert(obj.AckDt, "yyyy-MM-dd HH:mm:ss").ToString("dd-MM-yyyy HH:mm:ss");
                SupplyTypeCode.Text = obj.SupplyTypeCode;
                DocumentNo.Text = obj.DocumentNo;
                DocumentType.Text = obj.DocumentType;
                IGSTIntra.Text = obj.IGSTIntra;
                DocumentDate.Text = obj.DocumentDate.Value.ToString("dd-MM-yyyy");

                printdate.Text = Common.DateTimeNow().ToString("dd-MM-yyyy HH:mm:ss");

                TotalTaxableValue.Text = obj.TotalTaxableValue;
                SGSTAmt1.Text = obj.SGSTAmt1;
                CGSTAmt1.Text = obj.CGSTAmt1;
                CessAmount.Text = obj.CessAmount.ToString();
                StateCessAmount.Text = obj.StateCessAmount;
                Discount1.Text = obj.Discount1;
                OtherCharges1.Text = obj.OtherCharges1;
                RoundOff.Text = obj.RoundOff;
                TotalInvoiceValue.Text = obj.TotalInvoiceValue;



                var JsonStr = "[" + obj.Itemjson + "]";

                var Items = JsonConvert.DeserializeObject<List<Item>>(JsonStr);

                Common.BindControl(rptItems, Items.ToList());
                GenerateMyQCCode(obj.SignedQRCode);




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
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                    byte[] byteImage = ms.ToArray();
                    
                    RQIMG.Text = "<img src ='data:image/gif;base64," + Convert.ToBase64String(byteImage)+ "' width='210' height='210'>";
                }

            }
        }


    }
}