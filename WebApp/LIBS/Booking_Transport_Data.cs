using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApp.admin.ReportModal;

namespace WebApp.LIBS
{
    public class Booking_Transport_Data
    {

        public static string Transport_Data()
        {

            try
            {

                DataTable Datatable = OtherSqlConn.FillDataTableMaxTime("select Distinct x.[UTD],x.[PARENT_GROUP],x.[DEALER_MAP_CD],x.[LOC_CD],x.[MUL_DEALER_CD],x.[OUTLET_CD],[TRANS_TYPE],[TRANS_DATE],[TRANS_ID],[TRANS_REF_NUM],[TRANS_REF_DATE],[MODEL_CD],[VARIANT_CD],[ECOLOR_CD],[GST_NO],[PLACE_OF_SUPPLY],gd_fdi_trans_customer.[CUST_NAME],[EXECUTIVE],[TEAM_HEAD],[GE1],[GE2],[GE3],[GE4],[GE5],[GE6],[GE7],[GE8],[GE9],[GE10],[GE11],[GE12],[GE13],[GE14],[GE15],gd_fdi_trans_customer.[CUST_ID],[SALUTATION],[GENDER],[MARITAL_STATUS],[COMMUNICATE_TO],[RES_ADDRESS1],[RES_ADDRESS2],[RES_ADDRESS3],[RES_PIN_CD],[RES_CITY],[RES_PHONE],[OFF_ADDRESS1],[OFF_ADDRESS2],[OFF_ADDRESS3],[OFF_PIN_CD],[OFF_CITY],[OFF_PHONE],[MOBILE1],[MOBILE2],[EMAIL_ID],[PAN_NO],[STATE],[DISTRICT],[TEHSIL],[VILLAGE],[TIN],[UIN],[DOB],[DOA],[SHIP_ADDRESS1],[SHIP_ADDRESS2],[SHIP_ADDRESS3],[SHIP_PIN_CD],[SHIP_CITY],[SHIP_STATE],[SHIP_FULL_NAME],[SHIP_PAN],[SHIP_GST_NUM] ,[SHIP_UIN],(select top 1 variant_Desc from model_variant_master where model_variant_master.VARIANT_CD=x.variant_Cd) as VARIANT_NAME,(select top 1 ECOLOR_DESC from model_variant_master where model_variant_master.ECOLOR_CD=x.Ecolor_CD) as COLOR_NAME,x.[TRANS_SEGMENT],(select top 1 MODEL_DESC from model_variant_master where model_variant_master.variant_Cd=x.variant_Cd) as VEHICLE_GROUP from (SELECT  * FROM gd_fdi_trans where ISNULL( AutoVYN_Flag,0)=0 and TRANS_TYPE='ORDBK') as x  left join gd_fdi_trans_customer on x.UTD=gd_fdi_trans_customer.UTD ");
                
                if (Datatable.Rows.Count > 0)
                {

                    ConnModal.SpTransportData(Datatable);

                    string[] str = Datatable.AsEnumerable().Select(p => p["UTD"].ToString()).ToArray();
                    var joinstr = string.Join(",", str);
                    OtherSqlConn.FillDataTableMaxTime("update gd_Fdi_trans set autovyn_Flag=1 where utd in (" + joinstr + ")");


                }




                DataTable Datatable3 = OtherSqlConn.FillDataTableMaxTime("select utd,trans_ref_num as trans_id,Loc_Cd from gd_fdi_trans  where trans_type='VS' and trans_id in (select trans_Ref_num from gd_Fdi_trans where trans_type = 'VC')  and  isnull(Ax_Flag,0)= 0");

                if (Datatable3.Rows.Count > 0)
                {

                    ConnModal.SpTransportDataInvoiceCancel(Datatable3);

                    string[] str = Datatable3.AsEnumerable().Select(p => p["UTD"].ToString()).ToArray();
                    var joinstr = string.Join(",", str);
                    OtherSqlConn.FillDataTableMaxTime("update gd_Fdi_trans set Ax_Flag=1 where utd in (" + joinstr + ")");


                }
             
                DataTable Datatable1 = OtherSqlConn.FillDataTableMaxTime("Select UTD,Trans_id,Loc_Cd from Gd_Fdi_Trans where Trans_type='ORDBC' and isnull(AutoVYN_Flag,0)=0");

                DataTable Datatable2 = OtherSqlConn.FillDataTableMaxTime("select utd, trans_Ref_num as Trans_id,loc_cd from gd_Fdi_trans where trans_type = 'VS' and isnull(Ax_Flag,0)= 0 and trans_id not in (Select trans_ref_num from gd_fdi_trans where trans_type = 'VC')");



                if (Datatable1.Rows.Count > 0)
                {

                    ConnModal.SpTransportDataCancel(Datatable1);

                    string[] str = Datatable1.AsEnumerable().Select(p => p["UTD"].ToString()).ToArray();
                    var joinstr = string.Join(",", str);
                    OtherSqlConn.FillDataTableMaxTime("update gd_Fdi_trans set autovyn_Flag=1 where utd in (" + joinstr + ")");


                }


                if (Datatable2.Rows.Count > 0)
                {

                    ConnModal.SpTransportDataInvoice(Datatable2);

                    string[] str = Datatable2.AsEnumerable().Select(p => p["UTD"].ToString()).ToArray();
                    var joinstr = string.Join(",", str);
                    OtherSqlConn.FillDataTableMaxTime("update gd_Fdi_trans set Ax_Flag=1 where utd in (" + joinstr + ")");


                }

               


                return "Success";
            }
            catch(Exception ex) { return ex.Message; }
        }

    }
}