using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {
        static string serverResponse;
        static int connectionAttempts = 0;
        public static string ip;
        static string connectingClient = "";
        
        public static Socket _ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public ClientForm()
        {
            InitializeComponent();
        }

        private static void Connect()
        {
            
             
                try
                {
                    connectionAttempts++;
                    _ClientSocket.Connect(IPAddress.Parse(ip), 19777);
                    string clientInfo = connectingClient;
                    byte[] buffer = Encoding.ASCII.GetBytes(clientInfo);
                    _ClientSocket.Send(buffer);


                    byte[] recievedBuffer = new byte[1024];
                    int recievedTrimmed = _ClientSocket.Receive(recievedBuffer);
                    byte[] data = new byte[recievedTrimmed];
                    Array.Copy(recievedBuffer, data, recievedTrimmed);

                serverResponse = Encoding.ASCII.GetString(data);
                    
                    
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ip = tbIP.Text;
            connectingClient = tbUsername.Text;
            try
            {

                Connect();
                if (tbUsername.Text == serverResponse)
                {
                    lblConnectionAttempts.Text = "Connected to server";

                    //this.Hide();

                    MainForm fm = new MainForm();
                    fm.Show();
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ConnectCallback(IAsyncResult AR)
        {
            try
            {
                _ClientSocket.EndConnect(AR);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        

        private void btnSend_Click(object sender, EventArgs e)
        {

        }
        private static void SendCallback(IAsyncResult AR) 
        {
            try
            {
                _ClientSocket.EndSend(AR);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);  
            if (_ClientSocket != null && _ClientSocket.Connected)
            {
                
                _ClientSocket.Close();
            }
        }
    }
}
