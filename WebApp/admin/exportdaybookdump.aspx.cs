using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using System.Data;
using WebApp.admin.ReportModal;
using ClosedXML.Excel;
using System.IO;

namespace WebApp.admin
{
    public partial class exportdaybookdump : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saveAccountHead_Click(object sender, EventArgs e)
        {
            try
            {

                string str = "select acnt_id,acnt_no,acnt_Date,bill_Ref,(Select top 1 book_name from book_mst where book_mst.book_code=x.book_code) as Book_Name, (select top 1 Godw_Name from Godown_mst where godw_code=x.loc_code) as Branch_Name, (select top 1 Ledg_name from ledg_mst where ledg_Code=x.ledg_Ac) as Ledger_Name , Post_Amt, DRCR, export_type, (select user_name from user_tbl where user_code=x.USR_CODE and export_type<1) as Created_by, (select top 1 Group_Code from ledg_mst where ledg_Code=x.ledg_Ac) as Group_Code , ledg_narr,link_id from  ( select  acnt_post.export_type,entr_Date,entr_time,acnt_id,usr_Code,acnt_Date,acnt_no,bill_Ref,acnt_post.book_code,loc_code,ledg_Ac, ledg_ac2,post_amt,(Case when acnt_post.Amt_drcr=1 then 'DR' else 'CR' end) as DRCR,ledg_narr,link_id from   acnt_post  where acnt_post.export_type<=4 and acnt_date>='" + FromDate.Text.DateConvertTextMatchCaseStringSQL() + "' and acnt_date<='" + ToDate.Text.DateConvertTextMatchCaseStringSQL() + "' and loc_code in (" + string.Join(",", SiteSession.GetGodawanListSession.Select(x => x.Id.ToString()).ToArray()) + "))  as x";


                ErrorNote.Text = "Please Wait Process Data";

                

                              DataTable dt = OtherSqlConn.FillDataTableMaxTime(str);
                ErrorNote.Text = "Please Wait Exporting Data";

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "daybookdata");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }


                //string attachment = "attachment; filename=daybookdump" + Common.DateTimeNow().ToString("ddMMyyyyhhmmss") + ".xls";
                //Response.ClearContent();
                //Response.AddHeader("content-disposition", attachment);
                //Response.ContentType = "application/vnd.ms-excel";
                //string tab = "";
                //foreach (DataColumn dc in dt.Columns)
                //{
                //    Response.Write(tab + dc.ColumnName);
                //    tab = "\t";
                //}
                //Response.Write("\n");
                //int i;
                //foreach (DataRow dr in dt.Rows)
                //{
                //    tab = "";
                //    for (i = 0; i < dt.Columns.Count; i++)
                //    {
                //        Response.Write(tab + dr[i].ToString());
                //        tab = "\t";
                //    }
                //    Response.Write("\n");
                //}
                //Response.End();
                MessageBox.ShowMessage("Success", "Successfully Export data", SiteKey.MessageType.success);
                ErrorNote.Text = "Successfully Export data";

            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record/Username already exists. Please choose another."; }
                MessageBox.ShowMessage("Error", Message, SiteKey.MessageType.danger);
                
                ErrorNote.Text = Message;

            }



        }
    }
}