using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERVER_LABA
{
    public partial class Form1 : Form
    {
        ServerObject server;
        static Thread listenThread;
        public Form1()
        {
            InitializeComponent();
            server = new ServerObject();
            listenThread = new Thread(new
            ThreadStart(server.Listen));
            listenThread.Start();
        }
    }
}
