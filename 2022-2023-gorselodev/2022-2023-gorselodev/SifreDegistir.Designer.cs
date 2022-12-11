
namespace _2022_2023_gorselodev
{
    partial class SifreDegistir
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
            this.button_SifreDegistir = new System.Windows.Forms.Button();
            this.textBox_Captcha = new System.Windows.Forms.TextBox();
            this.textBox_YeniSifreOnay = new System.Windows.Forms.TextBox();
            this.textBox_YeniSifre = new System.Windows.Forms.TextBox();
            this.textBox_EskiSifre = new System.Windows.Forms.TextBox();
            this.label_Mesaj = new System.Windows.Forms.Label();
            this.label_Captcha = new System.Windows.Forms.Label();
            this.label_YeniSifreTekrar = new System.Windows.Forms.Label();
            this.label_YeniSifre = new System.Windows.Forms.Label();
            this.label_EskiSifre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_SifreDegistir
            // 
            this.button_SifreDegistir.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_SifreDegistir.Location = new System.Drawing.Point(237, 270);
            this.button_SifreDegistir.Name = "button_SifreDegistir";
            this.button_SifreDegistir.Size = new System.Drawing.Size(185, 72);
            this.button_SifreDegistir.TabIndex = 12;
            this.button_SifreDegistir.Text = "Şifre Değiştir";
            this.button_SifreDegistir.UseVisualStyleBackColor = true;
            this.button_SifreDegistir.Click += new System.EventHandler(this.button_SifreDegistir_Click);
            // 
            // textBox_Captcha
            // 
            this.textBox_Captcha.Location = new System.Drawing.Point(404, 212);
            this.textBox_Captcha.Name = "textBox_Captcha";
            this.textBox_Captcha.Size = new System.Drawing.Size(141, 22);
            this.textBox_Captcha.TabIndex = 8;
            // 
            // textBox_YeniSifreOnay
            // 
            this.textBox_YeniSifreOnay.Location = new System.Drawing.Point(211, 146);
            this.textBox_YeniSifreOnay.Name = "textBox_YeniSifreOnay";
            this.textBox_YeniSifreOnay.Size = new System.Drawing.Size(143, 22);
            this.textBox_YeniSifreOnay.TabIndex = 9;
            // 
            // textBox_YeniSifre
            // 
            this.textBox_YeniSifre.Location = new System.Drawing.Point(211, 94);
            this.textBox_YeniSifre.Name = "textBox_YeniSifre";
            this.textBox_YeniSifre.Size = new System.Drawing.Size(143, 22);
            this.textBox_YeniSifre.TabIndex = 10;
            // 
            // textBox_EskiSifre
            // 
            this.textBox_EskiSifre.Location = new System.Drawing.Point(211, 41);
            this.textBox_EskiSifre.Name = "textBox_EskiSifre";
            this.textBox_EskiSifre.Size = new System.Drawing.Size(143, 22);
            this.textBox_EskiSifre.TabIndex = 11;
            // 
            // label_Mesaj
            // 
            this.label_Mesaj.AutoSize = true;
            this.label_Mesaj.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_Mesaj.Location = new System.Drawing.Point(133, 270);
            this.label_Mesaj.Name = "label_Mesaj";
            this.label_Mesaj.Size = new System.Drawing.Size(59, 23);
            this.label_Mesaj.TabIndex = 3;
            this.label_Mesaj.Text = "label5";
            // 
            // label_Captcha
            // 
            this.label_Captcha.AutoSize = true;
            this.label_Captcha.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_Captcha.Location = new System.Drawing.Point(327, 210);
            this.label_Captcha.Name = "label_Captcha";
            this.label_Captcha.Size = new System.Drawing.Size(75, 23);
            this.label_Captcha.TabIndex = 4;
            this.label_Captcha.Text = "Captcha";
            // 
            // label_YeniSifreTekrar
            // 
            this.label_YeniSifreTekrar.AutoSize = true;
            this.label_YeniSifreTekrar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_YeniSifreTekrar.Location = new System.Drawing.Point(53, 144);
            this.label_YeniSifreTekrar.Name = "label_YeniSifreTekrar";
            this.label_YeniSifreTekrar.Size = new System.Drawing.Size(152, 23);
            this.label_YeniSifreTekrar.TabIndex = 5;
            this.label_YeniSifreTekrar.Text = "Yeni Şifre (Tekrar)";
            // 
            // label_YeniSifre
            // 
            this.label_YeniSifre.AutoSize = true;
            this.label_YeniSifre.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_YeniSifre.Location = new System.Drawing.Point(120, 92);
            this.label_YeniSifre.Name = "label_YeniSifre";
            this.label_YeniSifre.Size = new System.Drawing.Size(85, 23);
            this.label_YeniSifre.TabIndex = 6;
            this.label_YeniSifre.Text = "Yeni Şifre";
            // 
            // label_EskiSifre
            // 
            this.label_EskiSifre.AutoSize = true;
            this.label_EskiSifre.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_EskiSifre.Location = new System.Drawing.Point(121, 39);
            this.label_EskiSifre.Name = "label_EskiSifre";
            this.label_EskiSifre.Size = new System.Drawing.Size(84, 23);
            this.label_EskiSifre.TabIndex = 7;
            this.label_EskiSifre.Text = "Eski Şifre";
            // 
            // SifreDegistir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_SifreDegistir);
            this.Controls.Add(this.textBox_Captcha);
            this.Controls.Add(this.textBox_YeniSifreOnay);
            this.Controls.Add(this.textBox_YeniSifre);
            this.Controls.Add(this.textBox_EskiSifre);
            this.Controls.Add(this.label_Mesaj);
            this.Controls.Add(this.label_Captcha);
            this.Controls.Add(this.label_YeniSifreTekrar);
            this.Controls.Add(this.label_YeniSifre);
            this.Controls.Add(this.label_EskiSifre);
            this.Name = "SifreDegistir";
            this.Text = "SifreDegistir";
            this.Load += new System.EventHandler(this.SifreDegistir_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_SifreDegistir;
        private System.Windows.Forms.TextBox textBox_Captcha;
        private System.Windows.Forms.TextBox textBox_YeniSifreOnay;
        private System.Windows.Forms.TextBox textBox_YeniSifre;
        private System.Windows.Forms.TextBox textBox_EskiSifre;
        private System.Windows.Forms.Label label_Mesaj;
        private System.Windows.Forms.Label label_Captcha;
        private System.Windows.Forms.Label label_YeniSifreTekrar;
        private System.Windows.Forms.Label label_YeniSifre;
        private System.Windows.Forms.Label label_EskiSifre;
    }
}