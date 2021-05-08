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
        public AdminForm adminForm;
        public bool isAdmin = false;
        public bool openedWithAdmin = false;
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
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            using (UserContainer db = new UserContainer())
            {
                User user = null;
                if (FindEmail(textBoxEmail.Text)) {
                    MessageBox.Show("Пользователь с такой почтой уже существует");
                    return;
                }
                
                if (isAdmin)
                {
                    Bonus bonus = new Bonus() { AmountBonus = "0" };
                    user = new User() { Login = textBoxLog.Text, Email = textBoxEmail.Text, Password = CryptoService.GetHashString(textBoxPass.Text), Role = "Admin", Bonus = bonus, Balance = 0 };
                    adminForm.Show();
                }
                else if (openedWithAdmin)
                {
                    Bonus bonus = new Bonus() { AmountBonus = "0" };
                    user = new User() { Login = textBoxLog.Text, Email = textBoxEmail.Text, Password = CryptoService.GetHashString(textBoxPass.Text), Role = "User", Bonus = bonus, Balance = 0 };
                    adminForm.Show();
                }
                else
                {
                    Bonus bonus = new Bonus() { AmountBonus = "0" };
                    user = new User() { Login = textBoxLog.Text, Email = textBoxEmail.Text, Password = CryptoService.GetHashString(textBoxPass.Text), Role = "User", Bonus = bonus, Balance = 0 };
                    form1.Show();
                }
                db.UserSet.Add(user);
                db.SaveChanges();
                
            }
            
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
