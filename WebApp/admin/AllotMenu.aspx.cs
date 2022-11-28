using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using System.Transactions;
namespace WebApp.admin
{
    public partial class AllotMenu : LIBS.BasePageClass
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var User = Global.Context.ExecuteStoreQuery<FillUserTbl>("select User_Code,User_Name+'   ['+(select top 1 Comp_Name from Comp_Mst where Comp_Mst.Comp_Code=User_Tbl.Comp_Code)+']' as UserName from User_Tbl").ToList();

                Common.BindControl(ddlAccountCategory, User, "UserName", "User_Code", "Select User");

            }


        }


        protected void ddlAccountCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Common.ConvertInt(ddlAccountCategory.SelectedValue) > 0)
            {
                Common.BindControl(gvDistrict, Global.Context.AllotedMenu(Convert.ToInt32(ddlAccountCategory.SelectedValue)));
                
                    Common.BindControl(gvoption, Global.Context.AllotedOptions(Convert.ToInt32(ddlAccountCategory.SelectedValue)));
                
            }
        }

        protected void saveAccountHead_Click(object sender, EventArgs e)
        {
            try
            {


                if (Common.ConvertInt(ddlAccountCategory.SelectedValue) > 0)
                {
                    int Id = Common.ConvertInt(ddlAccountCategory.SelectedValue);
                    using (TransactionScope Trans = new TransactionScope())
                    {
                        int RoleId = Common.ConvertInt(ddlAccountCategory.SelectedValue);
                        for (int i = 0; i < gvDistrict.Rows.Count; i++)
                        {
                            bool boolSelect = ((CheckBox)gvDistrict.Rows[i].FindControl("ck")).Checked;
                            int ID = Convert.ToInt32(((HiddenField)gvDistrict.Rows[i].FindControl("IDs")).Value);
                            int MenuId = Convert.ToInt32(((HiddenField)gvDistrict.Rows[i].FindControl("MenuId")).Value);
                            if (boolSelect && ID == 0)
                            {

                                Business.AllotMenu ob = new  Business.AllotMenu()
                                { 
                                    MenuId = MenuId,
                                    UserId = Id,

                                };
                                ob.Save();
                            }

                            else if (boolSelect == false && ID > 0)
                            {
                                var ob = Global.Context.AllotMenus.SingleOrDefault(p => p.AllotMenuId == ID);
                                ob.Delete();
                            }

                        }

                        for (int i = 0; i < gvoption.Rows.Count; i++)
                        {
                            bool boolSelect = ((CheckBox)gvoption.Rows[i].FindControl("ck")).Checked;
                            int ID = Convert.ToInt32(((HiddenField)gvoption.Rows[i].FindControl("IDs")).Value);
                            int MenuId = Convert.ToInt32(((HiddenField)gvoption.Rows[i].FindControl("MenuId")).Value);
                            if (boolSelect && ID == 0)
                            {

                                Business.AllotOption ob = new AllotOption()
                                {
                                    OptionId = MenuId,
                                    UserId = Id,

                                };
                                ob.Save();
                            }

                            else if (boolSelect == false && ID > 0)
                            {
                                var ob = Global.Context.AllotOptions.SingleOrDefault(p => p.AllotOptionId == ID);
                                ob.Delete();
                            }

                        }



                        Common.UserLogsInsert("Allot Menu", "Allot Menu ", SiteSession.LoginUser.User_Code, Common.DateTimeNow());

                        Trans.Complete();
                    }
                }
                MessageBox.ShowMessage("Success", "successfully data Saved", SiteKey.MessageType.success);
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

public partial class FillUserTbl
{
public int User_Code { get; set; }
    public string UserName { get; set; }
    
}