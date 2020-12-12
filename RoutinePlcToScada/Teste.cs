//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace RoutinePlcToScada
//{
//    class Teste
//    {
//        static void Main(string[] args)
//        {
//            while (true)
//            {
//                task();
//            }

//        }

//        static async void task()
//        {
//            Parallel.Invoke(() =>
//            {
//                TesteAwait();
//            }, () =>
//            {
//                Primeiro();
//            }, () =>
//            {
//                Segundo();
//            }, () =>
//            {
//                Terceiro();
//            });




//        }
//        static async void TesteAwait()
//        {
//            Console.WriteLine("{0}", await Task.Run(() => Mensagem("nome")));

//        }
//        static async void Primeiro()
//        {
//            Console.WriteLine("{0}", await Task.Run(() => "Primeiroooooooo"));
//            task();
//        }
//        static async void Segundo()
//        {
//            Thread.Sleep(2000);
//            Console.WriteLine("{0}", await Task.Run(() => "Segundo"));

//        }
//        static async void Terceiro()
//        {

//            Thread.Sleep(3000);

//            Console.WriteLine("{0}", await Task.Run(() => "Terceiro"));


//        }
//        static string Mensagem(string nome)
//        {
//            Thread.Sleep(20000);

//            return "Hello, " + nome;

//        }


//    }
//}
