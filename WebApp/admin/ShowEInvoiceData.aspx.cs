using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using System.Drawing;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using Jitbit.Utils;

namespace WebApp.admin
{
    public partial class ShowEInvoiceData : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Common.BindControl(GodownId, SiteSession.GetGodawanListSession.ToList(), "Value", "Id", "All");
                Common.BindControl(VoucherId, Global.Context.VoucherMsts.ToList(), "VoucherContains", "VoucherType", "All");
            }
        }

        private void filterdata()
        {

            string str = "  where Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code.Value.ToString() + " ";

            SiteSession.FilterKeyHolderResponce = new List<FilterKeyHolder>();
            if (GodownId.SelectedValue != "All")
            {
                str = str + " and  GodownCode=" + GodownId.SelectedValue + "";
            }
            else
            {
                str = str + " and  GodownCode in (" + string.Join(",", SiteSession.GetGodawanListSession.Select(x => x.Id.ToString()).ToArray()) + ")";
            }
            if (FromDate.Text.Length > 0 && ToDate.Text.Length > 0)
            {
                str = str + "and DocumentDate between '" + FromDate.Text.DateConvertText().ToString("dd-MMM-yyyy") + "' and '" + ToDate.Text.DateConvertText().ToString("dd-MMM-yyyy") + "' ";
            }
            if (QrStatus.SelectedValue != "All")
            {
                str = str + "and isnull(ErrorStatus,'IRN Pending')='" + QrStatus.SelectedValue + "'";
            }
            string strtript = "SELECT  EInvoiceDataExcelId,'' EMCommition , '' as VoucherType,DocumentNo,DocumentDate,BuyerLegalName, BuyerGSTN,isnull(SignedQRCode,'') as SignedQRCode, (Case when  len(isnull(ErrorStatus,''))=0 then  'IRN Pending' else ErrorStatus end ) as [Status],Responce FROM  [EInvoiceDataExcel] " + str + "";

            var obj = Global.Context.ExecuteStoreQuery<EInvoiceData>(strtript).ToList();

            TotalInvoice.Text = obj.Count().ToString();
            Pending.Text = obj.Where(p => p.Status == "IRN Pending").Count().ToString();
            IRNGeneratedTotal.Text = obj.Where(p => p.Status == "IRN Generated").Count().ToString();
            ErroneousTotal.Text = obj.Where(p => p.Status == "Erroneous Case").Count().ToString();
            Cancelled.Text = obj.Where(p => p.Status == "Cancelled").Count().ToString();
            obj.ForEach(x =>
            {
                string Key = Guid.NewGuid().ToString() + DateTime.Now.Ticks.ToString();
                SiteSession.FilterKeyHolderResponce.Add(new FilterKeyHolder() { Key = Key, Value = x.Responce });
                x.Key = "<a style='color: black;' href='#' onclick= \"showLeter('jsoneditore.aspx?id=" + Key + "')\">Response</a>" + "</td>";
                //if (x.SignedQRCode.Length > 0)
                //{
                //    string Keyqr = Guid.NewGuid().ToString() + DateTime.Now.Ticks.ToString();
                //    SiteSession.FilterKeyHolderResponce.Add(new FilterKeyHolder() { Key = Keyqr, Value = x.SignedQRCode });

                //    x.DocShow = "<a style='color: black;' href='#' onclick= \"showLeterQrCode('showQRCode.aspx?id=" + Keyqr + "')\">" + x.DocumentNo + "</a>" + "</td>";

                //}
                if (x.SignedQRCode.Length > 0)
                {
                    string Keyqr = Guid.NewGuid().ToString() + DateTime.Now.Ticks.ToString();
                    SiteSession.FilterKeyHolderResponce.Add(new FilterKeyHolder() { Key = Keyqr, Value = x.SignedQRCode });

                    x.DocShow = "<a style='color: black;' href='#' onclick= \"showLeterQrCode('showQRCode.aspx?id=" + Keyqr + "')\">" + x.DocumentNo + "</a>" + "</td>";

                }
                else
                {
                    x.DocShow = x.DocumentNo;
                }

            });


            Common.BindControl(gvlocation, obj);

        }

        protected void gvlocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var SS = (e.Row.FindControl("Status") as Label).Text;

                if (SS == "Erroneous Case")
                {
                    e.Row.BackColor = Color.Silver;
                }
                else
                      if (SS == "IRN Generated")
                {
                    e.Row.BackColor = Color.FromName("#c1ffc0");
                }
                else
                      if (SS == "IRN Pending")
                {
                    e.Row.BackColor = Color.FromName("#ff7d00");
                }
                else
                      if (SS == "Cancelled")
                {
                    e.Row.BackColor = Color.FromName("#fd0100");
                }
            }
        }

        protected void GetData_Click(object sender, EventArgs e)
        {
            filterdata();
        }


        protected void GenrateIron_Click(object sender, EventArgs e)
        {

            try
            {
                string str = "";
                for (int x = 0; x < gvlocation.Rows.Count; x++)
                {
                    if ((gvlocation.Rows[x].FindControl("selectall") as CheckBox).Checked)
                    {
                        var mob = (gvlocation.Rows[x].FindControl("EInvoiceDataExcelId") as HiddenField).Value.ConvertInt().ToString();

                        str = str.Length > 0 ? str + "," + mob : mob;
                    }
                }
                var obj = Business.Global.Context.JsonList(str).ToList();
                var IsDealer = obj.Where(p => p.Dealer_cd.Length > 0).Count();
                DataTable SSV = new DataTable();
                if (IsDealer > 0)
                {
                    SSV.Columns.Add("Dealer_cd");

                    SSV.Columns.Add("For_cd");

                }
                SSV.Columns.Add("InvoiceNo");

                SSV.Columns.Add("IRN");

                SSV.Columns.Add("SignedQRCode");

                string Key = "";
                var GroupbyKeyId = obj.Where(p => p.Irn.Length == 0).GroupBy(p => p.GodownCode).ToList();
                #region IfNothave aIrnNo
                foreach (var p in GroupbyKeyId)

                {

                    if (string.IsNullOrWhiteSpace(p.FirstOrDefault().ASP_TockenId))
                    {
                        var status = SMZP.GenaretToken(p.FirstOrDefault().ASP_Userid, p.FirstOrDefault().ASP_Pwd, p.FirstOrDefault().API_Usrname, p.FirstOrDefault().API_Pwd, p.FirstOrDefault().GST_No);
                        if (status.Data != null)
                        {
                            Key = status.Data.AuthToken;
                            Global.Context.ExecuteQuery("update Godown_Mst set ASP_TockenId='" + status.Data.AuthToken + "' where Comp_code=" + SiteSession.Comp_MstSession.Comp_Code + "  and   Godw_Code=" + p.FirstOrDefault().GodownCode + " and EXPORT_TYPE<3");
                        }

                        else
                                if (Common.Convertstring(status.status_cd) == "0" || Common.Convertstring(status.Status) == "0")
                        {


                            DataRow drs = SSV.NewRow();
                            drs["InvoiceNo"] = "Erroneous Case";

                            drs["IRN"] = Common.Convertstring(status.status_cd) == "0" ? status.error.error_cd : JsonConvert.SerializeObject(status.ErrorDetails.GroupBy(px => px.ErrorCode).Select(px => new { px.Key }).ToList());

                            drs["SignedQRCode"] = Common.Convertstring(status.status_cd) == "0" ? status.error.message : JsonConvert.SerializeObject(status.ErrorDetails.Select(px => new { px.ErrorMessage }).ToList());
                            SSV.Rows.Add(drs);

                        }

                    }
                    else
                    {
                        Key = p.FirstOrDefault().ASP_TockenId;
                    }

                    var DataItem = obj.Where(c => c.GodownCode.Value == p.Key.Value && c.Irn.Length == 0).ToList();
                    foreach (var x in DataItem)
                    {
                        var statusIron = SMZP.GenaretIron(x.Json, x.ASP_Userid, x.ASP_Pwd, x.API_Usrname, x.API_Pwd, x.GST_No, Key);
                        if (statusIron.InfoDtls == null)
                        {
                            if (Common.Convertstring(statusIron.status_cd) == "0" && Common.Convertstring(statusIron.error.error_cd) == "GSP752")
                            {
                                var status = SMZP.GenaretToken(x.ASP_Userid, x.ASP_Pwd, x.API_Usrname, x.API_Pwd, x.GST_No);
                                if (status.Data != null)
                                {
                                    Key = status.Data.AuthToken;
                                    Global.Context.ExecuteQuery("update Godown_Mst set ASP_TockenId='" + status.Data.AuthToken + "' where  Comp_code=" + SiteSession.Comp_MstSession.Comp_Code + "  and   Godw_Code=" + p.FirstOrDefault().GodownCode + " and EXPORT_TYPE<3");
                                    var statusIronss = SMZP.GenaretIron(x.Json, x.ASP_Userid, x.ASP_Pwd, x.API_Usrname, x.API_Pwd, x.GST_No, Key);
                                    if (statusIronss.InfoDtls == null)
                                    {
                                        if (Common.Convertstring(statusIronss.status_cd) == "0" || Common.Convertstring(statusIronss.Status) == "0")
                                        {
                                            Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Erroneous Case', [Responce]='" + statusIronss.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                        }
                                        else
                                        {
                                            Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Erroneous Case', [Responce]='" + statusIronss.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                        }


                                        DataRow drs = SSV.NewRow();
                                        drs["InvoiceNo"] = "Erroneous Case";
                                        if (IsDealer > 0)
                                        {
                                            drs["Dealer_cd"] = x.Dealer_cd;
                                            drs["For_cd"] = x.For_cd;
                                        }

                                        drs["IRN"] = Common.Convertstring(statusIronss.status_cd) == "0" ? statusIronss.error.error_cd : JsonConvert.SerializeObject(statusIronss.ErrorDetails.GroupBy(px => px.ErrorCode).Select(px => new { px.Key }).ToList());

                                        drs["SignedQRCode"] = Common.Convertstring(statusIronss.status_cd) == "0" ? statusIronss.error.message : JsonConvert.SerializeObject(statusIronss.ErrorDetails.Select(px => new { px.ErrorMessage }).ToList());
                                        SSV.Rows.Add(drs);
                                    }
                                    else
                                    {
                                        if ((Common.Convertstring(statusIronss.status_cd) == "0" && Common.Convertstring(statusIronss.error.error_cd) == "2150") || Common.Convertstring(statusIronss.Status) == "0" && statusIronss.ErrorDetails.Where(px => px.ErrorCode == "2150").Count() > 0)
                                        {




                                            var statusIronssx = SMZP.GetDataAgain(statusIronss.InfoDtls.FirstOrDefault().Desc.Irn, x.ASP_Userid, x.ASP_Pwd, x.API_Usrname, x.API_Pwd, x.GST_No, Key);
                                            if (statusIronssx.InfoDtls == null)
                                            {
                                                if (Common.Convertstring(statusIronssx.status_cd) == "0" || Common.Convertstring(statusIronssx.Status) == "0")
                                                {
                                                    Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Erroneous Case', [Responce]='" + statusIronssx.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                                }
                                                else
                                                {
                                                    Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Erroneous Case', [Responce]='" + statusIronssx.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                                }


                                                DataRow drs = SSV.NewRow();
                                                drs["InvoiceNo"] = "Erroneous Case";
                                                if (IsDealer > 0)
                                                {
                                                    drs["Dealer_cd"] = x.Dealer_cd;
                                                    drs["For_cd"] = x.For_cd;
                                                }

                                                drs["IRN"] = Common.Convertstring(statusIronssx.status_cd) == "0" ? statusIronssx.error.error_cd : JsonConvert.SerializeObject(statusIronssx.ErrorDetails.GroupBy(px => px.ErrorCode).Select(px => new { px.Key }).ToList());

                                                drs["SignedQRCode"] = Common.Convertstring(statusIronssx.status_cd) == "0" ? statusIronssx.error.message : JsonConvert.SerializeObject(statusIronssx.ErrorDetails.Select(px => new { px.ErrorMessage }).ToList());
                                                SSV.Rows.Add(drs);
                                            }
                                            else
                                            {





                                                Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='IRN Generated',AckNo='" + statusIronssx.InfoDtls.FirstOrDefault().Desc.AckNo + "',AckDt='" + statusIronssx.InfoDtls.FirstOrDefault().Desc.AckDt + "',Irn='" + statusIronssx.InfoDtls.FirstOrDefault().Desc.Irn + "',SignedInvoice='" + statusIronssx.InfoDtls.FirstOrDefault().Desc.SignedInvoice + "',SignedQRCode='" + statusIronssx.InfoDtls.FirstOrDefault().Desc.SignedQRCode + "', [Responce]='" + statusIronssx.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                                DataRow drs = SSV.NewRow();
                                                drs["InvoiceNo"] = x.DocumentNo;

                                                drs["IRN"] = statusIronssx.InfoDtls.FirstOrDefault().Desc.Irn;
                                                if (IsDealer > 0)
                                                {
                                                    drs["Dealer_cd"] = x.Dealer_cd;
                                                    drs["For_cd"] = x.For_cd;
                                                }

                                                drs["SignedQRCode"] = statusIronssx.InfoDtls.FirstOrDefault().Desc.SignedQRCode;
                                                SSV.Rows.Add(drs);
                                            }


                                        }


                                        else {

                                            Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='IRN Generated',AckNo='" + statusIronss.InfoDtls.FirstOrDefault().Desc.AckNo + "',AckDt='" + statusIronss.InfoDtls.FirstOrDefault().Desc.AckDt + "',Irn='" + statusIronss.InfoDtls.FirstOrDefault().Desc.Irn + "',SignedInvoice='" + statusIronss.InfoDtls.FirstOrDefault().Desc.SignedInvoice + "',SignedQRCode='" + statusIronss.InfoDtls.FirstOrDefault().Desc.SignedQRCode + "', [Responce]='" + statusIronss.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                            DataRow drs = SSV.NewRow();
                                            drs["InvoiceNo"] = x.DocumentNo;

                                            drs["IRN"] = statusIronss.InfoDtls.FirstOrDefault().Desc.Irn;
                                            if (IsDealer > 0)
                                            {
                                                drs["Dealer_cd"] = x.Dealer_cd;
                                                drs["For_cd"] = x.For_cd;
                                            }

                                            drs["SignedQRCode"] = statusIronss.InfoDtls.FirstOrDefault().Desc.SignedQRCode;
                                            SSV.Rows.Add(drs);
                                        }
                                    }
                                }
                                else {
                                    if (Common.Convertstring(status.status_cd) == "0" || Common.Convertstring(status.Status) == "0")
                                    {

                                        Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Erroneous Case', [Responce]='" + status.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                        DataRow drs = SSV.NewRow();
                                        drs["InvoiceNo"] = "Erroneous Case";
                                        if (IsDealer > 0)
                                        {
                                            drs["Dealer_cd"] = x.Dealer_cd;
                                            drs["For_cd"] = x.For_cd;
                                        }

                                        drs["IRN"] = Common.Convertstring(status.status_cd) == "0" ? status.error.error_cd : JsonConvert.SerializeObject(status.ErrorDetails.GroupBy(px => px.ErrorCode).Select(px => new { px.Key }).ToList());

                                        drs["SignedQRCode"] = Common.Convertstring(status.status_cd) == "0" ? status.error.message : JsonConvert.SerializeObject(status.ErrorDetails.Select(px => new { px.ErrorMessage }).ToList());
                                        SSV.Rows.Add(drs);

                                    }

                                    break;
                                }

                            }
                            else if (Common.Convertstring(statusIron.status_cd) == "0" || Common.Convertstring(statusIron.Status) == "0")
                            {
                                Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Erroneous Case', [Responce]='" + statusIron.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");


                                DataRow drs = SSV.NewRow();
                                drs["InvoiceNo"] = "Erroneous Case";

                                drs["IRN"] = Common.Convertstring(statusIron.status_cd) == "0" ? statusIron.error.error_cd : JsonConvert.SerializeObject(statusIron.ErrorDetails.GroupBy(px => px.ErrorCode).Select(px => new { px.Key }).ToList());
                                if (IsDealer > 0)
                                {
                                    drs["Dealer_cd"] = x.Dealer_cd;
                                    drs["For_cd"] = x.For_cd;
                                }

                                drs["SignedQRCode"] = Common.Convertstring(statusIron.status_cd) == "0" ? statusIron.error.message : JsonConvert.SerializeObject(statusIron.ErrorDetails.Select(px => new { px.ErrorMessage }).ToList());
                                SSV.Rows.Add(drs);

                            }
                            else
                            {
                                Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='IRN Generated',AckNo=" + statusIron.InfoDtls.FirstOrDefault().Desc.AckNo + ",AckDt='" + statusIron.InfoDtls.FirstOrDefault().Desc.AckDt + "',Irn='" + statusIron.InfoDtls.FirstOrDefault().Desc.Irn + "', [Responce]='" + statusIron.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");


                            }

                        }
                        else
                        {

                            if ((Common.Convertstring(statusIron.status_cd) == "0" && Common.Convertstring(statusIron.error.error_cd) == "2150") || Common.Convertstring(statusIron.Status) == "0" && statusIron.ErrorDetails.Where(px => px.ErrorCode == "2150").Count() > 0)
                            {




                                var statusIronssx = SMZP.GetDataAgain(statusIron.InfoDtls.FirstOrDefault().Desc.Irn, x.ASP_Userid, x.ASP_Pwd, x.API_Usrname, x.API_Pwd, x.GST_No, Key);
                                if (statusIronssx.InfoDtls == null)
                                {
                                    if (Common.Convertstring(statusIronssx.status_cd) == "0" || Common.Convertstring(statusIronssx.Status) == "0")
                                    {
                                        Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Erroneous Case', [Responce]='" + statusIronssx.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                    }
                                    else
                                    {
                                        Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Erroneous Case', [Responce]='" + statusIronssx.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                    }


                                    DataRow drs = SSV.NewRow();
                                    drs["InvoiceNo"] = "Erroneous Case";
                                    if (IsDealer > 0)
                                    {
                                        drs["Dealer_cd"] = x.Dealer_cd;
                                        drs["For_cd"] = x.For_cd;
                                    }

                                    drs["IRN"] = Common.Convertstring(statusIronssx.status_cd) == "0" ? statusIronssx.error.error_cd : JsonConvert.SerializeObject(statusIronssx.ErrorDetails.GroupBy(px => px.ErrorCode).Select(px => new { px.Key }).ToList());

                                    drs["SignedQRCode"] = Common.Convertstring(statusIronssx.status_cd) == "0" ? statusIronssx.error.message : JsonConvert.SerializeObject(statusIronssx.ErrorDetails.Select(px => new { px.ErrorMessage }).ToList());
                                    SSV.Rows.Add(drs);
                                }
                                else
                                {





                                    Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='IRN Generated',AckNo='" + statusIronssx.InfoDtls.FirstOrDefault().Desc.AckNo + "',AckDt='" + statusIronssx.InfoDtls.FirstOrDefault().Desc.AckDt + "',Irn='" + statusIronssx.InfoDtls.FirstOrDefault().Desc.Irn + "',SignedInvoice='" + statusIronssx.InfoDtls.FirstOrDefault().Desc.SignedInvoice + "',SignedQRCode='" + statusIronssx.InfoDtls.FirstOrDefault().Desc.SignedQRCode + "', [Responce]='" + statusIronssx.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                    DataRow drs = SSV.NewRow();
                                    drs["InvoiceNo"] = x.DocumentNo;

                                    drs["IRN"] = statusIronssx.InfoDtls.FirstOrDefault().Desc.Irn;
                                    if (IsDealer > 0)
                                    {
                                        drs["Dealer_cd"] = x.Dealer_cd;
                                        drs["For_cd"] = x.For_cd;
                                    }

                                    drs["SignedQRCode"] = statusIronssx.InfoDtls.FirstOrDefault().Desc.SignedQRCode;
                                    SSV.Rows.Add(drs);
                                }


                            }
                            else
                            {
                                Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='IRN Generated',AckNo='" + statusIron.InfoDtls.FirstOrDefault().Desc.AckNo + "',AckDt='" + statusIron.InfoDtls.FirstOrDefault().Desc.AckDt + "',Irn='" + statusIron.InfoDtls.FirstOrDefault().Desc.Irn + "',SignedInvoice='" + statusIron.InfoDtls.FirstOrDefault().Desc.SignedInvoice + "',SignedQRCode='" + statusIron.InfoDtls.FirstOrDefault().Desc.SignedQRCode + "', [Responce]='" + statusIron.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                DataRow drs = SSV.NewRow();
                                drs["InvoiceNo"] = x.DocumentNo;

                                drs["IRN"] = statusIron.InfoDtls.FirstOrDefault().Desc.Irn;

                                drs["SignedQRCode"] = statusIron.InfoDtls.FirstOrDefault().Desc.SignedQRCode;
                                if (IsDealer > 0)
                                {
                                    drs["Dealer_cd"] = x.Dealer_cd;
                                    drs["For_cd"] = x.For_cd;
                                }

                                SSV.Rows.Add(drs);
                            }

                        }

                    }

                }

                #endregion




                var DataItems = obj.Where(c => c.Irn.Length > 0).ToList();
                DataItems.ForEach(cv =>
                {
                    DataRow drs = SSV.NewRow();

                    var objsss = Global.Context.EInvoiceDataExcels.SingleOrDefault(p => p.EInvoiceDataExcelId == cv.EInvoiceDataExcelId);
                    objsss.ErrorStatus = "IRN Generated";
                    objsss.Save();



                    drs["InvoiceNo"] = cv.DocumentNo;
                    if (IsDealer > 0)
                    {
                        drs["Dealer_cd"] = cv.Dealer_cd;
                        drs["For_cd"] = cv.For_cd;
                    }

                    drs["IRN"] = cv.Irn;

                    drs["SignedQRCode"] = cv.SignedQRCode;
                    SSV.Rows.Add(drs);
                });

                var dataTable = SSV;
                StringBuilder builder = new StringBuilder();
                List<string> columnNames = new List<string>();
                List<string> rows = new List<string>();



                foreach (DataRow row in dataTable.Rows)
                {
                    List<string> currentRow = new List<string>();

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        object item = row[column];

                        currentRow.Add(item.ToString().Replace("Key", "Error Code"));
                    }

                    rows.Add(string.Join(",", currentRow.ToArray()));
                }



                builder.Append(string.Join("\n", rows.ToArray()));
                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "text/csv";
                Response.AddHeader("Content-Disposition", "attachment;filename=IRNList.csv");
                Response.Write(builder.ToString());
                Response.End();

                MessageBox.ShowMessage("Sucess", "IRN Generate Successfully", SiteKey.MessageType.success);

            }
            catch (Exception ex)
            {

                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message == "Thread was being aborted.")
                {

                    MessageBox.ShowMessage("Sucess", "IRN Generate Successfully", SiteKey.MessageType.success);

                }
                else
                {


                    if (Message.Contains("UNIQUE KEY")) { Message = "Record/Username already exists. Please choose another."; }
                    MessageBox.ShowMessage("Error", Message, SiteKey.MessageType.danger);
                }
            }

            filterdata();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                UpdatePanels.Text = "  <div style='z-index: 10001;' class='windowbackground'><div class='progressbar breadcrumb'>                    <img alt='Loading...' src='../images/ajax-loader.gif'><br>                    Please Wait...                </div>            </div>";

                DataTable SSV = new DataTable();
                SSV.Columns.Add("InvoiceNo");
                SSV.Columns.Add("Date");
                SSV.Columns.Add("IRN");
                SSV.Columns.Add("SignedInvoice");
                SSV.Columns.Add("SignedQRCode");

                string str = "";
                for (int x = 0; x < gvlocation.Rows.Count; x++)
                {
                    if ((gvlocation.Rows[x].FindControl("selectall") as CheckBox).Checked)
                    {
                        var mob = (gvlocation.Rows[x].FindControl("EInvoiceDataExcelId") as HiddenField).Value.ConvertInt().ToString();

                        str = str.Length > 0 ? str + "," + mob : mob;


                    }
                }


                var obj = Business.Global.Context.CancelJsonList(str).ToList();
                string Key = "";
                var GroupbyKeyId = obj.GroupBy(p => p.GodownCode).ToList();

                foreach (var p in GroupbyKeyId)

                {

                    if (string.IsNullOrWhiteSpace(p.FirstOrDefault().ASP_TockenId))
                    {
                        var status = SMZP.GenaretToken(p.FirstOrDefault().ASP_Userid, p.FirstOrDefault().ASP_Pwd, p.FirstOrDefault().API_Usrname, p.FirstOrDefault().API_Pwd, p.FirstOrDefault().GST_No);
                        if (status.Data != null)
                        {
                            Key = status.Data.AuthToken;
                            Global.Context.ExecuteQuery("update Godown_Mst set ASP_TockenId='" + status.Data.AuthToken + "' where Comp_code=" + SiteSession.Comp_MstSession.Comp_Code + "  and   Godw_Code=" + p.FirstOrDefault().GodownCode + " and EXPORT_TYPE<3");
                        }

                        else
                                if (Common.Convertstring(status.status_cd) == "0" || Common.Convertstring(status.Status) == "0")
                        {


                            DataRow drs = SSV.NewRow();
                            drs["InvoiceNo"] = "Erroneous Case";

                            drs["IRN"] = Common.Convertstring(status.status_cd) == "0" ? status.error.error_cd : JsonConvert.SerializeObject(status.ErrorDetails.GroupBy(px => px.ErrorCode).Select(px => new { px.Key }).ToList());

                            drs["SignedQRCode"] = Common.Convertstring(status.status_cd) == "0" ? status.error.message : JsonConvert.SerializeObject(status.ErrorDetails.Select(px => new { px.ErrorMessage }).ToList());
                            SSV.Rows.Add(drs);

                        }

                    }
                    else
                    {
                        Key = p.FirstOrDefault().ASP_TockenId;
                    }
                    var DataItem = obj.Where(c => c.GodownCode.Value == p.Key.Value).ToList();
                    foreach (var x in DataItem)
                    {
                        var statusIron = SMZP.CancelIrn(x.Json, x.ASP_Userid, x.ASP_Pwd, x.API_Usrname, x.API_Pwd, x.GST_No, Key);
                        if (statusIron.InfoDtls == null)
                        {
                            if (Common.Convertstring(statusIron.status_cd) == "0" && Common.Convertstring(statusIron.error.error_cd) == "GSP752")
                            {
                                var status = SMZP.GenaretToken(x.ASP_Userid, x.ASP_Pwd, x.API_Usrname, x.API_Pwd, x.GST_No);
                                if (status.Data != null)
                                {
                                    Key = status.Data.AuthToken;
                                    Global.Context.ExecuteQuery("update Godown_Mst set ASP_TockenId='" + status.Data.AuthToken + "' where Comp_code=" + SiteSession.Comp_MstSession.Comp_Code + "  and   Godw_Code=" + p.FirstOrDefault().GodownCode + " and EXPORT_TYPE<3");
                                    var statusIronss = SMZP.CancelIrn(x.Json, x.ASP_Userid, x.ASP_Pwd, x.API_Usrname, x.API_Pwd, x.GST_No, Key);
                                    if (statusIronss.InfoDtls == null)
                                    {
                                        if (Common.Convertstring(statusIronss.status_cd) == "0" || Common.Convertstring(statusIronss.Status) == "0")
                                        {
                                            Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Erroneous Case', [Responce]='" + statusIronss.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                            DataRow drs = SSV.NewRow();
                                            drs["InvoiceNo"] = "Erroneous Case";

                                            drs["IRN"] = Common.Convertstring(statusIronss.status_cd) == "0" ? statusIronss.error.error_cd : JsonConvert.SerializeObject(statusIronss.ErrorDetails.GroupBy(px => px.ErrorCode).Select(px => new { px.Key }).ToList());

                                            drs["SignedQRCode"] = Common.Convertstring(statusIronss.status_cd) == "0" ? statusIronss.error.message : JsonConvert.SerializeObject(statusIronss.ErrorDetails.Select(px => new { px.ErrorMessage }).ToList());
                                            SSV.Rows.Add(drs);
                                        }
                                        else
                                        {
                                            Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Erroneous Case', [Responce]='" + statusIronss.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                        }
                                    }
                                    else
                                    {


                                        Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Cancelled',CancelDate=" + statusIronss.InfoDtls.FirstOrDefault().Desc.CancelDate + ", [Responce]='" + statusIronss.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");



                                    }
                                }
                                else {
                                    if (Common.Convertstring(status.status_cd) == "0" || Common.Convertstring(status.Status) == "0")
                                    {

                                        Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Erroneous Case', [Responce]='" + status.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                        DataRow drs = SSV.NewRow();
                                        drs["InvoiceNo"] = "Erroneous Case";

                                        drs["IRN"] = Common.Convertstring(status.status_cd) == "0" ? status.error.error_cd : JsonConvert.SerializeObject(status.ErrorDetails.GroupBy(px => px.ErrorCode).Select(px => new { px.Key }).ToList());

                                        drs["SignedQRCode"] = Common.Convertstring(status.status_cd) == "0" ? status.error.message : JsonConvert.SerializeObject(status.ErrorDetails.Select(px => new { px.ErrorMessage }).ToList());
                                        SSV.Rows.Add(drs);

                                    }

                                    break;
                                }

                            }
                            else if (Common.Convertstring(statusIron.status_cd) == "0" || Common.Convertstring(statusIron.Status) == "0")
                            {
                                Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Erroneous Case', [Responce]='" + statusIron.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                DataRow drs = SSV.NewRow();
                                drs["InvoiceNo"] = x.DocumentNo;

                                drs["IRN"] = Common.Convertstring(statusIron.status_cd) == "0" ? statusIron.error.error_cd : JsonConvert.SerializeObject(statusIron.ErrorDetails.GroupBy(px => px.ErrorCode).Select(px => new { px.Key }).ToList());

                                drs["SignedQRCode"] = Common.Convertstring(statusIron.status_cd) == "0" ? statusIron.error.message : JsonConvert.SerializeObject(statusIron.ErrorDetails.Select(px => new { px.ErrorMessage }).ToList());
                                SSV.Rows.Add(drs);
                            }
                            else
                            {
                                Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Cancelled',CancelDate=" + statusIron.InfoDtls.FirstOrDefault().Desc.CancelDate + ", [Responce]='" + statusIron.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");

                            }

                        }
                        else
                        {
                            Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Cancelled',CancelDate='" + statusIron.InfoDtls.FirstOrDefault().Desc.CancelDate + "', [Responce]='" + statusIron.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                            DataRow drs = SSV.NewRow();
                            drs["InvoiceNo"] = x.DocumentNo;

                            drs["IRN"] = "Cancelled";

                            drs["SignedQRCode"] = statusIron.InfoDtls.FirstOrDefault().Desc.CancelDate;
                            SSV.Rows.Add(drs);
                        }

                    }

                }

                filterdata();

                MessageBox.ShowMessage("Sucess", "Cancel IRN Successfully", SiteKey.MessageType.success);

                var dataTable = SSV;
                StringBuilder builder = new StringBuilder();
                List<string> columnNames = new List<string>();
                List<string> rows = new List<string>();

                //foreach (DataColumn column in dataTable.Columns)
                //{
                //    columnNames.Add(column.ColumnName);
                //}
                //builder.Append(string.Join(",", columnNames.ToArray())).Append("\n");

                foreach (DataRow row in dataTable.Rows)
                {
                    List<string> currentRow = new List<string>();

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        object item = row[column];

                        currentRow.Add(item.ToString());
                    }

                    rows.Add(string.Join(",", currentRow.ToArray()));
                }

                filterdata();

                MessageBox.ShowMessage("Successfully", "Cancelled Successfully", SiteKey.MessageType.success);

                builder.Append(string.Join("\n", rows.ToArray()));
                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";

                Response.Cache.SetCacheability(HttpCacheability.NoCache);


                Response.ContentType = "text/csv";
                Response.AddHeader("Content-Disposition", "attachment;filename=CancelledList.csv");
                Response.Write(builder.ToString());
                Response.End();
                UpdatePanels.Text = "";

            }
            catch (Exception ex)
            {

                UpdatePanels.Text = "";
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record/Username already exists. Please choose another."; }
                MessageBox.ShowMessage("Error", Message, SiteKey.MessageType.danger);

            }
        }

        protected void Excel_Click(object sender, EventArgs e)
        {
            string str = "  where Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code.Value.ToString() + " ";
           
            SiteSession.FilterKeyHolderResponce = new List<FilterKeyHolder>();
            if (GodownId.SelectedValue != "All")
            {
                str = GodownId.SelectedValue + "";
            }
            else
            {
                str = string.Join(",", SiteSession.GetGodawanListSession.Select(x => x.Id.ToString()).ToArray());
            }
         DataTable dt=   JsonToExportDataExcel.DataCreate(str, FromDate.Text.DateConvertTextMatchCaseStringSQL(), ToDate.Text.DateConvertTextMatchCaseStringSQL());

            string attachment = "attachment; filename=EnvoiceData"+Common.DateTimeNow().ToString("ddMMyyyyhhmmss")+".xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.ms-excel";
            string tab = "";
            foreach (DataColumn dc in dt.Columns)
            {
                Response.Write(tab + dc.ColumnName);
                tab = "\t";
            }
            Response.Write("\n");
            int i;
            foreach (DataRow dr in dt.Rows)
            {
                tab = "";
                for (i = 0; i < dt.Columns.Count; i++)
                {
                    Response.Write(tab + dr[i].ToString());
                    tab = "\t";
                }
                Response.Write("\n");
            }
            Response.End();


        }
    }
}


public partial class EInvoiceData
{
    public int EInvoiceDataExcelId { get; set; }
    public DateTime DocumentDate { get; set; }
    public string VoucherType { get; set; }
    public string DocumentNo { get; set; }
    public string BuyerLegalName { get; set; }
    public string BuyerGSTN { get; set; }
    public string Status { get; set; }
    public string Responce { get; set; }
    public string SignedQRCode { get; set; }

    public string Key { get; set; }
    public string DocShow { get; set; }
}