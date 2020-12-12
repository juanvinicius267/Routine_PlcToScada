using Opc.UaFx;
using Opc.UaFx.Client;
using RoutinePlcToScada.Dao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoutinePlcToScada
{
    public class ReadComponentesData
    {
        public  void GetData(OpcClient client)
        {
            ConnectionDB data = new ConnectionDB();
            data.UpdateData("dbo.CompOpc", ReadPlcData(client));
        }
        private List<object> ReadPlcData(OpcClient client)
        {
            List<object> dados = new List<object>();
            OpcReadNode[] commands = new OpcReadNode[] {
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Comp.Timer"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Comp.StopTime"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Comp.Objetivo"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Comp.Atual"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Comp.TempoRetornoParada"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Comp.Andon"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Comp.Emergencias"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Comp.CorDeTela"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Comp.NumMensagem"),
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