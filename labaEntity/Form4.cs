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
    public partial class Form4 : Form
    {
        // Сам юзер
        public User currentUser;
        public Form1 form1;
        public int basketSum = 0;
        public Label label;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label = labelBalance;
            labelBalance.Text = $"Баланс: {currentUser.Balance}";
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        private void linkLabelBonus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // бонусная программа

            using (UserContainer db = new UserContainer())
            {
                foreach (User user in db.UserSet)
                {
                    if (user.Id == currentUser.Id)
                    {
                        BonusForm bonusForm = new BonusForm();
                        bonusForm.form4 = this;
                        bonusForm.BonusNameLabel.Text = $"Имя: {user.Login}";
                        bonusForm.BonusAmount.Text = $"Количество бонусов: {user.Bonus.AmountBonus}";
                        bonusForm.Show();
                        this.Hide();
                    }
                }
            }
                    

        }

        // Пополнение баланса
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefillBalanceForm refillBalanceForm = new RefillBalanceForm();
            refillBalanceForm.userForm = this;
            refillBalanceForm.currentUser = currentUser;
            refillBalanceForm.Show();
            this.Hide();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            AllProducts allProductsForm = new AllProducts();
            allProductsForm.userForm = this;
            allProductsForm.currentUser = currentUser;
            allProductsForm.Show();
            this.Hide();
        }

        // Корзина
        private void button1_Click(object sender, EventArgs e)
        {
            BasketForm basketForm = new BasketForm();
            basketForm.userForm = this;
            basketForm.currentUser = currentUser;
            basketForm.Show();
            this.Hide();
            
        }
    }
}
