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
                    Console.WriteLine("EmployeId");
                    string id = Console.ReadLine();
                    Console.WriteLine("EmployeName");
                    string Name = Console.ReadLine();

                    string qry = "insert into Employe.Employes values(@id,@Name)";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.CommandText = qry;
                    cmd.Connection = conn;
                    conn.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        Console.WriteLine("data insert successfully");
                        Console.WriteLine(a);
                    }
                    else
                    {
                        Console.WriteLine("something went wrong...");
                    }
                    //string querry = "sp_AllEmploy";
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //SqlDataReader dr = cmd.ExecuteReader();
                    //while (dr.Read())
                    //{
                    //    Console.WriteLine("id = " + dr["id"] + " Name = " + dr["Name"]);
                    //}
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
