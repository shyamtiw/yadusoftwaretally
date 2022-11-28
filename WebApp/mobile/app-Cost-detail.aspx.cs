using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using WebApp.LIBS.MobileAppCS;
using System.Data;
using System.Transactions;

namespace WebApp.mobile
{
    public partial class app_Cost_detail : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int[] MasterId = { 4, 5, 6,7,12 };

                var MasterData = Global.Context.Masters.AsEnumerable().Where(p => MasterId.Contains(p.MasterParentId.Value)).ToList();
                Common.BindControl(ddlInsu_type, MasterData.Where(p => p.MasterParentId == 4).ToList(), "Name", "MasterId", "Select");
                Common.BindControl(ddlEW_Type, MasterData.Where(p => p.MasterParentId == 5).ToList(), "Name", "MasterId", "Select");
                Common.BindControl(ddlRTO_Type, MasterData.Where(p => p.MasterParentId == 6).ToList(), "Name", "MasterId", "Select");
                Common.BindControl(ddlMSR, MasterData.Where(p => p.MasterParentId == 7).ToList(), "Name", "MasterId", "Select");
                Common.BindControl(ddlFasTag, MasterData.Where(p => p.MasterParentId == 7).ToList(), "Name", "MasterId", "Select");

                Common.BindControl(ddlInsuCompName, MasterData.Where(p => p.MasterParentId == 12).ToList(), "Name", "MasterId", "Select");





                DataRow dr = SiteSession.SalesDataTable.Rows[0];
                try
                {
                    Insu_Typex.Text = MasterData.Where(p => p.MasterId == Common.ConvertInt(dr["Insu_Type"])).FirstOrDefault().Name;
                    ddlInsu_type.SelectedValue = dr["Insu_Type"].ToString();
                }
                catch { }

                try
                {
                    InsuCompName.Text = MasterData.Where(p => p.MasterId == Common.ConvertInt(dr["Insu_CompName"])).FirstOrDefault().Name;
                    ddlInsuCompName.SelectedValue = dr["Insu_CompName"].ToString();
                }
                catch { }


                Insu_Amt.Text = dr["Insu_Amt"].ToString();
                TXTInsu_Amt.Text= dr["Insu_Amt"].ToString();
                try
                {
                    EW_Type.Text = MasterData.Where(p => p.MasterId == Common.ConvertInt(dr["EW_Type"])).FirstOrDefault().Name;
                    ddlEW_Type.SelectedValue = dr["EW_Type"].ToString();
                }
                catch { }
                EW_Amt.Text = dr["EW_Amt"].ToString();
                TxtEW_Amt.Text = dr["EW_Amt"].ToString();
                try
                {
                    RTO_Type.Text = MasterData.Where(p => p.MasterId == Common.ConvertInt(dr["RTO_Type"])).FirstOrDefault().Name;
                    ddlRTO_Type.SelectedValue= dr["RTO_Type"].ToString();
                }
                catch { }
             
                RTO_Amt.Text = (Common.ConvertDecimal(dr["RTO_Amt"]) + Common.ConvertDecimal(dr["Trc_Amt"])).ToString();
                TxtRTO_Amt.Text = dr["RTO_Amt"].ToString();
                TxtTRC_Amt.Text = dr["Trc_Amt"].ToString();

                MSGA_AMT.Text = dr["MSGA_AMT"].ToString();

                MSR_AMT.Text = dr["MSR_AMT"].ToString();
                try
                {
                    ddlMSR.SelectedValue = dr["MSR_Type"].ToString();
                }
                catch { }
                
