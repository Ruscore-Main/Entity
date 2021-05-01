
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
            this.allProductsButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.Location = new System.Drawing.Point(259, 11);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(109, 39);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "label1";
            // 
            // linkLabelBonus
            // 
            this.linkLabelBonus.AutoSize = true;
            this.linkLabelBonus.Location = new System.Drawing.Point(36, 202);
            this.linkLabelBonus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelBonus.Name = "linkLabelBonus";
            this.linkLabelBonus.Size = new System.Drawing.Size(88, 17);
            this.linkLabelBonus.TabIndex = 2;
            this.linkLabelBonus.TabStop = true;
            this.linkLabelBonus.Text = "Мои Бонусы";
            this.linkLabelBonus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBonus_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(136, 202);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(149, 17);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Пополнение баланса";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Location = new System.Drawing.Point(296, 202);
            this.labelBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(60, 17);
            this.labelBalance.TabIndex = 4;
            this.labelBalance.Text = "Баланс:";
            // 
            // allProductsButton
            // 
            this.allProductsButton.Location = new System.Drawing.Point(421, 109);
            this.allProductsButton.Margin = new System.Windows.Forms.Padding(4);
            this.allProductsButton.Name = "allProductsButton";
            this.allProductsButton.Size = new System.Drawing.Size(194, 28);
            this.allProductsButton.TabIndex = 11;
            this.allProductsButton.Text = "Просмотреть товары";
            this.allProductsButton.UseVisualStyleBackColor = true;
            this.allProductsButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 145);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 28);
            this.button1.TabIndex = 12;
            this.button1.Text = "Корзина";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 273);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.allProductsButton);
            this.Controls.Add(this.labelBalance);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.linkLabelBonus);
            this.Controls.Add(this.labelLogin);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button allProductsButton;
        private System.Windows.Forms.Button button1;
    }
}