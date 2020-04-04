using System;
using System.Net;
using System.Net.Sockets;


namespace Klient
{
    class Socket_client
    {
        // The following example creates a Socket 
        // that can be used to communicate on a TCP/IP-based network, such as the Internet.
        private Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // The combination of network address and service port is called an endpoint
        // port numbers in the range 1,024 to 65,535.
        // for the client

        private IPAddress ipAddressClient;
        private int portClient;
        private IPEndPoint ipe;

        // Data buffer for incoming data.  
        byte[] bytes = new byte[1024];

        // The combination of network address and service port is called an endpoint
        // port numbers in the range 1,024 to 65,535.
        public void setIPEndPointForClient()
        {
            Console.WriteLine("Enter ip address: ");
            //string ip = Console.ReadLine();

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            this.ipAddressClient = ipHostInfo.AddressList[0];

            //this.ipAddressClient = IPAddress.Parse();
            this.portClient = 0;

            //while (port < 1024 && port > 65535)
            //{
            //    Console.WriteLine("Enter port: ");
            //    int p = int.Parse(Console.ReadLine());
            //    this.portClient = p;
            //}

            // The following code combines the IP address for ip with a port number
            // to create a remote endpoint for a connection.
            //this.ipe = new IPEndPoint(this.ipAddressClient, this.portClient);
            this.ipe = new IPEndPoint(this.ipAddressClient, 11000);
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
    }
}
