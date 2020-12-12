using Opc.UaFx;
using Opc.UaFx.Client;
using RoutinePlcToScada.Dao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoutinePlcToScada
{
    public class ReadSkdData
    {
        public void GetData(OpcClient client)
        {            
            ConnectionDB data = new ConnectionDB();
            data.UpdateData("dbo.SkdOpc", ReadPlcData(client));
           
        }
        private List<object> ReadPlcData(OpcClient client)
        {
            List<object> dados = new List<object>();
            OpcReadNode[] commands = new OpcReadNode[] {
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Skd.Timer"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Skd.StopTime"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Skd.Objetivo"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Skd.Atual"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Skd.TempoRetornoParada"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Skd.Andon"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Skd.Emergencias"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Skd.CorDeTela"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Skd.NumMensagem"),
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
