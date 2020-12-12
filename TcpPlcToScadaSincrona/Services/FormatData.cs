using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TcpPlcToScadaSincrona.Models;

namespace TcpPlcToScadaSincrona
{
    public class FormatData
    {
        //Converte a string para o formato Json conforme o modelo de dados do AGV
        public List<AgvDataFormat> FormaterAgv(string infos)
        {
            List<AgvDataFormat> data = new List<AgvDataFormat>();
            if ((infos.Contains("idAgv") && infos.Contains("sinais") && infos.Contains("posto")
                && infos.Contains("comando") && infos.Contains("velocidade") && infos.Contains("processo")
                && infos.Contains("velAtual") && infos.Contains("errosAgv") && infos.Contains("errosPgv")
                && infos.Contains("errosMotorPasso")) == true && (infos.Contains("idLine") || infos.Contains("timer") || infos.Contains("stopTime")
                || infos.Contains("objetivo") || infos.Contains("atual") || infos.Contains("tempoRetornoParada")
                || infos.Contains("andon") || infos.Contains("emergencia") || infos.Contains("corDeTela")
                || infos.Contains("numMesagem")) == false) {
               
                try
                {                   
                    data.Add(JsonConvert.DeserializeObject<AgvDataFormat>(infos.Remove(0, 2)));                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(infos.Remove(0, 2));
                    Console.WriteLine(e);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine(infos.Remove(0, 2));
            }
           
            return data;
        }
        //Converte a string para o formato Json conforme o modelo de dados do Takt
        public List<PlcDataFormat> FormaterTakt(string infos)
        {
            List<PlcDataFormat> data = new List<PlcDataFormat>();
            if ((infos.Contains("idLine") && infos.Contains("timer") && infos.Contains("stopTime")
                && infos.Contains("objetivo") && infos.Contains("atual") && infos.Contains("tempoRetornoParada")
                && infos.Contains("andon") && infos.Contains("emergencia") && infos.Contains("corDeTela")
                && infos.Contains("numMesagem")) == true && (infos.Contains("idAgv") || infos.Contains("sinais") || infos.Contains("posto")
                || infos.Contains("comando") || infos.Contains("velocidade") || infos.Contains("processo")
                || infos.Contains("velAtual") || infos.Contains("errosAgv") || infos.Contains("errosPgv")
                || infos.Contains("errosMotorPasso")) == false)
            {
                try
                {                   
                    data.Add(JsonConvert.DeserializeObject<PlcDataFormat>(infos.Remove(0, 2)));                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(infos.Remove(0, 2));                    
                    Console.WriteLine(e);                   
                }
            }
            
            return data;
        }       

    }
}
