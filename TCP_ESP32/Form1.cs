using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using SimpleTCP;
using System.Windows.Forms;

namespace TCP_ESP32
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpClient client;

        private void btn_conectar_Click(object sender, EventArgs e)
        {
            client.Connect(txtHost.Text, Convert.ToInt32(txtPorta.Text));
            btn_desconectar.Enabled = true;


            if (client.TcpClient.Connected == true)
            {

                btn_conectar.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();

            client.StringEncoder = Encoding.UTF8;

            client.DataReceived += Client_DataReceived;




        }

        private void Client_DataReceived (object sender , SimpleTCP.Message e)
        {
            textBox3.Invoke((MethodInvoker)delegate () {

                textBox3.Text += e.MessageString;         
            
            
            
            });
        }

        private void btn_desconectar_Click(object sender, EventArgs e)
        {
            if (client.TcpClient.Connected == true)
            {
                client.Disconnect();
                btn_conectar.Enabled = true;
                btn_desconectar.Enabled = false;
            }
        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            if (client.TcpClient.Connected == true)
            {
                client.Write(txtEnviar.Text+"\n"+"\r");
            }

        }
    }
}
