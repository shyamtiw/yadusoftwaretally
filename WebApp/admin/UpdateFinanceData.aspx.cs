using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using WebApp.admin.ReportModal;
using WebApp.LIBS;
namespace WebApp.admin
{
    public partial class UpdateFinanceData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Common.BindControl(Hypo, Global.Context.Masters.Where(p => p.MasterParentId == 10).ToList(), "Description", "MasterId", "Select");
                Fill();

           

            }

        }

        private void Fill()
        {
            int Id = Request.QueryString["ReceiptId"].ConvertInt();
            DataTable table = OtherSqlConn.FillDataTableMaxTime("select * from Finance where FinanceId=" + Id + " ");

            DataRow obj = table.Rows[0];
            try { DoAmt.Text = obj["DoAmt"].ToString(); } catch { }
            try { PfCharg.Text = obj["PfCharg"].ToString(); } catch { }
            try { LoanType.SelectedValue = obj["LoanType"].ToString(); } catch { }
            try { DoNo.Text = obj["DoNo"].ToString(); } catch { }
            try { Payoutpercent.Text = obj["Payoutpercent"].ToString(); } catch { }
            try { PayoutpercentAmount.Text = obj["PayoutpercentAmount"].ToString(); } catch { }
            try { GSTAmount.Text = obj["GSTAmount"].ToString(); } catch { }
            try { FinalAmout.Text = obj["FinalAmout"].ToString(); } catch { }
            try { DisbursementAmount.Text = obj["DisbursementAmount"].ToString(); } catch { }
            try { DisbursementDate.Text =  Convert.ToDateTime( obj["DisbursementDate"]).ToString("dd/MM/yyyy"); } catch { }
            try { BankName.Text = obj["BankName"].ToString(); } catch { }
            try { AccountNumber.Text = obj["AccountNumber"].ToString(); } catch { }
            try { ReceivedAmount.Text = obj["ReceivedAmount"].ToString(); } catch { }
            try { CreditRef.Text = obj["CreditRef"].ToString(); } catch { }
            try { Remark.Text = obj["Remark"].ToString(); } catch { }
            try { Hypo.SelectedValue = obj["Hypo"].ToString(); } catch { }
            try { hypoBranch.Text = obj["hypoBranch"].ToString(); } catch { }
            try { DSEPayout.Text = obj["DSEPayout"].ToString(); } catch { }
            try { TDSAmount.Text = obj["TDSAmount"].ToString(); } catch { }
            try { ShortCredited.Text = obj["ShortCredited"].ToString(); } catch { }

            try { DoDate.Text = Convert.ToDateTime(obj["DoDate"]).ToString("dd/MM/yyyy"); } catch { }
            try { DeliveryDate.Text = Convert.ToDateTime(obj["DeliveryDate"]).ToString("dd/MM/yyyy"); } catch { }

            try { PDDCharges.Text = obj["PDDCharges"].ToString(); } catch { }


            try { DoAmtT.Text = obj["DoAmt"].ToString(); } catch { }
            try { PfChargT.Text = obj["PfCharg"].ToString(); } catch { }
            
            try { DoNoT.Text = obj["DoNo"].ToString(); } catch { }
            try { DoDateT.Text = Convert.ToDateTime(obj["DoDate"]).ToString("dd/MM/yyyy"); } catch { }

            try { PayoutpercentT.Text = obj["Payoutpercent"].ToString(); } catch { }
            try { PayoutpercentAmountT.Text = obj["PayoutpercentAmount"].ToString(); } catch { }
            try { GSTAmountT.Text = obj["GSTAmount"].ToString(); } catch { }
            try { FinalAmoutT.Text = obj["FinalAmout"].ToString(); } catch { }

            try { DSEPayoutT.Text = obj["DSEPayout"].ToString(); } catch { }





            try { DisbursementAmountPayout.Text = obj["DisbursementAmountPayout"].ToString(); } catch { }
            try { DisbursementDatePayout.Text = Convert.ToDateTime(obj["DisbursementDatePayout"]).ToString("dd/MM/yyyy"); } catch { }
            try { BankNamePayout.Text = obj["BankNamePayout"].ToString(); } catch { }
            try { AccountNumberPayout.Text = obj["AccountNumberPayout"].ToString(); } catch { }

            try { MSSF.SelectedValue = obj["MSSF"].ToString(); } catch { }
            try { ROI.Text = obj["ROI"].ToString(); } catch { }





        }

        protected void savelocation_Click(object sender, EventArgs e)
        {
            try
            {

                if (Page.IsValid)
                {

                    if ((TDSAmount.Text.ConvertDecimal() > 0 || ShortCredited.Text.ConvertDecimal()>0) && Remark.Text.Length == 0)
                    {
                        MessageBox.ShowMessage("Error", "Please Fill Remarks", SiteKey.MessageType.danger);
                    }
                    else
                    {
                        int Id = Request.QueryString["ReceiptId"].ConvertInt();

                        if (Id > 0)
                        {


                            string update = "update Finance set " +
                                 "DisbursementAmountPayout = " + DisbursementAmountPayout.Text.ConvertDecimal() + ""+
                                 " " + (DisbursementDatePayout.Text.Length > 0 ? ", DisbursementDatePayout = '" + DisbursementDatePayout.Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy") + "'" : "") + "," +
                                 "BankNamePayout = '" + BankNamePayout.Text + "'," +
                                 "AccountNumberPayout = '" + AccountNumberPayout.Text + "'," +
                                 "MSSF = '" + MSSF.Text + "'," +
                                 "ROI = " + MSSF.Text.ConvertDecimal() + "," +

                                " TDSAmount=" + TDSAmount.Text.ConvertDecimal() + ",PDDCharges=" + PDDCharges.Text.ConvertDecimal() + ",ShortCredited=" + ShortCredited.Text.ConvertDecimal() + ",DSEPayout=" + DSEPayout.Text.ConvertDecimal() + ",Hypo=" + Hypo.SelectedValue.ConvertInt() + ", hypoBranch='" + hypoBranch.Text.Replace("'", "''") + "', UserId=" + SiteSession.LoginUser.User_Code.ToString() + ", DoAmt=" + DoAmt.Text.ConvertDecimal() + ",	PfCharg=" + PfCharg.Text.ConvertDecimal() + ",	LoanType='" + LoanType.SelectedValue + "',	DoNo='" + DoNo.Text + "',	Payoutpercent=" + Payoutpercent.Text.ConvertDecimal() + ",	PayoutpercentAmount='" + PayoutpercentAmount.Text.ConvertDecimal() + "',	GSTAmount='" + GSTAmount.Text.ConvertDecimal() + "',	FinalAmout='" + FinalAmout.Text.ConvertDecimal() + "',	DisbursementAmount='" + DisbursementAmount.Text.ConvertDecimal() + "' " + (DisbursementDate.Text.Length > 0 ? ", DisbursementDate = '" + DisbursementDate.Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy") + "'" : ", DisbursementDate =null") + ",	BankName='" + BankName.Text + "',	AccountNumber='" + AccountNumber.Text + "',	ReceivedAmount='" + ReceivedAmount.Text.ConvertDecimal() + "',	CreditRef='" + CreditRef.Text.Replace("'", "''") + "',	Remark='" + Remark.Text.Replace("'", "''") + "' " + (DeliveryDate.Text.Length > 0 ? ", DeliveryDate = '" + DeliveryDate.Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy") + "'" : ", DeliveryDate = null") + " " + (DoDate.Text.Length > 0 ? ", DoDate = '" + DoDate.Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy") + "'" : ",DoDate=null") + " where FinanceId=" + Id + "";
                            var Flag = OtherSqlConn.ExequteQuey(update);

                            if (Flag == "Yes")
                            {
                                MessageBox.ShowMessage("Success", "successfully data Saved", SiteKey.MessageType.success);
                            }
                            else

                            {
                                MessageBox.ShowMessage("Error", Flag, SiteKey.MessageType.danger);
                            }
                        }


                    }
                }

            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record/Username already exists. Please choose another."; }
                MessageBox.ShowMessage("Error", Message, SiteKey.MessageType.danger);
            }
        }

    
    }
}