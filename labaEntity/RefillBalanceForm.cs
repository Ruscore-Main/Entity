using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labaEntity
{
    public partial class RefillBalanceForm : Form
    {
        public Form4 userForm;
        public User currentUser;
        public RefillBalanceForm()
        {
            InitializeComponent();
        }

        private void RefillBalanceForm_Load(object sender, EventArgs e)
        {

        }

        private void RefillBalanceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            userForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UserContainer db = new UserContainer())
            {
                foreach (User user in db.UserSet)
                {
                    if (user.Login == currentUser.Login && user.Password == currentUser.Password)
                    {
                        user.Balance += Convert.ToInt32(textBox1.Text);
                        userForm.labelBalance.Text = $"Баланс: {user.Balance}";
                    }
                }
                
                db.SaveChanges();
            }
            this.Close();
        }
    }
}
