using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TcpPlcToScadaSincrona.Models;

namespace TcpPlcToScadaSincrona.Dao
{
    public class DbTakt
    {
        string connectionString = "Data Source=M13138\\SQLSERVER;Initial Catalog=NewTakt;User ID=sa;Password=SenhaSql2019;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void InsertData(List<PlcDataFormat> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                { 
                    //Cria uma objeto do tipo comando passando como
                    string queryString = $"UPDATE dbo.Takt SET Timer={Convert.ToInt32(data[i].timer)}" +
                            $", StopTime ={Convert.ToInt32(data[i].stopTime)}" +
                            $", Objetivo ={Convert.ToInt32(data[i].objetivo)}" +
                            $", Atual ={Convert.ToInt32(data[i].atual)}" +
                            $", TempoRetornoParada ={Convert.ToInt32(data[i].tempoRetornoParada)}" +
                            $", Andon ={Convert.ToInt32(data[i].andon)}" +
                            $", Emergencias ={Convert.ToInt32(data[i].emergencia)}" +
                            $", CorDaTela ={Convert.ToInt32(data[i].corDeTela)}" +
                            $", NumMensagem ={Convert.ToInt32(data[i].numMesagem)}" +
                            $", DataEscrita = GETDATE()" +
                            $" WHERE Linha='{data[i].idLine}'";

                    
                    //Cria uma objeto do tipo comando passando como parametro a string sql e a string de conexão
                    SqlCommand command = new SqlCommand(queryString, connection);

                    
                    //abre a conexao
                    //Console.WriteLine(queryString);
                    command.Connection.Open();
                    //executa o comando com os parametros que foram adicionados acima
                    command.ExecuteNonQuery();
                    //fecha a conexao
                    command.Connection.Close();
             }
            }
        }
    }
}
