using System;
using System.Threading;

namespace Serwer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(" Zapamietaj!" +
                "\n Jezeli chcesz otworzyc nowe nasluchiwanie wpisz 'tak'" +
                "\n Jezeli chcesz wyjsc 'nie'");
            while (true)
            {
                String czyWystartowac;
                
                czyWystartowac = Console.ReadLine();
                if (czyWystartowac.Equals("tak"))
                {
                    try
                    {
                        Console.Write("Wpisz port nasluchu: ");
                        String portInputed = Console.ReadLine();

                        Thread newThread;
                        Socket_server server = new Socket_server();
                        newThread = new Thread(() => server.startServer(portInputed));
                        newThread.Start();
                    } catch (Exception e)
                    {
                        Console.WriteLine(e.Source + e.Message);
                    }
                    
                }
                else if(czyWystartowac.Equals("nie"))
                {
                    Console.WriteLine("Oczekiwanie na skończenie połączeń...");
                    break;
                }
            }

        }
    }
}
