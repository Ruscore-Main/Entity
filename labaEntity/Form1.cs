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
    public partial class Form1 : Form
    {
        TcpClient client = new TcpClient("127.0.0.1", 8888);
        Byte[] data;
        NetworkStream stream;
        MyLib.Message m, m1, m2;
        ComplexMessage cm = new ComplexMessage();
        public Form1()
        {
            InitializeComponent();
            this.stream = client.GetStream();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.form1 = this;
            form2.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            form3.form1 = this;
            form3.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void EnterButtton_Click(object sender, EventArgs e)
        {
            this.m1 = SerializeAndDeserialize.Serialize(textBox1.Text);
            this.m2 = SerializeAndDeserialize.Serialize(textBox2.Text);
            this.cm.First = this.m1;
            this.cm.Second = this.m2;
            this.cm.NumberStatus = 1;
            this.m = SerializeAndDeserialize.Serialize(this.cm);
            data = this.m.Data;
            stream.Write(data, 0, data.Length);
            if (stream.CanRead)
            {
                int numberOfBytesRead = 0;
                byte[] readingData = new byte[6297630];
                do
                {
                    numberOfBytesRead = stream.Read(readingData, 0, readingData.Length);

                } while (stream.DataAvailable);
                this.m.Data = readingData;
                this.cm = (ComplexMessage)SerializeAndDeserialize.Deserialize(m);

                // Успешная авторизация
                if (cm.NumberStatus == 2)
                {
                    ComplexMessage complexMessage = (ComplexMessage)SerializeAndDeserialize.Deserialize(m);
                    User user1 = (User)SerializeAndDeserialize.Deserialize(complexMessage.First);
                    Bonus bonus = (Bonus)SerializeAndDeserialize.Deserialize(complexMessage.Second);
                    if (user1.Role == "Admin")
                    {
                        AdminForm adminForm = new AdminForm();
                        adminForm.form1 = this;
                        adminForm.label1.Text = user1.Login;
                        adminForm.Show();
                    }
                    else
                    {
                        Form4 userForm = new Form4();
                        userForm.labelLogin.Text = user1.Login;
                        userForm.currentUser = user1;
                        userForm.Show();
                        userForm.form1 = this;
                    }
                    // Здесь осуществляется вход в новую прогу (для 6 лабы)

                    this.Hide();
                }

                // Ошибка авторизации
                else if (cm.NumberStatus == 3)
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
           
           
        }
    }
}
