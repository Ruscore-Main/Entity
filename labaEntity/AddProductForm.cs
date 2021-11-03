using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace labaEntity
{
    public partial class AddProductForm : Form
    {
        byte[] imageBytes;
        public AdminForm adminForm;
        public AddProductForm()
        {
            InitializeComponent();
        }

        // Открытие картинки
        private void buttonImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();

            open_dialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.PNG)| *.BMP; *.JPG; *.GIF; *.PNG | All files(*.*) | *.* ";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.imageBytes = File.ReadAllBytes(open_dialog.FileName);
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }

        }

        // Добавление товара
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (UserContainer db = new UserContainer())
                {
                    Provider selectedProvider = db.ProviderSet.FirstOrDefault(provider => provider.NameProvider == listBoxProvider.SelectedItem.ToString());
                    product product = new product()
                    {
                        Name = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        PhotoPath = this.imageBytes,
                        ProviderId = selectedProvider.Id
                    };
                    db.productSet.Add(product);
                    db.SaveChanges();
                }
                this.Close();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка, возможно, поля заполнены неправильно");
            }
            
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            using (UserContainer db = new UserContainer())
            {
                foreach (Provider provider in db.ProviderSet)
                {
                    listBoxProvider.Items.Add(provider.NameProvider);
                }
            }
        }

        private void AddProductForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminForm.Show();
        }
    }
}
