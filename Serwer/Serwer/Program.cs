using System;

namespace Serwer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Socket_server server = new Socket_server();
            server.setIPEndPointForServer();
            //server.associatedWithEndpoint();
            //server.waitingForTheConnection();
            //server.receiveText();
        }
    }
}
