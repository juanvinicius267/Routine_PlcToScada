using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Opc.UaFx;
using Opc.UaFx.Client;
using RoutinePlcToScada.Dao;

namespace RoutinePlcToScada
{
    public class ReadCabData
    {
        public  void  GetData(OpcClient client)
        {
            ConnectionDB data = new ConnectionDB();
            data.UpdateData("dbo.CabOpc", ReadPlcData(client));

        }

        private List<object> ReadPlcData(OpcClient client)
        {
            List<object> dados = new List<object>();
            OpcReadNode[] commands = new OpcReadNode[] {
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Cabinas.Timer"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Cabinas.StopTime"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Cabinas.Objetivo"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Cabinas.Atual"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Cabinas.TempoRetornoParada"),         
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Cabinas.Andon"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Cabinas.Emergencias"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Cabinas.CorDeTela"),
            new OpcReadNode("ns=3;s=\"DB600_DadosScada\".Cabinas.NumMensagem"),            
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
            
        