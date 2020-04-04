﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Klient
{
    class Socket_client
    {
        public Socket_client()
        {
        }

        // The combination of network address and service port is called an endpoint
        // port numbers in the range 1,024 to 65,535.

        public void startClient(String ipAddressInputed, String portInputed)
        {
            try
            {
                setIPEndPointForClient(ipAddressInputed, portInputed);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Source + e.Message);
            }
            
        }

        private void setIPEndPointForClient(String ipAddressInputed, String portInputed)
        {
            // The combination of network address and service port is called an endpoint
            // port numbers in the range 1,024 to 65,535.
            // for the client

            IPAddress ipAddressClient = IPAddress.Parse("0.0.0.0");
            int portClient = 0;
            IPEndPoint localEndPoint;

            try
            {
                ipAddressClient = IPAddress.Parse(ipAddressInputed);
                portClient = int.Parse(portInputed);
            }
            catch (ArgumentNullException ae)
            {
                MessageBox.Show("ArgumentNullException: ", ae.ToString());
                //Console.WriteLine("ArgumentNullException: ", ae.ToString());
            }
            catch (FormatException fe)
            {
                MessageBox.Show("FormatException: ", fe.ToString());
                //Console.WriteLine("FormatException: ", fe.ToString());
            }
            catch (OverflowException oe)
            {
                MessageBox.Show("OverflowException: ", oe.ToString());
                //Console.WriteLine("OverflowException: ", oe.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show("Unexpected exception: ", e.ToString());
                //Console.WriteLine("Unexpected exception: ", e.ToString());
            }

            // The following code combines the IP address for ip with a port number
            // to create a remote endpoint for a connection.
            localEndPoint = new IPEndPoint(ipAddressClient, portClient);

            connectToRemoteDevice(localEndPoint);
        }

        // After determining the address of the remote device and choosing a port to use for the connection, 
        // the application can attempt to establish a connection with the remote device.
        // The following example uses an existing IPEndPoint 
        // to connect to a remote device and catches any exceptions that are thrown.
        private void connectToRemoteDevice(IPEndPoint localEndPoint)
        {
            // The following example creates a Socket 
            // that can be used to communicate on a TCP/IP-based network, such as the Internet.
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(localEndPoint);
                // Encode the data string into a byte array.  
                byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");
                // Send the data through the socket.  
                int bytesSent = clientSocket.Send(msg);

                // Receive the response from the remote device.  
                //int bytesRec = sender.Receive(bytes);
                //Console.WriteLine("Echoed test = {0}",
                //Encoding.ASCII.GetString(bytes, 0, bytesRec));
                //Console.WriteLine("Połączenie " + clientSocket.LocalEndPoint + " zakończone");
                closeConnection(clientSocket);
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

        private void closeConnection(Socket s)
        {
            // When the socket is no longer needed, you need to release it 
            // by calling the Shutdown method and then calling the Close method.
            s.Shutdown(SocketShutdown.Both);
            s.Close();
        }
    }
}
