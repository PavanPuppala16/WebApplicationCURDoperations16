using System.Data;
using WebApplicationCURDoperations16.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Configuration;

using System.Data.SqlClient;
using System.Reflection;

using System.ComponentModel;

namespace WebApplicationCURDoperations16.Businesslogic_bl
{
    public class Book_bl
    {

        public static bool Insertdata(Book obj)
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


                    SqlCommand cmd = new SqlCommand("sp_insert_TBL_BOOK", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", obj.Title);
                    cmd.Parameters.AddWithValue("@Author", obj.Author);
                    cmd.Parameters.AddWithValue("@Description", obj.Description);
                    cmd.Parameters.AddWithValue("@Publishedyear", Convert.ToDateTime(obj.Publishedyear));
                   
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
        public static List<Book> GetData()
        {
            List<Book> obj = new List<Book>();
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_GET_TBL_BOOK", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(new Book
                    {
                        BID = Convert.ToInt32(dr["BID"].ToString()),
                        Title = dr["Title"].ToString(),
                        Author = dr["Author"].ToString(),
                        Description = dr["Description"].ToString(),
                        Publishedyear = Convert.ToDateTime(dr["Publishedyear"].ToString()),

                    });

                }
                return obj;
            }
        }

        public static Book DataByID(int BID)
        {



            Book obj = null;
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("SP_Get_DATABYID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BID", BID);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    obj = new Book();
                    obj.BID = Convert.ToInt32(ds.Tables[0].Rows[i]["BID"].ToString());
                    obj.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    obj.Author = ds.Tables[0].Rows[i]["Author"].ToString();
                    obj.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    obj.Publishedyear = Convert.ToDateTime(ds.Tables[0].Rows[i]["Publishedyear"].ToString());


                }
                return obj;

            }
        }
        public static bool UpdateData(Book obj)
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
                    SqlCommand cmd = new SqlCommand("SP_UPDATE_TBL_BOOK", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Title", obj.Title);
                    cmd.Parameters.AddWithValue("Author", obj.Author);
                    cmd.Parameters.AddWithValue("Description", obj.Description);
                    cmd.Parameters.AddWithValue("Publishedyear", Convert.ToDateTime(obj.Publishedyear));
                    cmd.Parameters.AddWithValue("BID",  Convert.ToInt32(obj.BID));
                    int X = cmd.ExecuteNonQuery();
                    if (X > 0)
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
        public static bool DeleteData(int BID)
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
                    SqlCommand cmd = new SqlCommand("SP_DELETE_DATABYID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BID", BID);
                    int X = cmd.ExecuteNonQuery();
                    if (X > 0)
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


        public static Book DataByID1(int BID)
        {



            Book obj = null;
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("SP_Get_DATABYID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BID", BID);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    obj = new Book();
                    obj.BID = Convert.ToInt32(ds.Tables[0].Rows[i]["BID"].ToString());
                    obj.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    obj.Author = ds.Tables[0].Rows[i]["Author"].ToString();
                    obj.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    obj.Publishedyear = Convert.ToDateTime(ds.Tables[0].Rows[i]["Publishedyear"].ToString());


                }
                return obj;

            }
        }

        public static bool Details(Book obj)
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
                    SqlCommand cmd = new SqlCommand("SP_UPDATE_tbl_books", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Title", obj.Title);
                    cmd.Parameters.AddWithValue("Author", obj.Author);
                    cmd.Parameters.AddWithValue("Description", obj.Description);
                    cmd.Parameters.AddWithValue("Publishedyear", Convert.ToDateTime(obj.Publishedyear));
                    cmd.Parameters.AddWithValue("BID", obj.BID);
                    int X = cmd.ExecuteNonQuery();
                    if (X > 0)
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
