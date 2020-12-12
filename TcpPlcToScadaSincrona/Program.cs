using System;
using System.Net;
using System.Net.Sockets;
using TcpPlcToScadaSincrona;
using TcpPlcToScadaSincrona.Services;

namespace Socket_Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            IniciarServidor();
        }
        static IPEndPoint ipEnd_servidor;
        static Socket sock_Servidor;     
        public static void IniciarServidor()
        {
            try
            {
                //Define o IP do servidor
                string strEnderecoIP = "10.8.77.65";//10.8.77.65

                //Cria um IPEndPoint usando o IP , e a porta onde o servidor estará escutando
                ipEnd_servidor = new IPEndPoint(IPAddress.Parse(strEnderecoIP), 11000);//11000

                //Cria um objeto Socket usando uma família de endereços e definindo o tipo de soquete como stream que oferece suporte a fluxos de bytes bidirecional
                sock_Servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

                //Associa o socket ao EndPoint criado. Deve usar um Bind antes de chamar o Listen
                sock_Servidor.Bind(ipEnd_servidor);
            }
            catch (Exception ex)
            {
                //Detecta falhas e escreve na console
                Console.WriteLine("Erro ao iniciar servidor : " + ex.Message);

                Console.ReadLine();
                return;
            }

            try
            {
                Console.WriteLine("Subindo o servidor no IP: " + sock_Servidor.LocalEndPoint);
                //Coloca o socket em estado de escuta a espera da requisição do cliente indicando o número de conexões de entrada que podem ser colocadas na fila como igual a 100

                sock_Servidor.Listen(100);
                //Cria o novo socket para a conexão ativa a partir da conexões que estão na fila
                Socket clienteSock = sock_Servidor.Accept();

                //Define o tamanho do buffer de recebimento do socket
                clienteSock.ReceiveBufferSize = 130000;

                Console.WriteLine("O Ip: "+Convert.ToString(clienteSock.RemoteEndPoint)+ " esta conectado a rede");

                //Declara a memoria pra guardar os bytes recebidos
                byte[] dadosCliente = new byte[2048];

                //Declara as classes para serem chamadas
                FormatData format = new FormatData();

                ReadData read = new ReadData();

                //Enquanto o PLC estiver conectado fica lendo os dados 
                while (clienteSock.Connected)
                {
                    //Aguarda o PLC enviar dados para o TCP Servidor
                    clienteSock.Receive(dadosCliente, dadosCliente.Length, 0);
                    var inicio = DateTime.Now;
                    //Realiza a formatação para que o formatador de Json possa formatar os dados e realiza a gravação dos dados no DB
                    read.Formater(read.FormaterForJson(dadosCliente), format);
                    var fim = DateTime.Now;
                    Console.WriteLine("Tempo de Logica: " + (fim - inicio));
                }                
                //Finaliza a conexão e servidor.
                clienteSock.Close();
                Console.ReadKey();

            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message + " - Erro ao receber arquivo.");
                Console.ReadLine();
            }
        }
    }

}
