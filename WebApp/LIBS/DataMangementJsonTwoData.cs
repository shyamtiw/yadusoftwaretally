using DMStallyScheduler.TallyReadClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApp.admin.ReportModal;

namespace WebApp.LIBS
{
    public class DataMangementJsonTwoData
    {
        public static List<voucherRecoData> GetDGetData(DateTime FromDate, DateTime ToDate, int GodwnId)
        {

            DataTable dtMainTable = OtherSqlConn.FillDataTable("select   * from (select MAX(GSTNUM) as partygstIn,MAX(NameofCustomer) as partyName,MAX(PlaceofSupply) as placeOfSupply,CONVERT(decimal(18,2), TotalTaxCate) as MXCATE,INVOICENUM as voucherNumber,max( CONVERT(date, INVOICEDATE)) as voucherDate,sum(CONVERT(Decimal(18,2) ,TAXABLEVALUE)) as TAXABLEVALUE,MAX(CONVERT(Decimal(18,2) ,IGSTRATE)) as IGSTRATE,sum(CONVERT(Decimal(18,2) ,IGSTAMT)) as IGSTAMT,MAX(CONVERT(Decimal(18,2) ,CGSTRATE)) as CGSTRATE,sum(CONVERT(Decimal(18,2) ,CGSTAMT)) as CGSTAMT,MAX(CONVERT(Decimal(18,2) ,SGSTRATE)) as SGSTRATE,sum(CONVERT(Decimal(18,2) ,SGSTAMT)) as SGSTAMT,MAX(CONVERT(Decimal(18,2) ,KeralaFloodCessRate)) as KeralaFloodCessRate,sum(CONVERT(Decimal(18,2) ,KeralaFloodCessAmount)) as KeralaFloodCessAmount,MAX(CONVERT(Decimal(18,2) ,TCSRate)) as TCSRate,sum(CONVERT(Decimal(18,2) ,TCSAmount)) as TCSAmount,sum(CONVERT(Decimal(18,2) ,GrossAmount)) as GrossAmount from  (select * from  tallydataValidate where CONVERT(date,INVOICEDATE) between '" + FromDate.ToString("dd-MMM-yyyy") + "' and '" + ToDate.ToString("dd-MMM-yyyy") + "' and CONVERT(Decimal(18,2) ,isnull(TAXABLEVALUE,'0'))>0) as x  group by INVOICENUM,CONVERT(Decimal(18,2), TotalTaxCate)) as x  order by voucherNumber asc", "Data Source=POPULAR;Initial Catalog=MagicDMSSync;persist security info=True;user id=sa;password=India@#5010;multipleactiveresultsets=True;Timeout=3000000");
            var GroupVoucherNo = dtMainTable.AsEnumerable().GroupBy(p => p["voucherNumber"].ToString()).Select(p => new { INVOICENUM = p.Key }).ToList();
            var JoinSTR = string.Join(",", GroupVoucherNo.Select(p => "'" + p.INVOICENUM + "'").ToArray());
            DataTable dt = OtherSqlConn.FillDataTable("select  * from Voucher where  GodwnId=" + GodwnId + " and upper(trim( VoucherNumber)) in (" + JoinSTR + ")", "Data Source=POPULAR;Initial Catalog=MagicDMSSync;persist security info=True;user id=sa;password=India@#5010;multipleactiveresultsets=True;Timeout=3000000");
            var VoucherData = dt.AsEnumerable().Select(p => new voucher()
            {
                parentType = p["parentType"].ToString(),
                ledgerEntries = (p["ledgerEntries"].ToString().Length > 10 ? JsonConvert.DeserializeObject<List<voucher.ledgerEntry>>(p["ledgerEntries"].ToString()) : new List<voucher.ledgerEntry>()),

                StockItemEntries = (p["StockItemEntries"].ToString().Length > 10 ? JsonConvert.DeserializeObject<List<voucher.StockItemEntry>>(p["StockItemEntries"].ToString()) : new List<voucher.StockItemEntry>())
             ,
                partygstIn = p["partygstIn"].ToString(),
                partyLedgerName = p["partyLedgerName"].ToString(),
                partyName = p["partyName"].ToString(),
                placeOfSupply = p["placeOfSupply"].ToString(),
                voucherDate = Convert.ToDateTime(p["voucherDate"]),
                voucherNumber = p["voucherNumber"].ToString(),


            }).ToList();
            var ItemList = new List<voucherRecoData>();



            foreach (var INV in GroupVoucherNo)
            {
                var x = VoucherData.Where(p => p.voucherNumber.Trim().ToUpper() == INV.INVOICENUM.Trim().ToUpper()).FirstOrDefault();

                DataTable FilterDt = dtMainTable.AsEnumerable().Where(p => p["voucherNumber"].ToString().Trim().ToUpper() == INV.INVOICENUM.Trim().ToUpper() &&Common.ConvertDecimal(p["TAXABLEVALUE"]) > 0).CopyToDataTable();

                var Item = new voucherRecoData();
                #region dms_reCO
                FilterDt.AsEnumerable().ToList().ForEach(xc =>
                {
                    //TAXABLEVALUE,IGSTRATE,IGSTAMT,CGSTRATE,CGSTAMT,SGSTRATE,SGSTAMT,KeralaFloodCessRate,KeralaFloodCessAmount,TCSRate,TCSAmount, GrossAmount


                    Item.DMS_GSTIN = xc["partygstIn"].ToString();

                    Item.DMS_PartyName = xc["partyName"].ToString();
                    Item.DMS_placeOfSupply = xc["placeOfSupply"].ToString();
                    Item.DMS_voucherDate = Convert.ToDateTime(xc["voucherDate"]).ToString("dd/MM/yyyy");
                    Item.DMS_voucherNumber = xc["voucherNumber"].ToString();
                    if (Common.ConvertDecimal(xc["MXCATE"]) == 5m)
                    {
                        Item.DMS_Taxable_5 +=Common.ConvertDecimal(xc["TAXABLEVALUE"]);
                        try { Item.DMS_CGST_25 +=Common.ConvertDecimal(xc["CGSTAMT"]); } catch { };
                        try { Item.DMS_SGST_25 +=Common.ConvertDecimal(xc["SGSTAMT"]); } catch { };
                        try { Item.DMS_IGST_5 +=Common.ConvertDecimal(xc["IGSTAMT"]); } catch { };

                    }
                    else if (Common.ConvertDecimal(xc["MXCATE"]) == 12m)
                    {
                        Item.DMS_Taxable_12 +=Common.ConvertDecimal(xc["TAXABLEVALUE"]);
                        try { Item.DMS_CGST_6 +=Common.ConvertDecimal(xc["CGSTAMT"]); } catch { };
                        try { Item.DMS_SGST_6 +=Common.ConvertDecimal(xc["SGSTAMT"]); } catch { };
                        try { Item.DMS_IGST_12 +=Common.ConvertDecimal(xc["IGSTAMT"]); } catch { };

                    }
                    else if (Common.ConvertDecimal(xc["MXCATE"]) == 18m)
                    {
                        Item.DMS_Taxable_18 +=Common.ConvertDecimal(xc["TAXABLEVALUE"]);
                        try { Item.DMS_CGST_9 +=Common.ConvertDecimal(xc["CGSTAMT"]); } catch { };
                        try { Item.DMS_SGST_9 +=Common.ConvertDecimal(xc["SGSTAMT"]); } catch { };
                        try { Item.DMS_IGST_18 +=Common.ConvertDecimal(xc["IGSTAMT"]); } catch { };

                    }

                    else if (Common.ConvertDecimal(xc["MXCATE"]) == 28m)
                    {
                        Item.DMS_Taxable_28 +=Common.ConvertDecimal(xc["TAXABLEVALUE"]);
                        try { Item.DMS_CGST_14 +=Common.ConvertDecimal(xc["CGSTAMT"]); } catch { };
                        try { Item.DMS_SGST_14 +=Common.ConvertDecimal(xc["SGSTAMT"]); } catch { };
                        try { Item.DMS_IGST_28 +=Common.ConvertDecimal(xc["IGSTAMT"]); } catch { };

                    }
                    if (Common.ConvertDecimal(xc["KeralaFloodCessRate"]) == 1m)
                    {

                        try { Item.DMS_CESS_1 +=Common.ConvertDecimal(xc["KeralaFloodCessAmount"]); } catch { };

                    }
                    else if (Common.ConvertDecimal(xc["KeralaFloodCessRate"]) == 17m)
                    {

                        try { Item.DMS_CESS_17 +=Common.ConvertDecimal(xc["KeralaFloodCessAmount"]); } catch { };

                    }

                    if (Common.ConvertDecimal(xc["TCSAmount"]) > 0)
                    {

                        try { Item.DMS_TCS +=Common.ConvertDecimal(xc["TCSAmount"]); } catch { };

                    }
                    Item.DMS_InvAmt +=Common.ConvertDecimal(xc["GrossAmount"]); ;
                });





                #endregion
                if (x != null)
                {
                    var GroupItem = x.StockItemEntries.AsEnumerable().ToList().GroupBy(p => p.ledgerGuid).Select(p => new { p.FirstOrDefault().ledgerName, amount = p.Sum(px => Common.ConvertDecimal(px.amount)) });
                    if (GroupItem.ToList().Count > 0)
                    {
                        #region Tally_Reco
                        GroupItem.ToList().ForEach(xc =>
                        {
                            //Taxable 5%	Taxable 12%	Taxable 18%	Taxable 28%	CGSt 2.5%	CGST 6%	CGST 9%	CGST 14%	SGST 2.5%	SGST 6%	SGST 9%	SGST 14%	
                            //IGST 5%	IGST 12%	IGST 18%	IGST 28%	CESS 1%	CESS 17%	TCS	Round off	Inv Amt


                            Item.GSTIN = x.partygstIn;

                            Item.PartyName = x.partyName;
                            Item.placeOfSupply = x.placeOfSupply;
                            Item.voucherDate = x.voucherDate.ToString("dd/MM/yyyy"); ;
                            Item.voucherNumber = x.voucherNumber;
                            if (Common.ReplaceChar(xc.ledgerName).ToUpper().Contains("5"))
                            {
                                Item.Taxable_5 += xc.amount;
                                if (Item.CGST_25 == 0m && Item.IGST_5 == 0m)
                                {
                                    try { Item.CGST_25 += x.ledgerEntries.Where(p => p.amount > 0 && p.ledgerName.Contains("2.5") && p.ledgerName.Contains("CGST")).FirstOrDefault().amount; } catch { };
                                    try { Item.SGST_25 += x.ledgerEntries.Where(p => p.amount > 0 && p.ledgerName.Contains("2.5") && p.ledgerName.Contains("SGST")).FirstOrDefault().amount; } catch { };
                                    try { Item.IGST_5 += x.ledgerEntries.Where(p => p.amount > 0 && p.ledgerName.Contains("5") && p.ledgerName.Contains("IGST")).FirstOrDefault().amount; } catch { };
                                }
                            }
                            else if (Common.ReplaceChar(xc.ledgerName).ToUpper().Contains("12"))
                            {
                                Item.Taxable_12 += xc.amount;
                                if (Item.CGST_6 == 0m && Item.IGST_12 == 0m)
                                {
                                    try { Item.CGST_6 += x.ledgerEntries.Where(p => p.amount > 0 && p.ledgerName.Contains("6") && p.ledgerName.Contains("CGST")).FirstOrDefault().amount; } catch { };
                                    try { Item.SGST_6 += x.ledgerEntries.Where(p => p.amount > 0 && p.ledgerName.Contains("6") && p.ledgerName.Contains("SGST")).FirstOrDefault().amount; } catch { };
                                    try { Item.IGST_12 += x.ledgerEntries.Where(p => p.amount > 0 && p.ledgerName.Contains("12") && p.ledgerName.Contains("IGST")).FirstOrDefault().amount; } catch { };
                                }
                            }
                            else if (Common.ReplaceChar(xc.ledgerName).ToUpper().Contains("18"))
                            {
                                Item.Taxable_18 += xc.amount;
                                if (Item.CGST_9 == 0m && Item.IGST_18 == 0m)
                                {
                                    try { Item.CGST_9 += x.ledgerEntries.Where(p => p.amount > 0 && p.ledgerName.Contains("9") && p.ledgerName.Contains("CGST")).FirstOrDefault().amount; } catch { };
                                    try { Item.SGST_9 += x.ledgerEntries.Where(p => p.amount > 0 && p.ledgerName.Contains("9") && p.ledgerName.Contains("SGST")).FirstOrDefault().amount; } catch { };
                                    try { Item.IGST_18 += x.ledgerEntries.Where(p => p.amount > 0 && p.ledgerName.Contains("18") && p.ledgerName.Contains("IGST")).FirstOrDefault().amount; } catch { };
                                }
                            }

                            else if (Common.ReplaceChar(xc.ledgerName).ToUpper().Contains("28"))
                            {
                                Item.Taxable_28 += xc.amount;
                                if (Item.CGST_14 == 0m && Item.IGST_28 == 0m)
                                {
                                    try { Item.CGST_14 += x.ledgerEntries.Where(p => p.amount > 0 && p.ledgerName.Contains("14") && p.ledgerName.Contains("CGST")).FirstOrDefault().amount; } catch { };
                                    try { Item.SGST_14 += x.ledgerEntries.Where(p => p.amount > 0 && p.ledgerName.Contains("14") && p.ledgerName.Contains("SGST")).FirstOrDefault().amount; } catch { };
                                    try { Item.IGST_28 += x.ledgerEntries.Where(p => p.amount > 0 && p.ledgerName.Contains("28") && p.ledgerName.Contains("IGST")).FirstOrDefault().amount; } catch { };
                                }
                            }



                        });


                        try { Item.Roundoff = x.ledgerEntries.Where(p => p.ledgerName.ToUpper().Contains("ROUND")).FirstOrDefault().amount; } catch { };
                        try { Item.CESS_17 = x.ledgerEntries.Where(p => p.amount > 0 && p.ledgerName.Contains("17") && p.ledgerName.Contains("CESS")).FirstOrDefault().amount; } catch { };
                        try { Item.CESS_1 = x.ledgerEntries.Where(p => p.amount > 0 && p.ledgerName.Contains("1") && !p.ledgerName.Contains("17") && p.ledgerName.Contains("CESS")).FirstOrDefault().amount; } catch { };
                        try { Item.TCS = x.ledgerEntries.Where(p => p.amount > 0 && p.ledgerName.Contains("TCS")).FirstOrDefault().amount; } catch { };

                        Item.InvAmt = (Item.Taxable_5 + Item.Taxable_12 + Item.Taxable_18 + Item.Taxable_28 + Item.CGST_25 + Item.CGST_6 + Item.CGST_9 + Item.CGST_14 + Item.SGST_25 + Item.SGST_6 + Item.SGST_9 + Item.SGST_14 + Item.IGST_5 + Item.IGST_12 + Item.IGST_18 + Item.IGST_28 + Item.CESS_1 + Item.CESS_17 + Item.TCS) + Item.Roundoff;
                        #endregion

                    }
                }
                #region Compaire
                if (Item.GSTIN == Item.DMS_GSTIN) { Item.Diff_GSTIN = "True"; } else { Item.Diff_GSTIN = "False"; }
                if (Item.placeOfSupply == Item.DMS_placeOfSupply) { Item.Diff_placeOfSupply = "True"; } else { Item.Diff_placeOfSupply = "False"; }
                if (Item.PartyName == Item.DMS_PartyName) { Item.Diff_PartyName = "True"; } else { Item.Diff_PartyName = "False"; }
                if (Item.voucherDate == Item.DMS_voucherDate) { Item.Diff_voucherDate = "True"; } else { Item.Diff_voucherDate = "False"; }
                if (Item.voucherNumber == Item.DMS_voucherNumber) { Item.Diff_voucherNumber = "True"; } else { Item.Diff_voucherNumber = "False"; }
                if (Item.Taxable_5 == Item.DMS_Taxable_5) { Item.Diff_Taxable_5 = "0"; } else { Item.Diff_Taxable_5 = (Item.Taxable_5 - Item.DMS_Taxable_5).ToString(); }
                if (Item.Taxable_12 == Item.DMS_Taxable_12) { Item.Diff_Taxable_12 = "0"; } else { Item.Diff_Taxable_12 = (Item.Taxable_12 - Item.DMS_Taxable_12).ToString(); }
                if (Item.Taxable_18 == Item.DMS_Taxable_18) { Item.Diff_Taxable_18 = "0"; } else { Item.Diff_Taxable_18 = (Item.Taxable_18 - Item.DMS_Taxable_18).ToString(); }
                if (Item.Taxable_28 == Item.DMS_Taxable_28) { Item.Diff_Taxable_28 = "0"; } else { Item.Diff_Taxable_28 = (Item.Taxable_28 - Item.DMS_Taxable_28).ToString(); }
                if (Item.CGST_25 == Item.DMS_CGST_25) { Item.Diff_CGST_25 = "0"; } else { Item.Diff_CGST_25 = (Item.CGST_25 - Item.DMS_CGST_25).ToString(); }
                if (Item.CGST_6 == Item.DMS_CGST_6) { Item.Diff_CGST_6 = "0"; } else { Item.Diff_CGST_6 = (Item.CGST_6 - Item.DMS_CGST_6).ToString(); }
                if (Item.CGST_9 == Item.DMS_CGST_9) { Item.Diff_CGST_9 = "0"; } else { Item.Diff_CGST_9 = (Item.CGST_9 - Item.DMS_CGST_9).ToString(); }
                if (Item.CGST_14 == Item.DMS_CGST_14) { Item.Diff_CGST_14 = "0"; } else { Item.Diff_CGST_14 = (Item.CGST_14 - Item.DMS_CGST_14).ToString(); }
                if (Item.SGST_25 == Item.DMS_SGST_25) { Item.Diff_SGST_25 = "0"; } else { Item.Diff_SGST_25 = (Item.SGST_25 - Item.DMS_SGST_25).ToString(); }
                if (Item.SGST_6 == Item.DMS_SGST_6) { Item.Diff_SGST_6 = "0"; } else { Item.Diff_SGST_6 = (Item.SGST_6 - Item.DMS_SGST_6).ToString(); }
                if (Item.SGST_9 == Item.DMS_SGST_9) { Item.Diff_SGST_9 = "0"; } else { Item.Diff_SGST_9 = (Item.SGST_9 - Item.DMS_SGST_9).ToString(); }
                if (Item.SGST_14 == Item.DMS_SGST_14) { Item.Diff_SGST_14 = "0"; } else { Item.Diff_SGST_14 = (Item.SGST_14 - Item.DMS_SGST_14).ToString(); }
                if (Item.IGST_5 == Item.DMS_IGST_5) { Item.Diff_IGST_5 = "0"; } else { Item.Diff_IGST_5 = (Item.IGST_5 - Item.DMS_IGST_5).ToString(); }
                if (Item.IGST_12 == Item.DMS_IGST_12) { Item.Diff_IGST_12 = "0"; } else { Item.Diff_IGST_12 = (Item.IGST_12 - Item.DMS_IGST_12).ToString(); }
                if (Item.IGST_18 == Item.DMS_IGST_18) { Item.Diff_IGST_18 = "0"; } else { Item.Diff_IGST_18 = (Item.IGST_18 - Item.DMS_IGST_18).ToString(); }
                if (Item.IGST_28 == Item.DMS_IGST_28) { Item.Diff_IGST_28 = "0"; } else { Item.Diff_IGST_28 = (Item.IGST_28 - Item.DMS_IGST_28).ToString(); }
                if (Item.CESS_1 == Item.DMS_CESS_1) { Item.Diff_CESS_1 = "0"; } else { Item.Diff_CESS_1 = (Item.CESS_1 - Item.DMS_CESS_1).ToString(); }
                if (Item.CESS_17 == Item.DMS_CESS_17) { Item.Diff_CESS_17 = "0"; } else { Item.Diff_CESS_17 = (Item.CESS_17 - Item.DMS_CESS_17).ToString(); }
                if (Item.TCS == Item.DMS_TCS) { Item.Diff_TCS = "0"; } else { Item.Diff_TCS = (Item.TCS - Item.DMS_TCS).ToString(); }
                if (Item.Roundoff == Item.DMS_Roundoff) { Item.Diff_Roundoff = "0"; } else { Item.Diff_Roundoff = (Item.Roundoff - Item.DMS_Roundoff).ToString(); }
                if (Item.InvAmt == Item.DMS_InvAmt) { Item.Diff_InvAmt = "0"; } else { Item.Diff_InvAmt = (Item.InvAmt - Item.DMS_InvAmt).ToString(); }


                #endregion



                ItemList.Add(Item);
            }

            return ItemList;

        }





