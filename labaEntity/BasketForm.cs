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
                        foreach (BasketItem basketItem in user.BasketItems)
                        {
                            listBox1.Items.Add($"{basketItem.Name} - {basketItem.Count}");
                            sum += basketItem.Price*basketItem.Count;
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
            try
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
                                foreach (BasketItem basketItem in user.BasketItems)
                                {
                                    listBox1.Items.Remove(basketItem);
                                }
                                string date = DateTime.Now.ToString();
                                user.Bonus.AmountBonus = Convert.ToString(Math.Floor(Convert.ToDouble(sum / 4)));
                                MessageBox.Show($"Товар оплачен {date}\nВаш текущий баланс: {user.Balance}\nВаш текущий баланс бонусов: {user.Bonus.AmountBonus}", "ЧЕК");
                                user.BasketItems.Clear();
                                sum = 0;
                                listBox1.Items.Clear();
                                labelSum.Text = $"Сумма: {sum}";
                                userForm.label.Text = $"{user.Balance}";
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
            catch
            {
                MessageBox.Show("При оплате возникла ошибка");
            }
        }

        // Удаление из корзины
        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                using (UserContainer db = new UserContainer())
                {
                    foreach (User user in db.UserSet)
                    {
                        if (user.Id == currentUser.Id)
                        {
                            foreach (BasketItem basketItem in db.BasketItemSet)
                            {
                                if ($"{basketItem.Name} - {basketItem.Count}" == Convert.ToString(listBox1.SelectedItem))
                                {
                                    if (basketItem.Count == 1) {
                                        user.BasketItems.Remove(basketItem);
                                        sum -= basketItem.Price;
                                        listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                                    }
                                    else
                                    {
                                        basketItem.Count -= 1;
                                        sum -= basketItem.Price;
                                        listBox1.Items[listBox1.SelectedIndex] = $"{basketItem.Name} - {basketItem.Count}";
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    labelSum.Text = $"Сумма: {sum}";
                    MessageBox.Show($"Товар {listBox1.SelectedItem} был удален");
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("При удалении товара произошла ошибка");
            }
        }
    }
}
