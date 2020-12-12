using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestPlc
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                var inicio = DateTime.Now;

                Parallel.Invoke(
                    () => { Request(); },
                    () => { Request(); },
                    () => { Request(); },
                    () => { Request(); }
                    );

                var fim = DateTime.Now;
                Console.WriteLine(fim - inicio);
            }
            
            Console.ReadLine();
        }
        static async void Request()
        {
            string urlAddress = "http://10.8.77.70/awp/index.html";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                string data = readStream.ReadToEnd();
                //Console.WriteLine(data);
                response.Close();
                readStream.Close();
                Console.WriteLine("Aquie!");
            }
        }
    }
}
