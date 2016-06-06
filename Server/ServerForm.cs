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
    // //www.codeproject.com/Articles/488668/Csharp-NET-TCP-Server
    public partial class ServerForm : Form
    {
        private static int playersConnected = 0;
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        private static byte[] _buffer = new byte[1024];
        private static List<Socket> _clientSockets = new List<Socket>();
        private static List<string> clientsConnected = new List<string>();

        public ServerForm()
        {
            InitializeComponent();
            StartServer();
        }

        private void StartServer()
        {
            try
            {
                
                _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 19777));
                _serverSocket.Listen(1);
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
                Socket socket = _serverSocket.EndAccept(AR);
                _clientSockets.Add(socket);
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReciveCallback), socket);
                _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
               

                
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
                Socket socket = (Socket)AR.AsyncState;
                int received = socket.EndReceive(AR);

                byte[] dataBuff = new byte[received];
                Array.Copy(_buffer, dataBuff, received);
                string text = Encoding.ASCII.GetString(dataBuff);

                clientsConnected.Add(text);
                AppendToTextBox(text + " has connected.");
                playersConnected++;
                Player p = new Player(playersConnected, text);

                p.AddPlayer(p);
                

                socket.BeginSend(dataBuff, 0, dataBuff.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReciveCallback), null);

                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
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

        private void btnServerSend_Click(object sender, EventArgs e)
        {
            try
            {
                Socket socket = (Socket)AR.AsyncState;
                int received = socket.EndReceive(AR);

                byte[] dataBuff = new byte[received];
                Array.Copy(_buffer, dataBuff, received);
                string text = Encoding.ASCII.GetString(dataBuff);

              


                socket.BeginSend(dataBuff, 0, dataBuff.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReciveCallback), null);

            }
    }
}
