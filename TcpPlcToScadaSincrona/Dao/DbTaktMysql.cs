using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TcpPlcToScadaSincrona.Models;

namespace CallPlc_UsingTCP.Dao
{
    public class DbTaktMysql
    {
        public void InsertData(List<PlcDataFormat> data)
        {
            string connStr = "server=10.251.16.112;user=root;database=taktkd;port=3308;password=SenhaSql2019";
           
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                for (int i = 0; i < data.Count; i++)
                {
                    Console.WriteLine(data[i].idLine);
                    string sql = $"UPDATE takt SET Timer={Convert.ToInt32(data[i].timer)}" +
                            $", StopTime ={Convert.ToInt32(data[i].stopTime)}" +
                            $", Objetivo ={Convert.ToInt32(data[i].objetivo)}" +
                            $", Atual ={Convert.ToInt32(data[i].atual)}" +
                            $", TempoRetornoParada ={Convert.ToInt32(data[i].tempoRetornoParada)}" +
                            $", Andon ={Convert.ToInt32(data[i].andon)}" +
                            $", Emergencias ={Convert.ToInt32(data[i].emergencia)}" +
                            $", CorDaTela ={Convert.ToInt32(data[i].corDeTela)}" +
                            $", NumMensagem ={Convert.ToInt32(data[i].numMesagem)}" +
                            $" WHERE Linha='{data[i].idLine}'";
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
