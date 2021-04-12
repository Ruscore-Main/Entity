using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labaEntity
{
    public partial class Form3 : Form
    {
        static string code = "";
        static MailAddress to;
        public Form1 form1;
        public Form3()
        {
            InitializeComponent();
        }

        private void makeCode ()
        {
            Random rand = new Random();
            for (int i = 0; i < 4; i++) code += Convert.ToString(rand.Next(0, 9));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            code = "";
            MailAddress from = new MailAddress("Kakarandashru@bk.ru", "Kakarandash bratva");
            to = new MailAddress(textBoxEmail.Text);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Восстановление пароля";
            makeCode();
            using (UserContainer db = new UserContainer())
            {
                foreach (User user in db.UserSet)
                {
                    if (textBoxEmail.Text == user.Email)
                    {
                        m.Body = $"<h1>Код: <em>{code}</em> </h1>";
                    }
                }
            }
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.bk.ru", 587);
            smtp.Credentials = new NetworkCredential("Kakarandashru@bk.ru", "VE9du8@1MJ1");
            smtp.EnableSsl = true;
            smtp.Send(m);
            labelCode.Visible = true;
            textBoxCode.Visible = true;
            button1.Visible = false;
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            labelCode.Visible = false;
            textBoxCode.Visible = false;
            newPasLabel.Visible = false;
            newPasTextBox.Visible = false;
            changePasButton.Visible = false;
        }

        private void textBoxCode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCode.Text.Length == 4 && code == textBoxCode.Text)
            {
                labelCode.Visible = false;
                textBoxCode.Visible = false;
                newPasLabel.Visible = true;
                newPasTextBox.Visible = true;
                changePasButton.Visible = true;
            }
        }

        private void changePasButton_Click(object sender, EventArgs e)
        {
            using (UserContainer db = new UserContainer())
            {
                foreach (User user in db.UserSet)
                {
                    if (user.Email == to.Address)
                    {
                        user.Password = CryptoService.GetHashString(newPasTextBox.Text);
                        MessageBox.Show("Пароль успешно изменён");
                        break;
                    }
                }
                db.SaveChanges();
                form1.Show();
                this.Hide();
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }
    }
}
