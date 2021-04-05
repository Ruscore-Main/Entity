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
        public string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            MessageBox.Show(hash);
            return hash;

        }
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
                User user = new User() { Login = textBoxLog.Text, Email = textBoxEmail.Text, Password = this.GetHashString(textBoxPass.Text), Role = "User"};
                db.UserSet.Add(user);
                db.SaveChanges();
            }
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
