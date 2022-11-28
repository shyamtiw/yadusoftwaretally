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




        public string voucherNumber { get; set; }
        
        public bool isCancelled { get; set; }
        public bool isOptional { get; set; }
        public DateTime voucherDate { get; set; }
        
        public string voucherType { get; set; }
     
        
        public string narration { get; set; }

        
       
        public string partyLedgerName { get; set; }
        public string partyName { get; set; }
        
        public string parentType { get; set; }
        public string placeOfSupply { get; set; }
      
        public string partygstIn { get; set; }
        public List<voucher.ledgerEntry> ledgerEntries { get; set; }
        public List<voucher.StockItemEntry> StockItemEntries { get; set; }
        

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


        public class RATEDETAILSLIST
        {
            public string GSTRATEDUTYHEAD { get; set; }
            public string GSTRATEVALUATIONTYPE { get; set; }
            public string GSTRATE { get; set; }
            public string GSTRATEPERUNIT { get; set; }
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
         

            // Token: 0x170003D7 RID: 983
            // (get) Token: 0x060008B9 RID: 2233 RVA: 0x00014FC7 File Offset: 0x000131C7
            // (set) Token: 0x060008BA RID: 2234 RVA: 0x00014FCF File Offset: 0x000131CF
            public string descriptions { get; set; }
        }

        // Token: 0x02000070 RID: 112
    

        // Token: 0x02000071 RID: 113
 

        // Token: 0x02000072 RID: 114
     

        // Token: 0x02000073 RID: 115
    
     
        // Token: 0x02000075 RID: 117
    

        // Token: 0x02000076 RID: 118
        
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
