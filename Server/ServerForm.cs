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

namespace Server
{
    public partial class ServerForm : Form
    {
        private Socket _serverSocket, _clientSOcket;
        private byte[] _buffer;
        public ServerForm()
        {
            InitializeComponent();
            StartServer();
        }

        private void StartServer()
        {
            try
            {
                _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 19777));
                _serverSocket.Listen(0);
                _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AcceptCallback(IAsyncResult AR)
        {
            try
            {
                _clientSOcket = _serverSocket.EndAccept(AR);
                _buffer = new byte[_clientSOcket.ReceiveBufferSize];
                _clientSOcket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReciveCallback), null);

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReciveCallback(IAsyncResult AR)
        {
            try
            {
                int received = _clientSOcket.EndReceive(AR);

                if (received == 0)
                {
                    return;
                }
                
                Array.Resize(ref _buffer, received);
                string text = Encoding.ASCII.GetString(_buffer);
                AppendToTextBox(text + " has connected.");
                Array.Resize(ref _buffer, _clientSOcket.ReceiveBufferSize);
                _clientSOcket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReciveCallback), null);

                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AppendToTextBox(string text)
        {
            MethodInvoker invoker = new MethodInvoker(delegate
            {
                tb1.Text += text + "\r\n";
            });

            this.Invoke(invoker);
        }

        private void Server_Load(object sender, EventArgs e)
        {

        }
    }
}
