using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;


namespace Practice_ado
{
    public class ConnectionString
    {
        public static void Connection()
        {
            SqlConnection conn = null;
            string cs = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            try
            {
                using (conn = new SqlConnection(cs))
                {
                    string querry = "select * from Employe.Employes";
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = querry;
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader dr= cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine("id = " + dr["id"] + " Name = " + dr["Name"]);
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        } 
    }
}
