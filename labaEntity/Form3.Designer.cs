
namespace labaEntity
{
    partial class Form3
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
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCode = new System.Windows.Forms.Label();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.newPasLabel = new System.Windows.Forms.Label();
            this.newPasTextBox = new System.Windows.Forms.TextBox();
            this.changePasButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Почта";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEmail.Location = new System.Drawing.Point(54, 80);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(350, 26);
            this.textBoxEmail.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 201);
            this.button1.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(350, 55);
            this.button1.TabIndex = 21;
            this.button1.Text = "Восстановить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(97, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Востановление пароля";
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(55, 130);
            this.labelCode.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(149, 17);
            this.labelCode.TabIndex = 27;
            this.labelCode.Text = "Четырёхзначный код";
            // 
            // textBoxCode
            // 
            this.textBoxCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCode.Location = new System.Drawing.Point(220, 126);
            this.textBoxCode.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(96, 26);
            this.textBoxCode.TabIndex = 26;
            this.textBoxCode.TextChanged += new System.EventHandler(this.textBoxCode_TextChanged);
            // 
            // newPasLabel
            // 
            this.newPasLabel.AutoSize = true;
            this.newPasLabel.CausesValidation = false;
            this.newPasLabel.Location = new System.Drawing.Point(51, 163);
            this.newPasLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.newPasLabel.Name = "newPasLabel";
            this.newPasLabel.Size = new System.Drawing.Size(102, 17);
            this.newPasLabel.TabIndex = 29;
            this.newPasLabel.Text = "Новый пароль";
            // 
            // newPasTextBox
            // 
            this.newPasTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newPasTextBox.Location = new System.Drawing.Point(159, 157);
            this.newPasTextBox.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.newPasTextBox.Name = "newPasTextBox";
            this.newPasTextBox.Size = new System.Drawing.Size(216, 26);
            this.newPasTextBox.TabIndex = 28;
            // 
            // changePasButton
            // 
            this.changePasButton.Location = new System.Drawing.Point(386, 158);
            this.changePasButton.Name = "changePasButton";
            this.changePasButton.Size = new System.Drawing.Size(93, 26);
            this.changePasButton.TabIndex = 30;
            this.changePasButton.Text = "Изменить";
            this.changePasButton.UseVisualStyleBackColor = true;
            this.changePasButton.Click += new System.EventHandler(this.changePasButton_Click);
            // 
            // Form3
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 275);
            this.Controls.Add(this.changePasButton);
            this.Controls.Add(this.newPasLabel);
            this.Controls.Add(this.newPasTextBox);
            this.Controls.Add(this.labelCode);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form3";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.Label newPasLabel;
        private System.Windows.Forms.TextBox newPasTextBox;
        private System.Windows.Forms.Button changePasButton;
    }
}