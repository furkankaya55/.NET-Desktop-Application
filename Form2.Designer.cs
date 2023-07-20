
namespace istakip3
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.sifredegistiranabaslik = new System.Windows.Forms.Label();
            this.belediyelogo = new System.Windows.Forms.PictureBox();
            this.onaylabuton = new System.Windows.Forms.Button();
            this.dogrulabaslik = new System.Windows.Forms.Label();
            this.yenisifrebaslik = new System.Windows.Forms.Label();
            this.yenisifre = new System.Windows.Forms.TextBox();
            this.sifredogrula = new System.Windows.Forms.TextBox();
            this.kullaniciadi = new System.Windows.Forms.Label();
            this.iptalbuton = new System.Windows.Forms.Button();
            this.eskisifre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.belediyelogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.sifredegistiranabaslik);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 113);
            this.panel1.TabIndex = 0;
            // 
            // sifredegistiranabaslik
            // 
            this.sifredegistiranabaslik.AutoSize = true;
            this.sifredegistiranabaslik.BackColor = System.Drawing.SystemColors.Highlight;
            this.sifredegistiranabaslik.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifredegistiranabaslik.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sifredegistiranabaslik.Location = new System.Drawing.Point(146, 47);
            this.sifredegistiranabaslik.Name = "sifredegistiranabaslik";
            this.sifredegistiranabaslik.Size = new System.Drawing.Size(200, 31);
            this.sifredegistiranabaslik.TabIndex = 7;
            this.sifredegistiranabaslik.Text = "ŞİFRE DEĞİŞTİR";
            // 
            // belediyelogo
            // 
            this.belediyelogo.BackColor = System.Drawing.SystemColors.Highlight;
            this.belediyelogo.Image = ((System.Drawing.Image)(resources.GetObject("belediyelogo.Image")));
            this.belediyelogo.Location = new System.Drawing.Point(3, 2);
            this.belediyelogo.Name = "belediyelogo";
            this.belediyelogo.Size = new System.Drawing.Size(111, 107);
            this.belediyelogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.belediyelogo.TabIndex = 6;
            this.belediyelogo.TabStop = false;
            // 
            // onaylabuton
            // 
            this.onaylabuton.BackColor = System.Drawing.SystemColors.Highlight;
            this.onaylabuton.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.onaylabuton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.onaylabuton.Location = new System.Drawing.Point(210, 459);
            this.onaylabuton.Name = "onaylabuton";
            this.onaylabuton.Size = new System.Drawing.Size(130, 43);
            this.onaylabuton.TabIndex = 12;
            this.onaylabuton.Text = "✓  Onayla";
            this.onaylabuton.UseVisualStyleBackColor = false;
            this.onaylabuton.Click += new System.EventHandler(this.onaylabuton_Click);
            // 
            // dogrulabaslik
            // 
            this.dogrulabaslik.AutoSize = true;
            this.dogrulabaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.dogrulabaslik.Location = new System.Drawing.Point(110, 347);
            this.dogrulabaslik.Name = "dogrulabaslik";
            this.dogrulabaslik.Size = new System.Drawing.Size(212, 26);
            this.dogrulabaslik.TabIndex = 11;
            this.dogrulabaslik.Text = "Yeni Şifreyi Doğrula:";
            // 
            // yenisifrebaslik
            // 
            this.yenisifrebaslik.AutoSize = true;
            this.yenisifrebaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.yenisifrebaslik.Location = new System.Drawing.Point(147, 237);
            this.yenisifrebaslik.Name = "yenisifrebaslik";
            this.yenisifrebaslik.Size = new System.Drawing.Size(114, 26);
            this.yenisifrebaslik.TabIndex = 10;
            this.yenisifrebaslik.Text = "Yeni Şifre:";
            // 
            // yenisifre
            // 
            this.yenisifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.yenisifre.Location = new System.Drawing.Point(80, 279);
            this.yenisifre.Name = "yenisifre";
            this.yenisifre.PasswordChar = '*';
            this.yenisifre.Size = new System.Drawing.Size(260, 32);
            this.yenisifre.TabIndex = 8;
            // 
            // sifredogrula
            // 
            this.sifredogrula.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.sifredogrula.Location = new System.Drawing.Point(80, 400);
            this.sifredogrula.Name = "sifredogrula";
            this.sifredogrula.PasswordChar = '*';
            this.sifredogrula.Size = new System.Drawing.Size(260, 32);
            this.sifredogrula.TabIndex = 9;
            // 
            // kullaniciadi
            // 
            this.kullaniciadi.AutoSize = true;
            this.kullaniciadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kullaniciadi.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.kullaniciadi.Location = new System.Drawing.Point(208, 149);
            this.kullaniciadi.Name = "kullaniciadi";
            this.kullaniciadi.Size = new System.Drawing.Size(0, 25);
            this.kullaniciadi.TabIndex = 14;
            // 
            // iptalbuton
            // 
            this.iptalbuton.BackColor = System.Drawing.Color.Tomato;
            this.iptalbuton.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iptalbuton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iptalbuton.Location = new System.Drawing.Point(80, 459);
            this.iptalbuton.Name = "iptalbuton";
            this.iptalbuton.Size = new System.Drawing.Size(105, 43);
            this.iptalbuton.TabIndex = 15;
            this.iptalbuton.Text = "✗  İptal";
            this.iptalbuton.UseVisualStyleBackColor = false;
            this.iptalbuton.Click += new System.EventHandler(this.iptalbuton_Click);
            // 
            // eskisifre
            // 
            this.eskisifre.AutoSize = true;
            this.eskisifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.eskisifre.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.eskisifre.Location = new System.Drawing.Point(205, 178);
            this.eskisifre.Name = "eskisifre";
            this.eskisifre.Size = new System.Drawing.Size(0, 25);
            this.eskisifre.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(75, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(75, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Mevcut Şifre:";
            // 
            // Form2
            // 
            this.AcceptButton = this.onaylabuton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(412, 553);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eskisifre);
            this.Controls.Add(this.iptalbuton);
            this.Controls.Add(this.kullaniciadi);
            this.Controls.Add(this.belediyelogo);
            this.Controls.Add(this.onaylabuton);
            this.Controls.Add(this.dogrulabaslik);
            this.Controls.Add(this.yenisifrebaslik);
            this.Controls.Add(this.yenisifre);
            this.Controls.Add(this.sifredogrula);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(430, 600);
            this.MinimumSize = new System.Drawing.Size(430, 600);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ŞİFRE DEĞİŞTİR";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.belediyelogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label sifredegistiranabaslik;
        private System.Windows.Forms.PictureBox belediyelogo;
        private System.Windows.Forms.Button onaylabuton;
        private System.Windows.Forms.Label dogrulabaslik;
        private System.Windows.Forms.Label yenisifrebaslik;
        private System.Windows.Forms.TextBox yenisifre;
        private System.Windows.Forms.TextBox sifredogrula;
        private System.Windows.Forms.Label kullaniciadi;
        private System.Windows.Forms.Button iptalbuton;
        private System.Windows.Forms.Label eskisifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}