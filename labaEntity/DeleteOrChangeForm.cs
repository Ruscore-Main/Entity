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
    public partial class DeleteOrChangeForm : Form
    {
        public string[] selectedUser;
        public DeleteOrChangeForm()
        {
            InitializeComponent();
        }
        private void BlockButtons()
        {
            deleteButton.Enabled = false;
            changeButton.Enabled = false;
        }
        private void DeleteOrChangeForm_Load(object sender, EventArgs e)
        {
            BlockButtons();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            bool finded = false;
            try
            {
                using (UserContainer db = new UserContainer())
                {

                    foreach (User user in db.UserSet)
                    {
                        if (user.Login.ToLower() == textBoxLogin.Text.ToLower())
                        {
                            listBox1.Items.Add($"{user.Login} {user.Email}");
                            finded = true;
                        }
                    }

                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка, возможно, не все поля были правильно заполнены");
            }
            if (finded)
            {
                deleteButton.Enabled = true;
                changeButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }


        // Удаление юзера
        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                selectedUser = listBox1.SelectedItem.ToString().Split(' ');
                using (UserContainer db = new UserContainer())
                {
                    foreach (User user in db.UserSet)
                    {

                        // selectedUser[0] - login | selectedUser[1] - email
                        if (user.Login == selectedUser[0] && user.Email == selectedUser[1])
                        {

                            db.BonusSet.Remove(user.Bonus);
                            db.UserSet.Remove(user);
                            textBoxLogin.Text = "";
                            BlockButtons();
                            MessageBox.Show("Юзер удален");
                            break;
                        }
                    }
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("При удалении произошла ошибка");
            }
        }

        // Изменение юзера
        private void changeButton_Click(object sender, EventArgs e)
        {
            selectedUser = listBox1.SelectedItem.ToString().Split(' ');
            User currentUser = null;
            using (UserContainer db = new UserContainer())
            {
                foreach (User user in db.UserSet)
                {

                    // selectedUser[0] - login | selectedUser[1] - email
                    if (user.Login == selectedUser[0] && user.Email == selectedUser[1])
                    {
                        currentUser = user;
                        textBoxLogin.Text = "";
                        BlockButtons();
                        break;
                    }
                }
            }
            ChangeUser changeUserForm = new ChangeUser();
            changeUserForm.deleteOrChangeForm = this;
            changeUserForm.currentUser = currentUser;
            changeUserForm.Show();
            this.Hide();
        }
    }
}
