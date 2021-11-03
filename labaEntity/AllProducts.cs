﻿using System;
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
    
    public partial class AllProducts : Form
    {
        public User currentUser;
        public Form4 userForm;

        class BuyButton : Button
        {
            public int productId;
            public User currentUser;
            public Form4 userForm;
            public BuyButton(int productId, User currentUser, Form4 userForm)
            : base()
            {
                // set whatever styling properties needed here
                this.Click += new EventHandler(this.BuyButton_Click);
                this.Text = "Добавить";
                this.productId = productId;
                this.currentUser = currentUser;
                this.userForm = userForm;
            }

            void BuyButton_Click(object sender, EventArgs e)
            {
                // добавление в корзину
                // фига пирамида, лучше покрасивше сделай, пока не поздно)  ---- уже пофиксил
                /*foreach (product product in db.productSet)
                {
                    if (product.Id == this.productId)
                    {
                        foreach (User user in db.UserSet)
                        {
                            if (user.Id == this.currentUser.Id)
                            {
                                user.basket.Add(product);
                                userForm.basketSum += product.Price;
                                break;
                            }
                        }
                    }

                } ---------- вот так было ._.*/
                try
                {
                    using (UserContainer db = new UserContainer())
                    {
                        product foundProduct = db.productSet.FirstOrDefault(product => product.Id == this.productId);
                        User foundUser = db.UserSet.FirstOrDefault(user => user.Id == this.currentUser.Id);
                        if (foundProduct != null)
                        {
                            BasketItem basketItem = foundUser.BasketItems.FirstOrDefault(el => el.Name == foundProduct.Name && el.Price == foundProduct.Price);
                            if (basketItem != null)
                            {
                                basketItem.Count += 1;
                                
                            }
                            else
                            {
                                BasketItem newBasketItem = new BasketItem()
                                {
                                    Name = foundProduct.Name,
                                    Price = foundProduct.Price,
                                };
                                newBasketItem.Count += 1;
                                foundUser.BasketItems.Add(newBasketItem);
                            }
                            
                            

                            userForm.basketSum += foundProduct.Price;
                        }
                        
                        db.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("При добавлении товара в корзину возникла ошибка");
                }
            }
        }
        public AllProducts()
        {
            InitializeComponent();
        }
        private void AllProducts_Load(object sender, EventArgs e)
        {
            
            using (UserContainer db = new UserContainer())
            {
                foreach (product product in db.productSet)
                {
                    FlowLayoutPanel flowLP = new FlowLayoutPanel();
                    flowLP.AutoSize = false;
                    flowLP.Width = 500;
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = (Image)((new ImageConverter()).ConvertFrom(product.PhotoPath));
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    Label title = new Label();
                    title.Text = product.Name;
                    Label price = new Label();
                    price.Text = $"{product.Price} руб.";
                    BuyButton button = new BuyButton(product.Id, currentUser, userForm);
                    button.Text = "Добавить";
                    flowLP.Controls.Add(pictureBox);
                    flowLP.Controls.Add(title);
                    flowLP.Controls.Add(price);
                    flowLP.Controls.Add(button);
                    flowLayoutPanel1.Controls.Add(flowLP);
                }
            }
        }

        private void AllProducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            userForm.Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
