using MyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labaEntity
{
    public partial class Form2 : Form
    {
        public Form1 form1;
        public AdminForm adminForm;
        public bool isAdmin = false;
        public bool openedWithAdmin = false;
        private TcpClient client = new TcpClient("127.0.0.1", 8888);
        private Byte[] data;
        private NetworkStream stream;
        private MyLib.Message m1, m2, m;
        private ComplexMessage cm = new ComplexMessage();
        public bool FindEmail(string email) {
            using (UserContainer db = new UserContainer())
            {
                foreach (User user in db.UserSet)
                {
                    if (user.Email == email)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public Form2()
        {
            InitializeComponent();
            this.stream = client.GetStream();
        }


        private void InitComponentMessage(object first, object second, int status)
        {
            this.m1 = SerializeAndDeserialize.Serialize(first);
            this.m2 = SerializeAndDeserialize.Serialize(second);
            cm.First = m1;
            cm.Second = m2;
            cm.NumberStatus = status;
            m = SerializeAndDeserialize.Serialize(cm);
            this.data = m.Data;
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            User user = null;
            if (FindEmail(textBoxEmail.Text)) {
                MessageBox.Show("Пользователь с такой почтой уже существует");
                return;
            }
            Bonus bonus = new Bonus() { AmountBonus = "0" };
            if (isAdmin)
            {
                user = new User() { Login = textBoxLog.Text, Email = textBoxEmail.Text, Password = CryptoService.GetHashString(textBoxPass.Text), Role = "Admin", Bonus = bonus, Balance = 0 };
                adminForm.Show();
            }
            else if (openedWithAdmin)
            {
                user = new User() { Login = textBoxLog.Text, Email = textBoxEmail.Text, Password = CryptoService.GetHashString(textBoxPass.Text), Role = "User", Bonus = bonus, Balance = 0 };
                adminForm.Show();
            }
            else
            {
                user = new User() { Login = textBoxLog.Text, Email = textBoxEmail.Text, Password = CryptoService.GetHashString(textBoxPass.Text), Role = "User", Bonus = bonus, Balance = 0 };
                form1.Show();
            }
            this.InitComponentMessage(bonus, user, 0);
            stream.Write(data, 0, data.Length);
            stream.Flush();
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!openedWithAdmin) form1.Show();
            else
            {
                adminForm.Show();
            }
        }
    }
}
