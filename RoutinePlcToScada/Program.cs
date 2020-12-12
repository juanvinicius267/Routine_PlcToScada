using Opc.UaFx;
using Opc.UaFx.Client;
using RoutinePlcToScada.Dao;
using RoutinePlcToScada.Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace RoutinePlcToScada
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<object> dados = new List<object>();
                while (true)
                {
                    Ping ping = new Ping();
                    string ip = "10.8.77.70";
                    IPAddress address = IPAddress.Parse(ip);
                    PingReply pong = ping.Send(address);
                    if (pong.Status == IPStatus.Success)
                    {
                        Console.WriteLine(ip + " is up and running.");
                        int rep = 0;
                        using (var client = new OpcClient("opc.tcp://10.8.77.70:4840"))
                        {
                            client.Connect();
                            Console.WriteLine("Conectoooooooooooooou");
                            while (rep < 100)
                            {
                                var inicio = DateTime.Now;
                                Parallel.Invoke(() =>
                                {
                                    ReadCabData dataCab = new ReadCabData();
                                    dataCab.GetData(client);
                                }, () =>
                                {
                                    ReadSkdData dataSkd = new ReadSkdData();
                                    dataSkd.GetData(client);
                                }, () =>
                                {
                                    ReadComponentesData dataComponentes = new ReadComponentesData();
                                    dataComponentes.GetData(client);
                                }, () =>
                                {
                                    ReadEcuData dataEcu = new ReadEcuData();
                                    dataEcu.GetData(client);
                                },
                                () =>
                                {
                                    ReadAgvsData dataAgvs = new ReadAgvsData();
                                    dataAgvs.GetData(client);
                                });
                                var fim = DateTime.Now;
                                Console.WriteLine(fim - inicio);
                                rep++;
                            }
                            client.Disconnect();
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();               
            }
        }
    }
}





