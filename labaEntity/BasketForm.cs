using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace labaEntity
{
    public partial class BasketForm : Form
    {
        public Form4 userForm;
        public User currentUser;
        public int sum = 0;
        public string printContent = "";
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
                                string nowBalance = Convert.ToString(user.Balance);
                                string nowSum = Convert.ToString(sum);
                                user.Balance -= sum - int.Parse(user.Bonus.AmountBonus);
                                foreach (product product in user.basket)
                                {
                                    listBox1.Items.Remove(product);
                                }
                                string date = DateTime.Now.ToString();
                                user.Bonus.AmountBonus = Convert.ToString(Math.Floor(Convert.ToDouble(sum / 4)));
                                string nowBalanceAfterBuy = Convert.ToString(user.Balance);
                                string nowBonus = Convert.ToString(user.Bonus.AmountBonus); 
                                MessageBox.Show($"Товар оплачен {date}\nВаш текущий баланс: {user.Balance}\nВаш текущий баланс бонусов: {user.Bonus.AmountBonus}", "ЧЕК");
                                user.basket.Clear();
                                sum = 0;
                                listBox1.Items.Clear();
                                labelSum.Text = $"Сумма: {sum}";
                                DocX docs = outputDoc(nowBalance, nowSum, nowBalanceAfterBuy, nowBonus);

                                printContent = docs.Text;
                                PrintDocument printDocument = new PrintDocument();
                                PrintDialog printDialog = new PrintDialog();
                                printDocument.PrintPage += PrintPageHandler;
                                printDialog.Document = printDocument;
                                if (printDialog.ShowDialog() == DialogResult.OK)
                                {
                                    printDialog.Document.Print();
                                }

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

        private DocX outputDoc(string nowBalance, string nowSum, string nowBalanceAfterBuy, string nowBonus)
        {
            string pathDocument = "C:\\Users\\oobit\\Desktop\\first.docx";
            DocX document = DocX.Create(pathDocument);
            document.MarginLeft = 60.0f;
            document.MarginRight = 60.0f;
            document.MarginTop = 60.0f;
            document.MarginBottom = 60.0f;
            document.InsertParagraph("Чек покупки").Bold().Font("Times New Roman").FontSize(14);
            Table table = document.AddTable(4, 2);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.SetWidths(new float[] { 180.0f, 600.0f });
            table.Rows[0].Cells[0].Paragraphs[0].Append("Баланс до покупки").Font("Times New Roman").FontSize(12).Bold();
            table.Rows[0].Cells[1].Paragraphs[0].Append(nowBalance).Font("Times New Roman").FontSize(12);
            table.Rows[1].Cells[0].Paragraphs[0].Append("Сумма").Font("Times New Roman").FontSize(12).Bold();
            table.Rows[1].Cells[1].Paragraphs[0].Append(nowSum).Font("Times New Roman").FontSize(12);
            table.Rows[2].Cells[0].Paragraphs[0].Append("Баланс после покупки").Font("Times New Roman").FontSize(12).Bold();
            table.Rows[2].Cells[1].Paragraphs[0].Append(nowBalanceAfterBuy).Font("Times New Roman").FontSize(12);
            table.Rows[3].Cells[0].Paragraphs[0].Append("Текущее количество бонусов").Font("Times New Roman").FontSize(12).Bold();
            table.Rows[3].Cells[1].Paragraphs[0].Append(nowBonus).Font("Times New Roman").FontSize(12);
            document.InsertParagraph().InsertTableAfterSelf(table);
            document.Save();
            return document;

        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(printContent, new System.Drawing.Font("Arial", 16), Brushes.Black, 0, 0);
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
            catch
            {
                MessageBox.Show("При удалении товара произошла ошибка");
            }
        }
    }
}
