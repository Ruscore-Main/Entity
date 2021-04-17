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
    }
}
