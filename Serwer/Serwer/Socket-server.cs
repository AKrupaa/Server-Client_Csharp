using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Serwer
{
    class Socket_server
    {
        // The following example creates a Socket 
        // that can be used to communicate on a TCP/IP-based network, such as the Internet.
        private Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // UDP
        //Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);


        // The combination of network address and service port is called an endpoint
        // port numbers in the range 1,024 to 65,535.
        // for the client

        private IPAddress ipAddressClient;
        private int portClient;
        private IPEndPoint ipe;


        // Listener or server sockets open a port on the network 
        // and then wait for a client to connect to that port. 
        // for the server

        private IPHostEntry ipHostInfo;
        private IPAddress ipAddressServer;
        private int portServer;
        private IPEndPoint localEndPoint;
        private Socket listener;

        // The combination of network address and service port is called an endpoint
        // port numbers in the range 1,024 to 65,535.
        public void setIPEndPointForClient(long ipAddress, int port)
        {
            Console.WriteLine("Enter ip address: ");
            string ip = Console.ReadLine();
            this.ipAddressClient = IPAddress.Parse(ip);
            this.portClient = 0;

            while(port<1024 && port >65535)
            {
                Console.WriteLine("Enter port: ");
                int p = int.Parse(Console.ReadLine());
                this.portClient = p;
            }

            // The following code combines the IP address for ip with a port number
            // to create a remote endpoint for a connection.
            this.ipe = new IPEndPoint(this.ipAddressClient, this.portClient);
        }


        // After determining the address of the remote device and choosing a port to use for the connection, 
        // the application can attempt to establish a connection with the remote device.
        // The following example uses an existing IPEndPoint 
        // to connect to a remote device and catches any exceptions that are thrown.
        public void connectToRemoteDevice()
        {
            try
            {
                s.Connect(ipe);
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine("ArgumentNullException : {0}", ae.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
        }

        // The following example encodes a string into a byte array buffer 
        // using the Encoding.ASCII property and then 
        // transmits the buffer to the network device using the Send method.
        // The Send method returns the number of bytes sent to the network device.
        public int sendText(string text)
        {
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(text);
            int bytesSent = this.s.Send(msg);

            closeConnection(this.s);

            // returns the number of bytes sent to the network device
            return bytesSent;
        }

        private void closeConnection(Socket s)
        {
            // When the socket is no longer needed, you need to release it 
            // by calling the Shutdown method and then calling the Close method.
            s.Shutdown(SocketShutdown.Both);
            s.Close();
        }


        // To receive data from a network device, 
        // pass a buffer to one of the Socket class's receive-data methods (Receive and ReceiveFrom).
        // The Receive method returns the number of bytes received from the network.
        public int receiveText()
        {
            byte[] bytes = new byte[1024];
            int bytesRec = s.Receive(bytes);
            Console.WriteLine("Echoed text = {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));

            // The Receive method returns the number of bytes received from the network.
            return bytesRec;
        }

        // Listener or server sockets open a port on the network 
        // and then wait for a client to connect to that port. 

        // creates an IPEndPoint for a server 
        // by combining the first IP address returned by Dns for the host computer 
        // with a port number chosen from the registered port numbers range.
        public void setIPEndPointForServer()
        {
            this.ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            this.ipAddressServer = ipHostInfo.AddressList[0];
            this.localEndPoint = new IPEndPoint(ipAddressServer, 11000);
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

    }
}
