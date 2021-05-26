using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace TrueServerForms
{
    public partial class Form1 : Form
    {
        TcpListener listener;
        TcpClient   klient;
        int         port = 12345;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            klient = listener.AcceptTcpClient();

            byte[] inData = new byte[256];
            int antalByte = klient.GetStream().Read(inData, 0, inData.Length);

            tbxInbox.Text = Encoding.Unicode.GetString(inData, 0, antalByte);
            klient.Close();
            listener.Stop();

        }
    }
}