        public static DataTable GetDGetDataFromTallyRecod(DateTime FromDate, DateTime ToDate, int GodwnId)
        {

            DataTable dtMainTable = OtherSqlConn.FillDataTable("select   * from (select MAX(GSTNUM) as partygstIn,MAX(NameofCustomer) as partyName,MAX(PlaceofSupply) as placeOfSupply,CONVERT(decimal(18,2), TotalTaxCate) as MXCATE,INVOICENUM as voucherNumber,max( CONVERT(date, INVOICEDATE)) as voucherDate,sum(CONVERT(Decimal(18,2) ,TAXABLEVALUE)) as TAXABLEVALUE,MAX(CONVERT(Decimal(18,2) ,IGSTRATE)) as IGSTRATE,sum(CONVERT(Decimal(18,2) ,IGSTAMT)) as IGSTAMT,MAX(CONVERT(Decimal(18,2) ,CGSTRATE)) as CGSTRATE,sum(CONVERT(Decimal(18,2) ,CGSTAMT)) as CGSTAMT,MAX(CONVERT(Decimal(18,2) ,SGSTRATE)) as SGSTRATE,sum(CONVERT(Decimal(18,2) ,SGSTAMT)) as SGSTAMT,MAX(CONVERT(Decimal(18,2) ,KeralaFloodCessRate)) as KeralaFloodCessRate,sum(CONVERT(Decimal(18,2) ,KeralaFloodCessAmount)) as KeralaFloodCessAmount,MAX(CONVERT(Decimal(18,2) ,TCSRate)) as TCSRate,sum(CONVERT(Decimal(18,2) ,TCSAmount)) as TCSAmount,sum(CONVERT(Decimal(18,2) ,GrossAmount)) as GrossAmount from  (select * from  tallydataValidate where CONVERT(date,INVOICEDATE) between '" + FromDate.ToString("dd-MMM-yyyy") + "' and '" + ToDate.ToString("dd-MMM-yyyy") + "'  and godwnid="+GodwnId+") as x  group by INVOICENUM,CONVERT(Decimal(18,2), TotalTaxCate)) as x  order by voucherNumber asc");
            DataTable dtMainTableTally = OtherSqlConn.FillDataTable("select   * from (select   partygstIn,  partyName,placeOfSupply, MXCATE, voucherNumber, CONVERT(date, voucherDate,103) as voucherDate,  TAXABLEVALUE, IGSTRATE, IGSTAMT, CGSTRATE, CGSTAMT, SGSTRATE,  SGSTAMT, KeralaFloodCessRate,  KeralaFloodCessAmount,  TCSRate,  TCSAmount,  GrossAmount from  (select * from  TallyRecoDataFromTally where  CONVERT(date, voucherDate,103) between '" + FromDate.ToString("dd-MMM-yyyy") + "' and '" + ToDate.ToString("dd-MMM-yyyy") + "' and  isnull(godwnid,0)="+GodwnId+") as x ) as x  order by voucherNumber asc");
            DataTable dtMainTableTallyNotInDMS = OtherSqlConn.FillDataTable("select   voucherNumber from (select distinct voucherNumber from  TallyRecoDataFromTally where  CONVERT(date, voucherDate,103) between '" + FromDate.ToString("dd-MMM-yyyy") + "' and '" + ToDate.ToString("dd-MMM-yyyy") + "' and  isnull(godwnid,0)=" + GodwnId + ") as x  left join (select distinct INVOICENUM  from  tallydataValidate where CONVERT(date,INVOICEDATE) between '" + FromDate.ToString("dd-MMM-yyyy") + "' and '" + ToDate.ToString("dd-MMM-yyyy") + "' ) as y on x. voucherNumber=y.INVOICENUM where  ISNULL(y.INVOICENUM ,'')=''");
            var GroupVoucherNo = dtMainTable.AsEnumerable().GroupBy(p => p["voucherNumber"].ToString()).Select(p => new { INVOICENUM = p.Key }).ToList();
            var GroupNotInDMSVoucherNo = dtMainTableTallyNotInDMS.AsEnumerable().GroupBy(p => p["voucherNumber"].ToString()).Select(p => new { INVOICENUM = p.Key }).ToList();
            
            
           
            var ItemList = new List<voucherRecoData>();


            #region DMSVocuher
            foreach (var INV in GroupVoucherNo)
            {
                DataTable x = new DataTable();
                try
                {
                    x = dtMainTableTally.AsEnumerable().Where(p => p["voucherNumber"].ToString().ToUpper() == INV.INVOICENUM.Trim().ToUpper()).CopyToDataTable();
                }
                catch { }
                DataTable FilterDt = new DataTable();
                try
                {
                    FilterDt = dtMainTable.AsEnumerable().Where(p => p["voucherNumber"].ToString().Trim().ToUpper() == INV.INVOICENUM.Trim().ToUpper()).CopyToDataTable();
                }
                catch { }
                var Item = new voucherRecoData();
                #region dms_reCO
                FilterDt.AsEnumerable().ToList().ForEach(xc =>
                {
                    //TAXABLEVALUE,IGSTRATE,IGSTAMT,CGSTRATE,CGSTAMT,SGSTRATE,SGSTAMT,KeralaFloodCessRate,KeralaFloodCessAmount,TCSRate,TCSAmount, GrossAmount


                    Item.DMS_GSTIN = xc["partygstIn"].ToString();

                    Item.DMS_PartyName = xc["partyName"].ToString();
                    Item.DMS_placeOfSupply = xc["placeOfSupply"].ToString();
                    Item.DMS_voucherDate = Convert.ToDateTime(xc["voucherDate"]).ToString("dd/MM/yyyy");
                    Item.DMS_voucherNumber = xc["voucherNumber"].ToString();
                    if (Common.ConvertDecimal(xc["MXCATE"]) == 5m)
                    {
                        Item.DMS_Taxable_5 += Common.ConvertDecimal(xc["TAXABLEVALUE"]);
                        try { Item.DMS_CGST_25 += Common.ConvertDecimal(xc["CGSTAMT"]); } catch { };
                        try { Item.DMS_SGST_25 += Common.ConvertDecimal(xc["SGSTAMT"]); } catch { };
                        try { Item.DMS_IGST_5 += Common.ConvertDecimal(xc["IGSTAMT"]); } catch { };

                    }
                    else if (Common.ConvertDecimal(xc["MXCATE"]) == 12m)
                    {
                        Item.DMS_Taxable_12 += Common.ConvertDecimal(xc["TAXABLEVALUE"]);
                        try { Item.DMS_CGST_6 += Common.ConvertDecimal(xc["CGSTAMT"]); } catch { };
                        try { Item.DMS_SGST_6 += Common.ConvertDecimal(xc["SGSTAMT"]); } catch { };
                        try { Item.DMS_IGST_12 += Common.ConvertDecimal(xc["IGSTAMT"]); } catch { };

                    }
                    else if (Common.ConvertDecimal(xc["MXCATE"]) == 18m)
                    {
                        Item.DMS_Taxable_18 += Common.ConvertDecimal(xc["TAXABLEVALUE"]);
                        try { Item.DMS_CGST_9 += Common.ConvertDecimal(xc["CGSTAMT"]); } catch { };
                        try { Item.DMS_SGST_9 += Common.ConvertDecimal(xc["SGSTAMT"]); } catch { };
                        try { Item.DMS_IGST_18 += Common.ConvertDecimal(xc["IGSTAMT"]); } catch { };

                    }

                    else if (Common.ConvertDecimal(xc["MXCATE"]) == 28m)
                    {
                        Item.DMS_Taxable_28 += Common.ConvertDecimal(xc["TAXABLEVALUE"]);
                        try { Item.DMS_CGST_14 += Common.ConvertDecimal(xc["CGSTAMT"]); } catch { };
                        try { Item.DMS_SGST_14 += Common.ConvertDecimal(xc["SGSTAMT"]); } catch { };
                        try { Item.DMS_IGST_28 += Common.ConvertDecimal(xc["IGSTAMT"]); } catch { };

                    }
                    if (Common.ConvertDecimal(xc["KeralaFloodCessRate"]) == 1m)
                    {

                        try { Item.DMS_CESS_1 += Common.ConvertDecimal(xc["KeralaFloodCessAmount"]); } catch { };

                    }
                    else if (Common.ConvertDecimal(xc["KeralaFloodCessRate"]) == 17m)
                    {

                        try { Item.DMS_CESS_17 += Common.ConvertDecimal(xc["KeralaFloodCessAmount"]); } catch { };

                    }

                    if (Common.ConvertDecimal(xc["TCSAmount"]) > 0)
                    {

                        try { Item.DMS_TCS += Common.ConvertDecimal(xc["TCSAmount"]); } catch { };

                    }
                    Item.DMS_InvAmt += Common.ConvertDecimal(xc["GrossAmount"]); ;
                });
                var RoundOff = (Convert.ToDecimal(Common.RoundF(Item.DMS_InvAmt)) - Item.DMS_InvAmt);
                Item.DMS_Roundoff = RoundOff;
                Item.DMS_InvAmt = Convert.ToDecimal(Common.RoundF(Item.DMS_InvAmt));


                #endregion


                #region dms_Tally_Reco
                x.AsEnumerable().ToList().ForEach(xc =>
                {
                    //TAXABLEVALUE,IGSTRATE,IGSTAMT,CGSTRATE,CGSTAMT,SGSTRATE,SGSTAMT,KeralaFloodCessRate,KeralaFloodCessAmount,TCSRate,TCSAmount, GrossAmount


                    Item.GSTIN = xc["partygstIn"].ToString();

                    Item.PartyName = xc["partyName"].ToString();
                    Item.placeOfSupply = xc["placeOfSupply"].ToString();
                    Item.voucherDate = Convert.ToDateTime(xc["voucherDate"]).ToString("dd/MM/yyyy");
                    Item.voucherNumber = xc["voucherNumber"].ToString();
                    if (Common.ConvertDecimal(xc["MXCATE"]) == 5m)
                    {
                        Item.Taxable_5 += Common.ConvertDecimal(xc["TAXABLEVALUE"]);
                        try { Item.CGST_25 += Common.ConvertDecimal(xc["CGSTAMT"]); } catch { };
                        try { Item.SGST_25 += Common.ConvertDecimal(xc["SGSTAMT"]); } catch { };
                        try { Item.IGST_5 += Common.ConvertDecimal(xc["IGSTAMT"]); } catch { };

                    }
                    else if (Common.ConvertDecimal(xc["MXCATE"]) == 12m)
                    {
                        Item.Taxable_12 += Common.ConvertDecimal(xc["TAXABLEVALUE"]);
                        try { Item.CGST_6 += Common.ConvertDecimal(xc["CGSTAMT"]); } catch { };
                        try { Item.SGST_6 += Common.ConvertDecimal(xc["SGSTAMT"]); } catch { };
                        try { Item.IGST_12 += Common.ConvertDecimal(xc["IGSTAMT"]); } catch { };

                    }
                    else if (Common.ConvertDecimal(xc["MXCATE"]) == 18m)
                    {
                        Item.DMS_Taxable_18 += Common.ConvertDecimal(xc["TAXABLEVALUE"]);
                        try { Item.CGST_9 += Common.ConvertDecimal(xc["CGSTAMT"]); } catch { };
                        try { Item.SGST_9 += Common.ConvertDecimal(xc["SGSTAMT"]); } catch { };
                        try { Item.IGST_18 += Common.ConvertDecimal(xc["IGSTAMT"]); } catch { };

                    }

                    else if (Common.ConvertDecimal(xc["MXCATE"]) == 28m)
                    {
                        Item.Taxable_28 += Common.ConvertDecimal(xc["TAXABLEVALUE"]);
                        try { Item.CGST_14 += Common.ConvertDecimal(xc["CGSTAMT"]); } catch { };
                        try { Item.SGST_14 += Common.ConvertDecimal(xc["SGSTAMT"]); } catch { };
                        try { Item.IGST_28 += Common.ConvertDecimal(xc["IGSTAMT"]); } catch { };

                    }
                    if (Common.ConvertDecimal(xc["KeralaFloodCessRate"]) == 1m)
                    {

                        try { Item.CESS_1 = Common.ConvertDecimal(xc["KeralaFloodCessAmount"]); } catch { };

                    }
                    else if (Common.ConvertDecimal(xc["KeralaFloodCessRate"]) == 17m)
                    {

                        try { Item.DMS_CESS_17 = Common.ConvertDecimal(xc["KeralaFloodCessAmount"]); } catch { };

                    }

                    if (Common.ConvertDecimal(xc["TCSAmount"]) > 0)
                    {

                        try { Item.TCS = Common.ConvertDecimal(xc["TCSAmount"]); } catch { };

                    }
                    Item.InvAmt = Common.ConvertDecimal(xc["GrossAmount"]); ;
                });





                #endregion

                #region CheckStatus
                if (Item.InvAmt == Item.DMS_InvAmt)
                {
                    Item.Status = "Ok";
                }
                else if (Item.voucherNumber.Length==0)
                {
                    Item.Status = "Not in tally";
                }
                else if (Item.voucherNumber.Length == 0)
                {
                    Item.Status = "Not in tally";
                }
               
                #endregion
                #region Compaire
                if (Item.GSTIN == Item.DMS_GSTIN) { Item.Diff_GSTIN = "True"; } else { Item.Diff_GSTIN = "False"; }
                if (Item.placeOfSupply == Item.DMS_placeOfSupply) { Item.Diff_placeOfSupply = "True"; } else { Item.Diff_placeOfSupply = "False"; }
                if (Item.PartyName == Item.DMS_PartyName) { Item.Diff_PartyName = "True"; } else { Item.Diff_PartyName = "False"; }
                if (Item.voucherDate == Item.DMS_voucherDate) { Item.Diff_voucherDate = "True"; } else { Item.Diff_voucherDate = "False"; }
                if (Item.voucherNumber == Item.DMS_voucherNumber) { Item.Diff_voucherNumber = "True"; } else { Item.Diff_voucherNumber = "False"; }
                if (Item.Taxable_5 == Item.DMS_Taxable_5) { Item.Diff_Taxable_5 = "0"; } else { Item.Diff_Taxable_5 = (Item.Taxable_5 - Item.DMS_Taxable_5).ToString(); }
                if (Item.Taxable_12 == Item.DMS_Taxable_12) { Item.Diff_Taxable_12 = "0"; } else { Item.Diff_Taxable_12 = (Item.Taxable_12 - Item.DMS_Taxable_12).ToString(); }
                if (Item.Taxable_18 == Item.DMS_Taxable_18) { Item.Diff_Taxable_18 = "0"; } else { Item.Diff_Taxable_18 = (Item.Taxable_18 - Item.DMS_Taxable_18).ToString(); }
                if (Item.Taxable_28 == Item.DMS_Taxable_28) { Item.Diff_Taxable_28 = "0"; } else { Item.Diff_Taxable_28 = (Item.Taxable_28 - Item.DMS_Taxable_28).ToString(); }
                if (Item.CGST_25 == Item.DMS_CGST_25) { Item.Diff_CGST_25 = "0"; } else { Item.Diff_CGST_25 = (Item.CGST_25 - Item.DMS_CGST_25).ToString(); }
                if (Item.CGST_6 == Item.DMS_CGST_6) { Item.Diff_CGST_6 = "0"; } else { Item.Diff_CGST_6 = (Item.CGST_6 - Item.DMS_CGST_6).ToString(); }
                if (Item.CGST_9 == Item.DMS_CGST_9) { Item.Diff_CGST_9 = "0"; } else { Item.Diff_CGST_9 = (Item.CGST_9 - Item.DMS_CGST_9).ToString(); }
                if (Item.CGST_14 == Item.DMS_CGST_14) { Item.Diff_CGST_14 = "0"; } else { Item.Diff_CGST_14 = (Item.CGST_14 - Item.DMS_CGST_14).ToString(); }
                if (Item.SGST_25 == Item.DMS_SGST_25) { Item.Diff_SGST_25 = "0"; } else { Item.Diff_SGST_25 = (Item.SGST_25 - Item.DMS_SGST_25).ToString(); }
                if (Item.SGST_6 == Item.DMS_SGST_6) { Item.Diff_SGST_6 = "0"; } else { Item.Diff_SGST_6 = (Item.SGST_6 - Item.DMS_SGST_6).ToString(); }
                if (Item.SGST_9 == Item.DMS_SGST_9) { Item.Diff_SGST_9 = "0"; } else { Item.Diff_SGST_9 = (Item.SGST_9 - Item.DMS_SGST_9).ToString(); }
                if (Item.SGST_14 == Item.DMS_SGST_14) { Item.Diff_SGST_14 = "0"; } else { Item.Diff_SGST_14 = (Item.SGST_14 - Item.DMS_SGST_14).ToString(); }
                if (Item.IGST_5 == Item.DMS_IGST_5) { Item.Diff_IGST_5 = "0"; } else { Item.Diff_IGST_5 = (Item.IGST_5 - Item.DMS_IGST_5).ToString(); }
                if (Item.IGST_12 == Item.DMS_IGST_12) { Item.Diff_IGST_12 = "0"; } else { Item.Diff_IGST_12 = (Item.IGST_12 - Item.DMS_IGST_12).ToString(); }
                if (Item.IGST_18 == Item.DMS_IGST_18) { Item.Diff_IGST_18 = "0"; } else { Item.Diff_IGST_18 = (Item.IGST_18 - Item.DMS_IGST_18).ToString(); }
                if (Item.IGST_28 == Item.DMS_IGST_28) { Item.Diff_IGST_28 = "0"; } else { Item.Diff_IGST_28 = (Item.IGST_28 - Item.DMS_IGST_28).ToString(); }
                if (Item.CESS_1 == Item.DMS_CESS_1) { Item.Diff_CESS_1 = "0"; } else { Item.Diff_CESS_1 = (Item.CESS_1 - Item.DMS_CESS_1).ToString(); }
                if (Item.CESS_17 == Item.DMS_CESS_17) { Item.Diff_CESS_17 = "0"; } else { Item.Diff_CESS_17 = (Item.CESS_17 - Item.DMS_CESS_17).ToString(); }
                if (Item.TCS == Item.DMS_TCS) { Item.Diff_TCS = "0"; } else { Item.Diff_TCS = (Item.TCS - Item.DMS_TCS).ToString(); }
                if (Item.Roundoff == Item.DMS_Roundoff) { Item.Diff_Roundoff = "0"; } else { Item.Diff_Roundoff = (Item.Roundoff - Item.DMS_Roundoff).ToString(); }
                if (Item.InvAmt == Item.DMS_InvAmt) { Item.Diff_InvAmt = "0"; } else { Item.Diff_InvAmt = (Item.InvAmt - Item.DMS_InvAmt).ToString(); }


                #endregion



                ItemList.Add(Item);
            }
            #endregion









            #region NotInDMS
            foreach (var INV in GroupNotInDMSVoucherNo)
            {
                DataTable x = new DataTable();
                try
                {
                    x = dtMainTableTally.AsEnumerable().Where(p => p["voucherNumber"].ToString().ToUpper() == INV.INVOICENUM.Trim().ToUpper()).CopyToDataTable();
                }
                catch { }
               
                var Item = new voucherRecoData();
                

                #region dms_Tally_Reco
                x.AsEnumerable().ToList().ForEach(xc =>
                {
                    //TAXABLEVALUE,IGSTRATE,IGSTAMT,CGSTRATE,CGSTAMT,SGSTRATE,SGSTAMT,KeralaFloodCessRate,KeralaFloodCessAmount,TCSRate,TCSAmount, GrossAmount


                    Item.GSTIN = xc["partygstIn"].ToString();

                    Item.PartyName = xc["partyName"].ToString();
                    Item.placeOfSupply = xc["placeOfSupply"].ToString();
                    Item.voucherDate = Convert.ToDateTime(xc["voucherDate"]).ToString("dd/MM/yyyy");
                    Item.voucherNumber = xc["voucherNumber"].ToString();
                    if (Common.ConvertDecimal(xc["MXCATE"]) == 5m)
                    {
                        Item.Taxable_5 += Common.ConvertDecimal(xc["TAXABLEVALUE"]);
                        try { Item.CGST_25 += Common.ConvertDecimal(xc["CGSTAMT"]); } catch { };
                        try { Item.SGST_25 += Common.ConvertDecimal(xc["SGSTAMT"]); } catch { };
                        try { Item.IGST_5 += Common.ConvertDecimal(xc["IGSTAMT"]); } catch { };

                    }
                    else if (Common.ConvertDecimal(xc["MXCATE"]) == 12m)
                    {
                        Item.Taxable_12 += Common.ConvertDecimal(xc["TAXABLEVALUE"]);
                        try { Item.CGST_6 += Common.ConvertDecimal(xc["CGSTAMT"]); } catch { };
                        try { Item.SGST_6 += Common.ConvertDecimal(xc["SGSTAMT"]); } catch { };
                        try { Item.IGST_12 += Common.ConvertDecimal(xc["IGSTAMT"]); } catch { };

                    }
                    else if (Common.ConvertDecimal(xc["MXCATE"]) == 18m)
                    {
                        Item.DMS_Taxable_18 += Common.ConvertDecimal(xc["TAXABLEVALUE"]);
                        try { Item.CGST_9 += Common.ConvertDecimal(xc["CGSTAMT"]); } catch { };
                        try { Item.SGST_9 += Common.ConvertDecimal(xc["SGSTAMT"]); } catch { };
                        try { Item.IGST_18 += Common.ConvertDecimal(xc["IGSTAMT"]); } catch { };

                    }

                    else if (Common.ConvertDecimal(xc["MXCATE"]) == 28m)
                    {
                        Item.Taxable_28 += Common.ConvertDecimal(xc["TAXABLEVALUE"]);
                        try { Item.CGST_14 += Common.ConvertDecimal(xc["CGSTAMT"]); } catch { };
                        try { Item.SGST_14 += Common.ConvertDecimal(xc["SGSTAMT"]); } catch { };
                        try { Item.IGST_28 += Common.ConvertDecimal(xc["IGSTAMT"]); } catch { };

                    }
                    if (Common.ConvertDecimal(xc["KeralaFloodCessRate"]) == 1m)
                    {

                        try { Item.CESS_1 = Common.ConvertDecimal(xc["KeralaFloodCessAmount"]); } catch { };

                    }
                    else if (Common.ConvertDecimal(xc["KeralaFloodCessRate"]) == 17m)
                    {

                        try { Item.DMS_CESS_17 = Common.ConvertDecimal(xc["KeralaFloodCessAmount"]); } catch { };

                    }

                    if (Common.ConvertDecimal(xc["TCSAmount"]) > 0)
                    {

                        try { Item.TCS = Common.ConvertDecimal(xc["TCSAmount"]); } catch { };

                    }
                    Item.InvAmt = Common.ConvertDecimal(xc["GrossAmount"]); ;
                });

                #endregion

                #region CheckStatus
             
                    Item.Status = "Not in DMS";
             

                #endregion
                #region Compaire
                if (Item.GSTIN == Item.DMS_GSTIN) { Item.Diff_GSTIN = "True"; } else { Item.Diff_GSTIN = "False"; }
                if (Item.placeOfSupply == Item.DMS_placeOfSupply) { Item.Diff_placeOfSupply = "True"; } else { Item.Diff_placeOfSupply = "False"; }
                if (Item.PartyName == Item.DMS_PartyName) { Item.Diff_PartyName = "True"; } else { Item.Diff_PartyName = "False"; }
                if (Item.voucherDate == Item.DMS_voucherDate) { Item.Diff_voucherDate = "True"; } else { Item.Diff_voucherDate = "False"; }
                if (Item.voucherNumber == Item.DMS_voucherNumber) { Item.Diff_voucherNumber = "True"; } else { Item.Diff_voucherNumber = "False"; }
                if (Item.Taxable_5 == Item.DMS_Taxable_5) { Item.Diff_Taxable_5 = "0"; } else { Item.Diff_Taxable_5 = (Item.Taxable_5 - Item.DMS_Taxable_5).ToString(); }
                if (Item.Taxable_12 == Item.DMS_Taxable_12) { Item.Diff_Taxable_12 = "0"; } else { Item.Diff_Taxable_12 = (Item.Taxable_12 - Item.DMS_Taxable_12).ToString(); }
                if (Item.Taxable_18 == Item.DMS_Taxable_18) { Item.Diff_Taxable_18 = "0"; } else { Item.Diff_Taxable_18 = (Item.Taxable_18 - Item.DMS_Taxable_18).ToString(); }
                if (Item.Taxable_28 == Item.DMS_Taxable_28) { Item.Diff_Taxable_28 = "0"; } else { Item.Diff_Taxable_28 = (Item.Taxable_28 - Item.DMS_Taxable_28).ToString(); }
                if (Item.CGST_25 == Item.DMS_CGST_25) { Item.Diff_CGST_25 = "0"; } else { Item.Diff_CGST_25 = (Item.CGST_25 - Item.DMS_CGST_25).ToString(); }
                if (Item.CGST_6 == Item.DMS_CGST_6) { Item.Diff_CGST_6 = "0"; } else { Item.Diff_CGST_6 = (Item.CGST_6 - Item.DMS_CGST_6).ToString(); }
                if (Item.CGST_9 == Item.DMS_CGST_9) { Item.Diff_CGST_9 = "0"; } else { Item.Diff_CGST_9 = (Item.CGST_9 - Item.DMS_CGST_9).ToString(); }
                if (Item.CGST_14 == Item.DMS_CGST_14) { Item.Diff_CGST_14 = "0"; } else { Item.Diff_CGST_14 = (Item.CGST_14 - Item.DMS_CGST_14).ToString(); }
                if (Item.SGST_25 == Item.DMS_SGST_25) { Item.Diff_SGST_25 = "0"; } else { Item.Diff_SGST_25 = (Item.SGST_25 - Item.DMS_SGST_25).ToString(); }
                if (Item.SGST_6 == Item.DMS_SGST_6) { Item.Diff_SGST_6 = "0"; } else { Item.Diff_SGST_6 = (Item.SGST_6 - Item.DMS_SGST_6).ToString(); }
                if (Item.SGST_9 == Item.DMS_SGST_9) { Item.Diff_SGST_9 = "0"; } else { Item.Diff_SGST_9 = (Item.SGST_9 - Item.DMS_SGST_9).ToString(); }
                if (Item.SGST_14 == Item.DMS_SGST_14) { Item.Diff_SGST_14 = "0"; } else { Item.Diff_SGST_14 = (Item.SGST_14 - Item.DMS_SGST_14).ToString(); }
                if (Item.IGST_5 == Item.DMS_IGST_5) { Item.Diff_IGST_5 = "0"; } else { Item.Diff_IGST_5 = (Item.IGST_5 - Item.DMS_IGST_5).ToString(); }
                if (Item.IGST_12 == Item.DMS_IGST_12) { Item.Diff_IGST_12 = "0"; } else { Item.Diff_IGST_12 = (Item.IGST_12 - Item.DMS_IGST_12).ToString(); }
                if (Item.IGST_18 == Item.DMS_IGST_18) { Item.Diff_IGST_18 = "0"; } else { Item.Diff_IGST_18 = (Item.IGST_18 - Item.DMS_IGST_18).ToString(); }
                if (Item.IGST_28 == Item.DMS_IGST_28) { Item.Diff_IGST_28 = "0"; } else { Item.Diff_IGST_28 = (Item.IGST_28 - Item.DMS_IGST_28).ToString(); }
                if (Item.CESS_1 == Item.DMS_CESS_1) { Item.Diff_CESS_1 = "0"; } else { Item.Diff_CESS_1 = (Item.CESS_1 - Item.DMS_CESS_1).ToString(); }
                if (Item.CESS_17 == Item.DMS_CESS_17) { Item.Diff_CESS_17 = "0"; } else { Item.Diff_CESS_17 = (Item.CESS_17 - Item.DMS_CESS_17).ToString(); }
                if (Item.TCS == Item.DMS_TCS) { Item.Diff_TCS = "0"; } else { Item.Diff_TCS = (Item.TCS - Item.DMS_TCS).ToString(); }
                if (Item.Roundoff == Item.DMS_Roundoff) { Item.Diff_Roundoff = "0"; } else { Item.Diff_Roundoff = (Item.Roundoff - Item.DMS_Roundoff).ToString(); }
                if (Item.InvAmt == Item.DMS_InvAmt) { Item.Diff_InvAmt = "0"; } else { Item.Diff_InvAmt = (Item.InvAmt - Item.DMS_InvAmt).ToString(); }


                #endregion



                ItemList.Add(Item);
            }
            #endregion







            return Class.CreateDatatable.GenericListToDataTableNullAlowed( ItemList.ToList());

        }



