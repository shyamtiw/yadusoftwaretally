using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public partial class UserLogin
    {
        public static User_Tbl GetUser(string UserName, string Password)
        {

            return Global.Context.User_Tbl.Where(U => String.Compare(U.User_Name, UserName, true) == 0 && String.Compare(U.User_Pwd, Password, false) == 0 && U.Export_Type <= 3).FirstOrDefault();
        }



        public static User_Tbl GetUserIsDeviceId(string DeviceId)
        {
            try
            {
                var objGetData = Global.Context.ExecuteStoreQuery<UserCodeGet>("select User_Code from User_Tbl where isnull(DeviceId, '') = '" + DeviceId + "'").FirstOrDefault().User_Code;



                return Global.Context.User_Tbl.Where(U =>  U.User_Code== objGetData.Value).FirstOrDefault();
            }
            catch {
                return null;
            }
        }

        public static string GetUserDeviceId(int UserId)
        {
            try
            {
                return Global.Context.User_Tbl.AsEnumerable().SingleOrDefault(U => U.User_Code == UserId).DeviceId;
            }
            catch { return ""; }
        }

        public static string[]  GetUserDeviceIdMultipal(int[] UserId)
        {
            try
            {
                return Global.Context.User_Tbl.AsEnumerable().Where(U => UserId.Contains(U.User_Code) && !String.IsNullOrWhiteSpace(U.DeviceId)).Select(p => p.DeviceId).ToArray();
            }
            catch { return null; }
        }

        public static User_Tbl GetUserSingle(int UserId)
        {
            return Global.Context.User_Tbl.AsEnumerable().SingleOrDefault(U => U.User_Code == UserId);
        }



        public static List<GodawnList> GetGodawanList(string Banch, int  Comp_Code)
        {
            int[] LocationId = Banch.Split(',').Select(p => Convert.ToInt32(p)).ToArray();

            var Godown = Global.Context.ExecuteStoreQuery<GodawnList>("select Godw_Code as Id,isnull(TallyURL,'') as TallyURL,Region,BR_DMDT as DlrCode,Godw_Name as [Value],BR_EWC,BR_TCU,isnull(SPL_REM,'') as SPL_REM from Godown_Mst where Godw_Code in (" + Banch + ") and Comp_Code="+ Comp_Code + "").ToList();
            return Godown;
        }


        public static List<GodawnList> GetGodawanLisExportType(string BranchCode)
        {
            

            var Godown = Global.Context.ExecuteStoreQuery<GodawnList>("select Godw_Code as Id,BR_DMDT as DlrCode,Godw_Name as [Value] from Godown_Mst  where Godw_Code in (" + BranchCode + ") and  EXPORT_TYPE<=3").ToList();
            return Godown;
        }



        public static List<GodawnList> GetGodawanListEInvoiceInser(int Comp_Code)
        {
            

            var Godown = Global.Context.ExecuteStoreQuery<GodawnList>("select Godw_Code as Id,DMS_HSN_CODE as DlrCode from Godown_Mst where  EXPORT_TYPE<=3 and Comp_Code="+ Comp_Code + "").ToList();
            return Godown;
        }

        public static List<GodawnList> GetGodawanListEInvoiceInserWithValue(int Comp_Code)
        {


            var Godown = Global.Context.ExecuteStoreQuery<GodawnList>("select Godw_Code as Id,Godw_Name as [Value] from Godown_Mst where  EXPORT_TYPE<=3 and Comp_Code=" + Comp_Code + "").ToList();
            return Godown;
        }



        public static List<GodawnListDeatils> GodwwnListGetUserWise(int Comp_Code,int Godw_Code)
        {


            var Godown = Global.Context.ExecuteStoreQuery<GodawnListDeatils>("select top 1 GST_No,Godw_Code, Godw_Add1,Godw_Add2,City,State,Pin_Code,State_Code,Mob_No,Com_Add3 from Godown_Mst where Comp_Code=" + Comp_Code + " and Godw_Code="+ Godw_Code + "").ToList();
            return Godown;
        }


    }
}

public partial class GodawnList
{
    public byte Id { get; set; }
    public string Value { get; set; }
    public string DlrCode { get; set; }
    public string BR_EWC { get; set; }
    public string BR_TCU { get; set; }
    public string SPL_REM { get; set; }
    public string TallyURL { get; set; }
    public string Region { get; set; }


}




public partial class GodawnListDeatils
{
    public string GST_No { get; set; }
    public byte Godw_Code { get; set; }
    public string Godw_Add1 { get; set; }
    public string Godw_Add2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Pin_Code { get; set; }
    public byte State_Code { get; set; }
    public string Mob_No { get; set; }
    public string Com_Add3 { get; set; }
}


public partial class UserCodeGet { 
public int? User_Code { get; set; }
}
