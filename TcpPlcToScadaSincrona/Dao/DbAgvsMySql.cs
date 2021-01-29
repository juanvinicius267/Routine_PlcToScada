using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TcpPlcToScadaSincrona.Models;

namespace CallPlc_UsingTCP.Dao
{
    public class DbAgvsMySql
    {
        public void UpdateData(List<AgvDataFormat> data)
        {
            string connStr = "server=10.251.16.112;user=root;database=taktkd;port=3308;password=SenhaSql2019";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                for (int i = 0; i < data.Count; i++)
                {

                    string sql = $"UPDATE agvs SET Sinais='{Convert.ToString(data[i].sinais)}'" +
                            $", Posto ='{Convert.ToString(data[i].posto)}'" +
                            $", Comando ='{Convert.ToString(data[i].comando)}'" +
                            $", Velocidade ='{Convert.ToString(data[i].velocidade)}'" +
                            $", Processo ='{Convert.ToString(data[i].processo)}'" +
                            $", VelAtual ='{Convert.ToString(data[i].velAtual)}'" +
                            $", Erros_Agv ='{Convert.ToString(data[i].errosAgv)}'" +
                            $", Erros_Pgv ='{Convert.ToString(data[i].errosPgv)}'" +
                            $", Erros_Motor ='{Convert.ToString(data[i].errosMotorPasso)}'" +
                            $" WHERE Id='{ Convert.ToString(Convert.ToInt16(data[i].idAgv))}'";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}