        public static DataTable GetDGetDataFromDataTableTally(DateTime FromDate, DateTime ToDate, DataTable TallyTable, int GodwnId)
        {

            DataTable dtMainTable = OtherSqlConn.FillDataTable("select   * from (select MAX(GSTNUM) as partygstIn,MAX(NameofCustomer) as partyName,MAX(PlaceofSupply) as placeOfSupply,CONVERT(decimal(18,2), TotalTaxCate) as MXCATE,INVOICENUM as voucherNumber,max( CONVERT(date, INVOICEDATE)) as voucherDate,sum(CONVERT(Decimal(18,2) ,TAXABLEVALUE)) as TAXABLEVALUE,MAX(CONVERT(Decimal(18,2) ,IGSTRATE)) as IGSTRATE,sum(CONVERT(Decimal(18,2) ,IGSTAMT)) as IGSTAMT,MAX(CONVERT(Decimal(18,2) ,CGSTRATE)) as CGSTRATE,sum(CONVERT(Decimal(18,2) ,CGSTAMT)) as CGSTAMT,MAX(CONVERT(Decimal(18,2) ,SGSTRATE)) as SGSTRATE,sum(CONVERT(Decimal(18,2) ,SGSTAMT)) as SGSTAMT,MAX(CONVERT(Decimal(18,2) ,KeralaFloodCessRate)) as KeralaFloodCessRate,sum(CONVERT(Decimal(18,2) ,KeralaFloodCessAmount)) as KeralaFloodCessAmount,MAX(CONVERT(Decimal(18,2) ,TCSRate)) as TCSRate,sum(CONVERT(Decimal(18,2) ,TCSAmount)) as TCSAmount,sum(CONVERT(Decimal(18,2) ,GrossAmount)) as GrossAmount from  (select * from  tallydataValidate where CONVERT(date,INVOICEDATE) between '" + FromDate.ToString("dd-MMM-yyyy") + "' and '" + ToDate.ToString("dd-MMM-yyyy") + "' and CONVERT(Decimal(18,2) ,isnull(TAXABLEVALUE,'0'))>0) as x  group by INVOICENUM,CONVERT(Decimal(18,2), TotalTaxCate)) as x  order by voucherNumber asc");
            var GroupVoucherNo = dtMainTable.AsEnumerable().GroupBy(p => p["voucherNumber"].ToString()).Select(p => new { INVOICENUM = p.Key }).ToList();
            var GSTCTAGORY = dtMainTable.AsEnumerable().GroupBy(p =>Common.ConvertDecimal(p["MXCATE"])).Select(p => new { MXCATE = p.Key }).ToList();
            var TallyColumn = TallyTable.Columns;
            DataTable MaperData = OtherSqlConn.FillDataTable("select * from DMSTallyLedgerMapper");
            DataTable NewReturn = new DataTable();
            #region CreateTable
            NewReturn.Columns.Add(new DataColumn("DMS_partygstIn") { DefaultValue = "", Caption = "DMS_GSTIN", DataType = typeof(String) });
            NewReturn.Columns.Add(new DataColumn("DMS_partyName") { DefaultValue = "", Caption = "DMS_Party", DataType = typeof(String) });
            NewReturn.Columns.Add(new DataColumn("DMS_voucherNumber") { DefaultValue = "", Caption = "DMS_Voucher Number", DataType = typeof(String) });
            NewReturn.Columns.Add(new DataColumn("DMS_voucherDate") { DefaultValue = "", Caption = "DMS_voucher Date", DataType = typeof(String) });
            foreach (DataRow dr in MaperData.Rows)
            {
                try
                {
                    NewReturn.Columns.Add(new DataColumn("DMS_" + dr["DMSLedgerName"].ToString()) { DefaultValue = "", Caption = "DMS_" + dr["TallyLedgerName"].ToString(), DataType = typeof(String) });
                }
                catch { }
            }
            try
            {
                NewReturn.Columns.Add(new DataColumn("DMS_CESS_17") { DefaultValue = "", Caption = "DMS_CESS_17", DataType = typeof(String) });
            }
            catch { }
            try
            {
                NewReturn.Columns.Add(new DataColumn("DMS_CESS_1") { DefaultValue = "", Caption = "DMS_CESS_1", DataType = typeof(String) });
            }
            catch { }
            try
            {
                NewReturn.Columns.Add(new DataColumn("DMS_TCS") { DefaultValue = "", Caption = "DMS_TCS", DataType = typeof(String) });
            }
            catch { }

            NewReturn.Columns.Add(new DataColumn("DMS_RoundOff") { DefaultValue = "", Caption = "DMS_RoundOff", DataType = typeof(String) });
            NewReturn.Columns.Add(new DataColumn("DMS_TotalAmount") { DefaultValue = "", Caption = "DMS_Total Amount", DataType = typeof(String) });

            NewReturn.Columns.Add(new DataColumn("Tally_partygstIn") { DefaultValue = "", Caption = "Tally_GSTIN", DataType = typeof(String) });
            NewReturn.Columns.Add(new DataColumn("Tally_partyName") { DefaultValue = "", Caption = "Tally_Party", DataType = typeof(String) });
            NewReturn.Columns.Add(new DataColumn("Tally_voucherNumber") { DefaultValue = "", Caption = "Tally_Voucher Number", DataType = typeof(String) });
            NewReturn.Columns.Add(new DataColumn("Tally_voucherDate") { DefaultValue = "", Caption = "Tally_voucher Date", DataType = typeof(String) });
            foreach (DataRow dr in MaperData.Rows)
            {
                try
                {
                    NewReturn.Columns.Add(new DataColumn("Tally_" + dr["DMSLedgerName"].ToString()) { DefaultValue = "", Caption = "Tally_" + dr["TallyLedgerName"].ToString(), DataType = typeof(String) });
                }
                catch { }
                }
            try
            {
                NewReturn.Columns.Add(new DataColumn("Tally_CESS_17") { DefaultValue = "", Caption = "Tally_CESS_17", DataType = typeof(String) });
            }
            catch { }


            try
            {
                NewReturn.Columns.Add(new DataColumn("Tally_TCS") { DefaultValue = "", Caption = "DMS_TCS", DataType = typeof(String) });
            }
            catch { }
            NewReturn.Columns.Add(new DataColumn("Tally_RoundOff") { DefaultValue = "", Caption = "Tally_RoundOff", DataType = typeof(String) });
            NewReturn.Columns.Add(new DataColumn("Tally_TotalAmount") { DefaultValue = "", Caption = "Tally_Total Amount", DataType = typeof(String) });

            NewReturn.Columns.Add(new DataColumn("Diff_partygstIn") { DefaultValue = "", Caption = "Diff_GSTIN", DataType = typeof(String) });
            NewReturn.Columns.Add(new DataColumn("Diff_partyName") { DefaultValue = "", Caption = "Diff_Party", DataType = typeof(String) });
            NewReturn.Columns.Add(new DataColumn("Diff_voucherNumber") { DefaultValue = "", Caption = "Diff_Voucher Number", DataType = typeof(String) });
            NewReturn.Columns.Add(new DataColumn("Diff_voucherDate") { DefaultValue = "", Caption = "Diff_voucher Date", DataType = typeof(String) });
            foreach (DataRow dr in MaperData.Rows)
            {
                try
                {
                    NewReturn.Columns.Add(new DataColumn("Diff_" + dr["DMSLedgerName"].ToString()) { DefaultValue = "", Caption = "Diff_" + dr["TallyLedgerName"].ToString(), DataType = typeof(String) });
                }
                catch { }
            }
            try
            {
                NewReturn.Columns.Add(new DataColumn("Diff_CESS_17") { DefaultValue = "", Caption = "Diff_CESS_17", DataType = typeof(String) });
            }
            catch { }
            try
            {
                NewReturn.Columns.Add(new DataColumn("Diff_CESS_1") { DefaultValue = "", Caption = "Diff_CESS_1", DataType = typeof(String) });
            }
            catch { }
            try
            {
                NewReturn.Columns.Add(new DataColumn("Diff_TCS") { DefaultValue = "", Caption = "DMS_TCS", DataType = typeof(String) });
            }
            catch { }

            NewReturn.Columns.Add(new DataColumn("Diff_RoundOff") { DefaultValue = "", Caption = "Diff_RoundOff", DataType = typeof(String) });

            NewReturn.Columns.Add(new DataColumn("Diff_TotalAmount") { DefaultValue = "", Caption = "Diff_Total Amount", DataType = typeof(String) });
            #endregion


            foreach (var INV in GroupVoucherNo)
            {


                DataTable FilterDt = dtMainTable.AsEnumerable().Where(p => p["voucherNumber"].ToString().Trim().ToUpper() == INV.INVOICENUM.Trim().ToUpper() &&Common.ConvertDecimal(p["TAXABLEVALUE"]) > 0).CopyToDataTable();

                DataRow Item = NewReturn.NewRow();
                DataRow Dr = null;
                try
                {
                    Dr = TallyTable.AsEnumerable().Where(p => p["VoucherNo"].ToString() == INV.INVOICENUM).FirstOrDefault();
                }
                catch { }

                FilterDt.AsEnumerable().ToList().ForEach(xc =>
                {
                    //TAXABLEVALUE,IGSTRATE,IGSTAMT,CGSTRATE,CGSTAMT,SGSTRATE,SGSTAMT,KeralaFloodCessRate,KeralaFloodCessAmount,TCSRate,TCSAmount, GrossAmount
                    Item["DMS_partygstIn"] = xc["partygstIn"].ToString();
                    Item["DMS_partyName"] = xc["partyName"].ToString();
                    Item["DMS_voucherDate"] = Convert.ToDateTime(xc["voucherDate"]).ToString("dd/MM/yyyy");
                    Item["DMS_voucherNumber"] = xc["voucherNumber"].ToString();

                    if (Dr != null)
                    {
                        Item["Tally_partygstIn"] = Dr["GSTINUIN"].ToString();
                        Item["Tally_partyName"] = Dr["Particulars"].ToString();
                        Item["Tally_voucherDate"] = Dr["Date"].ToString();
                        Item["Tally_voucherNumber"] = Dr["VoucherNo"].ToString();
                    }

                    GSTCTAGORY.ForEach(cate =>
                    {
                        if (Common.ConvertDecimal(xc["MXCATE"]) == cate.MXCATE)
                        {
                            
                            string GSTCate = (cate.MXCATE / 2m).ToString().Replace(".00", "").Length >= 3 ? (cate.MXCATE / 2m).ToString().Replace(".", "").Substring(0, 2) : (cate.MXCATE / 2m).ToString().Replace(".00", "");
                            string Taxable = "Taxable" + "_" + cate.MXCATE.ToString().Replace(".00","").Split('.')[0];
                            string IGST = "IGST" + "_" + cate.MXCATE.ToString().Replace(".00","").Split('.')[0];
                            string SGST = "SGST" + "_" + GSTCate;
                            string CGST = "CGST" + "_" + GSTCate;


                            Item[("DMS_Taxable" + "_" + cate.MXCATE.ToString().Replace(".00","").Split('.')[0])] = Common.ConvertDecimal(Item[("DMS_Taxable" + "_" + cate.MXCATE.ToString().Replace(".00","").Split('.')[0])]) +Common.ConvertDecimal(xc["TAXABLEVALUE"]).ToString();
                            Item[("DMS_IGST" + "_" + cate.MXCATE.ToString().Replace(".00","").Split('.')[0])] = Common.ConvertDecimal(Item[("DMS_IGST" + "_" + cate.MXCATE.ToString().Replace(".00","").Split('.')[0])]) +Common.ConvertDecimal(xc["IGSTAMT"]).ToString();
                            Item[("DMS_SGST" + "_" + GSTCate)] = Common.ConvertDecimal(Item[("DMS_SGST" + "_" + GSTCate)]) +Common.ConvertDecimal(xc["SGSTAMT"]).ToString();
                            Item[("DMS_CGST" + "_" + GSTCate)] = Common.ConvertDecimal(Item[("DMS_CGST" + "_" + GSTCate)]) +Common.ConvertDecimal(xc["CGSTAMT"]).ToString();
                            if (Dr != null)
                            {
                                try
                                {
                                    #region TallyData
                                    try
                                    {
                                        DataTable Filtertaxble = MaperData.AsEnumerable().Where(xxc => xxc["DMSLedgerName"].ToString() == Taxable).CopyToDataTable();
                                        foreach (DataRow cv in Filtertaxble.Rows)
                                        {
                                            foreach (DataColumn Coll in TallyColumn)
                                            {
                                                if ("Tally_" + cv["TallyLedgerName"].ToString().Trim() == Coll.Caption.Trim())
                                                {
                                                    string str = Coll.Caption.Replace("Tally_", "").Replace(",","").Trim().ToString().Replace(".", "").Replace("/", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "").Replace(@"\", "");

                                                    Item[("Tally_" + Taxable)] = Common.ConvertDecimal(Item[(("Tally_" + Taxable))]) + Common.ConvertDecimal(Dr[str]).ToString();
                                                    break;
                                                }


                                            }
                                        }
                                    }
                                    catch { }


                                    try
                                    {
                                        DataTable Filtertaxble = MaperData.AsEnumerable().Where(xxc => xxc["DMSLedgerName"].ToString() == IGST).CopyToDataTable();
                                        foreach (DataRow cv in Filtertaxble.Rows)
                                        {
                                            foreach (DataColumn Coll in TallyColumn)
                                            {
                                                if (cv["TallyLedgerName"].ToString().Trim() == Coll.Caption.Trim())
                                                {
                                                    string str = Coll.Caption.Trim().Replace(",", "").Replace("Tally_", "").ToString().Replace(".", "").Replace("/", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "").Replace(@"\", "");

                                                    Item[("Tally_" + IGST)] = Common.ConvertDecimal(Item[(("Tally_" + IGST))]) + Common.ConvertDecimal(Dr[str]).ToString();
                                                    break;
                                                }


                                            }
                                        }
                                    }
                                    catch { }


                                    try
                                    {
                                        DataTable Filtertaxble = MaperData.AsEnumerable().Where(xxc => xxc["DMSLedgerName"].ToString() == CGST).CopyToDataTable();
                                        foreach (DataRow cv in Filtertaxble.Rows)
                                        {
                                            foreach (DataColumn Coll in TallyColumn)
                                            {
                                                if (cv["TallyLedgerName"].ToString().Trim() == Coll.Caption.Trim())
                                                {
                                                    string str = Coll.Caption.Trim().Replace(",", "").ToString().Replace("Tally_", "").Replace(".", "").Replace("/", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "").Replace(@"\", "");

                                                    Item[("Tally_" + CGST)] = Common.ConvertDecimal(Item[(("Tally_" + CGST))]) + Common.ConvertDecimal(Dr[str]).ToString();
                                                    break;
                                                }


                                            }

                                        }
                                    }
                                    catch { }


                                    try
                                    {
                                        DataTable Filtertaxble = MaperData.AsEnumerable().Where(xxc => xxc["DMSLedgerName"].ToString() == SGST).CopyToDataTable();
                                        foreach (DataRow cv in Filtertaxble.Rows)
                                        {
                                            foreach (DataColumn Coll in TallyColumn)
                                            {
                                                if (cv["TallyLedgerName"].ToString().Trim() == Coll.Caption.Trim())
                                                {
                                                    string str = Coll.Caption.Trim().ToString().Replace(",", "").Replace("Tally_", "").Replace(".", "").Replace("/", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "").Replace(@"\", "");

                                                    Item[("Tally_" + SGST)] = Common.ConvertDecimal(Item[(("Tally_" + SGST))]) + Common.ConvertDecimal(Dr[str]).ToString();
                                                    break;
                                                }


                                            }
                                        }
                                    }
                                    catch { }

                                    #endregion


                                    #region Tally_Cess17%
                                    try
                                    {
                                        if (Common.ConvertDecimal(Item[("Tally_" + "CESS_17")]) == 0)
                                        {
                                            DataTable Filtertaxble = MaperData.AsEnumerable().Where(xxc => xxc["DMSLedgerName"].ToString() == "CESS_17").CopyToDataTable();
                                            foreach (DataRow cv in Filtertaxble.Rows)
                                            {
                                                foreach (DataColumn Coll in TallyColumn)
                                                {
                                                    if (cv["TallyLedgerName"].ToString().Trim() == Coll.Caption.Trim())
                                                    {
                                                        string str = Coll.Caption.Trim().ToString().Replace("Tally_", "").Replace(",", "").Replace(".", "").Replace("/", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "").Replace(@"\", "");

                                                        Item[("Tally_" + "CESS_17")] = Common.ConvertDecimal(Item[(("Tally_" + "CESS_17"))]) + Common.ConvertDecimal(Dr[str]).ToString();
                                                        break;
                                                    }


                                                }
                                            }
                                        }
                                    }
                                    catch { }


                                    #endregion

                                    #region Tally_Cess1%
                                    try
                                    {
                                        if (Common.ConvertDecimal(Item[("Tally_" + "CESS_1")]) == 0)
                                        {
                                            DataTable Filtertaxble = MaperData.AsEnumerable().Where(xxc => xxc["DMSLedgerName"].ToString() == "CESS_1").CopyToDataTable();
                                            foreach (DataRow cv in Filtertaxble.Rows)
                                            {
                                                foreach (DataColumn Coll in TallyColumn)
                                                {
                                                    if (cv["TallyLedgerName"].ToString().Trim() == Coll.Caption.Trim())
                                                    {
                                                        string str = Coll.Caption.Trim().ToString().Replace("Tally_", "").Replace(",", "").Replace(".", "").Replace("/", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "").Replace(@"\", "");

                                                        Item[("Tally_" + "CESS_1")] = Common.ConvertDecimal(Item[(("Tally_" + "CESS_1"))]) + Common.ConvertDecimal(Dr[str]).ToString();
                                                        break;

                                                    }


                                                }
                                            }
                                        }
                                    }
                                    catch { }


                                    #endregion


                                    #region Tally_TCS%
                                    try
                                    {
                                        DataTable Filtertaxble = MaperData.AsEnumerable().Where(xxc => xxc["DMSLedgerName"].ToString() == "TCS").CopyToDataTable();
                                        if (Common.ConvertDecimal(Item[("Tally_" + "TCS")]) == 0)
                                        {
                                            foreach (DataRow cv in Filtertaxble.Rows)
                                            {
                                                foreach (DataColumn Coll in TallyColumn)
                                                {
                                                    if (cv["TallyLedgerName"].ToString().Trim() == Coll.Caption.Trim())
                                                    {
                                                        string str = Coll.Caption.Trim().ToString().Replace("Tally_", "").Replace(",", "").Replace(".", "").Replace("/", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "").Replace(@"\", "");

                                                        Item[("Tally_" + "TCS")] = Common.ConvertDecimal(Item[(("Tally_" + "TCS"))]) + Common.ConvertDecimal(Dr[str]).ToString();
                                                        break;
                                                    }


                                                }
                                            }
                                        }
                                    }
                                    catch { }


                                    #endregion

                                }
                                catch { }
                            }
                        }
                    });




                    if (Common.ConvertDecimal(xc["KeralaFloodCessRate"]) == 1m)
                    {

                        try { Item["DMS_CESS_1"] = (Convert.ToDecimal(xc["DMS_CESS_1"]) +Common.ConvertDecimal(xc["KeralaFloodCessAmount"])).ToString(); } catch { };

                    }
                    else if (Common.ConvertDecimal(xc["KeralaFloodCessRate"]) == 17m)
                    {

                        try { Item["DMS_CESS_17"] = (Convert.ToDecimal(xc["DMS_CESS_17"]) +Common.ConvertDecimal(xc["KeralaFloodCessAmount"])).ToString(); } catch { };

                    }

                    if (Common.ConvertDecimal(xc["TCSAmount"]) > 0)
                    {

                        try
                        {

                            Item["DMS_TCS"] = (Convert.ToDecimal(xc["DMS_TCS"]) +Common.ConvertDecimal(xc["TCSAmount"])).ToString();


                        }
                        catch { };

                    }
                       Item["DMS_TotalAmount"] = (Common.ConvertDecimal(Item["DMS_TotalAmount"]) +Common.ConvertDecimal(xc["GrossAmount"])).ToString();
                    if (Dr != null)
                    {
                        Item["Tally_TotalAmount"] = (Common.ConvertDecimal(Item["Tally_TotalAmount"]) + Common.ConvertDecimal(Dr["GrossTotal"])).ToString();
                    }

                });
                NewReturn.Rows.Add(Item);
            }
            return NewReturn;
        }
    }
}
public partial class voucherRecoData
{

    public string DMS_GSTIN { get; set; } = "";
    public string DMS_placeOfSupply { get; set; } = "";
    public string DMS_PartyName { get; set; } = "";
    public string DMS_voucherDate { get; set; } = "";
    public string DMS_voucherNumber { get; set; } = "";
    public decimal DMS_Taxable_5 { get; set; } = 0;
    public decimal DMS_Taxable_12 { get; set; } = 0;
    public decimal DMS_Taxable_18 { get; set; } = 0;
    public decimal DMS_Taxable_28 { get; set; } = 0;
    public decimal DMS_CGST_25 { get; set; } = 0;
    public decimal DMS_CGST_6 { get; set; } = 0;
    public decimal DMS_CGST_9 { get; set; } = 0;
    public decimal DMS_CGST_14 { get; set; } = 0;
    public decimal DMS_SGST_25 { get; set; } = 0;
    public decimal DMS_SGST_6 { get; set; } = 0;
    public decimal DMS_SGST_9 { get; set; } = 0;
    public decimal DMS_SGST_14 { get; set; } = 0;
    public decimal DMS_IGST_5 { get; set; } = 0;
    public decimal DMS_IGST_12 { get; set; } = 0;
    public decimal DMS_IGST_18 { get; set; } = 0;
    public decimal DMS_IGST_28 { get; set; } = 0;
    public decimal DMS_CESS_1 { get; set; } = 0;
    public decimal DMS_CESS_17 { get; set; } = 0;
    public decimal DMS_TCS { get; set; } = 0;
    public decimal DMS_Roundoff { get; set; } = 0;
    public decimal DMS_InvAmt { get; set; } = 0;



    public string GSTIN { get; set; } = "";
    public string placeOfSupply { get; set; } = "";
    public string PartyName { get; set; } = "";
    public string voucherDate { get; set; } = "";
    public string voucherNumber { get; set; } = "";
    public decimal Taxable_5 { get; set; } = 0;
    public decimal Taxable_12 { get; set; } = 0;
    public decimal Taxable_18 { get; set; } = 0;
    public decimal Taxable_28 { get; set; } = 0;
    public decimal CGST_25 { get; set; } = 0;
    public decimal CGST_6 { get; set; } = 0;
    public decimal CGST_9 { get; set; } = 0;
    public decimal CGST_14 { get; set; } = 0;
    public decimal SGST_25 { get; set; } = 0;
    public decimal SGST_6 { get; set; } = 0;
    public decimal SGST_9 { get; set; } = 0;
    public decimal SGST_14 { get; set; } = 0;
    public decimal IGST_5 { get; set; } = 0;
    public decimal IGST_12 { get; set; } = 0;
    public decimal IGST_18 { get; set; } = 0;
    public decimal IGST_28 { get; set; } = 0;
    public decimal CESS_1 { get; set; } = 0;
    public decimal CESS_17 { get; set; } = 0;
    public decimal TCS { get; set; } = 0;
    public decimal Roundoff { get; set; } = 0;
    public decimal InvAmt { get; set; } = 0;



    public string Diff_GSTIN { get; set; } = "";
    public string Diff_placeOfSupply { get; set; } = "";
    public string Diff_PartyName { get; set; } = "";
    public string Diff_voucherDate { get; set; }
    public string Diff_voucherNumber { get; set; } = "";
    public string Diff_Taxable_5 { get; set; } = "";
    public string Diff_Taxable_12 { get; set; } = "";
    public string Diff_Taxable_18 { get; set; } = "";
    public string Diff_Taxable_28 { get; set; } = "";
    public string Diff_CGST_25 { get; set; } = "";
    public string Diff_CGST_6 { get; set; } = "";
    public string Diff_CGST_9 { get; set; } = "";
    public string Diff_CGST_14 { get; set; } = "";
    public string Diff_SGST_25 { get; set; } = "";
    public string Diff_SGST_6 { get; set; } = "";
    public string Diff_SGST_9 { get; set; } = "";
    public string Diff_SGST_14 { get; set; } = "";
    public string Diff_IGST_5 { get; set; } = "";
    public string Diff_IGST_12 { get; set; } = "";
    public string Diff_IGST_18 { get; set; } = "";
    public string Diff_IGST_28 { get; set; } = "";
    public string Diff_CESS_1 { get; set; } = "";
    public string Diff_CESS_17 { get; set; } = "";
    public string Diff_TCS { get; set; } = "";
    public string Diff_Roundoff { get; set; } = "";
    public string Diff_InvAmt { get; set; } = "";

    public string Status { get; set; } = "";




}