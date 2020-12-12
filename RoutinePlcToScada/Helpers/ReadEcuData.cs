using Opc.UaFx;
using Opc.UaFx.Client;
using RoutinePlcToScada.Dao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoutinePlcToScada
{
    public class ReadEcuData
    {
        public  void GetData(OpcClient client) 
        {
            ConnectionDB data = new ConnectionDB();
           data.UpdateData("dbo.EcuOpc", ReadPlcData(client));
        }

        private List<object> ReadPlcData(OpcClient client)
        {
            List<object> dados = new List<object>();
            OpcReadNode[] commands = new OpcReadNode[] {
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Ecu.Timer"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Ecu.StopTime"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Ecu.Objetivo"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Ecu.Atual"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Ecu.TempoRetornoParada"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Ecu.Andon"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Ecu.Emergencias"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Ecu.CorDeTela"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Ecu.NumMensagem"),
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