                FasTag_Amt.Text = dr["FasTag_Amt"].ToString();
                try
                {
                    ddlFasTag.SelectedValue = dr["FASTAG_Type"].ToString();
                }
                catch { }
                Trans_Id.Text = dr["TRANS_ID"].ToString();
              
            }
        }
       
        protected void btnInsurancActionSheet_Click(object sender, EventArgs e)
        {
            try
            {


                DataRow dr = SiteSession.SalesDataTable.Rows[0];
                if (dr != null)
                {
                    using (TransactionScope trans = new TransactionScope())
                    {

                        int Id = Convert.ToInt32(dr["BookingId"]);
                        var objuser = Global.Context.Bookings.SingleOrDefault(p => p.BookingId == Id);
                        objuser.Insu_Type = ddlInsu_type.SelectedValue.ConvertInt();
                        objuser.Insu_amt = TXTInsu_Amt.Text.ConvertDecimal();
                        objuser.Insu_CompName = ddlInsuCompName.SelectedValue.ConvertInt();
                        objuser.Save();
                        trans.Complete();
                    }
                    dr["Insu_Type"] = ddlInsu_type.SelectedValue.ConvertInt();
                    dr["Insu_Type"] = ddlInsu_type.SelectedValue.ConvertInt();
                    dr["Insu_CompName"] = ddlInsuCompName.SelectedValue.ConvertInt();
                    Insu_Typex.Text = ddlInsu_type.SelectedItem.Text;
                    Insu_Amt.Text = TXTInsu_Amt.Text;
                    InsuCompName.Text= ddlInsuCompName.SelectedItem.Text;

                    Message.ShowMessage("Suc", "Record Updated", SiteKey.MessageType.success);


                }
                   



                
            }
            catch (Exception ex) { Message.ShowMessage("Suc", ex.Message, SiteKey.MessageType.danger); }
        }

        protected void btnEW_Click(object sender, EventArgs e)
        {

            try
            {


                DataRow dr = SiteSession.SalesDataTable.Rows[0];
                if (dr != null)
                {
                    using (TransactionScope trans = new TransactionScope())
                    {

                        int Id = Convert.ToInt32(dr["BookingId"]);
                        var objuser = Global.Context.Bookings.SingleOrDefault(p => p.BookingId == Id);
                        objuser.EW_Type = ddlEW_Type.SelectedValue.ConvertInt();
                        objuser.EW_amt = TxtEW_Amt.Text.ConvertDecimal();
                        objuser.Save();
                        trans.Complete();
                    }

                    dr["EW_Type"] = ddlEW_Type.SelectedValue.ConvertInt();
                    dr["EW_amt"] = TxtEW_Amt.Text.ConvertDecimal();
                    EW_Type.Text = ddlEW_Type.SelectedItem.Text;
                    EW_Amt.Text = TxtEW_Amt.Text;

                   Message.ShowMessage("Suc", "Record Updated", SiteKey.MessageType.success);


                }





            }
            catch (Exception ex) { Message.ShowMessage("Suc", ex.Message, SiteKey.MessageType.danger); }

        }

        protected void btnRTO_Click(object sender, EventArgs e)
        {
            try
            {


                DataRow dr = SiteSession.SalesDataTable.Rows[0];
                if (dr != null)
                {
                    using (TransactionScope trans = new TransactionScope())
                    {

                        int Id = Convert.ToInt32(dr["BookingId"]);
                        var objuser = Global.Context.Bookings.SingleOrDefault(p => p.BookingId == Id);
                        objuser.RTO_Type = ddlRTO_Type.SelectedValue.ConvertInt();
                        objuser.RTO_amt = TxtRTO_Amt.Text.ConvertDecimal();
                        objuser.Trc_Amt = TxtTRC_Amt.Text.ConvertDecimal();
                        objuser.Save();
                        trans.Complete();
                    }

                    dr["RTO_Type"] = ddlRTO_Type.SelectedValue.ConvertInt();
                    dr["RTO_Amt"] = TxtRTO_Amt.Text.ConvertDecimal();
                    dr["Trc_Amt"] = TxtTRC_Amt.Text.ConvertDecimal();
                    RTO_Type.Text = ddlRTO_Type.SelectedItem.Text;
                    RTO_Amt.Text = (TxtRTO_Amt.Text.ConvertDecimal() + TxtTRC_Amt.Text.ConvertDecimal()).ToString();

                    Message.ShowMessage("Suc", "Record Updated", SiteKey.MessageType.success);


                }





            }
            catch (Exception ex) { Message.ShowMessage("Suc", ex.Message, SiteKey.MessageType.danger); }


        }

        protected void btnMSGA_Click(object sender, EventArgs e)
        {

            try
            {


                if (TxtMSGA_AMT.Text.ConvertDecimal() >= 1200)
                {
                    DataRow dr = SiteSession.SalesDataTable.Rows[0];
                    if (dr != null)
                    {
                        using (TransactionScope trans = new TransactionScope())
                        {

                            int Id = Convert.ToInt32(dr["BookingId"]);
                            var objuser = Global.Context.Bookings.SingleOrDefault(p => p.BookingId == Id);
                            objuser.MSGA_amt = TxtMSGA_AMT.Text.ConvertDecimal();
                            objuser.Save();
                            trans.Complete();
                        }

                        dr["MSGA_amt"] = TxtMSGA_AMT.Text.ConvertDecimal();

                        MSGA_AMT.Text = TxtMSGA_AMT.Text;

                        Message.ShowMessage("Suc", "Record Updated", SiteKey.MessageType.success);


                    }
                }
                else

                {
                    Message.ShowMessage("Err","MSGA Amount not valid", SiteKey.MessageType.danger);
                }





            }
            catch (Exception ex) { Message.ShowMessage("Suc", ex.Message, SiteKey.MessageType.danger); }


        }

        protected void btnMSR_Click(object sender, EventArgs e)
        {
            try
            {


                DataRow dr = SiteSession.SalesDataTable.Rows[0];
                if (dr != null)
                {
                    using (TransactionScope trans = new TransactionScope())
                    {

                        int Id = Convert.ToInt32(dr["BookingId"]);
                        var objuser = Global.Context.Bookings.SingleOrDefault(p => p.BookingId == Id);
                   
                        objuser.MSR_Type = ddlMSR.SelectedValue.ConvertInt();
                        objuser.MSR_AMT = objuser.MSR_Type == 39 ? 885 : 0;
                        objuser.Save();
                        trans.Complete();
                    }

                    dr["MSR_AMT"] = ddlMSR.SelectedValue.ConvertInt() == 39 ? 885 : 0;

                    MSR_AMT.Text = ddlMSR.SelectedValue.ConvertInt() == 39 ? "885" : "0";

                    Message.ShowMessage("Suc", "Record Updated", SiteKey.MessageType.success);

                }

            }
            catch (Exception ex) { Message.ShowMessage("Suc", ex.Message, SiteKey.MessageType.danger); }



        }

        protected void btnFasTag_Click(object sender, EventArgs e)
        {

            try
            {


                DataRow dr = SiteSession.SalesDataTable.Rows[0];
                if (dr != null)
                {
                    using (TransactionScope trans = new TransactionScope())
                    {

                        int Id = Convert.ToInt32(dr["BookingId"]);
                        var objuser = Global.Context.Bookings.SingleOrDefault(p => p.BookingId == Id);

                        objuser.FASTAG_Type = ddlFasTag.SelectedValue.ConvertInt();
                        objuser.FASTAG_amt = objuser.FASTAG_Type == 39 ? 500 : 0;
                        objuser.Save();
                        trans.Complete();
                    }

                    dr["FASTAG_amt"] = ddlFasTag.SelectedValue.ConvertInt() == 39 ? 500 : 0;

                    FasTag_Amt.Text = ddlFasTag.SelectedValue.ConvertInt() == 39 ? "500" : "0";

                    Message.ShowMessage("Suc", "Record Updated", SiteKey.MessageType.success);

                }

            }
            catch (Exception ex) { Message.ShowMessage("Suc", ex.Message, SiteKey.MessageType.danger); }


        }
    }
}