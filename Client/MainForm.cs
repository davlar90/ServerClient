using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            
            string message = tbChatInput.Text;
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            ClientForm._ClientSocket.Send(buffer);
            tbChatWindow.Text = message;


            //byte[] recievedBuffer = new byte[1024];
            //int recievedTrimmed = _ClientSocket.Receive(recievedBuffer);
            //byte[] data = new byte[recievedTrimmed];
            //Array.Copy(recievedBuffer, data, recievedTrimmed);
        }
    }
}
