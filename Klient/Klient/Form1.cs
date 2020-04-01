using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klient
{
    public partial class Form1 : Form
    {
        Socket_client client = new Socket_client();

        public Form1()
        {
            InitializeComponent();
            //client.setIPEndPointForClient();
            //client.connectToRemoteDevice();
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
            textBox_TextToSend.Text = openFileDialog.FileName;
        }
    }
}
