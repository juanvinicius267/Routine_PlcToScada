using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TcpPlcToScadaSincrona.Models;

namespace TcpPlcToScadaSincrona.Dao
{
    public class DbAgvs
    {
        string connectionString = "Data Source=M13138\\SQLSERVER;Initial Catalog=NewTakt;User ID=sa;Password=SenhaSql2019;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Insere no banco de dados os valores atualizados dos AGVs
        public void UpdateData(List<AgvDataFormat> data)
        {

            //Console.WriteLine("Entrou dbagv");
            for (int i = 0; i < data.Count; i++)
            {
                


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string queryString = $"UPDATE dbo.Agvs SET Sinais='{Convert.ToString(data[i].sinais)}'" +
                            $", Posto ='{Convert.ToString(data[i].posto)}'" +
                            $", Comando ='{Convert.ToString(data[i].comando)}'" +
                            $", Velocidade ='{Convert.ToString(data[i].velocidade)}'" +
                            $", Processo ='{Convert.ToString(data[i].processo)}'" +
                            $", VelAtual ='{Convert.ToString(data[i].velAtual)}'" +
                            $", Erros_Agv ='{Convert.ToString(data[i].errosAgv)}'" +
                            $", Erros_Pgv ='{Convert.ToString(data[i].errosPgv)}'" +
                            $", Erros_Motor ='{Convert.ToString(data[i].errosMotorPasso)}'" +
                            $" WHERE Id='{ Convert.ToString(Convert.ToInt16(data[i].idAgv))}'";
                    
                    SqlCommand command = new SqlCommand(queryString, connection);
                    //Console.WriteLine(queryString);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
               
            }
        }
    }
}
