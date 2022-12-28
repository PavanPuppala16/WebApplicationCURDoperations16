using System.Data;
using WebApplicationCURDoperations16.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Configuration;

using System.Data.SqlClient;
using System.Reflection;
using WebApplicationCURDoperations16.Models;


namespace WebApplicationCURDoperations16.Businesslogic_bl
{
    public class curd
    {
         public static bool Insertdata(INVOICE_MODEL obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))

            {
                try
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand("SP_INSERT_cartype", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@equipment", obj.equipment);
                    cmd.Parameters.AddWithValue("@cartype", obj.cartype);
                    cmd.Parameters.AddWithValue("@credits", obj.credits);
                    cmd.Parameters.AddWithValue("@Notified", Convert.ToDateTime(obj.Notified));
                    cmd.Parameters.AddWithValue("@dates", obj.dates);
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }

        }
        public static List<INVOICE_MODEL> GetALlData()
        {



            List<INVOICE_MODEL> obj = new List<INVOICE_MODEL>();
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GETALLDATA_invoice", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(
                        new INVOICE_MODEL
                        {

                            equipment = dr["equipment"].ToString(),
                            cartype = dr["cartype"].ToString(),
                            Notified = Convert.ToDateTime(dr["Notified"].ToString()),
                            credits = Convert.ToInt32(dr["credits"].ToString()),
                            dates = Convert.ToInt32(dr["dates"].ToString()),

                        }
                        );
                }
                return obj;
            }
        }

        public static bool updata(INVOICE_MODEL obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand("SP_UPDATE_TBL_INSERTS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@equipment", obj.equipment);
                    cmd.Parameters.AddWithValue("@cartype", obj.cartype);
                    cmd.Parameters.AddWithValue("@Notified", Convert.ToDateTime(obj.Notified));
                    cmd.Parameters.AddWithValue("@credits", obj.credits);
                    cmd.Parameters.AddWithValue("@dates", obj.dates);

                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }
        }
        public static bool DELETEDATA(int dates)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand("SP_DELETEDATABY_credits", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@dates", dates);
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }

        }

    }
}
