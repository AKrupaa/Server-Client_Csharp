using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //client.setIPEndPointForClient();
            //client.connectToRemoteDevice();
        }

        private void buttonSendFile_Click(object sender, EventArgs e)
        {
            String getIPText = textBox_IPaddress.Text;
            String getPortText = textBox_Port.Text;

            try
            {
                int parsedPort = int.Parse(getPortText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + ex.ToString());
            }


            try
            {
                if (int.Parse(getPortText) < 1024 || int.Parse(getPortText) > 65535)
                {
                    MessageBox.Show("Port powienien zawierac sie e [1024, 65535]");
                }
                else
                {
                    Thread newThread;
                    Socket_client socketClient = new Socket_client();

                    newThread = new Thread(() => socketClient.startClient(getIPText, getPortText));
                    newThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source + ex.ToString());
            }


            //int size = -1;
            //DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            //if (result == DialogResult.OK) // Test result.
            //{
            //    string file = openFileDialog.FileName;
            //    try
            //    {
            //        string text = File.ReadAllText(file);
            //        size = text.Length;
            //    }
            //    catch (IOException)
            //    {
            //    }
            //}
            //Console.WriteLine(size); // <-- Shows file size in debugging mode.
            //Console.WriteLine(result); // <-- For debugging use.
            //textBox_TextToSend.Text = openFileDialog.FileName;
        }
    }
}
