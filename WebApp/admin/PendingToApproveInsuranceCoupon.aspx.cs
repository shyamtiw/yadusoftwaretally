using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebApp.admin.ReportModal;
using System.IO;
using SelectPdf;
using Emailer;
using System.Threading;
using System.Transactions;

namespace WebApp.admin
{
    public partial class PendingToApproveInsuranceCoupon : System.Web.UI.Page
    {
        public static int COuntColl = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillTable();
            }

        }

        private void FillTable()
        {
            string[] Array = Global.Context.Masters.AsEnumerable().Where(print => print.MasterParentId == 2).Select(p => p.Name.Replace(" ", "")).ToArray();
            var ArrayItem = string.Join(",", Array);

            var TotalArray = Array.Select(p => string.Concat("isnull(", p, ",0)")).ToArray();

            var TotalConvert = ",(" + string.Join("+", TotalArray) + ") as Total ";





            string str = "select x.InsuranceIndividualId,InsuranceCouponId,isnull( CreateBy,'') as CreateBy,CustomerName,VehicleRegnNo,isnull(EmailId,'') as EmailId ," + ArrayItem + " " + TotalConvert + " from   (select InsuranceIndividualId,InsuranceCouponId,CreateBy,EmailId," + ArrayItem + " from( select x.InsuranceIndividualId, (select top 1 ISNULL(EmailId,'') from InsuranceCoupon where InsuranceCoupon.InsuranceIndividualId = (x.InsuranceIndividualId)  and Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code + " and LEN( ISNULL(EmailId,''))>0) as EmailId ,(select top 1 stuff(( select ',' + u.InsuranceCouponId from  (select convert (nvarchar(50), InsuranceCouponId)+'_'+convert (nvarchar(50), MasterId) InsuranceCouponId from InsuranceCoupon where InsuranceCoupon.InsuranceIndividualId in (x.InsuranceIndividualId) and    isnull(ApproveBy,0)=0 and Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code + ") u for xml path('') ),1,1,'')) as  InsuranceCouponId,(select top 1 stuff(( select ',' + u.[User_Name] from  (select Distinct isnull(convert (nvarchar(50), [User_Name]),'') [User_Name] from User_Tbl where User_Tbl.User_Code in (select CreatedBy from  InsuranceCoupon where InsuranceCoupon.InsuranceIndividualId=x.InsuranceIndividualId and isnull(ApproveBy,0)=0 and Comp_Code=1)) u for xml path('') ),1,1,'') ) as  CreateBy ,replace( Name,' ','') as Name,TotalCoupon from (select InsuranceIndividualId,MasterId,COUNT(*) as TotalCoupon from  (select   InsuranceCouponId,MasterId,MobNo,InsuranceIndividualId from InsuranceCoupon  where   isnull(ApproveBy,0)=0 and Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code + ") as x group by InsuranceIndividualId,MasterId ) as x  left join [Master] on x.MasterId=[Master].MasterId  ) d pivot ( sum(TotalCoupon) for Name in (" + ArrayItem + ") ) piv) as x left join  InsuranceIndividual on  x.InsuranceIndividualId=InsuranceIndividual.InsuranceIndividualId";
            DataTable dt = ConnModal.FillDataTable(str);
            COuntColl = dt.Columns.Count - 3;
            foreach (DataColumn dr in dt.Columns)
            {
                if (!"InsuranceCouponId,InsuranceIndividualId,CustomerName,EmailId,CreateBy".Split(',').Contains(dr.ColumnName))
                {
                    BoundField newColumnName = new BoundField();

                    newColumnName.DataField = dr.ColumnName;
                    newColumnName.HeaderText = Common.AddSpacesToSentence(dr.ColumnName);

                    gvlocation.Columns.Add(newColumnName);
                }


            }

            //HiddenField lnkView = new HiddenField();
            //lnkView.ID = "lnkView";
            //lnkView.Text = "View";
            //lnkView.Click += ViewDetails;
            //lnkView.CommandArgument = (e.Row.DataItem as DataRowView).Row["Id"].ToString();
            //e.Row.Cells[2].Controls.Add(lnkView);



            gvlocation.DataSource = dt;

            gvlocation.DataBind();
        }


    //    private void SendInduEMAIL() {


    //        //string[] InsRanceId = (gvlocation.Rows[i].FindControl("InsuranceCouponId") as HiddenField).Value.ToString().Split(',');
    //        //foreach (var s in InsRanceId)
    //        //{
    //        //    string StrCodeGen = Status == 1 ? " ((select top 1 Code from [Master] where Master.MasterId=" + s.Split('_')[1] + ")+'/20-21/'+ REPLACE(STR(convert (nvarchar(50),((select COUNT(*)+1 from InsuranceCoupon where Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code + " and MasterId=" + s.Split('_')[1] + " and isnull(IsApprove,0)=1))),5),' ', '0')) " : "''";
    //        //    if (StrUpdateStr.Length > 0)
    //        //    {
    //        //        StrUpdateStr = StrUpdateStr + ";" + "update InsuranceCoupon set Code=" + StrCodeGen + " , ApproveBy=" + SiteSession.LoginUser.User_Code + ", ApproveDate='" + Common.DateTimeNow().ToString("dd-MMM-yyyy hh:mm tt") + "',IsApprove=" + (Status == 1 ? 1 : 0) + ",IsReject=" + (Status == 2 ? 1 : 0) + " where InsuranceCouponId=" + s.Split('_')[0] + "";
    //        //    }
    //        //    else
    //        //    {
    //        //        StrUpdateStr = "update InsuranceCoupon set Code=" + StrCodeGen + " , ApproveBy=" + SiteSession.LoginUser.User_Code + ", ApproveDate='" + Common.DateTimeNow().ToString("dd-MMM-yyyy hh:mm tt") + "',IsApprove=" + (Status == 1 ? 1 : 0) + ",IsReject=" + (Status == 2 ? 1 : 0) + " where InsuranceCouponId=" + s.Split('_')[0] + "";
    //        //    }
    //        //}



    //        //if (Status == 1)
    //        //{
    //        //    if (!string.IsNullOrEmpty((gvlocation.Rows[i].FindControl("EmailId") as Label).Text))
    //        //    {
    //        //        EmailSenders.Add(new EmailSender()
    //        //        {
    //        //            EmailId = (gvlocation.Rows[i].FindControl("EmailId") as Label).Text,
    //        //            Id = string.Join(",", InsRanceId.AsEnumerable().Select(p => p.Split('_')[0]).ToArray())
    //        //        });




    //        //    }
    //        //}
    //    }
    //}


        private void SaveData()
        {

            try
            {

                string StrUpdateStr = "";

                List<EmailSender> EmailSenders = new List<EmailSender>();

                for (int i = 0; i < gvlocation.Rows.Count; i++)
                {

                    var Status = (gvlocation.Rows[i].FindControl("Status") as RadioButtonList).SelectedValue.ConvertInt();
                    if (Status != 0)
                    {

                        string[] InsRanceId = (gvlocation.Rows[i].FindControl("InsuranceCouponId") as HiddenField).Value.ToString().Split(',');
                        foreach (var s in InsRanceId)
                        {
                            string StrCodeGen = Status == 1? " ((select top 1 Code from [Master] where Master.MasterId=" + s.Split('_')[1] + ")+'/20-21/'+ REPLACE(STR(convert (nvarchar(50),((select COUNT(*)+1 from InsuranceCoupon where Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code + " and MasterId=" + s.Split('_')[1] + " and isnull(IsApprove,0)=1))),5),' ', '0')) ":"''";
                            if (StrUpdateStr.Length > 0)
                            {
                                StrUpdateStr = StrUpdateStr + ";" + "update InsuranceCoupon set Code=" + StrCodeGen + " , ApproveBy=" + SiteSession.LoginUser.User_Code + ", ApproveDate='" + Common.DateTimeNow().ToString("dd-MMM-yyyy hh:mm tt") + "',IsApprove=" + (Status == 1 ? 1 : 0) + ",IsReject=" + (Status == 2 ? 1 : 0) + " where InsuranceCouponId=" + s.Split('_')[0] + "";
                            }
                            else
                            {
                                StrUpdateStr = "update InsuranceCoupon set Code=" + StrCodeGen + " , ApproveBy=" + SiteSession.LoginUser.User_Code + ", ApproveDate='" + Common.DateTimeNow().ToString("dd-MMM-yyyy hh:mm tt") + "',IsApprove=" + (Status == 1 ? 1 : 0) + ",IsReject=" + (Status == 2 ? 1 : 0) + " where InsuranceCouponId=" + s.Split('_')[0] + "";
                            }
                        }



                        if (Status == 1)
                        {
                            if (!string.IsNullOrEmpty((gvlocation.Rows[i].FindControl("EmailId") as Label).Text))
                            {
                                EmailSenders.Add(new EmailSender()
                                {
                                    EmailId = (gvlocation.Rows[i].FindControl("EmailId") as Label).Text,
                                    Id = string.Join(",", InsRanceId.AsEnumerable().Select(p => p.Split('_')[0]).ToArray())
                                });




                            }
                        }
                    }

                }
                using (TransactionScope trans = new TransactionScope())
                {
                    Global.Context.UpdateAllCouponApprove(StrUpdateStr);
                    trans.Complete();
                }
                var BodyCondande = Global.Context.Teplates.Where(Page => Page.TeplateId == 2).FirstOrDefault().Template;
                string CompanyName = SiteSession.Comp_MstSession.Comp_Name;
                var UserId = SiteSession.LoginUser.User_Code;
              

               

                    //var objs = Emailer.Mailer.SendMail(x.EmailId, ConfigurationSettings.AppSettings["SMTPUserName"], "", BodyCondande, "Coupon", null, true, "", "vikas@autovyn.in", null, objListOfDocument, CompanyName + " Discount Coupon");
                    Thread ThProcessSendDataOracle = new Thread(() =>

                          CallFunctionForThread(BodyCondande.Replace("{COMP_Name}", CompanyName), EmailSenders, UserId, CompanyName)

                      );
                 
                    ThProcessSendDataOracle.IsBackground = true;
                    ThProcessSendDataOracle.Start();
              

                FillTable();
                MessageBox.ShowMessage("Success", "Data has been saved and Send to  thread for sending Email", SiteKey.MessageType.success);


            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record/Username already exists. Please choose another."; }
                MessageBox.ShowMessage("Error", Message, SiteKey.MessageType.danger);



            }

        }


        private  async void CallFunctionForThread(string BodyCondande, List<EmailSender> EmailSenders, int UserId, string CompanyName)
        {
            EmailSenders.ForEach(x =>
            {
                var objListOfDocument = new List<Emailer.AttachmentStream>();

                objListOfDocument.Add(new Emailer.AttachmentStream() { FileName = "Coupon", File = Common.CreatePDFMultipalhred(x.Id, CompanyName), Extranson = "pdf", subExtranson = "pdf" });

                try
                {
                    var objs = Emailer.Mailer.SendMail(x.EmailId, ConfigurationSettings.AppSettings["SMTPUserName"], "", BodyCondande, "Coupon", null, true, "", "vikas@autovyn.in", null, objListOfDocument, CompanyName + " Discount Coupon");

                    if (objs == "Send")
                    {
                        string str = "insert into WaMassge(MessageType,Message,UserId,datetime,Status,Responce,MobileNo,TransNo) values ('Email','Send Coupon Id=" + x.Id + "'," + UserId + ",'" + Common.DateTimeNow().ToString("dd-MMM-yyyy hh:mm tt") + "',1,'','" + x.EmailId + "','successfully Send')";
                        ConnModal.ExequteQuey(str);
                    }
                    else
                    {
                        string str = "insert into WaMassge(MessageType,Message,UserId,datetime,Status,Responce,MobileNo,TransNo) values ('Email','Send Coupon Id=" + x.Id + "'," + UserId + ",'" + Common.DateTimeNow().ToString("dd-MMM-yyyy hh:mm tt") + "',0,'','" + x.EmailId + "','" + objs.Replace("'", "''") + "')";
                        ConnModal.ExequteQuey(str);
                    }
                }
                catch (Exception ex)
                {
                    string str = "insert into WaMassge(MessageType,Message,UserId,datetime,Status,Responce,MobileNo,TransNo) values ('Email','Send Coupon Id=" + x.Id + "'," + UserId + ",'" + Common.DateTimeNow().ToString("dd-MMM-yyyy hh:mm tt") + "',0,'','" + x.EmailId + "','" + ex.Message.Replace("'", "''") + "')";
                    ConnModal.ExequteQuey(str);
                }
            });
        }


 



        protected void GetData_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}

public class EmailSender
{
    public string Id { get; set; }
    public string EmailId { get; set; }
}


