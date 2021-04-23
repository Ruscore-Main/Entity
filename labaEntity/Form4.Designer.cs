
namespace labaEntity
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelLogin = new System.Windows.Forms.Label();
            this.linkLabelBonus = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labelBalance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.Location = new System.Drawing.Point(194, 9);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(86, 31);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "label1";
            // 
            // linkLabelBonus
            // 
            this.linkLabelBonus.AutoSize = true;
            this.linkLabelBonus.Location = new System.Drawing.Point(27, 164);
            this.linkLabelBonus.Name = "linkLabelBonus";
            this.linkLabelBonus.Size = new System.Drawing.Size(69, 13);
            this.linkLabelBonus.TabIndex = 2;
            this.linkLabelBonus.TabStop = true;
            this.linkLabelBonus.Text = "Мои Бонусы";
            this.linkLabelBonus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBonus_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(102, 164);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(114, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Пополнение баланса";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Location = new System.Drawing.Point(222, 164);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(47, 13);
            this.labelBalance.TabIndex = 4;
            this.labelBalance.Text = "Баланс:";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 222);
            this.Controls.Add(this.labelBalance);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.linkLabelBonus);
            this.Controls.Add(this.labelLogin);
            this.Name = "Form4";
            this.Text = "User";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form4_FormClosing);
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.LinkLabel linkLabelBonus;
        private System.Windows.Forms.LinkLabel linkLabel1;
        public System.Windows.Forms.Label labelBalance;
    }
}