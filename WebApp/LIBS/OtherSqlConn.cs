using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.LIBS;
using Business;
using System.Data;
using System.Data.SqlClient;

namespace WebApp.admin.ReportModal
{
    public  static class OtherSqlConn
    {

       
        public static SqlConnection SqlConnection()
        {
            var myCon = new SqlConnection("Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=3000000");
            myCon.Open();
            return myCon;

        }

            public static DataTable FillDataTable(string str,string ConStr="")
        {
           var  myCon = new SqlConnection(

               ConStr.Length>0 ? ConStr :
               "Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=3000000");
            myCon.Open();

            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand(str, myCon))
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandTimeout = int.MaxValue;
                        //cmd.ExecuteNonQuery();
                        adp.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
            myCon.Dispose();

            return dt;
        }

        public static DataSet FillDataSet(string str, string ConStr = "")
        {
            var myCon = new SqlConnection(

                ConStr.Length > 0 ? ConStr :
                "Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=3000000");
            myCon.Open();

            DataSet dt = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand(str, myCon))
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandTimeout = int.MaxValue;
                        //cmd.ExecuteNonQuery();
                        adp.Fill(dt);
                    }
                }
            }
            catch
            {
                throw;
            }
            myCon.Dispose();

            return dt;
        }





        public static DataTable FillDataTableMaxTime(string str)
        {
            var myCon = new SqlConnection("Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=3000000");
            myCon.Open();

            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand(str, myCon))
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandTimeout = 1000;
                       // cmd.ExecuteNonQuery();
                        adp.Fill(dt);
                    }
                }
            }
            catch
            {
                throw;
            }
            myCon.Dispose();

            return dt;
        }



        public static DataTable ExecuteSTORETallyDataImport(DataTable dt)
        {
            var myCon = new SqlConnection("Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=3000000");
            myCon.Open();

            
            try
            {
                using (SqlCommand cmd = new SqlCommand("ImportTallyRecoDataFromTally", myCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Details", dt);
                    cmd.ExecuteNonQuery();


                }
            }
            catch
            {
                throw;
            }
            myCon.Dispose();

            return dt;
        }


        public static DataTable ExecuteSTORETallyFillAliasToGroup(string GodwnId,string SearchTerm)
        {
            var myCon = new SqlConnection("Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=3000000");
            myCon.Open();
            DataTable dt = new DataTable();

            try
            {
                using (SqlCommand cmd = new SqlCommand("OutStandingReportGetGroupName", myCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GodwnId", GodwnId);
                    cmd.Parameters.AddWithValue("@SearchTerm", SearchTerm);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {


                        da.Fill(dt);
                    }


                }
            }
            catch
            {
                throw;
            }
            myCon.Dispose();

            return dt;
        }



        public static DataTable FillDataTableStoredProcedureCorporateGroupCodeWise(string StoreName,string MultiLocation,int GroupCode)
        {
            var myCon = new SqlConnection("Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=3000000");
            myCon.Open();

            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand(StoreName, myCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Multi_LOC", MultiLocation);
                    cmd.Parameters.AddWithValue("@Group_Code", GroupCode);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                      

                        da.Fill(dt);
                    }
                }
            }
            catch
            {
                throw;
            }
            myCon.Dispose();

            return dt;
        }




        public static DataTable SPtrialBalance(int Godwnid, string ParentGroup)
        {
            var myCon = new SqlConnection("Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=3000000");
            myCon.Open();
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SPTrialBalanceRecurcive", myCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompId", SiteSession.Comp_MstSession.Comp_Code);
                    cmd.Parameters.AddWithValue("@Godwnid", Godwnid);
                    cmd.Parameters.AddWithValue("@ParentgroupName", ParentGroup);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {


                        da.Fill(dt);
                    }
                }
            }
            catch
            {
                throw;
            }
            myCon.Dispose();

            return dt;
        }



        public static DataTable SPtrialBalanceAlonLedger(int Godwnid)
        {
            var myCon = new SqlConnection("Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=3000000");
            myCon.Open();
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("AccountLedgerTrialBalanceAlonLedger", myCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompId", SiteSession.Comp_MstSession.Comp_Code);
                    cmd.Parameters.AddWithValue("@Godwnid", Godwnid);
                    
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {


                        da.Fill(dt);
                    }
                }
            }
            catch
            {
                throw;
            }
            myCon.Dispose();

            return dt;
        }



        public static DataTable LedgerDropdownList(string StoreName)
        {
            var myCon = new SqlConnection("Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=3000000");
            myCon.Open();

            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand(StoreName, myCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@compid", SiteSession.Comp_MstSession.Comp_Code);
                    cmd.Parameters.AddWithValue("@godwnid", SiteSession.GodownId);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {


                        da.Fill(dt);
                    }
                }
            }
            catch
            {
                throw;
            }
            myCon.Dispose();

            return dt;
        }






        public static int TransInsertgetID(string str, string tblnm)
        {
            var myCon = new SqlConnection("Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=3000000");
            myCon.Open();

            int Id;
            try
            {
                using (SqlCommand cmd = new SqlCommand(str, myCon))
                {

                    cmd.ExecuteNonQuery();
                    cmd.CommandText = (String.Format("select @@identity from {0}", tblnm));
                    Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch
            {
                Id = 0;
            }
            myCon.Dispose();
            return Id;
        }
        public static string ExequteQuey1(string str,string Con)
        {
            var myCon = new SqlConnection(Con);
            myCon.Open();
            string Flag;
            try
            {
                using (SqlCommand cmd = new SqlCommand(str, myCon))
                {
                    cmd.CommandTimeout = int.MaxValue;
                    cmd.ExecuteNonQuery();

                    
                    Flag = "Yes";
                }
            }
            catch (Exception ex)
            {
                Flag = ex.Message;
            }
            myCon.Dispose();
            return Flag;
        }


        public static string ExequteQuey(string str)
        {
            var myCon = new SqlConnection("Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=30000");
            myCon.Open();
            string Flag;
            try
            {
                using (SqlCommand cmd = new SqlCommand(str, myCon))
                {
                    cmd.ExecuteNonQuery();
                    Flag = "Yes";
                }
            }
            catch (Exception ex)
            {
                Flag = ex.Message;
            }
            myCon.Dispose();
            return Flag;
        }

    }
}