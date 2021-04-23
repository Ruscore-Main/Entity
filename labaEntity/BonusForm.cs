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
    public partial class BonusForm : Form
    {
        public Form4 form4;
        public BonusForm()
        {
            InitializeComponent();
        }

        private void BonusForm_Load(object sender, EventArgs e)
        {

        }

        private void BonusForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form4.Show();
        }
    }
}
