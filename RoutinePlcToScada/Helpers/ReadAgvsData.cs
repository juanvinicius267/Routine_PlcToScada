using Opc.UaFx;
using Opc.UaFx.Client;
using RoutinePlcToScada.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutinePlcToScada.Helpers
{
    public class ReadAgvsData
    {
        public void GetData(OpcClient client)
        {
            List<List<Object>> infos = new List<List<Object>>();
            for (int i = 0; i <= 9; i++)
            {
                infos.Add(ReadPlcData(client, i));
            };
            ConnectionDB data = new ConnectionDB();
            data.UpdateDataAgv("dbo.Agvs", infos);

        }

        private List<object> ReadPlcData(OpcClient client, int i)
        {
            List<object> dados = new List<object>();
            OpcReadNode[] commands = new OpcReadNode[] {
                // "DB600_DadosScada".AGV[1].Sinais
            new OpcReadNode($"ns=3;s=\"DB600_DadosScada\".AGV[{i}].Sinais"),
            new OpcReadNode($"ns=3;s=\"DB600_DadosScada\".AGV[{i}].Posto"),
            new OpcReadNode($"ns=3;s=\"DB600_DadosScada\".AGV[{i}].Comando"),
            new OpcReadNode($"ns=3;s=\"DB600_DadosScada\".AGV[{i}].Velocidade"),
            new OpcReadNode($"ns=3;s=\"DB600_DadosScada\".AGV[{i}].Processo"),
            new OpcReadNode($"ns=3;s=\"DB600_DadosScada\".AGV[{i}].VelAtual"),
            new OpcReadNode($"ns=3;s=\"DB600_DadosScada\".AGV[{i}].\"Erros.Agv\""),
            new OpcReadNode($"ns=3;s=\"DB600_DadosScada\".AGV[{i}].\"Erros.Pgv\""),
            new OpcReadNode($"ns=3;s=\"DB600_DadosScada\".AGV[{i}].\"Erros.MotorPasso\"")
        };
            IEnumerable<OpcValue> jobDisplayNames = client.ReadNodes(commands);
            foreach (OpcValue value in jobDisplayNames)
            {
                dados.Add(value);
            }
            return dados;



        }
    }
}
