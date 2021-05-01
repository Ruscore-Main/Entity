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
    public partial class AdminForm : Form
    {
        public Form1 form1;
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 adminForm = new Form2();
            adminForm.isAdmin = true;
            adminForm.openedWithAdmin = true;
            adminForm.adminForm = this;
            this.Hide();
            adminForm.Show();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 userForm = new Form2();
            userForm.openedWithAdmin = true;
            userForm.adminForm = this;
            this.Hide();
            userForm.Show();
        }

        // Удаление / Изменение юзера
        private void button3_Click(object sender, EventArgs e)
        {
            DeleteOrChangeForm deleteOrChangeForm = new DeleteOrChangeForm();
            deleteOrChangeForm.Show();
        }

        // Добавлени товара
        private void button4_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.adminForm = this;
            addProductForm.Show();
            this.Hide();
        }

        // Удаление / Изменение товара
        private void button5_Click(object sender, EventArgs e)
        {
            DeleteOrChangeProductForm deleteOrChangeProductForm = new DeleteOrChangeProductForm();
            deleteOrChangeProductForm.adminForm = this;
            deleteOrChangeProductForm.Show();
            this.Hide();
        }
    }
}
