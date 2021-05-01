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
    public partial class BasketForm : Form
    {
        public Form4 userForm;
        public User currentUser;
        public int sum = 0;
        public BasketForm()
        {
            InitializeComponent();
        }

        private void BasketForm_Load(object sender, EventArgs e)
        {
            using (UserContainer db = new UserContainer())
            {
                foreach (User user in db.UserSet)
                {
                    if (user.Id == currentUser.Id)
                    {
                        foreach (product product in user.basket)
                        {
                            listBox1.Items.Add(product.Name);
                            sum += product.Price;
                        }
                        break;
                    }
                }
                labelSum.Text = $"Сумма: {sum}";
            }

        }

        private void BasketForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            userForm.Show();
        }


        // Оплата
        private void button1_Click(object sender, EventArgs e)
        {
            using (UserContainer db = new UserContainer())
            {
                foreach (User user in db.UserSet)
                {
                    if (user.Id == currentUser.Id)
                    {
                        // Если хватает денег
                        if (user.Balance >= sum)
                        {
                            user.Balance -= sum - int.Parse(user.Bonus.AmountBonus);
                            foreach (product product in user.basket)
                            {
                                listBox1.Items.Remove(product);
                            }
                            user.Bonus.AmountBonus = Convert.ToString(Math.Floor(Convert.ToDouble(sum / 4)));
                            MessageBox.Show($"Товар оплачен, ваш текущий баланс: {user.Balance}\nВаш текущий баланс бонусов: {user.Bonus.AmountBonus}");
                            user.basket.Clear();
                            sum = 0;
                            listBox1.Items.Clear();
                            labelSum.Text = $"Сумма: {sum}";

                            break;
                        }
                        else
                        {
                            MessageBox.Show("Недостаточно средств на счету!");
                        }
                        
                    }
                }

                db.SaveChanges();
            }
        }

        // Удаление из корзины
        private void button2_Click(object sender, EventArgs e)
        {
            
            using (UserContainer db = new UserContainer())
            {
                foreach (User user in db.UserSet)
                {
                    if (user.Id == currentUser.Id)
                    {
                        foreach (product product in db.productSet)
                        {
                            if (product.Name == Convert.ToString(listBox1.SelectedItem))
                            {
                                user.basket.Remove(product);
                                sum -= product.Price;
                                break;
                            }
                        }
                    }
                }
                labelSum.Text = $"Сумма: {sum}";
                MessageBox.Show($"Товар {listBox1.SelectedItem} был удален");
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                db.SaveChanges();
            }
        }
    }
}
