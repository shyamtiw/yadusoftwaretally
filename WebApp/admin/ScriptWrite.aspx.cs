using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using System.Data.SqlClient;
using System.Data;
using WebApp.admin.ReportModal;

namespace WebApp.admin
{
    public partial class ScriptWrite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var MasterDatax = Global.Context.Masters.Where(xc => xc.MasterParentId == 11).ToList();
                Common.BindControl(MasterData, MasterDatax.Select(xc => new { MasterId = (xc.MasterId.ToString() + "~" + xc.Code.Split(',')[1].ToString() + "~" + xc.Name), Code = xc.Code.Split(',')[0] }), "Code", "MasterId", "Select");
                Table.Visible = false;
                Excute.Visible = false;
            }
        }

        protected void MasterData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MasterData.SelectedValue != "Select")
            {
                Perameter.Text = MasterData.SelectedValue.Split('~')[2].ToString();
            }

        }

        protected void GetData_Click(object sender, EventArgs e)
        {
            if (MasterData.SelectedValue != "Select")
            {
                var ExcuteType = MasterData.SelectedValue.Split('~')[1].ToString();
                int MasterId = MasterData.SelectedValue.Split('~')[0].ConvertInt();
                string FirstData = Global.Context.Masters.Where(xc => xc.MasterId == MasterId).FirstOrDefault().Description;
                string Str = FirstData.Replace("{Para1}", Para1.Text).Replace("{Para2}", Para2.Text).Replace("{Para3}", Para3.Text);

                DataTable dtrcpt = OtherSqlConn.FillDataTable("select  ''''+NEWCAR_RCPT+'''' as [Data] from  godown_mst where  Godw_Code in (" + SiteSession.LoginUser.Multi_loc + ")");
                Str= Str.Replace("{LOC}", string.Join(",", dtrcpt.AsEnumerable().Select(p => p[0].ToString()).ToArray()));
               
                var myCon = new SqlConnection("Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=30000");
                myCon.Open();
                string Flag;
                try
                {
                    using (SqlCommand cmd = new SqlCommand(Str, myCon))
                    {
                        cmd.CommandTimeout = int.MaxValue;

                        if (ExcuteType == "Execution")
                        {
                            cmd.ExecuteNonQuery();
                            Table.Visible = false;
                            Excute.Visible = true;
                            responce.Text = "script successfully execute";

                        }
                        else

                        {
                            DataTable dt = new DataTable();
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {


                                da.Fill(dt);
                            }
                            gvlocation.Columns.Clear();
                            gvlocation.DataSource = dt;
                            gvlocation.DataBind();
                            Table.Visible = true;
                            Excute.Visible = false;

                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    Table.Visible = false;
                    Excute.Visible = true;
                    responce.Text = ex.Message;
                    
                }

            }
        }
    }
}