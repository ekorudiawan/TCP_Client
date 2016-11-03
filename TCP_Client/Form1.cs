using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace TCP_Client
{
    public partial class Form1 : Form
    {
        TcpClient tcpclient;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tcpclient = new TcpClient();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            bool err = false;

            try
            {
                    
                tcpclient.Connect(textBoxIP.Text, Int32.Parse(textBoxPort.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                err = true;
            }

            if (!err)
            {
                buttonConnect.Enabled = false;
            }

        }

        private void buttonLedOn_Click(object sender, EventArgs e)
        {
            try
            {
                Stream tcpData = tcpclient.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                String data = "on";
                byte[] ba = asen.GetBytes(data);
                tcpData.Write(ba, 0, ba.Length);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void buttonLedOff_Click(object sender, EventArgs e)
        {
            try
            {
                Stream tcpData = tcpclient.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                String data = "off";
                byte[] ba = asen.GetBytes(data);
                tcpData.Write(ba, 0, ba.Length);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
    }
}
