using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using WebApp.TallyData;
namespace WebApp.admin
{
    public partial class frmtrialbalance : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SiteSession.GetGodawanListSession.ForEach(x => {

                    BranchId.Items.Add(new ListItem() { Text = x.Value, Value = x.Value });

                });
            }
        }

        protected void btnsearchdata_Click(object sender, EventArgs e)
        {
            var fdate = FromDate.Text.DateConvertTextMatchCase();
            var tdate = ToDate.Text.DateConvertTextMatchCase();
            string strth = "";
            string str = "";
            var TopRow = "";
            var skipnumber = 0;
            var intominusonedata = 0;
            var FooterRow = "<th>Net Diffrence</th>";

            foreach (ListItem listItem in BranchId.Items)
            {
                if (listItem.Selected)
                {
                    var objdata = trialbalance.readPTallytrialbalance(listItem.Text, fdate.ToString("yyyyMMddd"), tdate.ToString("yyyyMMddd"));
                    if (TopRow.Length == 0)
                    {

                        if (objdata.ENVELOPEtrialbalance != null)
                        {
                            TopRow = "<th>Particular</th>";
                            str += "<td>";
                            objdata.ENVELOPEtrialbalance.DSPACCNAME.ForEach(x => {
                                if (x.DSPDISPNAME.Contains("Closing Stock"))
                                {
                                    str += "" + x.DSPDISPNAME + "<br/>";
                                    intominusonedata = x.number;
                                }
                                else
                                if (!x.DSPDISPNAME.Contains("Cost of Sales"))
                                {
                                    str += "" + x.DSPDISPNAME + "<br/>";
                                }

                                else
                                {
                                    skipnumber = x.number;
                                }
                            });
                            str += "</td>";

                        }
                    }



                    if (objdata.ENVELOPEtrialbalance != null)
                    {
                        decimal posi = 0m;
                        decimal neg = 0m;
                        TopRow += "<th style='text-align:right'>" + listItem.Text + "<br/>" + fdate.ToString("dd-MMM-yyyy") + " to " + tdate.ToString("dd-MMM-yyyy") + "</th>";
                        str += "<td style='text-align:right'>";
                        objdata.ENVELOPEtrialbalance.DSPACCINFO.ForEach(x => {
                            var TAmount = x.DSPCLCRAMT.DSPCLCRAMTA.ConvertDecimal() + x.DSPCLDRAMT.DSPCLDRAMTA.ConvertDecimal();
                            if (x.number == intominusonedata)
                            {
                               
                                str += "" + (TAmount != 0 ?(TAmount * -1m).ToString() : "-") + "<br/>";
                                posi += (TAmount != 0 ? (TAmount * -1m) : 0m);


                            }

                            else
                                if (x.number != skipnumber)
                            {
                                str += "" + (TAmount != 0 ? TAmount.ToString() : "-") + "<br/>";
                                posi += (TAmount != 0 ? TAmount : 0m);
                            }


                        });

                        str += "</td>";
                        FooterRow += "<th style='text-align:right'>" + posi.ToString() + "</th>";
                    }

                }
            }

            MulticompData.Text = "<tr>" + TopRow + "</tr><tr>" + str + "</tr><tr>" + FooterRow + "</tr>";
        }
    }
}