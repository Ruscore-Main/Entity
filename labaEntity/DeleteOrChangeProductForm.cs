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
    public partial class DeleteOrChangeProductForm : Form
    {
        string selectedProduct;
        public AdminForm adminForm;
        private void BlockButtons()
        {
            deleteButton.Enabled = false;
            changeButton.Enabled = false;
        }
        public DeleteOrChangeProductForm()
        {
            InitializeComponent();
        }

        private void DeleteOrChangeProductForm_Load(object sender, EventArgs e)
        {
            BlockButtons();

        }

        // Удаление товара
        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                selectedProduct = listBox1.SelectedItem.ToString().Split(' ')[0];
                using (UserContainer db = new UserContainer())
                {
                    foreach (product product in db.productSet)
                    {
                        if (product.Id == Convert.ToInt32(selectedProduct))
                        {

                            db.productSet.Remove(product);
                            textBoxLogin.Text = "";
                            BlockButtons();
                            MessageBox.Show("Пользователь удален");
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

        // Поиск товара
        private void findButton_Click(object sender, EventArgs e)
        {
            bool finded = false;
            using (UserContainer db = new UserContainer())
            {

                foreach (product product in db.productSet)
                {
                    if (product.Name.ToLower() == textBoxLogin.Text.ToLower())
                    {
                        listBox1.Items.Add($"{product.Id} {product.Name}");
                        finded = true;
                    }
                }

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

        private void changeButton_Click(object sender, EventArgs e)
        {
            selectedProduct = listBox1.SelectedItem.ToString().Split(' ')[0];
            product currentProduct = null;
            try
            {
                using (UserContainer db = new UserContainer())
                {
                    foreach (product product in db.productSet)
                    {
                        if (product.Id == Convert.ToInt32(selectedProduct))
                        {
                            currentProduct = product;
                            textBoxLogin.Text = "";
                            BlockButtons();
                            break;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка, возможно, не все поля были правильно заполнены");
            }
            
            ChangeProductForm changeProductForm = new ChangeProductForm();
            changeProductForm.deleteOrChangeProductForm = this;
            changeProductForm.currentProduct = currentProduct;
            changeProductForm.Show();
            this.Hide();
        }

        private void DeleteOrChangeProductForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminForm.Show();
        }
    }
}
