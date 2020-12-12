using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace RoutinePlcToScada.Dao
{
    public class ConnectionDB
    {
         string connectionString = "Data Source=M13138\\SQLSERVER;Initial Catalog=NewTakt;User ID=sa;Password=SenhaSql2019;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void UpdateDataAgv(string tableName, List<List<Object>> dados)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    
                    string queryString = "";
                    for (int i = 1; i < dados.Count; i++)
                    {
                        queryString = $"UPDATE {tableName} SET Sinais='{Convert.ToString(dados[i - 1][0])}'" +
                            $", Posto ='{Convert.ToString(dados[i - 1][1])}'" +
                            $", Comando ='{Convert.ToString(dados[i - 1][2])}'" +
                            $", Velocidade ='{Convert.ToString(dados[i - 1][3])}'" +
                            $", Processo ='{Convert.ToString(dados[i - 1][4])}'" +
                            $", VelAtual ='{Convert.ToString(dados[i - 1][5])}'" +
                            $", Erros_Agv ='{Convert.ToString(dados[i - 1][6])}'" +
                            $", Erros_Pgv ='{Convert.ToString(dados[i - 1][7])}'" +
                            $", Erros_Motor ='{Convert.ToString(dados[i - 1][8])}'" +
                            $" WHERE Id='{i}'";
                        SqlCommand command = new SqlCommand(queryString, connection);
                        //Console.WriteLine(queryString);
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                        command.Connection.Close();
                    }                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Deu ruim AGV Tabela: " + e);                
            }
        }

        public  bool UpdateData (string tableName, List<object> dados)
        {
           
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string queryString = "";
                    for (int i = 1; i < dados.Count; i++)
                    {
                        queryString = $"UPDATE {tableName} SET WriteValue='{Convert.ToString(dados[i - 1])}' WHERE Id='{ Convert.ToString(i)}'";
                        SqlCommand command = new SqlCommand(queryString, connection);
                        //Console.WriteLine(queryString);
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                        command.Connection.Close();
                    }
                   
                    return true;
                }                    
               
            }
            catch (Exception e)
            {
                Console.WriteLine("Deu ruim: " + e);
                return false;
            }
           
        }
    }
}
