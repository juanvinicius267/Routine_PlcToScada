using System;
using System.Data.SqlClient;

namespace TcpPlcToScadaSincrona.Dao
{
    public class ConnectionDB
    {
        string connectionString = "Data Source=M13138\\SQLSERVER;Initial Catalog=NewTakt;User ID=sa;Password=SenhaSql2019;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public SqlConnection CreateConenction()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return connection;
                }
            }
            catch (Exception e)
            {
                  
                Console.WriteLine(e);
                Console.ReadLine();
                SqlConnection connection2 = new SqlConnection(connectionString);
                return connection2;
            }
            
        }
    }
}
