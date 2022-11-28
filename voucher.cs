using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WebApp.admin.ReportModal;

namespace DMStallyScheduler.TallyReadClass
{
    public class voucher
    {
        // Token: 0x1700038E RID: 910
        // (get) Token: 0x0600081D RID: 2077 RVA: 0x00013FCF File Offset: 0x000121CF
        // (set) Token: 0x0600081E RID: 2078 RVA: 0x00013FD7 File Offset: 0x000121D7




        public string InsertUpdateDB(List<voucher> objstockCategoryList, string CompName)
        {

            try
            {
             
                DataTable dt = new DataTable();
                dt.Columns.Add("voucherNumber", System.Type.GetType("System.String"));
                dt.Columns.Add("isCancelled", System.Type.GetType("System.Int32"));
                dt.Columns.Add("isOptional", System.Type.GetType("System.Int32"));
                dt.Columns.Add("voucherDate", System.Type.GetType("System.String"));
                dt.Columns.Add("voucherCreatedDate", System.Type.GetType("System.String"));
                dt.Columns.Add("effectiveDate", System.Type.GetType("System.String"));
                dt.Columns.Add("voucherType", System.Type.GetType("System.String"));
                dt.Columns.Add("voucherTypeGuid", System.Type.GetType("System.String"));
                dt.Columns.Add("voucherKey", System.Type.GetType("System.String"));
                dt.Columns.Add("guid", System.Type.GetType("System.String"));
                dt.Columns.Add("narration", System.Type.GetType("System.String"));
                dt.Columns.Add("alterId", System.Type.GetType("System.Int32"));
                dt.Columns.Add("partyLedgerName", System.Type.GetType("System.String"));
                dt.Columns.Add("partyLedgerGuid", System.Type.GetType("System.String"));
                dt.Columns.Add("partyName", System.Type.GetType("System.String"));
                dt.Columns.Add("partyGuid", System.Type.GetType("System.String"));
                dt.Columns.Add("ledgerGroup", System.Type.GetType("System.String"));
                dt.Columns.Add("ledgerGroupParent", System.Type.GetType("System.String"));
                dt.Columns.Add("reference", System.Type.GetType("System.String"));
                dt.Columns.Add("parentType", System.Type.GetType("System.String"));
                dt.Columns.Add("masterId", System.Type.GetType("System.Int32"));
                dt.Columns.Add("isInvoice", System.Type.GetType("System.String"));
                dt.Columns.Add("billOfLadingNo", System.Type.GetType("System.String"));
                dt.Columns.Add("placeOfSupply", System.Type.GetType("System.String"));
                dt.Columns.Add("conSigneegstin", System.Type.GetType("System.String"));
                dt.Columns.Add("basicShipVesselNo", System.Type.GetType("System.String"));
                dt.Columns.Add("basicOrderRef", System.Type.GetType("System.String"));
                dt.Columns.Add("basicFinalDestination", System.Type.GetType("System.String"));
                dt.Columns.Add("basicShipedBy", System.Type.GetType("System.String"));
                dt.Columns.Add("basicBuyerName", System.Type.GetType("System.String"));
                dt.Columns.Add("basicShipDocumentNo", System.Type.GetType("System.String"));
                dt.Columns.Add("basicDueDateOfPymt", System.Type.GetType("System.String"));
                dt.Columns.Add("basicDateTimeOfInvoice", System.Type.GetType("System.String"));
                dt.Columns.Add("basicDateTimeOfRemoval", System.Type.GetType("System.String"));
                dt.Columns.Add("basicBuyerAddress", System.Type.GetType("System.String"));
                dt.Columns.Add("basicShippingDate", System.Type.GetType("System.String"));
                dt.Columns.Add("basicShipDeliveryNote", System.Type.GetType("System.String"));
                dt.Columns.Add("basicOrderDate", System.Type.GetType("System.String"));
                dt.Columns.Add("basicPurchaseOrderNo", System.Type.GetType("System.String"));
                dt.Columns.Add("basicOrderTerms", System.Type.GetType("System.String"));
                dt.Columns.Add("partygstIn", System.Type.GetType("System.String"));
                dt.Columns.Add("invoiceDelNotes", System.Type.GetType("System.String"));
                dt.Columns.Add("invoiceOrders", System.Type.GetType("System.String"));
                dt.Columns.Add("ledgerEntries", System.Type.GetType("System.String"));
                dt.Columns.Add("StockItemEntries", System.Type.GetType("System.String"));
                dt.Columns.Add("eWayBillDetails", System.Type.GetType("System.String"));



                objstockCategoryList.ToList().ForEach(p =>
                {
                    DataRow dr = dt.NewRow();
                    dr["voucherNumber"] = p.voucherNumber;
                    dr["isCancelled"] = p.isCancelled;
                    dr["isOptional"] = p.isOptional;
                    dr["voucherDate"] = p.voucherDate == null ? "null" : p.voucherDate.ToString("dd-MMM-yyyy");
                    dr["voucherCreatedDate"] = p.voucherCreatedDate == null ? "null" : p.voucherCreatedDate.ToString("dd-MMM-yyyy");
                    dr["effectiveDate"] = p.effectiveDate == null ? "null" : p.effectiveDate.ToString("dd-MMM-yyyy");
                    dr["voucherType"] = p.voucherType;
                    dr["voucherTypeGuid"] = p.voucherTypeGuid;
                    dr["voucherKey"] = p.voucherKey;
                    dr["guid"] = p.guid;
                    dr["narration"] = p.narration;
                    dr["alterId"] = p.alterId;
                    dr["partyLedgerName"] = p.partyLedgerName;
                    dr["partyLedgerGuid"] = p.partyLedgerGuid;
                    dr["partyName"] = p.partyName;
                    dr["partyGuid"] = p.partyGuid;
                    dr["ledgerGroup"] = p.ledgerGroup;
                    dr["ledgerGroupParent"] = p.ledgerGroupParent;
                    dr["reference"] = p.reference;
                    dr["parentType"] = p.parentType;
                    dr["masterId"] = p.masterId;
                    dr["isInvoice"] = p.isInvoice;
                    dr["billOfLadingNo"] = p.billOfLadingNo;
                    dr["placeOfSupply"] = p.placeOfSupply;
                    dr["conSigneegstin"] = p.conSigneegstin;
                    dr["basicShipVesselNo"] = p.basicShipVesselNo;
                    dr["basicOrderRef"] = p.basicOrderRef;
                    dr["basicFinalDestination"] = p.basicFinalDestination;
                    dr["basicShipedBy"] = p.basicShipedBy;
                    dr["basicBuyerName"] = p.basicBuyerName;
                    dr["basicShipDocumentNo"] = p.basicShipDocumentNo;
                    dr["basicDueDateOfPymt"] = p.basicDueDateOfPymt;
                    dr["basicDateTimeOfInvoice"] = p.basicDateTimeOfInvoice;
                    dr["basicDateTimeOfRemoval"] = p.basicDateTimeOfRemoval;
                    dr["basicBuyerAddress"] = p.basicBuyerAddress;
                    dr["basicShippingDate"] = p.basicShippingDate ==null?"null": p.basicShippingDate.ToString("dd-MMM-yyyy");
                    dr["basicShipDeliveryNote"] = p.basicShipDeliveryNote;
                    dr["basicOrderDate"] = p.basicOrderDate == null ? "null" : p.basicOrderDate.ToString("dd-MMM-yyyy");
                    dr["basicPurchaseOrderNo"] = p.basicPurchaseOrderNo;
                    dr["basicOrderTerms"] = p.basicOrderTerms;
                    dr["partygstIn"] = p.partygstIn;


                  

                    if (p.invoiceDelNotes != null)
                    {
                        dr["invoiceDelNotes"] = JsonConvert.SerializeObject(p.invoiceDelNotes);

                    }
                    else {
                        dr["invoiceDelNotes"] = "";
                    }


                    if (p.eWayBillDetails != null)
                    {
                        dr["eWayBillDetails"] = JsonConvert.SerializeObject(p.eWayBillDetails);

                    }
                    else {
                        dr["eWayBillDetails"] = "";
                    }


                    if (p.StockItemEntries != null)
                    {
                        //p.StockItemEntries.re
                        

                        dr["StockItemEntries"] = JsonConvert.SerializeObject(p.StockItemEntries);

                    }
                    else {
                        dr["StockItemEntries"] = "";
                    }

                    if (p.ledgerEntries != null)
                    {
                        dr["ledgerEntries"] = JsonConvert.SerializeObject(p.ledgerEntries);

                    }
                    else {
                        dr["ledgerEntries"] = "";
                    }



                    if (p.invoiceOrders != null)
                    {
                        dr["invoiceOrders"] = JsonConvert.SerializeObject(p.invoiceOrders);

                    }
                    else {
                        dr["invoiceOrders"] = "";
                    }


                    dt.Rows.Add(dr);


                });
                OtherSqlConn.SpExcute("Importvoucher", dt, CompName);

                return "successfully";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }




        public int companyId { get; set; }

        // Token: 0x1700038F RID: 911
        // (get) Token: 0x0600081F RID: 2079 RVA: 0x00013FE0 File Offset: 0x000121E0
        // (set) Token: 0x06000820 RID: 2080 RVA: 0x00013FE8 File Offset: 0x000121E8
    
        public object company_id { get; set; }

        // Token: 0x17000390 RID: 912
        // (get) Token: 0x06000821 RID: 2081 RVA: 0x00013FF1 File Offset: 0x000121F1
        // (set) Token: 0x06000822 RID: 2082 RVA: 0x00013FF9 File Offset: 0x000121F9
        public string voucherNumber { get; set; }

        // Token: 0x17000391 RID: 913
        // (get) Token: 0x06000823 RID: 2083 RVA: 0x00014002 File Offset: 0x00012202
        // (set) Token: 0x06000824 RID: 2084 RVA: 0x0001400A File Offset: 0x0001220A
        
        public bool isCancelled { get; set; }

        // Token: 0x17000392 RID: 914
        // (get) Token: 0x06000825 RID: 2085 RVA: 0x00014013 File Offset: 0x00012213
        // (set) Token: 0x06000826 RID: 2086 RVA: 0x0001401B File Offset: 0x0001221B
        public bool isOptional { get; set; }

        // Token: 0x17000393 RID: 915
        // (get) Token: 0x06000827 RID: 2087 RVA: 0x00014024 File Offset: 0x00012224
        // (set) Token: 0x06000828 RID: 2088 RVA: 0x0001402C File Offset: 0x0001222C
        public DateTime voucherDate { get; set; }

        // Token: 0x17000394 RID: 916
        // (get) Token: 0x06000829 RID: 2089 RVA: 0x00014035 File Offset: 0x00012235
        // (set) Token: 0x0600082A RID: 2090 RVA: 0x0001403D File Offset: 0x0001223D
        
        public DateTime voucherCreatedDate { get; set; }

        // Token: 0x17000395 RID: 917
        // (get) Token: 0x0600082B RID: 2091 RVA: 0x00014046 File Offset: 0x00012246
        // (set) Token: 0x0600082C RID: 2092 RVA: 0x0001404E File Offset: 0x0001224E
        public DateTime effectiveDate { get; set; }

        // Token: 0x17000396 RID: 918
        // (get) Token: 0x0600082D RID: 2093 RVA: 0x00014057 File Offset: 0x00012257
        // (set) Token: 0x0600082E RID: 2094 RVA: 0x0001405F File Offset: 0x0001225F
     
        public string voucherType { get; set; }

        // Token: 0x17000397 RID: 919
        // (get) Token: 0x0600082F RID: 2095 RVA: 0x00014068 File Offset: 0x00012268
        // (set) Token: 0x06000830 RID: 2096 RVA: 0x00014070 File Offset: 0x00012270
       
        public string voucherTypeGuid { get; set; }

        // Token: 0x17000398 RID: 920
        // (get) Token: 0x06000831 RID: 2097 RVA: 0x00014079 File Offset: 0x00012279
        // (set) Token: 0x06000832 RID: 2098 RVA: 0x00014081 File Offset: 0x00012281
      
        public string voucherKey { get; set; }

        // Token: 0x17000399 RID: 921
        // (get) Token: 0x06000833 RID: 2099 RVA: 0x0001408A File Offset: 0x0001228A
        // (set) Token: 0x06000834 RID: 2100 RVA: 0x00014092 File Offset: 0x00012292

        public string guid { get; set; }

        // Token: 0x1700039A RID: 922
        // (get) Token: 0x06000835 RID: 2101 RVA: 0x0001409B File Offset: 0x0001229B
        // (set) Token: 0x06000836 RID: 2102 RVA: 0x000140A3 File Offset: 0x000122A3
        
        public string narration { get; set; }

        // Token: 0x1700039B RID: 923
        // (get) Token: 0x06000837 RID: 2103 RVA: 0x000140AC File Offset: 0x000122AC
        // (set) Token: 0x06000838 RID: 2104 RVA: 0x000140B4 File Offset: 0x000122B4
        
        public int alterId { get; set; }

        // Token: 0x1700039C RID: 924
        // (get) Token: 0x06000839 RID: 2105 RVA: 0x000140BD File Offset: 0x000122BD
        // (set) Token: 0x0600083A RID: 2106 RVA: 0x000140C5 File Offset: 0x000122C5
       
        public string partyLedgerName { get; set; }

        // Token: 0x1700039D RID: 925
        // (get) Token: 0x0600083B RID: 2107 RVA: 0x000140CE File Offset: 0x000122CE
        // (set) Token: 0x0600083C RID: 2108 RVA: 0x000140D6 File Offset: 0x000122D6
     
        public string partyLedgerGuid { get; set; }

        // Token: 0x1700039E RID: 926
        // (get) Token: 0x0600083D RID: 2109 RVA: 0x000140DF File Offset: 0x000122DF
        // (set) Token: 0x0600083E RID: 2110 RVA: 0x000140E7 File Offset: 0x000122E7
      
        public string partyName { get; set; }

        // Token: 0x1700039F RID: 927
        // (get) Token: 0x0600083F RID: 2111 RVA: 0x000140F0 File Offset: 0x000122F0
        // (set) Token: 0x06000840 RID: 2112 RVA: 0x000140F8 File Offset: 0x000122F8
        
        public string partyGuid { get; set; }

        // Token: 0x170003A0 RID: 928
        // (get) Token: 0x06000841 RID: 2113 RVA: 0x00014101 File Offset: 0x00012301
        // (set) Token: 0x06000842 RID: 2114 RVA: 0x00014109 File Offset: 0x00012309
       
        public string ledgerGroup { get; set; }

        // Token: 0x170003A1 RID: 929
        // (get) Token: 0x06000843 RID: 2115 RVA: 0x00014112 File Offset: 0x00012312
        // (set) Token: 0x06000844 RID: 2116 RVA: 0x0001411A File Offset: 0x0001231A
        
        public string ledgerGroupParent { get; set; }

        // Token: 0x170003A2 RID: 930
        // (get) Token: 0x06000845 RID: 2117 RVA: 0x00014123 File Offset: 0x00012323
        // (set) Token: 0x06000846 RID: 2118 RVA: 0x0001412B File Offset: 0x0001232B
     
        public string reference { get; set; }

        // Token: 0x170003A3 RID: 931
        // (get) Token: 0x06000847 RID: 2119 RVA: 0x00014134 File Offset: 0x00012334
        // (set) Token: 0x06000848 RID: 2120 RVA: 0x0001413C File Offset: 0x0001233C
        
        public string parentType { get; set; }

        // Token: 0x170003A4 RID: 932
        // (get) Token: 0x06000849 RID: 2121 RVA: 0x00014145 File Offset: 0x00012345
        // (set) Token: 0x0600084A RID: 2122 RVA: 0x0001414D File Offset: 0x0001234D
       
        public int masterId { get; set; }

        // Token: 0x170003A5 RID: 933
        // (get) Token: 0x0600084B RID: 2123 RVA: 0x00014156 File Offset: 0x00012356
        // (set) Token: 0x0600084C RID: 2124 RVA: 0x0001415E File Offset: 0x0001235E
     
        public string isInvoice { get; set; }

        // Token: 0x170003A6 RID: 934
        // (get) Token: 0x0600084D RID: 2125 RVA: 0x00014167 File Offset: 0x00012367
        // (set) Token: 0x0600084E RID: 2126 RVA: 0x0001416F File Offset: 0x0001236F
       
        public string billOfLadingNo { get; set; }

        // Token: 0x170003A7 RID: 935
        // (get) Token: 0x0600084F RID: 2127 RVA: 0x00014178 File Offset: 0x00012378
        // (set) Token: 0x06000850 RID: 2128 RVA: 0x00014180 File Offset: 0x00012380
       
        public string placeOfSupply { get; set; }

        // Token: 0x170003A8 RID: 936
        // (get) Token: 0x06000851 RID: 2129 RVA: 0x00014189 File Offset: 0x00012389
        // (set) Token: 0x06000852 RID: 2130 RVA: 0x00014191 File Offset: 0x00012391
        public string conSigneegstin { get; set; }

        // Token: 0x170003A9 RID: 937
        // (get) Token: 0x06000853 RID: 2131 RVA: 0x0001419A File Offset: 0x0001239A
        // (set) Token: 0x06000854 RID: 2132 RVA: 0x000141A2 File Offset: 0x000123A2
        public string basicShipVesselNo { get; set; }

        // Token: 0x170003AA RID: 938
        // (get) Token: 0x06000855 RID: 2133 RVA: 0x000141AB File Offset: 0x000123AB
        // (set) Token: 0x06000856 RID: 2134 RVA: 0x000141B3 File Offset: 0x000123B3
        public string basicOrderRef { get; set; }

        // Token: 0x170003AB RID: 939
        // (get) Token: 0x06000857 RID: 2135 RVA: 0x000141BC File Offset: 0x000123BC
        // (set) Token: 0x06000858 RID: 2136 RVA: 0x000141C4 File Offset: 0x000123C4
        public string basicFinalDestination { get; set; }

        // Token: 0x170003AC RID: 940
        // (get) Token: 0x06000859 RID: 2137 RVA: 0x000141CD File Offset: 0x000123CD
        // (set) Token: 0x0600085A RID: 2138 RVA: 0x000141D5 File Offset: 0x000123D5
        public string basicShipedBy { get; set; }

        // Token: 0x170003AD RID: 941
        // (get) Token: 0x0600085B RID: 2139 RVA: 0x000141DE File Offset: 0x000123DE
        // (set) Token: 0x0600085C RID: 2140 RVA: 0x000141E6 File Offset: 0x000123E6
        
        public string basicBuyerName { get; set; }

        // Token: 0x170003AE RID: 942
        // (get) Token: 0x0600085D RID: 2141 RVA: 0x000141EF File Offset: 0x000123EF
        // (set) Token: 0x0600085E RID: 2142 RVA: 0x000141F7 File Offset: 0x000123F7
        public string basicShipDocumentNo { get; set; }

        // Token: 0x170003AF RID: 943
        // (get) Token: 0x0600085F RID: 2143 RVA: 0x00014200 File Offset: 0x00012400
        // (set) Token: 0x06000860 RID: 2144 RVA: 0x00014208 File Offset: 0x00012408
      
        public string basicDueDateOfPymt { get; set; }

        // Token: 0x170003B0 RID: 944
        // (get) Token: 0x06000861 RID: 2145 RVA: 0x00014211 File Offset: 0x00012411
        // (set) Token: 0x06000862 RID: 2146 RVA: 0x00014219 File Offset: 0x00012419
      public string basicDateTimeOfInvoice { get; set; }

        // Token: 0x170003B1 RID: 945
        // (get) Token: 0x06000863 RID: 2147 RVA: 0x00014222 File Offset: 0x00012422
        // (set) Token: 0x06000864 RID: 2148 RVA: 0x0001422A File Offset: 0x0001242A
        public string basicDateTimeOfRemoval { get; set; }

        // Token: 0x170003B2 RID: 946
        // (get) Token: 0x06000865 RID: 2149 RVA: 0x00014233 File Offset: 0x00012433
        // (set) Token: 0x06000866 RID: 2150 RVA: 0x0001423B File Offset: 0x0001243B
        public string basicBuyerAddress { get; set; }

        // Token: 0x170003B3 RID: 947
        // (get) Token: 0x06000867 RID: 2151 RVA: 0x00014244 File Offset: 0x00012444
        // (set) Token: 0x06000868 RID: 2152 RVA: 0x0001424C File Offset: 0x0001244C
        public string basicSenderAddress { get; set; }

        // Token: 0x170003B4 RID: 948
        // (get) Token: 0x06000869 RID: 2153 RVA: 0x00014255 File Offset: 0x00012455
        // (set) Token: 0x0600086A RID: 2154 RVA: 0x0001425D File Offset: 0x0001245D
       
        public DateTime basicShippingDate { get; set; }

        // Token: 0x170003B5 RID: 949
        // (get) Token: 0x0600086B RID: 2155 RVA: 0x00014266 File Offset: 0x00012466
        // (set) Token: 0x0600086C RID: 2156 RVA: 0x0001426E File Offset: 0x0001246E
       
        public string basicShipDeliveryNote { get; set; }

        // Token: 0x170003B6 RID: 950
        // (get) Token: 0x0600086D RID: 2157 RVA: 0x00014277 File Offset: 0x00012477
        // (set) Token: 0x0600086E RID: 2158 RVA: 0x0001427F File Offset: 0x0001247F
       
        public DateTime basicOrderDate { get; set; }

        // Token: 0x170003B7 RID: 951
        // (get) Token: 0x0600086F RID: 2159 RVA: 0x00014288 File Offset: 0x00012488
        // (set) Token: 0x06000870 RID: 2160 RVA: 0x00014290 File Offset: 0x00012490
      
        public string basicPurchaseOrderNo { get; set; }

        // Token: 0x170003B8 RID: 952
        // (get) Token: 0x06000871 RID: 2161 RVA: 0x00014299 File Offset: 0x00012499
        // (set) Token: 0x06000872 RID: 2162 RVA: 0x000142A1 File Offset: 0x000124A1
      
        public string basicOrderTerms { get; set; }

        // Token: 0x170003B9 RID: 953
        // (get) Token: 0x06000873 RID: 2163 RVA: 0x000142AA File Offset: 0x000124AA
        // (set) Token: 0x06000874 RID: 2164 RVA: 0x000142B2 File Offset: 0x000124B2
      
        public string partygstIn { get; set; }

        // Token: 0x170003BA RID: 954
        // (get) Token: 0x06000875 RID: 2165 RVA: 0x000142BB File Offset: 0x000124BB
        // (set) Token: 0x06000876 RID: 2166 RVA: 0x000142C3 File Offset: 0x000124C3
        public List<voucher.invoiceDelNote> invoiceDelNotes { get; set; }

        // Token: 0x170003BB RID: 955
        // (get) Token: 0x06000877 RID: 2167 RVA: 0x000142CC File Offset: 0x000124CC
        // (set) Token: 0x06000878 RID: 2168 RVA: 0x000142D4 File Offset: 0x000124D4
        public List<voucher.invoiceOrder> invoiceOrders { get; set; }

        // Token: 0x170003BC RID: 956
        // (get) Token: 0x06000879 RID: 2169 RVA: 0x000142DD File Offset: 0x000124DD
        // (set) Token: 0x0600087A RID: 2170 RVA: 0x000142E5 File Offset: 0x000124E5
        public List<voucher.ledgerEntry> ledgerEntries { get; set; }

        // Token: 0x170003BD RID: 957
        // (get) Token: 0x0600087B RID: 2171 RVA: 0x000142EE File Offset: 0x000124EE
        // (set) Token: 0x0600087C RID: 2172 RVA: 0x000142F6 File Offset: 0x000124F6
        public List<voucher.StockItemEntry> StockItemEntries { get; set; }

        // Token: 0x170003BE RID: 958
        // (get) Token: 0x0600087D RID: 2173 RVA: 0x000142FF File Offset: 0x000124FF
        // (set) Token: 0x0600087E RID: 2174 RVA: 0x00014307 File Offset: 0x00012507
        public List<voucher.eWayBillDetail> eWayBillDetails { get; set; }

        // Token: 0x0600087F RID: 2175 RVA: 0x00014310 File Offset: 0x00012510
        //public response findandUpdateManyVoucher(List<voucher> objvoucherList, int companyId)
        //{
        //    response response = new response();
        //    response result;
        //    try
        //    {
        //        this.conn = new mongoConnection();
        //        this.db = this.conn._database;
        //        IMongoCollection<BsonDocument> collection = this.db.GetCollection<BsonDocument>("vouchers", null);
        //        WriteModel<BsonDocument>[] array = new WriteModel<BsonDocument>[objvoucherList.Count];
        //        for (int i = 0; i < objvoucherList.Count; i++)
        //        {
        //            FilterDefinitionBuilder<BsonDocument> filter = Builders<BsonDocument>.Filter;
        //            FilterDefinition<BsonDocument> filter2 = filter.Eq<string>("guid", objvoucherList[i].guid) & filter.Eq<int>("companyId", companyId);
        //            BsonDocument replacement = objvoucherList[i].ToBsonDocument(null, null, default(BsonSerializationArgs));
        //            array[i] = new ReplaceOneModel<BsonDocument>(filter2, replacement)
        //            {
        //                IsUpsert = true
        //            };
        //        }
        //        collection.BulkWriteAsync(array, null, default(CancellationToken));
        //        response.status = 1;
        //        response.message = "vouchers updated successfully";
        //        result = response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.status = 0;
        //        response.message = ex.Message;
        //        response.data = ex.StackTrace;
        //        result = response;
        //    }
        //    return result;
        //}

        //// Token: 0x06000880 RID: 2176 RVA: 0x00014444 File Offset: 0x00012644
        //public response deleteVouchers(int companyId)
        //{
        //    response response = new response();
        //    response result;
        //    try
        //    {
        //        this.conn = new mongoConnection();
        //        this.db = this.conn._database;
        //        IMongoCollection<voucher> collection = this.db.GetCollection<voucher>("vouchers", null);
        //        BsonDocument document = new BsonDocument("companyId", companyId);
        //        collection.DeleteMany(document, default(CancellationToken));
        //        response.status = 1;
        //        response.message = "Vouchers deleted successfully";
        //        result = response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.status = 0;
        //        response.message = ex.Message;
        //        response.data = ex.StackTrace;
        //        result = response;
        //    }
        //    return result;
        //}

        //// Token: 0x06000881 RID: 2177 RVA: 0x000144FC File Offset: 0x000126FC
        //public response deleteSyncedVouchers(int companyId, DateTime fromDate)
        //{
        //    response response = new response();
        //    response result;
        //    try
        //    {
        //        this.conn = new mongoConnection();
        //        this.db = this.conn._database;
        //        IMongoCollection<BsonDocument> collection = this.db.GetCollection<BsonDocument>("vouchers", null);
        //        FilterDefinitionBuilder<BsonDocument> filter = Builders<BsonDocument>.Filter;
        //        FilterDefinition<BsonDocument> filter2 = filter.Eq<int>("companyId", companyId) & filter.Gte<DateTime>("voucherDate", fromDate);
        //        DeleteResult deleteResult = collection.DeleteMany(filter2, default(CancellationToken));
        //        response.status = 1;
        //        response.data = deleteResult.DeletedCount;
        //        response.message = "vouchers deleted successfully";
        //        result = response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.status = 0;
        //        response.message = ex.Message;
        //        response.data = ex.StackTrace;
        //        result = response;
        //    }
        //    return result;
        //}

        //// Token: 0x06000882 RID: 2178 RVA: 0x000145E4 File Offset: 0x000127E4
        //public response findandUpdateManyVoucherTypeOfVoucher(string vouchertype, string newvoucherType, int companyId)
        //{
        //    response response = new response();
        //    response result;
        //    try
        //    {
        //        this.conn = new mongoConnection();
        //        this.db = this.conn._database;
        //        IMongoCollection<BsonDocument> collection = this.db.GetCollection<BsonDocument>("vouchers", null);
        //        FilterDefinitionBuilder<BsonDocument> filter = Builders<BsonDocument>.Filter;
        //        FilterDefinition<BsonDocument> filter2 = filter.Eq<string>("voucherType", vouchertype) & filter.Eq<int>("companyId", companyId);
        //        string json = "{$set: {parentType:'" + newvoucherType + "'}}";
        //        collection.UpdateManyAsync(filter2, json, null, default(CancellationToken));
        //        response.status = 1;
        //        response.message = "vouchers updated successfully.";
        //        result = response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.status = 0;
        //        response.message = ex.Message;
        //        response.data = ex.StackTrace;
        //        result = response;
        //    }
        //    return result;
        //}

        //// Token: 0x06000883 RID: 2179 RVA: 0x000146D0 File Offset: 0x000128D0
        //public response updateManyVouchers124to125(List<voucher> objvoucherList)
        //{
        //    response response = new response();
        //    response result;
        //    try
        //    {
        //        this.conn = new mongoConnection();
        //        this.db = this.conn._database;
        //        IMongoCollection<BsonDocument> collection = this.db.GetCollection<BsonDocument>("vouchers", null);
        //        WriteModel<BsonDocument>[] array = new WriteModel<BsonDocument>[objvoucherList.Count];
        //        WriteModel<BsonDocument>[] array2 = new WriteModel<BsonDocument>[objvoucherList.Count];
        //        WriteModel<BsonDocument>[] array3 = new WriteModel<BsonDocument>[objvoucherList.Count];
        //        for (int i = 0; i < objvoucherList.Count; i++)
        //        {
        //            FilterDefinitionBuilder<BsonDocument> filter = Builders<BsonDocument>.Filter;
        //            FilterDefinition<BsonDocument> filter2 = filter.Eq<string>("guid", objvoucherList[i].guid) & filter.Eq<int>("companyId", objvoucherList[i].companyId);
        //            BsonDocument obj = new BsonDocument
        //            {
        //                {
        //                    "$set",
        //                    new BsonDocument
        //                    {
        //                        {
        //                            "partygstIn",
        //                            objvoucherList[i].partygstIn
        //                        },
        //                        {
        //                            "basicBuyerAddress",
        //                            objvoucherList[i].basicBuyerAddress
        //                        },
        //                        {
        //                            "basicSenderAddress",
        //                            objvoucherList[i].basicSenderAddress
        //                        }
        //                    }
        //                }
        //            };
        //            UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set<BsonArray>("eWayBillDetails", new BsonArray(new voucher.eWayBillDetail[0])).Set("StockItemEntries", new BsonArray(new voucher.StockItemEntry[0]));
        //            UpdateDefinition<BsonDocument> update2 = Builders<BsonDocument>.Update.PushEach<voucher.eWayBillDetail>("eWayBillDetails", objvoucherList[i].eWayBillDetails, null, null, null).PushEach("StockItemEntries", objvoucherList[i].StockItemEntries, null, null, null);
        //            array2[i] = new UpdateOneModel<BsonDocument>(filter2, update);
        //            array3[i] = new UpdateOneModel<BsonDocument>(filter2, update2);
        //            array[i] = new UpdateManyModel<BsonDocument>(filter2, obj.ToBsonDocument(null, null, default(BsonSerializationArgs)));
        //        }
        //        collection.BulkWrite(array, null, default(CancellationToken));
        //        collection.BulkWrite(array2, null, default(CancellationToken));
        //        collection.BulkWrite(array3, null, default(CancellationToken));
        //        response.status = 1;
        //        response.message = "vouchers updated successfully";
        //        result = response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.status = 0;
        //        response.message = ex.Message;
        //        response.data = ex.StackTrace;
        //        result = response;
        //    }
        //    return result;
        //}

        //// Token: 0x06000884 RID: 2180 RVA: 0x00014994 File Offset: 0x00012B94
        //public response updateManyVouchers125to126(List<voucher> objvoucherList)
        //{
        //    response response = new response();
        //    response result;
        //    try
        //    {
        //        this.conn = new mongoConnection();
        //        this.db = this.conn._database;
        //        IMongoCollection<BsonDocument> collection = this.db.GetCollection<BsonDocument>("vouchers", null);
        //        WriteModel<BsonDocument>[] array = new WriteModel<BsonDocument>[objvoucherList.Count];
        //        WriteModel<BsonDocument>[] array2 = new WriteModel<BsonDocument>[objvoucherList.Count];
        //        for (int i = 0; i < objvoucherList.Count; i++)
        //        {
        //            FilterDefinitionBuilder<BsonDocument> filter = Builders<BsonDocument>.Filter;
        //            FilterDefinition<BsonDocument> filter2 = filter.Eq<string>("guid", objvoucherList[i].guid) & filter.Eq<int>("companyId", objvoucherList[i].companyId);
        //            UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set<BsonArray>("eWayBillDetails", new BsonArray(new voucher.eWayBillDetail[0])).Set("StockItemEntries", new BsonArray(new voucher.StockItemEntry[0]));
        //            UpdateDefinition<BsonDocument> update2 = Builders<BsonDocument>.Update.PushEach<voucher.eWayBillDetail>("eWayBillDetails", objvoucherList[i].eWayBillDetails, null, null, null).PushEach("StockItemEntries", objvoucherList[i].StockItemEntries, null, null, null);
        //            array[i] = new UpdateOneModel<BsonDocument>(filter2, update);
        //            array2[i] = new UpdateOneModel<BsonDocument>(filter2, update2);
        //        }
        //        collection.BulkWrite(array, null, default(CancellationToken));
        //        collection.BulkWrite(array2, null, default(CancellationToken));
        //        response.status = 1;
        //        response.message = "vouchers updated successfully";
        //        result = response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.status = 0;
        //        response.message = ex.Message;
        //        response.data = ex.StackTrace;
        //        result = response;
        //    }
        //    return result;
        //}

        // Token: 0x06000885 RID: 2181 RVA: 0x00014B94 File Offset: 0x00012D94
        //public response deleteVouchersBasedGuid(int companyId, List<string> voucherGuids, DateTime voucherDate)
        //{
        //    response response = new response();
        //    response result;
        //    try
        //    {
        //        this.conn = new mongoConnection();
        //        this.db = this.conn._database;
        //        IMongoCollection<BsonDocument> collection = this.db.GetCollection<BsonDocument>("vouchers", null);
        //        new BsonDocument("companyId", companyId);
        //        FilterDefinitionBuilder<BsonDocument> filter = Builders<BsonDocument>.Filter;
        //        FilterDefinition<BsonDocument> filter2 = filter.Eq<int>("companyId", companyId) & filter.Gte<DateTime>("voucherDate", voucherDate) & filter.Nin<string>("guid", voucherGuids);
        //        DeleteResult deleteResult = collection.DeleteMany(filter2, default(CancellationToken));
        //        response.status = 1;
        //        response.data = deleteResult.DeletedCount;
        //        response.message = "Vouchers deleted successfully";
        //        result = response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.status = 0;
        //        response.message = ex.Message;
        //        response.data = ex.StackTrace;
        //        result = response;
        //    }
        //    return result;
        //}

        // Token: 0x06000886 RID: 2182 RVA: 0x00014CA0 File Offset: 0x00012EA0
        //public response updateVoucherNumbers(List<voucher> objvoucherList, int companyId)
        //{
        //    response response = new response();
        //    response result;
        //    try
        //    {
        //        this.conn = new mongoConnection();
        //        this.db = this.conn._database;
        //        IMongoCollection<BsonDocument> collection = this.db.GetCollection<BsonDocument>("vouchers", null);
        //        WriteModel<BsonDocument>[] array = new WriteModel<BsonDocument>[objvoucherList.Count];
        //        for (int i = 0; i < objvoucherList.Count; i++)
        //        {
        //            FilterDefinitionBuilder<BsonDocument> filter = Builders<BsonDocument>.Filter;
        //            FilterDefinition<BsonDocument> filter2 = filter.Eq<string>("guid", objvoucherList[i].guid) & filter.Eq<int>("companyId", companyId);
        //            BsonDocument obj = new BsonDocument
        //            {
        //                {
        //                    "$set",
        //                    new BsonDocument
        //                    {
        //                        {
        //                            "voucherNumber",
        //                            objvoucherList[i].voucherNumber
        //                        }
        //                    }
        //                }
        //            };
        //            array[i] = new UpdateManyModel<BsonDocument>(filter2, obj.ToBsonDocument(null, null, default(BsonSerializationArgs)));
        //        }
        //        collection.BulkWrite(array, null, default(CancellationToken));
        //        response.status = 1;
        //        response.message = "vouchers updated successfully";
        //        result = response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.status = 0;
        //        response.message = ex.Message;
        //        response.data = ex.StackTrace;
        //        result = response;
        //    }
        //    return result;
        //}

        // Token: 0x0400040C RID: 1036
     

        // Token: 0x0200006E RID: 110
        public class ledgerEntry
        {
            // Token: 0x170003BF RID: 959
            // (get) Token: 0x06000888 RID: 2184 RVA: 0x00014E27 File Offset: 0x00013027
            // (set) Token: 0x06000889 RID: 2185 RVA: 0x00014E2F File Offset: 0x0001302F
         
            public string ledgerName { get; set; }

            // Token: 0x170003C0 RID: 960
            // (get) Token: 0x0600088A RID: 2186 RVA: 0x00014E38 File Offset: 0x00013038
            // (set) Token: 0x0600088B RID: 2187 RVA: 0x00014E40 File Offset: 0x00013040
        
            public string ledgerGuid { get; set; }

            // Token: 0x170003C1 RID: 961
            // (get) Token: 0x0600088C RID: 2188 RVA: 0x00014E49 File Offset: 0x00013049
            // (set) Token: 0x0600088D RID: 2189 RVA: 0x00014E51 File Offset: 0x00013051
            public decimal amount { get; set; }

            // Token: 0x170003C2 RID: 962
            // (get) Token: 0x0600088E RID: 2190 RVA: 0x00014E5A File Offset: 0x0001305A
            // (set) Token: 0x0600088F RID: 2191 RVA: 0x00014E62 File Offset: 0x00013062
        
            public string ledgerGroup { get; set; }

            // Token: 0x170003C3 RID: 963
            // (get) Token: 0x06000890 RID: 2192 RVA: 0x00014E6B File Offset: 0x0001306B
            // (set) Token: 0x06000891 RID: 2193 RVA: 0x00014E73 File Offset: 0x00013073
        
            public string ledgerGroupParent { get; set; }

            // Token: 0x170003C4 RID: 964
            // (get) Token: 0x06000892 RID: 2194 RVA: 0x00014E7C File Offset: 0x0001307C
            // (set) Token: 0x06000893 RID: 2195 RVA: 0x00014E84 File Offset: 0x00013084
            public List<voucher.bankAllocationdetail> bankAllocationDetails { get; set; }

            // Token: 0x170003C5 RID: 965
            // (get) Token: 0x06000894 RID: 2196 RVA: 0x00014E8D File Offset: 0x0001308D
            // (set) Token: 0x06000895 RID: 2197 RVA: 0x00014E95 File Offset: 0x00013095
            public List<voucher.billAllocationdetail> billAllocationdetails { get; set; }

            // Token: 0x170003C6 RID: 966
            // (get) Token: 0x06000896 RID: 2198 RVA: 0x00014E9E File Offset: 0x0001309E
            // (set) Token: 0x06000897 RID: 2199 RVA: 0x00014EA6 File Offset: 0x000130A6
            public string descriptions { get; set; }
        }


        public class ACCOUNTINGALLOCATIONSLISTs
        {
            
            public object ORIGPURCHINVDATE { get; set; }
            public object NARRATION { get; set; }
            public object ADDLALLOCTYPE { get; set; }
            public object TAXCLASSIFICATIONNAME { get; set; }
            public object NOTIFICATIONSLNO { get; set; }
            public object SWIFTCODE { get; set; }
            public object ROUNDTYPE { get; set; }
            public string LEDGERNAME { get; set; }
            public object TAXUNITNAME { get; set; }
            public object STATNATURENAME { get; set; }
            public object GOODSTYPE { get; set; }
            public object METHODTYPE { get; set; }
            public object CLASSRATE { get; set; }
            public object STATCLASSIFICATIONNAME { get; set; }
            public object EXCISECLASSIFICATIONNAME { get; set; }
            public object ISZRBASICSERVICE { get; set; }
            public object VATCOMMODITYNAME { get; set; }
            public object SCHEDULE { get; set; }
            public object SCHEDULESERIALNUMBER { get; set; }
            public object VATCOMMODITYCODE { get; set; }
            public object VATSUBCOMMODITYCODE { get; set; }
            public object VATTRADENAME { get; set; }
            public object VATMAJORCOMMODITYNAME { get; set; }
            public object TDSPARTYNAME { get; set; }
            public object VATPARTYORGNAME { get; set; }
            public object XBRLADJTYPE { get; set; }
            public object VOUCHERFBTCATEGORY { get; set; }
            public object TYPEOFTAXPAYMENT { get; set; }
            public object VATCALCULATIONTYPE { get; set; }
            public object VATWORKSCONTRACTTYPE { get; set; }
            public object VATWCDESCRIPTION { get; set; }
            public string GSTCLASS { get; set; }
            public object SCHVIADJTYPE { get; set; }
            public object GSTOVRDNCLASSIFICATION { get; set; }
            public string GSTOVRDNNATURE { get; set; }
            public object GSTOVRDNINELIGIBLEITC { get; set; }
            public object GSTOVRDNISREVCHARGEAPPL { get; set; }
            public object GSTOVRDNTAXABILITY { get; set; }
            public object GSTHSNSACCODE { get; set; }
            public object VATGOODSNATURE { get; set; }
            public object POSPAYMENTTYPE { get; set; }
            public object GSTPARTYLEDGER { get; set; }
            public object ORIGPURCHPARTY { get; set; }
            public object ORIGPURCHPARTYADDRESS { get; set; }
            public object ORIGPURCHINVNO { get; set; }
            public object ORIGPURCHNOTE { get; set; }
            public string ISDEEMEDPOSITIVE { get; set; }
            public string LEDGERFROMITEM { get; set; }
            public object REMOVEZEROENTRIES { get; set; }
            public string ISPARTYLEDGER { get; set; }
            public string ISLASTDEEMEDPOSITIVE { get; set; }
            public object ISCAPVATTAXALTERED { get; set; }
            public string ISCAPVATNOTCLAIMED { get; set; }
            public string STCRADJPERCENT { get; set; }
            public string ROUNDLIMIT { get; set; }
            public string RATEOFADDLVAT { get; set; }
            public string RATEOFCESSONVAT { get; set; }
            public string VATTAXRATE { get; set; }
            public string VATITEMQTY { get; set; }
            public string PREVINVTOTALNUM { get; set; }
            public string VATWCDEDUCTIONRATE { get; set; }
            public string GSTTAXRATE { get; set; }
            public string ORIGINVGOODSQTY { get; set; }
            public string CAPVATTAXRATE { get; set; }
            public string AMOUNT { get; set; }
            public object FBTEXEMPTAMOUNT { get; set; }
            public object VATASSESSABLEVALUE { get; set; }
            public object VATWCCOSTOFLAND { get; set; }
            public object VATWCDEDLABOURCHARGES { get; set; }
            public object VATWCOTHERDEDUCTIONAMT { get; set; }
            public object VATWCVALUEOFTAXFREEGOODS { get; set; }
            public object VATWCOTHERCHARGES { get; set; }
            public object VATWCSUBCONTRACTORAMT { get; set; }
            public object PREVAMOUNT { get; set; }
            public object PREVINVTOTALAMT { get; set; }
            public object VATWCDEDUCTIONAMOUNT { get; set; }
            public object ORIGINVGOODSVALUE { get; set; }
            public object CENVATCAPTINPUTAMT { get; set; }
            public object GSTASSESSABLEVALUE { get; set; }
            public object IGSTLIABILITY { get; set; }
            public object CGSTLIABILITY { get; set; }
            public object SGSTLIABILITY { get; set; }
            public object GSTCESSLIABILITY { get; set; }
            public string GSTOVRDNASSESSABLEVALUE { get; set; }
            public object GSTASSBLVALUE { get; set; }
            public object ORIGINVGOODSTAXVALUE { get; set; }
            public object VATWCESTABLISHMENTCOST { get; set; }
            public object VATWCCONTRACTORPROFIT { get; set; }
            public object VATWCPLANNINGDESIGNFEES { get; set; }
            public object VATWCMACHINERYTOOLSCHARGES { get; set; }
            public object VATWCCONSUMABLESCOST { get; set; }
            public object VATEXPAMOUNT { get; set; }
            public object VATASSBLVALUE { get; set; }
            public object VATACCEPTEDTAXAMT { get; set; }
            public object VATACCEPTEDADDLTAXAMT { get; set; }
            public object CASHRECEIVED { get; set; }
            public object CAPVATASSEABLEVALUE { get; set; }
            public object CAPVATTAXVALUE { get; set; }
            public object ORIGPURCHVALUE { get; set; }
            public object SUPPLYMARGVAL { get; set; }
            public string SERVICETAXDETAILSLIST { get; set; }
            public string BANKALLOCATIONSLIST { get; set; }
            public string BILLALLOCATIONSLIST { get; set; }
            public string INTERESTCOLLECTIONLIST { get; set; }
            public string OLDAUDITENTRIESLIST { get; set; }
            public string ACCOUNTAUDITENTRIESLIST { get; set; }
            public string AUDITENTRIESLIST { get; set; }
            public string INPUTCRALLOCSLIST { get; set; }
            public string DUTYHEADDETAILSLIST { get; set; }
            public string EXCISEDUTYHEADDETAILSLIST { get; set; }
            public object  RATEDETAILSLIST { get; set; }
            public string SUMMARYALLOCSLIST { get; set; }
            public string STPYMTDETAILSLIST { get; set; }
            public string EXCISEPAYMENTALLOCATIONSLIST { get; set; }
            public string TAXBILLALLOCATIONSLIST { get; set; }
            public string TAXOBJECTALLOCATIONSLIST { get; set; }
            public string TDSEXPENSEALLOCATIONSLIST { get; set; }
            public string VATSTATUTORYDETAILSLIST { get; set; }
            public string COSTTRACKALLOCATIONSLIST { get; set; }
            public string REFVOUCHERDETAILSLIST { get; set; }
            public string INVOICEWISEDETAILSLIST { get; set; }
            public string VATITCDETAILSLIST { get; set; }
            public string ADVANCETAXDETAILSLIST { get; set; }
        }



     
        public class StockItemEntry
        {

            public List<RATEDETAILSLIST> RATEDETAILSLIST { get; set; }
            public string stockItemName { get; set; }
            public string stockItemGuid { get; set; }

          
            public decimal amount { get; set; }
            
            public string rate { get; set; }
            public string discount { get; set; }
            public string vatTaxRate { get; set; }

            public string actualQty { get; set; }
            
            public string billedQty { get; set; }

            public string stockGroup { get; set; }
            public string stockCategory { get; set; }

         
            public string stockGroupGuid { get; set; }

         
            public string stockCategoryGuid { get; set; }

            // Token: 0x170003D3 RID: 979
            // (get) Token: 0x060008B1 RID: 2225 RVA: 0x00014F83 File Offset: 0x00013183
            // (set) Token: 0x060008B2 RID: 2226 RVA: 0x00014F8B File Offset: 0x0001318B
      
            public decimal qty { get; set; }

            // Token: 0x170003D4 RID: 980
            // (get) Token: 0x060008B3 RID: 2227 RVA: 0x00014F94 File Offset: 0x00013194
            // (set) Token: 0x060008B4 RID: 2228 RVA: 0x00014F9C File Offset: 0x0001319C
         
            public string ledgerName { get; set; }

            // Token: 0x170003D5 RID: 981
            // (get) Token: 0x060008B5 RID: 2229 RVA: 0x00014FA5 File Offset: 0x000131A5
            // (set) Token: 0x060008B6 RID: 2230 RVA: 0x00014FAD File Offset: 0x000131AD
         
            public string ledgerGuid { get; set; }

            // Token: 0x170003D6 RID: 982
            // (get) Token: 0x060008B7 RID: 2231 RVA: 0x00014FB6 File Offset: 0x000131B6
            // (set) Token: 0x060008B8 RID: 2232 RVA: 0x00014FBE File Offset: 0x000131BE
            public List<voucher.batchAllocationDetail> batchAllocationDetails { get; set; }

            // Token: 0x170003D7 RID: 983
            // (get) Token: 0x060008B9 RID: 2233 RVA: 0x00014FC7 File Offset: 0x000131C7
            // (set) Token: 0x060008BA RID: 2234 RVA: 0x00014FCF File Offset: 0x000131CF
            public string descriptions { get; set; }
        }

        // Token: 0x02000070 RID: 112
        public class bankAllocationdetail
        {
            public string date { get; set; }
            public string InstrumentDate { get; set; }
            public string BankersDate { get; set; }

            public string name { get; set; }
            public string transactionType { get; set; }
            public string micrCode { get; set; }
            public string ifsCode { get; set; }
            public string bankName { get; set; }
            public string narration { get; set; }
            public string bankBranchName { get; set; }
            public string paymentGateway { get; set; }
            public string accountNumber { get; set; }
            public string paymentFavouring { get; set; }
            public string transactionName { get; set; }
            public string accountType { get; set; }
            public string deliveryMode { get; set; }
            public string deliveryTo { get; set; }
            public string cardNumber { get; set; }
            public string bankcode { get; set; }
            public string amount { get; set; }
        }

        // Token: 0x02000071 RID: 113
        public class billAllocationdetail
        {
            public DateTime billDate { get; set; }
             public string billName { get; set; }

            public decimal amount { get; set; }
            public int billId { get; set; }

            public string billType { get; set; }
            
            public string billCreditperiod { get; set; }
        }

        // Token: 0x02000072 RID: 114
        public class eWayBillDetail
        {
         
            public string consignorAddress { get; set; }
            public string consigneeAddress { get; set; }

            public DateTime billDate { get; set; }

            public string documentType { get; set; }

            public string consigneeGstIn { get; set; }
            
            public string consigneeStateName { get; set; }
            public string consigneePincode { get; set; }

            public string billNumber { get; set; }

         
            public string subType { get; set; }

            public string billStatus { get; set; }

            public string consignorName { get; set; }

            public string consignorPincode { get; set; }

            public string consignorGstIn { get; set; }

    
            public string consignorStateName { get; set; }
            public string consigneeName { get; set; }

            public string shippedToState { get; set; }
            public string shippedFromState { get; set; }
            

            public string ignoreGstInValidation { get; set; }

       
            public List<voucher.transpoertDetail> transpoertDetails { get; set; }
        }

        // Token: 0x02000073 RID: 115
        public class transpoertDetail
        {
        
            public DateTime documentDate { get; set; }

          
            public string transporterId { get; set; }

     
            public string transporterName { get; set; }

            public string transporterMode { get; set; }

           
            public string vehicleNumber { get; set; }
            public string documentNumber { get; set; }

            public string vehicleType { get; set; }

            public string ignoreVehicleOnValidation { get; set; }

            public decimal distance { get; set; }
        }

        // Token: 0x02000074 RID: 116
        public class batchAllocationDetail
        {
        
            public string godownName { get; set; }

            public string batchName { get; set; }

            public string orderNumber { get; set; }
            public string trackingNumber { get; set; }

            public string orderDueDate { get; set; }
            public string orderType { get; set; }

            public string trackId { get; set; }

            public string batchId { get; set; }
            
            public decimal batchDiscount { get; set; }
            
            public decimal amount { get; set; }
            
            public string actualQty { get; set; }
            
            public string billedQty { get; set; }

            
            public DateTime manufactureDate { get; set; }

       
            public DateTime expiryDate { get; set; }
        }

        // Token: 0x02000075 RID: 117
        public class invoiceDelNote
        {
            // Token: 0x1700041B RID: 1051
            // (get) Token: 0x06000947 RID: 2375 RVA: 0x0001547B File Offset: 0x0001367B
            // (set) Token: 0x06000948 RID: 2376 RVA: 0x00015483 File Offset: 0x00013683
     
            public DateTime basicShippingDate { get; set; }

            // Token: 0x1700041C RID: 1052
            // (get) Token: 0x06000949 RID: 2377 RVA: 0x0001548C File Offset: 0x0001368C
            // (set) Token: 0x0600094A RID: 2378 RVA: 0x00015494 File Offset: 0x00013694
            public string basicShipDeliveryNote { get; set; }
        }

        // Token: 0x02000076 RID: 118
        public class invoiceOrder
        {
            // Token: 0x1700041D RID: 1053
            // (get) Token: 0x0600094C RID: 2380 RVA: 0x000154A5 File Offset: 0x000136A5
            // (set) Token: 0x0600094D RID: 2381 RVA: 0x000154AD File Offset: 0x000136AD
            public string basicPurchaseOrderNo { get; set; }

            // Token: 0x1700041E RID: 1054
            // (get) Token: 0x0600094E RID: 2382 RVA: 0x000154B6 File Offset: 0x000136B6
            // (set) Token: 0x0600094F RID: 2383 RVA: 0x000154BE File Offset: 0x000136BE
        
            public DateTime basicOrderDate { get; set; }
        }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
   
    public class ISDEEMEDPOSITIVE
    {
        [JsonProperty("@TYPE")]
        public string TYPE { get; set; }

        [JsonProperty("#text")]
        public string Text { get; set; }
    }

    public class ALLLEDGERENTRIESLIST
    {
        public OLDAUDITENTRYIDSLIST OLDAUDITENTRYIDSLIST { get; set; }
        public object ORIGPURCHINVDATE { get; set; }
        public object NARRATION { get; set; }
        public object ADDLALLOCTYPE { get; set; }
        public object TAXCLASSIFICATIONNAME { get; set; }
        public object NOTIFICATIONSLNO { get; set; }
        public object SWIFTCODE { get; set; }
        public object ROUNDTYPE { get; set; }
        public string LEDGERNAME { get; set; }
        public object TAXUNITNAME { get; set; }
        public object STATNATURENAME { get; set; }
        public object GOODSTYPE { get; set; }
        public object METHODTYPE { get; set; }
        public object CLASSRATE { get; set; }
        public object STATCLASSIFICATIONNAME { get; set; }
        public object EXCISECLASSIFICATIONNAME { get; set; }
        public object ISZRBASICSERVICE { get; set; }
        public object VATCOMMODITYNAME { get; set; }
        public object SCHEDULE { get; set; }
        public object SCHEDULESERIALNUMBER { get; set; }
        public object VATCOMMODITYCODE { get; set; }
        public object VATSUBCOMMODITYCODE { get; set; }
        public object VATTRADENAME { get; set; }
        public object VATMAJORCOMMODITYNAME { get; set; }
        public object TDSPARTYNAME { get; set; }
        public object VATPARTYORGNAME { get; set; }
        public object XBRLADJTYPE { get; set; }
        public object VOUCHERFBTCATEGORY { get; set; }
        public object TYPEOFTAXPAYMENT { get; set; }
        public object VATCALCULATIONTYPE { get; set; }
        public object VATWORKSCONTRACTTYPE { get; set; }
        public object VATWCDESCRIPTION { get; set; }
        public string GSTCLASS { get; set; }
        public object SCHVIADJTYPE { get; set; }
        public object GSTOVRDNCLASSIFICATION { get; set; }
        public object GSTOVRDNNATURE { get; set; }
        public object GSTOVRDNINELIGIBLEITC { get; set; }
        public object GSTOVRDNISREVCHARGEAPPL { get; set; }
        public object GSTOVRDNTAXABILITY { get; set; }
        public object GSTHSNSACCODE { get; set; }
        public object VATGOODSNATURE { get; set; }
        public object POSPAYMENTTYPE { get; set; }
        public object GSTPARTYLEDGER { get; set; }
        public object ORIGPURCHPARTY { get; set; }
        public object ORIGPURCHPARTYADDRESS { get; set; }
        public object ORIGPURCHINVNO { get; set; }
        public object ORIGPURCHNOTE { get; set; }
        public string ISDEEMEDPOSITIVE { get; set; }
        public string LEDGERFROMITEM { get; set; }
        public object REMOVEZEROENTRIES { get; set; }
        public string ISPARTYLEDGER { get; set; }
        public string ISLASTDEEMEDPOSITIVE { get; set; }
        public object ISCAPVATTAXALTERED { get; set; }
        public string ISCAPVATNOTCLAIMED { get; set; }
        public string STCRADJPERCENT { get; set; }
        public string ROUNDLIMIT { get; set; }
        public string RATEOFADDLVAT { get; set; }
        public string RATEOFCESSONVAT { get; set; }
        public string VATTAXRATE { get; set; }
        public string VATITEMQTY { get; set; }
        public string PREVINVTOTALNUM { get; set; }
        public string VATWCDEDUCTIONRATE { get; set; }
        public string GSTTAXRATE { get; set; }
        public string ORIGINVGOODSQTY { get; set; }
        public string CAPVATTAXRATE { get; set; }
        public string AMOUNT { get; set; }
        public object FBTEXEMPTAMOUNT { get; set; }
        public object VATASSESSABLEVALUE { get; set; }
        public object VATWCCOSTOFLAND { get; set; }
        public object VATWCDEDLABOURCHARGES { get; set; }
        public object VATWCOTHERDEDUCTIONAMT { get; set; }
        public object VATWCVALUEOFTAXFREEGOODS { get; set; }
        public object VATWCOTHERCHARGES { get; set; }
        public object VATWCSUBCONTRACTORAMT { get; set; }
        public object PREVAMOUNT { get; set; }
        public object PREVINVTOTALAMT { get; set; }
        public object VATWCDEDUCTIONAMOUNT { get; set; }
        public object ORIGINVGOODSVALUE { get; set; }
        public object CENVATCAPTINPUTAMT { get; set; }
        public object GSTASSESSABLEVALUE { get; set; }
        public object IGSTLIABILITY { get; set; }
        public object CGSTLIABILITY { get; set; }
        public object SGSTLIABILITY { get; set; }
        public object GSTCESSLIABILITY { get; set; }
        public object GSTOVRDNASSESSABLEVALUE { get; set; }
        public object GSTASSBLVALUE { get; set; }
        public object ORIGINVGOODSTAXVALUE { get; set; }
        public object VATWCESTABLISHMENTCOST { get; set; }
        public object VATWCCONTRACTORPROFIT { get; set; }
        public object VATWCPLANNINGDESIGNFEES { get; set; }
        public object VATWCMACHINERYTOOLSCHARGES { get; set; }
        public object VATWCCONSUMABLESCOST { get; set; }
        public string VATEXPAMOUNT { get; set; }
        public object VATASSBLVALUE { get; set; }
        public object VATACCEPTEDTAXAMT { get; set; }
        public object VATACCEPTEDADDLTAXAMT { get; set; }
        public object CASHRECEIVED { get; set; }
        public object CAPVATASSEABLEVALUE { get; set; }
        public object CAPVATTAXVALUE { get; set; }
        public object ORIGPURCHVALUE { get; set; }
        public object SUPPLYMARGVAL { get; set; }
        public object SERVICETAXDETAILSLIST { get; set; }
        public object BANKALLOCATIONSLIST { get; set; }
        public object BILLALLOCATIONSLIST { get; set; }
        public object INTERESTCOLLECTIONLIST { get; set; }
        public object OLDAUDITENTRIESLIST { get; set; }
        public object ACCOUNTAUDITENTRIESLIST { get; set; }
        public object AUDITENTRIESLIST { get; set; }
        public object INPUTCRALLOCSLIST { get; set; }
        public object DUTYHEADDETAILSLIST { get; set; }
        public object EXCISEDUTYHEADDETAILSLIST { get; set; }
        public object RATEDETAILSLIST { get; set; }
        public object SUMMARYALLOCSLIST { get; set; }
        public object STPYMTDETAILSLIST { get; set; }
        public object EXCISEPAYMENTALLOCATIONSLIST { get; set; }
        public object TAXBILLALLOCATIONSLIST { get; set; }
        public object TAXOBJECTALLOCATIONSLIST { get; set; }
        public object TDSEXPENSEALLOCATIONSLIST { get; set; }
        public object VATSTATUTORYDETAILSLIST { get; set; }
        public object COSTTRACKALLOCATIONSLIST { get; set; }
        public object REFVOUCHERDETAILSLIST { get; set; }
        public object INVOICEWISEDETAILSLIST { get; set; }
        public object VATITCDETAILSLIST { get; set; }
        public object ADVANCETAXDETAILSLIST { get; set; }
    }

    public class UDF788529795
    {
        [JsonProperty("@DESC")]
        public string DESC { get; set; }

        [JsonProperty("#text")]
        public string Text { get; set; }
    }

    public class UDF788529795LIST
    {
        [JsonProperty("@DESC")]
        public string DESC { get; set; }

        [JsonProperty("@ISLIST")]
        public string ISLIST { get; set; }

        [JsonProperty("@TYPE")]
        public string TYPE { get; set; }

        [JsonProperty("@INDEX")]
        public string INDEX { get; set; }
        public UDF788529795 _UDF_788529795 { get; set; }
    }

    public class UDF788529996
    {
        [JsonProperty("@DESC")]
        public string DESC { get; set; }

        [JsonProperty("#text")]
        public string Text { get; set; }
    }

    public class UDF788529996LIST
    {
        [JsonProperty("@DESC")]
        public string DESC { get; set; }

        [JsonProperty("@ISLIST")]
        public string ISLIST { get; set; }

        [JsonProperty("@TYPE")]
        public string TYPE { get; set; }

        [JsonProperty("@INDEX")]
        public string INDEX { get; set; }
        public UDF788529996 _UDF_788529996 { get; set; }
    }

    public class UDF788529997
    {
        [JsonProperty("@DESC")]
        public string DESC { get; set; }

        [JsonProperty("#text")]
        public string Text { get; set; }
    }

    public class UDF788529997LIST
    {
        [JsonProperty("@DESC")]
        public string DESC { get; set; }

        [JsonProperty("@ISLIST")]
        public string ISLIST { get; set; }

        [JsonProperty("@TYPE")]
        public string TYPE { get; set; }

        [JsonProperty("@INDEX")]
        public string INDEX { get; set; }
        public UDF788529997 _UDF_788529997 { get; set; }
    }

    public class UDF788529998
    {
        [JsonProperty("@DESC")]
        public string DESC { get; set; }

        [JsonProperty("#text")]
        public string Text { get; set; }
    }

    public class UDF788529998LIST
    {
        [JsonProperty("@DESC")]
        public string DESC { get; set; }

        [JsonProperty("@ISLIST")]
        public string ISLIST { get; set; }

        [JsonProperty("@TYPE")]
        public string TYPE { get; set; }

        [JsonProperty("@INDEX")]
        public string INDEX { get; set; }
        public UDF788529998 _UDF_788529998 { get; set; }
    }

    public class UDF805307210LIST
    {
        [JsonProperty("@DESC")]
        public string DESC { get; set; }

        [JsonProperty("@INDEX")]
        public string INDEX { get; set; }
        public UDF788529795LIST _UDF_788529795LIST { get; set; }
        public UDF788529996LIST _UDF_788529996LIST { get; set; }
        public UDF788529997LIST _UDF_788529997LIST { get; set; }
        public UDF788529998LIST _UDF_788529998LIST { get; set; }
    }

    public class UDF788529999
    {
        [JsonProperty("@DESC")]
        public string DESC { get; set; }

        [JsonProperty("#text")]
        public string Text { get; set; }
    }

    public class UDF788529999LIST
    {
        [JsonProperty("@DESC")]
        public string DESC { get; set; }

        [JsonProperty("@ISLIST")]
        public string ISLIST { get; set; }

        [JsonProperty("@TYPE")]
        public string TYPE { get; set; }

        [JsonProperty("@INDEX")]
        public string INDEX { get; set; }
        public UDF788529999 _UDF_788529999 { get; set; }
    }

    public class UDF788530000
    {
        [JsonProperty("@DESC")]
        public string DESC { get; set; }

        [JsonProperty("#text")]
        public string Text { get; set; }
    }

    public class UDF788530000LIST
    {
        [JsonProperty("@DESC")]
        public string DESC { get; set; }

        [JsonProperty("@ISLIST")]
        public string ISLIST { get; set; }

        [JsonProperty("@TYPE")]
        public string TYPE { get; set; }

        [JsonProperty("@INDEX")]
        public string INDEX { get; set; }
        public UDF788530000 _UDF_788530000 { get; set; }
    }
    public class BASICBUYERADDRESSLIST
    {
        [JsonProperty("@TYPE")]
        public string TYPE { get; set; }
        public string BASICBUYERADDRESS { get; set; }
    }

    public class BASICBUYERADDRESSLISTmulty
    {
        [JsonProperty("@TYPE")]
        public string TYPE { get; set; }
        public List<string> BASICBUYERADDRESS { get; set; }
    }

    public class UDF788530001
    {
        [JsonProperty("@DESC")]
        public string DESC { get; set; }

        [JsonProperty("#text")]
        public string Text { get; set; }
    }

    public class UDF788530001LIST
    {
        [JsonProperty("@DESC")]
        public string DESC { get; set; }

        [JsonProperty("@ISLIST")]
        public string ISLIST { get; set; }

        [JsonProperty("@TYPE")]
        public string TYPE { get; set; }

        [JsonProperty("@INDEX")]
        public string INDEX { get; set; }
        public UDF788530001 _UDF_788530001 { get; set; }
    }

    public class VOUCHERData
    {
        [JsonProperty("@REMOTEID")]
        public string REMOTEID { get; set; }

        [JsonProperty("@VCHKEY")]
        public string VCHKEY { get; set; }

        [JsonProperty("@VCHTYPE")]
        public string VCHTYPE { get; set; }

        [JsonProperty("@OBJVIEW")]
        public string OBJVIEW { get; set; }
        public OLDAUDITENTRYIDSLIST OLDAUDITENTRYIDSLIST { get; set; }
        public object ACTIVETO { get; set; }
        public object ALTEREDON { get; set; }
        public string DATE { get; set; }
        public object LUTDATEOFISSUE { get; set; }
        public object LUTEXPIRYDATE { get; set; }
        public object BONDDATEOFISSUE { get; set; }
        public object BONDEXPIRYDATE { get; set; }
        public object TAXCHEQUEDATE { get; set; }
        public object TAXCHALLANDATE { get; set; }
        public object REFERENCEDATE { get; set; }
        public object SHIPPINGBILLDATE { get; set; }
        public object BILLOFENTRYDATE { get; set; }
        public object VATPARTYTRANSRETURNDATE { get; set; }
        public object RECONCILATIONDATE { get; set; }
        public object FORM16ISSUEDATE { get; set; }
        public object CSTFORMISSUEDATE { get; set; }
        public object CSTFORMRECVDATE { get; set; }
        public object CERTIFICATEDATE { get; set; }
        public object FBTFROMDATE { get; set; }
        public object FBTTODATE { get; set; }
        public object RETURNINVOICEDATE { get; set; }
        public object AGGREMENTORDERDATE { get; set; }
        public object GOODSRCPTDATE { get; set; }
        public object LORRYRECPTDATE { get; set; }
        public object TRANSSALELANDINGDATE { get; set; }
        public object TRANSBUYERLANDINGDATE { get; set; }
        public object CREDITLETTERDATE { get; set; }
        public object AIRWAYBILLDATE { get; set; }
        public object VATORDERDATE { get; set; }
        public object INVENTORYENTRIESLIST { get; set; }
        
        public object INVDELIVERYDATE { get; set; }
        public object BILLOFLADINGDATE { get; set; }
        public object VATDEPOSITDATE { get; set; }
        public object VATDOCUMENTDATE { get; set; }
        public object VATCHALLANDATE { get; set; }
        public object ECDATE { get; set; }
        public object VATTDSDATE { get; set; }
        public object ADJFROMDATE { get; set; }
        public object ADJTODATE { get; set; }
        public object VATDDCHEQUEDATE { get; set; }
        public object TAXPAYPERIODFROMDATE { get; set; }
        public object TAXPAYPERIODTODATE { get; set; }
        public object STTAXCHALLANDATE { get; set; }
        public object GSTCHALLANDATE { get; set; }
        public object GSTCHALLANEXPIRYDATE { get; set; }
        public object ADJPARTYINVOICEDATE { get; set; }
        public object ADJPARTYPAYMENTDATE { get; set; }
        public object PARTYORDERDATE { get; set; }
        public object ADVANCERECEIPTDATE { get; set; }
        public object REFUNDVOUCHERDATE { get; set; }
        public object IRNACKDATE { get; set; }
        public object IRNCANCELDATE { get; set; }
        public object VATSUBMISSIONDATE { get; set; }
        public object PARTYINVDATE { get; set; }
        public object INSPDOCDATE { get; set; }
        public object VATCANCINVDATE { get; set; }
        public object VATGOODSRECEIPTDATE { get; set; }
        public object VATCSTE1DATE { get; set; }
        public object DISPATCHDATE { get; set; }
        public object AUDITEDON { get; set; }
        public string GUID { get; set; }
        public object GSTREGISTRATIONTYPE { get; set; }
        public object VATDEALERTYPE { get; set; }
        public object STATENAME { get; set; }
        public object PRICELEVEL { get; set; }
        public object TDSNATUREOFPAYMENT { get; set; }
        public object AUTOCOSTLEVEL { get; set; }
        public string NARRATION { get; set; }
        public object REMOTEGUID { get; set; }
        public string REMOTEALTGUID { get; set; }
        public object REQUESTORRULE { get; set; }
        public object ALTEREDBY { get; set; }
        public object COUNTRYOFRESIDENCE { get; set; }
        public object IMPORTEREXPORTERCODE { get; set; }
        public object PARTYGSTIN { get; set; }
       

        public object BASICBUYERADDRESSLIST { get; set; }
        public object ADDRESS { get; set; }
        
        public object BASICBUYERADDRESS { get; set; }

        public object NATUREOFSALES { get; set; }
        public object EXCISENOTIFICATIONNO { get; set; }
        public object PLACEOFSUPPLY { get; set; }
        public object LUTNUMBER { get; set; }
        public object BONDNUMBER { get; set; }
        public object AUTHORITYNAME { get; set; }
        public object AUTHORITYADDRESS { get; set; }
        public object TAXUNITNAME { get; set; }
        public object EXCISEUNITNAME { get; set; }
        public object CLASSNAME { get; set; }
        public object POSCARDLEDGER { get; set; }
        public object POSCASHLEDGER { get; set; }
        public object POSGIFTLEDGER { get; set; }
        public object POSCHEQUELEDGER { get; set; }
        public object EXCISECLASSIFICATIONNAME { get; set; }
        public object TDSSECTIONNO { get; set; }
        public object TDSDEDNSTATUS { get; set; }
        public object TAXBANKCHALLANNUMBER { get; set; }
        public object TAXCHALLANBSRCODE { get; set; }
        public object TAXCHEQUENUMBER { get; set; }
        public object TAXBANKNAME { get; set; }
        public object TAXBANKBRANCHNAME { get; set; }
        public string PARTYNAME { get; set; }
        public string PARTYLEDGERNAME { get; set; }
        public object GSTACTIVITYSTATUS { get; set; }
        public object TAXADJUSTMENT { get; set; }
        public object BUYERADDRESSTYPE { get; set; }
        public object PORTCODE { get; set; }
        public object SHIPPINGBILLNO { get; set; }
        public object BILLOFENTRYNO { get; set; }
        public object VATPARTYTRANSRETURNNUMBER { get; set; }
        public object URDORIGINALSALEVALUE { get; set; }
        public object GSTNATUREOFRETURN { get; set; }
        public string VOUCHERTYPENAME { get; set; }
        public object REFERENCE { get; set; }
        public string VOUCHERNUMBER { get; set; }
        public object BASICBASEPARTYNAME { get; set; }
        public object BASICVOUCHERCHEQUENAME { get; set; }
        public object BASICVOUCHERCROSSCOMMENT { get; set; }
        public object EXCHGCURRENCYNAME { get; set; }
        public object SERIALMASTER { get; set; }
        public object SERIALNUMBER { get; set; }
        public object STATADJUSTMENTTYPE { get; set; }
        public object STATPAYMENTTYPE { get; set; }
        public object CONSIGNEEIECODE { get; set; }
        public object SUPPLIERIECODE { get; set; }
        public object ARESERIALMASTER { get; set; }
        public object ARESERIALNUMBER { get; set; }
        public object SUMAUTOVCHNUM { get; set; }
        public object TAXBANKACCOUNTNUMBER { get; set; }
        public string CSTFORMISSUETYPE { get; set; }
        public object CSTFORMISSUENUMBER { get; set; }
        public string CSTFORMRECVTYPE { get; set; }
        public object CSTFORMRECVNUMBER { get; set; }
        public object CONSIGNEECSTNUMBER { get; set; }
        public object BUYERSCSTNUMBER { get; set; }
        public object CSTFORMISSUESERIESNUM { get; set; }
        public object CSTFORMRECVSERIESNUM { get; set; }
        public object EXCISETREASURYNUMBER { get; set; }
        public object EXCISETREASURYNAME { get; set; }
        public object CERTIFICATETYPE { get; set; }
        public object CERTIFICATENUMBER { get; set; }
        public object AREFORMTYPE { get; set; }
        public object DESTINATIONTAXUNIT { get; set; }
        public string FBTPAYMENTTYPE { get; set; }
        public object POSCARDNUMBER { get; set; }
        public object POSCHEQUENUMBER { get; set; }
        public object POSCHEQUEBANKNAME { get; set; }
        public object CHALLANTYPE { get; set; }
        public object CHEQUEDEPOSITORNAME { get; set; }
        public object EXCISENOTIFICATIONSERIALNO { get; set; }
        public string PERSISTEDVIEW { get; set; }
        public object EXCISETARIFFTYPE { get; set; }
        public object CONSIGNEELBTREGNNO { get; set; }
        public object CONSIGNEELBTZONE { get; set; }
        public object SUPPLIERLBTREGNNO { get; set; }
        public object SUPPLIERLBTZONE { get; set; }
        public object LBTMAPPEDCATEGORY { get; set; }
        public object LBTMAPPEDZONE { get; set; }
        public object LBTNATUREOFLIABILITY { get; set; }
        public object CASHPARTYPAN { get; set; }
        public object CASHPARTYDEDTYPE { get; set; }
        public object VCHTAXTYPE { get; set; }
        public object PURPOSEOFPURCHASE { get; set; }
        public object POINTOFTRANSACTION { get; set; }
        public object TRANSPORTERNAME { get; set; }
        public object TRANSPORTMODE { get; set; }
        public object AGGREMENTORDERNO { get; set; }
        public object FOREIGNSELLERNAME { get; set; }
        public object EXPORTERCOUNTRY { get; set; }
        public object GOODSVEHICLENUMBER { get; set; }
        public object SHIPNAME { get; set; }
        public object SHIPAGENTNAME { get; set; }
        public object CLEARINGAGENTNAME { get; set; }
        public object LORRYRECPTNO { get; set; }
        public object CARRIERNAME { get; set; }
        public object CREDITLETTERREF { get; set; }
        public object AIRWAYBILLNO { get; set; }
        public object FWDAGENTNAME { get; set; }
        public object VATORDERNO { get; set; }
        public object VATSELLERTIN { get; set; }
        public object TRANSSOURCEPLACE { get; set; }
        public object TRANSCATEGORY { get; set; }
        public object VATDOCUMENTTYPE { get; set; }
        public object VATTRANSBILLQTY { get; set; }
        public object VATTRANSBILLNO { get; set; }
        public object BILLOFLADINGNO { get; set; }
        public object VATPAIDAGAINST { get; set; }
        public object VATBANKNAME { get; set; }
        public object VATBANKBRANCH { get; set; }
        public object VATDDCHEQUENO { get; set; }
        public object VATADJUSTMENTTYPE { get; set; }
        public object VATFORMSTATUS { get; set; }
        public object VATDOCUMENTNUMBER { get; set; }
        public object VATSOURCESTATE { get; set; }
        public object VATDESTINATIONSTATE { get; set; }
        public object VATDESTINATIONPLACE { get; set; }
        public object VATPARTYORGTYPE { get; set; }
        public object VATPARTYTYPE { get; set; }
        public object VATCHALLANNUMBER { get; set; }
        public object VATDESIGOFPURCHASER { get; set; }
        public object VATPURCHASERCPTTYPE { get; set; }
        public object VATGOODSRCPTNO { get; set; }
        public object VATPARTYORGNAME { get; set; }
        public object AIRPORTNAME { get; set; }
        public object TDNOFAWARDER { get; set; }
        public object ECNUMBER { get; set; }
        public object ECISSUINGAUTHORITY { get; set; }
        public object CONTRACTORTIN { get; set; }
        public object VATTDSBARCODE { get; set; }
        public object VATPYMTMODEOFDEPOSIT { get; set; }
        public object VATPYMTTAXDESC { get; set; }
        public object VATBANKACCNUMBER { get; set; }
        public object VATBRANCHCODE { get; set; }
        public object VATTRANSSOURCE { get; set; }
        public object VATADJADDLDETAILS { get; set; }
        public object VATBRANCHNAME { get; set; }
        public object PRIORITYSTATECONFLICT { get; set; }
        public object EICHECKPOST { get; set; }
        public object PORTNAME { get; set; }
        public object VATEFORMAPPLICABLE { get; set; }
        public object VATEFORMAPPLICABLENO { get; set; }
        public object VATINCOURSEOF { get; set; }
        public object VATDISPATCHTIME { get; set; }
        public object VATTRANSPORTERADDRESS { get; set; }
        public object VATCONTRACTEETDN { get; set; }
        public object VATCONTRACTEEDISTRICT { get; set; }
        public object VATCONTRACTEENAME { get; set; }
        public object CONSUMERIDENTIFICATIONNUMBER { get; set; }
        public object STTVCHRHANDLE { get; set; }
        public object SRVTREGNUMBER { get; set; }
        public object TAXPAYMENTTYPE { get; set; }
        public object STTAXBANKCHALLANNUMBER { get; set; }
        public object TYPEOFEXCISEVOUCHER { get; set; }
        public object GSTBANKNAME { get; set; }
        public object GSTBANKACCOUNTNUMBER { get; set; }
        public object GSTBANKACCOUNTTYPE { get; set; }
        public object GSTBANKACCOUNTHOLDER { get; set; }
        public object GSTBANKBRANCHADDRESS { get; set; }
        public object GSTBANKIFSCCODE { get; set; }
        public object GSTBANKMICRCODE { get; set; }
        public object GSTDEBITDOCNUMBER { get; set; }
        public object GSTPYMTMODEOFDEPOSIT { get; set; }
        public object GSTBANKBRANCHNAME { get; set; }
        public object GSTINSTRUMENTNUMBER { get; set; }
        public object GSTCHALLANNUMBER { get; set; }
        public object GSTCPINNUMBER { get; set; }
        public object GSTCINNUMBER { get; set; }
        public object ADJPARTYGSTIN { get; set; }
        public object ADJPARTYINVOICENO { get; set; }
        public object GSTMERCHANTID { get; set; }
        public object PARTYORDERNO { get; set; }
        public object GSTITCREVERSALDETAILS { get; set; }
        public object GSTITCDOCUMENTTYPE { get; set; }
        public object GSTADDITIONALDETAILS { get; set; }
        public object GSTRECONSTATUS { get; set; }
        public object GSTREASONFORREJECTION { get; set; }
        public object ADVANCERECEIPTNUMBER { get; set; }
        public object REFUNDVOUCHERNUMBER { get; set; }
        public object VCHTAXUNIT { get; set; }
        public object CONSIGNEEGSTIN { get; set; }
        public object IRNACKNO { get; set; }
        public object IRN { get; set; }
        public object IRNQRCODE { get; set; }
        public object BILLTOPLACE { get; set; }
        public object SHIPTOPLACE { get; set; }
        public object DISPATCHFROMNAME { get; set; }
        public object DISPATCHFROMADDRESSTYPE { get; set; }
        public object DISPATCHFROMSTATENAME { get; set; }
        public object DISPATCHFROMPINCODE { get; set; }
        public object DISPATCHFROMPLACE { get; set; }
        public object IRNCANCELREASON { get; set; }
        public object IRNCANCELCODE { get; set; }
        public string BASICSHIPPEDBY { get; set; }
        public object BASICDESTINATIONCOUNTRY { get; set; }
        public object BASICBUYERNAME { get; set; }
        public object BASICPLACEOFRECEIPT { get; set; }
        public object BASICSHIPDOCUMENTNO { get; set; }
        public object BASICPORTOFLOADING { get; set; }
        public object BASICPORTOFDISCHARGE { get; set; }
        public object BASICFINALDESTINATION { get; set; }
        public object BASICORDERREF { get; set; }
        public object BASICSHIPVESSELNO { get; set; }
        public object BASICBUYERSSALESTAXNO { get; set; }
        public object BASICDUEDATEOFPYMT { get; set; }
        public object BASICSERIALNUMINPLA { get; set; }
        public object BASICDATETIMEOFINVOICE { get; set; }
        public object BASICDATETIMEOFREMOVAL { get; set; }
        public object PARTYADDRESSTYPE { get; set; }
        public object MFGRADDRESSTYPE { get; set; }
        public object TRANSPORTERADDRROOM { get; set; }
        public object TRANSPORTERADDRBLDG { get; set; }
        public object TRANSPORTERADDRROAD { get; set; }
        public object TRANSPORTERADDRAREA { get; set; }
        public object TRANSPORTERADDRTOWN { get; set; }
        public object TRANSPORTERADDRDIST { get; set; }
        public object TRANSPORTERADDRSTATE { get; set; }
        public object TRANSPORTERADDRPINCODE { get; set; }
        public object TRANSPORTERADDRPHONE { get; set; }
        public object TRANSPORTERADDRFAX { get; set; }
        public object TRANSPORTERVEHICLE2 { get; set; }
        public object TRANSPORTLOCALTIN { get; set; }
        public object VATCFORMISSUESTATE { get; set; }
        public object PLACEOFSUPPLYSTATE { get; set; }
        public object PLACEOFSUPPLYCOUNTRY { get; set; }
        public object EMIRATEPOS { get; set; }
        public object PARTYMAILINGNAME { get; set; }
        public object PARTYPINCODE { get; set; }
        public object CONSIGNEEMAILINGNAME { get; set; }
        public object CONSIGNEECOUNTRYNAME { get; set; }
        public string VCHGSTCLASS { get; set; }
        public object COSTCENTRENAME { get; set; }
        public object ADDITIONALNARRATION { get; set; }
        public object PARTYINVNO { get; set; }
        public object INSPDOCNO { get; set; }
        public object SETTLEMENTTYPE { get; set; }
        public object VOUCHERTIME { get; set; }
        public object HOLDREFERENCE { get; set; }
        public object VATCANCINVNO { get; set; }
        public object VATCANCPURCTIN { get; set; }
        public object VATCANCPURCNAME { get; set; }
        public object VATTYPEOFDEVICE { get; set; }
        public object VATBRIEFDESCRIPTION { get; set; }
        public object VATDEVICENO { get; set; }
        public object BUYERPINNUMBER { get; set; }
        public object VATEXPORTENTRYNO { get; set; }
        public object CONSIGNEEPINNUMBER { get; set; }
        public object VATEXEMPTCERTIFICATENO { get; set; }
        public object VATVEHICLENUMBER { get; set; }
        public object VATGOODSRECEIPTNUMBER { get; set; }
        public object VATMOBILENUMBER { get; set; }
        public object VATCSTE1SERIESNO { get; set; }
        public object VATCSTE1SERIALNO { get; set; }
        public object VATPERMITFORM { get; set; }
        public object VATCERTIFICATENO { get; set; }
        public object CONSIGNEECIRCLE { get; set; }
        public object CONSIGNEECITY { get; set; }
        public object CONSIGNEESTATENAME { get; set; }
        public object CONSIGNEEPINCODE { get; set; }
        public object CONSIGNEEMOBILENUMBER { get; set; }
        public object CONSIGNEEOTHERS { get; set; }
        public object CONSIGNEEMAIL { get; set; }
        public object DELIVERYCITY { get; set; }
        public object DELIVERYPINCODE { get; set; }
        public object DELIVERYOTHERS { get; set; }
        public object DELIVERYSTATE { get; set; }
        public object DISPATCHCITY { get; set; }
        public object DISPATCHPINCODE { get; set; }
        public object DESTINATIONPERMITNUMBER { get; set; }
        public object ENTRYCHECKPOSTLOCATION { get; set; }
        public object EXITCHECKPOSTLOCATION { get; set; }
        public object VATTDSDEDUCTORNAME { get; set; }
        public object VCHENTRYMODE { get; set; }
        public string ENTEREDBY { get; set; }
        public object REMOTEVCHKEY { get; set; }
        public object VOUCHERTYPEORIGNAME { get; set; }
        public string DIFFACTUALQTY { get; set; }
        public string ISMSTFROMSYNC { get; set; }
        public string ASORIGINAL { get; set; }
        public ISDEEMEDPOSITIVE ISDEEMEDPOSITIVE { get; set; }
        public string AUDITED { get; set; }
        public string FORJOBCOSTING { get; set; }
        public string ISOPTIONAL { get; set; }
        public string EFFECTIVEDATE { get; set; }
        public string USEFOREXCISE { get; set; }
        public string ISFORJOBWORKIN { get; set; }
        public string ALLOWCONSUMPTION { get; set; }
        public string USEFORINTEREST { get; set; }
        public string USEFORGAINLOSS { get; set; }
        public string USEFORGODOWNTRANSFER { get; set; }
        public string USEFORCOMPOUND { get; set; }
        public string USEFORSERVICETAX { get; set; }
        public string ISDELETED { get; set; }
        public string ISONHOLD { get; set; }
        public string ISBOENOTAPPLICABLE { get; set; }
        public string ISEXCISEVOUCHER { get; set; }
        public string EXCISETAXOVERRIDE { get; set; }
        public string USEFORTAXUNITTRANSFER { get; set; }
        public string IGNOREPOSVALIDATION { get; set; }
        public string EXCISEOPENING { get; set; }
        public string USEFORFINALPRODUCTION { get; set; }
        public string ISTDSOVERRIDDEN { get; set; }
        public string ISTCSOVERRIDDEN { get; set; }
        public string ISTDSTCSCASHVCH { get; set; }
        public string INCLUDEADVPYMTVCH { get; set; }
        public string ISSUBWORKSCONTRACT { get; set; }
        public string ISVATOVERRIDDEN { get; set; }
        public string IGNOREORIGVCHDATE { get; set; }
        public string ISVATPAIDATCUSTOMS { get; set; }
        public string ISDECLAREDTOCUSTOMS { get; set; }
        public string ISSERVICETAXOVERRIDDEN { get; set; }
        public string ISISDVOUCHER { get; set; }
        public string ISEXCISEOVERRIDDEN { get; set; }
        public string ISEXCISESUPPLYVCH { get; set; }
        public string ISGSTOVERRIDDEN { get; set; }
        public string GSTNOTEXPORTED { get; set; }
        public string IGNOREGSTINVALIDATION { get; set; }
        public string ISGSTREFUND { get; set; }
        public string ISGSTSECSEVENAPPLICABLE { get; set; }
        public string ISVATPRINCIPALACCOUNT { get; set; }
        public string IGNOREEINVVALIDATION { get; set; }
        public string IRNJSONEXPORTED { get; set; }
        public string IRNCANCELLED { get; set; }
        public string ISSHIPPINGWITHINSTATE { get; set; }
        public string ISOVERSEASTOURISTTRANS { get; set; }
        public string ISDESIGNATEDZONEPARTY { get; set; }
        public string ISCANCELLED { get; set; }
        public string HASCASHFLOW { get; set; }
        public string ISPOSTDATED { get; set; }
        public string USETRACKINGNUMBER { get; set; }
        public string ISINVOICE { get; set; }
        public string MFGJOURNAL { get; set; }
        public string HASDISCOUNTS { get; set; }
        public string ASPAYSLIP { get; set; }
        public string ISCOSTCENTRE { get; set; }
        public string ISSTXNONREALIZEDVCH { get; set; }
        public string ISEXCISEMANUFACTURERON { get; set; }
        public string ISBLANKCHEQUE { get; set; }
        public string ISVOID { get; set; }
        public string ORDERLINESTATUS { get; set; }
        public string VATISAGNSTCANCSALES { get; set; }
        public string VATISPURCEXEMPTED { get; set; }
        public string ISVATRESTAXINVOICE { get; set; }
        public string VATISASSESABLECALCVCH { get; set; }
        public string ISVATDUTYPAID { get; set; }
        public string ISDELIVERYSAMEASCONSIGNEE { get; set; }
        public string ISDISPATCHSAMEASCONSIGNOR { get; set; }
        public string ISDELETEDVCHRETAINED { get; set; }
        public string CHANGEVCHMODE { get; set; }
        public string RESETIRNQRCODE { get; set; }
        public string ALTERID { get; set; }
        public string REMOTEALTERID { get; set; }
        public string MASTERID { get; set; }
        public string VOUCHERKEY { get; set; }
        public string ECFEERATE { get; set; }
        public string VATCONSIGNMENTNO { get; set; }
        public string QRCODECRC { get; set; }
        public string VATTDSRATE { get; set; }
        public object BONDAMOUNT { get; set; }
        public object POSCASHRECEIVED { get; set; }
        public object CUSTOMDUTYPAID { get; set; }
        public object VATPARTYITCCLAIMED { get; set; }
        public object VATPARTYTAXLIABILITY { get; set; }
        public object VALUEOFWORKSCONTRACT { get; set; }
        public object ECFEEAMOUNT { get; set; }
        public object ECFEEDEPOSITBYAWARDER { get; set; }
        public object ECFEEDEPOSITBYCONTRACTOR { get; set; }
        public object TDSDEDUCTED { get; set; }
        public object VALUEOFSUBWORKSCONT { get; set; }
        public object VATTDSAMT { get; set; }
        public object ADJPARTYINVOICEVALUE { get; set; }
        public object GSTINVASSESSABLEVALUE { get; set; }
        public object VATGOODSVALUE { get; set; }
        public object EXCHGRATE { get; set; }
        public object PROCESSINGDURATION { get; set; }
        public object EWAYBILLDETAILSLIST { get; set; }
        public object LEDGERENTRIESLIST { get; set; }

        
        public object EXCLUDEDTAXATIONSLIST { get; set; }
        public object OLDAUDITENTRIESLIST { get; set; }
        public object ACCOUNTAUDITENTRIESLIST { get; set; }
        public object AUDITENTRIESLIST { get; set; }
        public object DUTYHEADDETAILSLIST { get; set; }
        public object ALLINVENTORYENTRIESLIST { get; set; }
        public object SUPPLEMENTARYDUTYHEADDETAILSLIST { get; set; }
        public object IRNERRORLISTLIST { get; set; }
        public object INVOICEDELNOTESLIST { get; set; }
        public object INVOICEORDERLISTLIST { get; set; }
        public object BASICORDERTERMSLIST { get; set; }

      


        public object  ADDRESSLIST { get; set; }
        
        public object INVOICEINDENTLISTLIST { get; set; }
        public object ATTENDANCEENTRIESLIST { get; set; }
        public object ORIGINVOICEDETAILSLIST { get; set; }
        public object INVOICEEXPORTLISTLIST { get; set; }
        public object ALLLEDGERENTRIESLIST { get; set; }
        public object _UDF_805307210LIST { get; set; }
        public object _UDF_788529999LIST { get; set; }
        public object _UDF_788530000LIST { get; set; }
        public object _UDF_788530001LIST { get; set; }
    }

    public class RootVouher
    {
        public VOUCHERData VOUCHER { get; set; }
    }






    //StockLadgerItemEntery

    public class BATCHID
    {
        [JsonProperty("@TYPE")]
        public string TYPE { get; set; }

        [JsonProperty("#text")]
        public string Text { get; set; }
    }

    public class BATCHDISCOUNT
    {
        [JsonProperty("@TYPE")]
        public string TYPE { get; set; }

        [JsonProperty("#text")]
        public string Text { get; set; }
    }

    public class BATCHRATE
    {
        [JsonProperty("@TYPE")]
        public string TYPE { get; set; }
    }

    public class BATCHALLOCATIONSLIST
    {
        public object MFDON { get; set; }
        public object ORDERYEAREND { get; set; }
        public object TRACKINGYEAREND { get; set; }
        public object ORDERPRECLOSUREDATE { get; set; }
        public object NARRATION { get; set; }
        public string GODOWNNAME { get; set; }
        public string BATCHNAME { get; set; }
        public object DESTINATIONGODOWNNAME { get; set; }
        public string INDENTNO { get; set; }
        public object ORDERTYPE { get; set; }
        public object PARENTITEM { get; set; }
        public object ORDERCLOSUREREASON { get; set; }
        public string ORDERNO { get; set; }
        public string TRACKINGNUMBER { get; set; }
        public object DYNAMICCSTNO { get; set; }
        public object DYNAMICCSTPARENTITEM { get; set; }
        public object SUMDYNAMICCSTNO { get; set; }
        public object SUMBATCHNAME { get; set; }
        public object SUMTRACKINGNUMBER { get; set; }
        public object SUMORDERNO { get; set; }
        public object SUMINDENTNO { get; set; }
        public object ADDLAMOUNT { get; set; }
        public string DYNAMICCSTISCLEARED { get; set; }
        public BATCHID BATCHID { get; set; }
        public BATCHDISCOUNT BATCHDISCOUNT { get; set; }
        public string AMOUNT { get; set; }
        public object ADDLEXPENSEAMOUNT { get; set; }
        public object BATCHDIFFVAL { get; set; }
        public object ACTUALQTY { get; set; }
        public object BILLEDQTY { get; set; }
        public object ORDERPRECLOSUREQTY { get; set; }
        public object ORIGACTUALQTY { get; set; }
        public object ORIGBILLEDQTY { get; set; }
        public object BATCHPHYSDIFF { get; set; }
        public object ORIGRATE { get; set; }
        public object REVISEDRATE { get; set; }
        public object ESCALATIONRATE { get; set; }
        public object INCLVATRATE { get; set; }
        public BATCHRATE BATCHRATE { get; set; }
        public object EXPIRYPERIOD { get; set; }
        public object INDENTDUEDATE { get; set; }
        public object ORDERDUEDATE { get; set; }
        public string ADDITIONALDETAILSLIST { get; set; }
        public string VOUCHERCOMPONENTLISTLIST { get; set; }
    }

   

    public class ACCOUNTINGALLOCATIONSLIST
    {
        public OLDAUDITENTRYIDSLIST OLDAUDITENTRYIDSLIST { get; set; }
        public object RATEDETAILSLIST { get; set; }
        
        public object ORIGPURCHINVDATE { get; set; }
        public object NARRATION { get; set; }
        public object ADDLALLOCTYPE { get; set; }
        public object TAXCLASSIFICATIONNAME { get; set; }
        public object NOTIFICATIONSLNO { get; set; }
        public object SWIFTCODE { get; set; }
        public object ROUNDTYPE { get; set; }
        public string LEDGERNAME { get; set; }
        public object TAXUNITNAME { get; set; }
        public object STATNATURENAME { get; set; }
        public object GOODSTYPE { get; set; }
        public object METHODTYPE { get; set; }
        public object CLASSRATE { get; set; }
        public object STATCLASSIFICATIONNAME { get; set; }
        public object EXCISECLASSIFICATIONNAME { get; set; }
        public object ISZRBASICSERVICE { get; set; }
        public object VATCOMMODITYNAME { get; set; }
        public object SCHEDULE { get; set; }
        public object SCHEDULESERIALNUMBER { get; set; }
        public object VATCOMMODITYCODE { get; set; }
        public object VATSUBCOMMODITYCODE { get; set; }
        public object VATTRADENAME { get; set; }
        public object VATMAJORCOMMODITYNAME { get; set; }
        public object TDSPARTYNAME { get; set; }
        public object VATPARTYORGNAME { get; set; }
        public object XBRLADJTYPE { get; set; }
        public object VOUCHERFBTCATEGORY { get; set; }
        public object TYPEOFTAXPAYMENT { get; set; }
        public object VATCALCULATIONTYPE { get; set; }
        public object VATWORKSCONTRACTTYPE { get; set; }
        public object VATWCDESCRIPTION { get; set; }
        public string GSTCLASS { get; set; }
        public object SCHVIADJTYPE { get; set; }
        public object GSTOVRDNCLASSIFICATION { get; set; }
        public object GSTOVRDNNATURE { get; set; }
        public object GSTOVRDNINELIGIBLEITC { get; set; }
        public object GSTOVRDNISREVCHARGEAPPL { get; set; }
        public object GSTOVRDNTAXABILITY { get; set; }
        public object GSTHSNSACCODE { get; set; }
        public object VATGOODSNATURE { get; set; }
        public object POSPAYMENTTYPE { get; set; }
        public object GSTPARTYLEDGER { get; set; }
        public object ORIGPURCHPARTY { get; set; }
        public object ORIGPURCHPARTYADDRESS { get; set; }
        public object ORIGPURCHINVNO { get; set; }
        public object ORIGPURCHNOTE { get; set; }
        public string ISDEEMEDPOSITIVE { get; set; }
        public string LEDGERFROMITEM { get; set; }
        public object REMOVEZEROENTRIES { get; set; }
        public string ISPARTYLEDGER { get; set; }
        public string ISLASTDEEMEDPOSITIVE { get; set; }
        public object ISCAPVATTAXALTERED { get; set; }
        public string ISCAPVATNOTCLAIMED { get; set; }
        public string STCRADJPERCENT { get; set; }
        public string ROUNDLIMIT { get; set; }
        public string RATEOFADDLVAT { get; set; }
        public string RATEOFCESSONVAT { get; set; }
        public string VATTAXRATE { get; set; }
        public string VATITEMQTY { get; set; }
        public string PREVINVTOTALNUM { get; set; }
        public string VATWCDEDUCTIONRATE { get; set; }
        public string GSTTAXRATE { get; set; }
        public string ORIGINVGOODSQTY { get; set; }
        public string CAPVATTAXRATE { get; set; }
        public string AMOUNT { get; set; }
        public object FBTEXEMPTAMOUNT { get; set; }
        public object VATASSESSABLEVALUE { get; set; }
        public object VATWCCOSTOFLAND { get; set; }
        public object VATWCDEDLABOURCHARGES { get; set; }
        public object VATWCOTHERDEDUCTIONAMT { get; set; }
        public object VATWCVALUEOFTAXFREEGOODS { get; set; }
        public object VATWCOTHERCHARGES { get; set; }
        public object VATWCSUBCONTRACTORAMT { get; set; }
        public object PREVAMOUNT { get; set; }
        public object PREVINVTOTALAMT { get; set; }
        public object VATWCDEDUCTIONAMOUNT { get; set; }
        public object ORIGINVGOODSVALUE { get; set; }
        public object CENVATCAPTINPUTAMT { get; set; }
        public object GSTASSESSABLEVALUE { get; set; }
        public object IGSTLIABILITY { get; set; }
        public object CGSTLIABILITY { get; set; }
        public object SGSTLIABILITY { get; set; }
        public object GSTCESSLIABILITY { get; set; }
        public object GSTOVRDNASSESSABLEVALUE { get; set; }
        public object GSTASSBLVALUE { get; set; }
        public object ORIGINVGOODSTAXVALUE { get; set; }
        public object VATWCESTABLISHMENTCOST { get; set; }
        public object VATWCCONTRACTORPROFIT { get; set; }
        public object VATWCPLANNINGDESIGNFEES { get; set; }
        public object VATWCMACHINERYTOOLSCHARGES { get; set; }
        public object VATWCCONSUMABLESCOST { get; set; }
        public string VATEXPAMOUNT { get; set; }
        public object VATASSBLVALUE { get; set; }
        public object VATACCEPTEDTAXAMT { get; set; }
        public object VATACCEPTEDADDLTAXAMT { get; set; }
        public object CASHRECEIVED { get; set; }
        public object CAPVATASSEABLEVALUE { get; set; }
        public object CAPVATTAXVALUE { get; set; }
        public object ORIGPURCHVALUE { get; set; }
        public object SUPPLYMARGVAL { get; set; }
        public string SERVICETAXDETAILSLIST { get; set; }
        public string BANKALLOCATIONSLIST { get; set; }
        public string BILLALLOCATIONSLIST { get; set; }
        public string INTERESTCOLLECTIONLIST { get; set; }
        public string OLDAUDITENTRIESLIST { get; set; }
        public string ACCOUNTAUDITENTRIESLIST { get; set; }
        public string AUDITENTRIESLIST { get; set; }
        public string INPUTCRALLOCSLIST { get; set; }
        public string DUTYHEADDETAILSLIST { get; set; }
        public string EXCISEDUTYHEADDETAILSLIST { get; set; }
        
        public string SUMMARYALLOCSLIST { get; set; }
        public string STPYMTDETAILSLIST { get; set; }
        public string EXCISEPAYMENTALLOCATIONSLIST { get; set; }
        public string TAXBILLALLOCATIONSLIST { get; set; }
        public string TAXOBJECTALLOCATIONSLIST { get; set; }
        public string TDSEXPENSEALLOCATIONSLIST { get; set; }
        public string VATSTATUTORYDETAILSLIST { get; set; }
        public string COSTTRACKALLOCATIONSLIST { get; set; }
        public string REFVOUCHERDETAILSLIST { get; set; }
        public string INVOICEWISEDETAILSLIST { get; set; }
        public string VATITCDETAILSLIST { get; set; }
        public string ADVANCETAXDETAILSLIST { get; set; }
    }
    public class INVOICEDELNOTESLIST
    {
        public string BASICSHIPPINGDATE { get; set; }
        public string BASICSHIPDELIVERYNOTE { get; set; }
    }

    public class INVOICEDELNOTESLISTMulty
    {
        public  List<INVOICEDELNOTESLIST> INVOICEDELNOTESLIST { get; set; }
      
    }


    public class RootStockItemEntry
    {
        
        public object ORIGINVOICEDATE { get; set; }
        public object ORIGSALESINVDATE { get; set; }
        public object DESCRIPTION { get; set; }
        public string STOCKITEMNAME { get; set; }
        public object STATNATURENAME { get; set; }
        public object EXCISECLASSIFICATIONNAME { get; set; }
        public object ISZRBASICSERVICE { get; set; }
        public object EXCISETARIFF { get; set; }
        public object EXCISEEXEMPTION { get; set; }
        public object TRADERCNSALESNUMBER { get; set; }
        public object BASICPACKAGEMARKS { get; set; }
        public object BASICNUMPACKAGES { get; set; }
        public object SDTAXCLASSIFICATIONNAME { get; set; }
        public object NATUREOFCOMPONENT { get; set; }
        public object COMPONENTLISTTYPE { get; set; }
        public object DISPLAYNATUREOFCOMPONENT { get; set; }
        public object BOMNAME { get; set; }
        public object ORIGINVOICENUMBER { get; set; }
        public object ORIGINVOICEBOOKNAME { get; set; }
        public object ORIGSALESINVNO { get; set; }
        public object EXCISERETURNINVOICENO { get; set; }
        public object REASONOFREJECTION { get; set; }
        public object EXCISECREDITPARTY { get; set; }
        public object EXCISECREDITSTKITEM { get; set; }
        public object EXCISECREDITCATEGORY { get; set; }
        public object TRADERSUPPLIERINVOICENO { get; set; }
        public object EXCISESALESINVOICENO { get; set; }
        public object ADDLAMOUNT { get; set; }
        public string ISDEEMEDPOSITIVE { get; set; }
        public string ISLASTDEEMEDPOSITIVE { get; set; }
        public string ISAUTONEGATE { get; set; }
        public object ISCUSTOMSCLEARANCE { get; set; }
        public object ISTRACKCOMPONENT { get; set; }
        public object ISTRACKPRODUCTION { get; set; }
        public object ISPRIMARYITEM { get; set; }
        public string ISSCRAP { get; set; }
        public object RATE { get; set; }
        public string DISCOUNT { get; set; }
        public string VATTAXRATE { get; set; }
        public string ORIGINVGOODSQTY { get; set; }
        public string EXCISEMRPABATEMENT { get; set; }
        public string ADDLCOSTPERC { get; set; }
        public string REVISEDRATEOFDUTY { get; set; }
        public string ORIGRATEOFDUTY { get; set; }
        public string ORIGMRPABATEMENT { get; set; }
        public string EXCISERETURNDUTYRATE { get; set; }
        public string GVATEXCISERATE { get; set; }
        public string AMOUNT { get; set; }
        public object EXCISEASSESSABLEVALUE { get; set; }
        public object VATASSESSABLEVALUE { get; set; }
        public object ORIGINVGOODSVALUE { get; set; }
        public object GSTASSBLVALUE { get; set; }
        public object ORIGINVGOODSTAXVALUE { get; set; }
        public object VATASSBLVALUE { get; set; }
        public object VATACCEPTEDTAXAMT { get; set; }
        public object VATACCEPTEDADDLTAXAMT { get; set; }
        public object GVATEXCISEAMT { get; set; }
        public object ACTUALQTY { get; set; }
        public object BILLEDQTY { get; set; }
        public object ORIGACTUALQTY { get; set; }
        public object ORIGBILLEDQTY { get; set; }
        public object EXCISERETURNINVOICEQTY { get; set; }
        public object USABLEQTY { get; set; }
        public object EXCISECREDITPENDINGQTY { get; set; }
        public object MRPRATE { get; set; }
        public object EXCISEMRPRATE { get; set; }
        public object ORIGRATE { get; set; }
        public object REVISEDRATE { get; set; }
        public object ESCALATIONRATE { get; set; }
        public object ORIGMRPRATE { get; set; }
        public object ORIGRATEOFQTY { get; set; }
        public object REVISEDRATEOFQTY { get; set; }
        public object INCLVATRATE { get; set; }
        public BATCHALLOCATIONSLIST BATCHALLOCATIONSLIST { get; set; }
        public object ACCOUNTINGALLOCATIONSLIST { get; set; }
        public string DUTYHEADDETAILSLIST { get; set; }
        public string SUPPLEMENTARYDUTYHEADDETAILSLIST { get; set; }
        public string TAXOBJECTALLOCATIONSLIST { get; set; }
        public string REFVOUCHERDETAILSLIST { get; set; }
        public string EXCISEALLOCATIONSLIST { get; set; }
        public string EXPENSEALLOCATIONSLIST { get; set; }
    }





}
