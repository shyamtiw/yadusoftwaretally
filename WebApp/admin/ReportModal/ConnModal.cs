using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.LIBS;
using Business;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.admin.ReportModal
{
    public class ConnModal
    {
        public static string ConectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;


        public static DataTable FillDataTable(string str)
        {
            var myCon = new SqlConnection(ConectionString);
            myCon.Open();

            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand(str, myCon))
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
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




        public static DataTable FillDataTableStoredProcedureCorporateGroupCodeWise(string StoreName, string MultiLocation, int GroupCode)
        {
            var myCon = new SqlConnection(ConectionString);
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


        public static DataTable SpTransportData(DataTable  dt)
        {
            var myCon = new SqlConnection(ConectionString);
            myCon.Open();

         
            try
            {
                using (SqlCommand cmd = new SqlCommand("ImportSPBookingData", myCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Details", dt);
                    cmd.Parameters.AddWithValue("@Godw_Code", SiteSession.GodownId);
                    cmd.Parameters.AddWithValue("@Comp_Code", SiteSession.Comp_MstSession.Comp_Code.Value.ToString());
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
        public static DataTable SpTransportDataCancel(DataTable dt)
        {
            var myCon = new SqlConnection(ConectionString);
            myCon.Open();


            try
            {
                using (SqlCommand cmd = new SqlCommand("SPBkgCancel", myCon))
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

        public static DataTable SpTransportDataInvoice(DataTable dt)
        {
            var myCon = new SqlConnection(ConectionString);
            myCon.Open();


            try
            {
                using (SqlCommand cmd = new SqlCommand("SPBkgInvoice", myCon))
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


        

            public static DataTable SpTransportDataInvoiceCancel(DataTable dt)
        {
            var myCon = new SqlConnection(ConectionString);
            myCon.Open();


            try
            {
                using (SqlCommand cmd = new SqlCommand("SPInvCancel", myCon))
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


        public static int TransInsertgetID(string str, string tblnm)
        {
            var myCon = new SqlConnection(ConectionString);
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
        public static string ExequteQuey(string str)
        {
            var myCon = new SqlConnection(ConectionString);
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