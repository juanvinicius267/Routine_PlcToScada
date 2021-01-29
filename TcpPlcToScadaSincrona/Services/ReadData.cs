using CallPlc_UsingTCP.Dao;
using System;
using System.Text;
using TcpPlcToScadaSincrona.Dao;

namespace TcpPlcToScadaSincrona.Services
{
    public class ReadData
    {
        //Recebe os dados no formato de Byte[] e converte para string[] 
        public string[] FormaterForJson(byte[] dadosCliente)
        {
            //int tamanhoBytesRecebidos = clienteSock.Receive(dadosCliente, dadosCliente.Length, 0);
            int tamnhoNomeArquivo = BitConverter.ToInt32(dadosCliente, 0);
            string dados = Encoding.UTF8.GetString(dadosCliente).Replace("-", "");
            dados = dados.Replace("??", "");
            dados = dados.Replace("}", "};");
            string[] infos = dados.Split(';');
            return infos;
        }
        // Recebe os dados em um Array de string e chama os formatadores do formato Json para os dados do AGV e do Takt 
        public void Formater(string [] infos, FormatData format)
        {
            for (int i = 0; i < infos.Length; i++)
            {
                //Console.WriteLine(infos[i]);//.Replace("??", " "));
                if (infos[i].Contains("idAgv") && infos[i].Contains("sinais") && infos[i].Contains("posto")
                    && infos[i].Contains("comando") && infos[i].Contains("velocidade") && infos[i].Contains("processo")
                    && infos[i].Contains("velAtual") && infos[i].Contains("errosAgv") && infos[i].Contains("errosPgv")
                    && infos[i].Contains("errosMotorPasso"))
                {                    
                    DbAgvsMySql dbAgv = new DbAgvsMySql();
                    try { 
                        dbAgv.UpdateData(format.FormaterAgv(infos[i]));
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.ReadLine();
                    }
                   
            }
                else if (infos[i].Contains("idLine") && infos[i].Contains("timer") && infos[i].Contains("stopTime")
                    && infos[i].Contains("objetivo") && infos[i].Contains("atual") && infos[i].Contains("tempoRetornoParada")
                    && infos[i].Contains("andon") && infos[i].Contains("emergencia") && infos[i].Contains("corDeTela")
                    && infos[i].Contains("numMesagem"))
                {
                    DbTaktMysql dbTakt = new DbTaktMysql();        
                    try
                    {                       
                        dbTakt.InsertData( format.FormaterTakt(infos[i]));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.ReadLine();
                    }
                }

            }
        }      
    }
}
