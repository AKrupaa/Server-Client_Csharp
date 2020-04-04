using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;
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

        //private IPAddress ipAddressServer;
        //private int portServer;
        //private IPEndPoint localEndPoint;
        //// Create a TCP/IP socket.  
        //private Socket listener;
        // Data buffer for incoming data.  
        //private byte[] bytes = new byte[1024];

        public Socket_server()
        {
        }

        public void startServer(String portInputed)
        {
            setIPEndPointForServer(portInputed);
        }

        // creates an IPEndPoint for a server 
        // by combining the first IP address returned by Dns for the host computer 
        // with a port number chosen from the registered port numbers range.
        private void setIPEndPointForServer(String portInputed)
        {
            int portServer = 0;
            IPAddress ipAddressServer;
            IPEndPoint localEndPoint;
            String serverIpAddress = GetLocalIPAddress();
            ipAddressServer = IPAddress.Parse(serverIpAddress);

            try
            {
                portServer = int.Parse(portInputed);
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


            associatedWithEndpoint(ipAddressServer, localEndPoint);
        }

        // the Socket must be associated with that endpoint 
        // using the Bind method and set to listen on the endpoint using the Listen method. 
        // Bind throws an exception if the specific address and port combination is already in use.
        private void associatedWithEndpoint(IPAddress ipAddressServer, IPEndPoint localEndPoint)
        {
            // Create a TCP/IP socket.  
            Socket listener;
            listener = new Socket(ipAddressServer.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(localEndPoint);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Source + ex.Message);
            }


            // The Listen method takes a single parameter that specifies 
            // how many pending connections to the Socket are allowed before 
            // a server busy error is returned to the connecting client. 
            try
            {
                listener.Listen(100);
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.Source + se.Message);
            }


            waitingForTheConnection(ref listener);
        }

        // start lisening for the connection
        private void waitingForTheConnection(ref Socket listener)
        {
            //Console.WriteLine("waiting for a connection...");
            // Program is suspended while waiting for an incoming connection.  
            try
            {
                Socket handler = listener.Accept();
                String data = null;


                // tu zdobywam rozmiar przychodzacego pliku
                while (true)
                {
                    // Data buffer for incoming data.  
                    byte[] bytes = new byte[1024];
                    // liczba bitow otrzymanych
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("KONIEC") > -1)
                    {
                        break;
                    }
                }
                // rozmiar pliku, ktory otrzymamy bez wyrazenia KONIEC
                int rozmiarPlikuDoOtrzymania = int.Parse(data.Substring(0, data.Length - 6));
                // utworz taki buffer na dane
                byte[] bytesZawierajacyPlik = new byte[rozmiarPlikuDoOtrzymania];
                // otrzymaj dane
                int otrzymanyRozmiar = handler.Receive(bytesZawierajacyPlik);

                // miejscwe na: nazwa pliku + rozszerzenie
                string stringNazwaPlikuZRozszerzeniem;
                byte[] bytesNazwaPlikuZRozszerzeniem = new byte[250];
                int rozmiarNazwaPlikuZRozszerzeniem;

                rozmiarNazwaPlikuZRozszerzeniem = handler.Receive(bytesNazwaPlikuZRozszerzeniem);
                stringNazwaPlikuZRozszerzeniem = Encoding.ASCII.GetString(bytesNazwaPlikuZRozszerzeniem);

                // jak nie ma rozszerzenia
                if (stringNazwaPlikuZRozszerzeniem.Length < 2)
                    stringNazwaPlikuZRozszerzeniem = "nazwa.rozszerzenie";
                // jest plik z rozszerzeniem (?)

                // zapisz gdzies plik
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                stringNazwaPlikuZRozszerzeniem = stringNazwaPlikuZRozszerzeniem.Trim('\0');

                FileStream fs = File.Create(path + "\\\\" + stringNazwaPlikuZRozszerzeniem);
                fs.Write(bytesZawierajacyPlik, 0, otrzymanyRozmiar);
                fs.Close();

                Console.WriteLine("Połączenie " + handler.LocalEndPoint + " zakończone");
                closeConnection(handler);
                listener.Close();
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Source + ioe.Message);
            }
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
