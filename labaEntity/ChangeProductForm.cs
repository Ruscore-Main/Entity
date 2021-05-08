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
    public partial class ChangeProductForm : Form
    {
        public DeleteOrChangeProductForm deleteOrChangeProductForm;
        public product currentProduct;
        public ChangeProductForm()
        {
            InitializeComponent();
        }

        private void ChangeProductForm_Load(object sender, EventArgs e)
        {
            textBoxName.Text = currentProduct.Name;
            textBoxPrice.Text = Convert.ToString(currentProduct.Price);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (UserContainer db = new UserContainer())
                {
                    foreach (product product in db.productSet)
                    {
                        if (product.Id == currentProduct.Id)
                        {
                            product.Name = textBoxName.Text;
                            product.Price = Convert.ToInt32(textBoxPrice.Text);
                            break;
                        }
                    }
                    db.SaveChanges();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка, возможно, не все поля заполнены правильно");
            }
        }
    }
}
