using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labaEntity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            using (UserContainer db = new UserContainer())
            {
                foreach (User user in db.UserSet)
                {
                    if (textBox1.Text == user.Login && CryptoService.GetHashString(textBox2.Text) == user.Password)
                    {
                        if (user.Role == "Admin")
                        {
                            AdminForm adminForm = new AdminForm();
                            adminForm.form1 = this;
                            adminForm.label1.Text = user.Login;
                            adminForm.Show();
                        }
                        else
                        {
                            Form4 userForm = new Form4();
                            userForm.labelLogin.Text = user.Login;

                            userForm.Show();
                            userForm.form1 = this;
                        }
                        // Здесь осуществляется вход в новую прогу (для 6 лабы)
                       
                        this.Hide();
                        return;
                    }
                    
                }
            }
            MessageBox.Show("Логин или пароль указан неверно!");
        }
    }
}
