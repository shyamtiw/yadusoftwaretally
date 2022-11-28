using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using WebApp.LIBS;
using System.Transactions;

namespace WebApp.schooladmin
{
    public partial class Perameter : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillTable();

               

            }
            #region Location
            if (Request.QueryString != null && !string.IsNullOrEmpty(Convert.ToString(Request.QueryString["MasterParentId"])) && LIBS.Common.ConvertInt(savelocation.CommandArgument) == 0)
            {
                savelocation.CommandArgument = Convert.ToString(Request.QueryString["MasterParentId"]);
                BindLocation(LIBS.Common.ConvertInt(savelocation.CommandArgument));
            }
            if (Request.QueryString["MasterParentId"].ConvertInt() > 0)
            {
                if (Request.QueryString != null && !string.IsNullOrEmpty(Convert.ToString(Request.QueryString["MasterParentId"])) && LIBS.Common.ConvertInt(savelocation.CommandArgument) != Request.QueryString["MasterParentId"].ConvertInt())
                {
                    savelocation.CommandArgument = Convert.ToString(Request.QueryString["MasterParentId"]);
                }
            }
            #endregion

            #region Class
            if (Request.QueryString != null && !string.IsNullOrEmpty(Convert.ToString(Request.QueryString["MasterId"])) && LIBS.Common.ConvertInt(saveClass.CommandArgument) == 0)
            {
                saveClass.CommandArgument = Convert.ToString(Request.QueryString["MasterId"]);
                BindClass(LIBS.Common.ConvertInt(saveClass.CommandArgument));

            }
            if (Request.QueryString["MasterId"].ConvertInt() > 0)
            {
                if (Request.QueryString != null && !string.IsNullOrEmpty(Convert.ToString(Request.QueryString["MasterId"])) && LIBS.Common.ConvertInt(saveClass.CommandArgument) != Request.QueryString["MasterId"].ConvertInt())
                {
                    saveClass.CommandArgument = Convert.ToString(Request.QueryString["MasterId"]);
                }
            }
            #endregion



        }


        #region LocationData
        private void FillTable()
        {
            try
            {
                Common.BindControl(MasterParentId, Global.Context.MasterParents.ToList(), "ParentName", "MasterParentId", "Select");

                LIBS.Common.BindControl(gvlocation, Global.Context.MasterParents.AsEnumerable().ToList());

            }
            catch { }


        }


        private void BindLocation(int v)
        {
            var obj = Global.Context.MasterParents.SingleOrDefault(p => p.MasterParentId == v);
            {

                ParentName.Text = obj.ParentName.ToString();



            }
        }



        protected void savelocation_Click(object sender, EventArgs e)
        {
            try
            {

                if (Page.IsValid)
                {

                    if (LIBS.Common.ConvertInt(savelocation.CommandArgument) > 0)
                    {
                        using (TransactionScope Trans = new TransactionScope())
                        {
                            int projectid = LIBS.Common.ConvertInt(savelocation.CommandArgument);
                            var obj = Global.Context.MasterParents.SingleOrDefault(p => p.MasterParentId == projectid);
                            {
                                obj.ParentName = ParentName.Text;


                                obj.Save();
                                FillTable();
                                Trans.Complete();
                            }
                        }
                        Response.Redirect("Perameter.aspx", false);
                    }
                    else
                    {
                        using (TransactionScope Trans = new TransactionScope())
                        {
                            Business.MasterParent obj = new Business.MasterParent()
                            {
                                ParentName = ParentName.Text,


                            }; obj.Save();
                            FillTable();
                            Trans.Complete();
                        }

                        ParentName.Text = "";
                        MessageBox.ShowMessage("Success", "successfully data Saved", SiteKey.MessageType.success);
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
        #endregion
        #region ClassData
        private void FillClass(int Id)
        {
            try
            {

                LIBS.Common.BindControl(gvclass, Global.Context.Masters.Where(parameters=> parameters.MasterParentId==Id).ToList());

            }
            catch { }
        }

        private void BindClass(int v)
        {
            var obj = Global.Context.Masters.SingleOrDefault(p => p.MasterId == v);
            {

                Code.Text = obj.Code.ToString();
                Names.Text = obj.Name.ToString();

                Description.Text = obj.Description.ToString();


                try
                {
                    MasterParentId.SelectedValue = obj.MasterParentId.Value.ToString();
                }
                catch { }
            }
        }




        protected void saveClass_Click(object sender, EventArgs e)
        {
            try
            {

                if (Page.IsValid)
                {

                    if (LIBS.Common.ConvertInt(saveClass.CommandArgument) > 0)
                    {
                        using (TransactionScope Trans = new TransactionScope())
                        {
                            int projectid = LIBS.Common.ConvertInt(saveClass.CommandArgument);
                            var obj = Global.Context.Masters.SingleOrDefault(p => p.MasterId == projectid);
                            {
                                obj.Code = Code.Text;
                                obj.Name = Names.Text;
                                obj.Description = Description.Text;
                                obj.MasterParentId = MasterParentId.SelectedValue.ConvertInt();


                                obj.Save();
                           
                                Trans.Complete();
                            }
                        }
                        Response.Redirect("Perameter.aspx", false);
                    }
                    else
                    {
                        using (TransactionScope Trans = new TransactionScope())
                        {
                            Business.Master obj = new Business.Master()
                            {
                                Code = Code.Text,
                                Name = Names.Text,
                                Description = Description.Text,
                                MasterParentId = MasterParentId.SelectedValue.ConvertInt(),
                            }; obj.Save();
                            
                            Trans.Complete();
                        }

                        Code.Text = "";
                        Names.Text = "";
                        Description.Text = "";
                        FillClass(MasterParentId.SelectedValue.ConvertInt());
                        MessageBox.ShowMessage("Success", "successfully data Saved", SiteKey.MessageType.success);
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




        #endregion

        protected void MasterParentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillClass(MasterParentId.SelectedValue.ConvertInt());
            }
            catch { }
        }
    }
}