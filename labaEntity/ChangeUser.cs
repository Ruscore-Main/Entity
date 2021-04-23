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
    public partial class ChangeUser : Form
    {
        public DeleteOrChangeForm deleteOrChangeForm;
        public User currentUser;
        public ChangeUser()
        {
            InitializeComponent();
        }

        private void ChangeUser_Load(object sender, EventArgs e)
        {
            textBoxLogin.Text = currentUser.Login;
            textBoxEmail.Text = currentUser.Email;
            textBoxRole.Text = currentUser.Role;
        }

        private void ChangeUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            deleteOrChangeForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UserContainer db = new UserContainer())
            {
                foreach (User user in db.UserSet)
                {
                    if (user.Login == currentUser.Login && user.Email == currentUser.Email)
                    {
                        user.Login = textBoxLogin.Text;
                        user.Email = textBoxEmail.Text;
                        user.Role = textBoxRole.Text;
                        break;
                    }
                }
                db.SaveChanges();
                this.Close();
            }
        }
    }
}
