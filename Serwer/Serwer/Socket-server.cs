using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;


/*
 Aplikacja serwera ma być wykonana jako aplikacja konsolowa.
 Ma umożliwiać konfigurację portu nasłuchu.
 Ma umożliwić jednoczesną obsługę wielu połączeń (wielowątkowość!).
 Odebrane pliki należy składować w wybranym folderze, zachowując rozszerzenie oryginału oraz dbając o brak duplikacji nazw.
 */

namespace Serwer
{
    class Socket_server
    {
        // Listener or server sockets open a port on the network 
        // and then wait for a client to connect to that port. 
        // for the server

        private IPAddress ipAddressServer;
        private int portServer;
        private IPEndPoint localEndPoint;
        // Create a TCP/IP socket.  
        private Socket listener;
        // Data buffer for incoming data.  
        private byte[] bytes = new byte[1024];

        public Socket_server()
        {
            setIPEndPointForServer();
            associatedWithEndpoint();
            waitingForTheConnection();
            Console.WriteLine("Połączenie zakończone");
        }

        // creates an IPEndPoint for a server 
        // by combining the first IP address returned by Dns for the host computer 
        // with a port number chosen from the registered port numbers range.
        public void setIPEndPointForServer()
        {
            String serverIpAddress = GetLocalIPAddress();
            ipAddressServer = IPAddress.Parse(serverIpAddress);

            try
            {
                Console.WriteLine("Wprowadz numer portu do nasluchu [1024, 65535]: ");
                String portServerString = Console.ReadLine();
                portServer = int.Parse(portServerString);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }

            if (portServer < 1024 || portServer > 65535)
            {
                throw new Exception("Port serwera moze zawierac sie tylko w przedziale [1024, 65535]");
            }

            localEndPoint = new IPEndPoint(ipAddressServer, portServer);
            Console.WriteLine("Nasluchiwany jest: " + localEndPoint);

            //Console.WriteLine(localEndPoint);
        }

        // the Socket must be associated with that endpoint 
        // using the Bind method and set to listen on the endpoint using the Listen method. 
        // Bind throws an exception if the specific address and port combination is already in use.
        public void associatedWithEndpoint()
        {
            this.listener = new Socket(this.ipAddressServer.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);

            // The Listen method takes a single parameter that specifies 
            // how many pending connections to the Socket are allowed before 
            // a server busy error is returned to the connecting client. 
            listener.Listen(100);
        }

        // start lisening for the connection
        public void waitingForTheConnection()
        {
            Console.WriteLine("Waiting for a connection...");
            // Program is suspended while waiting for an incoming connection.  
            Socket handler = listener.Accept();
            String data = null;

            while (true)
            {
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }
            }

            Console.WriteLine("Text received : {0}", data);

            // Echo the data back to the client.
            //byte[] msg = Encoding.ASCII.GetBytes(data);
            //handler.Send(msg);
            closeConnection(handler);
        }

        private void closeConnection(Socket s)
        {
            // When the socket is no longer needed, you need to release it 
            // by calling the Shutdown method and then calling the Close method.
            s.Shutdown(SocketShutdown.Both);
            s.Close();
        }

        private static string GetLocalIPAddress()
        {
            /*
             * https://stackoverflow.com/questions/6803073/get-local-ip-address
             * You can disregard the Ethernet adapter by its name. 
             * As the VM Ethernet adapter is represented by a valid NIC driver, 
             * it is fully equivalent to the physical NIC of your machine from the OS's point of view.
             * */

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
