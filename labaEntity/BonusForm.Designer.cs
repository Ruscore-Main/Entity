
namespace labaEntity
{
    partial class BonusForm
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
            this.BonusTitle = new System.Windows.Forms.Label();
            this.BonusAmount = new System.Windows.Forms.Label();
            this.BonusNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BonusTitle
            // 
            this.BonusTitle.AutoSize = true;
            this.BonusTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BonusTitle.Location = new System.Drawing.Point(96, 19);
            this.BonusTitle.Name = "BonusTitle";
            this.BonusTitle.Size = new System.Drawing.Size(185, 26);
            this.BonusTitle.TabIndex = 0;
            this.BonusTitle.Text = "Бонусная карта";
            // 
            // BonusAmount
            // 
            this.BonusAmount.AutoSize = true;
            this.BonusAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BonusAmount.Location = new System.Drawing.Point(12, 100);
            this.BonusAmount.Name = "BonusAmount";
            this.BonusAmount.Size = new System.Drawing.Size(147, 17);
            this.BonusAmount.TabIndex = 1;
            this.BonusAmount.Text = "Количество бонусов:";
            // 
            // BonusNameLabel
            // 
            this.BonusNameLabel.AutoSize = true;
            this.BonusNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BonusNameLabel.Location = new System.Drawing.Point(120, 74);
            this.BonusNameLabel.Name = "BonusNameLabel";
            this.BonusNameLabel.Size = new System.Drawing.Size(39, 17);
            this.BonusNameLabel.TabIndex = 3;
            this.BonusNameLabel.Text = "Имя:";
            // 
            // BonusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 159);
            this.Controls.Add(this.BonusNameLabel);
            this.Controls.Add(this.BonusAmount);
            this.Controls.Add(this.BonusTitle);
            this.Name = "BonusForm";
            this.Text = "BonusForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BonusForm_FormClosing);
            this.Load += new System.EventHandler(this.BonusForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BonusTitle;
        public System.Windows.Forms.Label BonusAmount;
        public System.Windows.Forms.Label BonusNameLabel;
    }
}