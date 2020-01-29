using System;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    public static class ConnectingMySql
    {
        public static void ConnectingMySqlMain()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=HPS;Trusted_Connection=True;MultipleActiveResultSets=true";
            string sqlQuery = "select * from RequestForQuotations";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand command = new SqlCommand(sqlQuery, con);
                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    while (sqlDataReader.Read())
                    {

                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
