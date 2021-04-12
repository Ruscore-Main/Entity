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
    public partial class Form2 : Form
    {
        public Form1 form1;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            using (UserContainer db = new UserContainer())
            {
                User user = new User() { Login = textBoxLog.Text, Email = textBoxEmail.Text, Password = CryptoService.GetHashString(textBoxPass.Text), Role = "User"};
                db.UserSet.Add(user);
                db.SaveChanges();
            }
            form1.Show();
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }
    }
}
