
namespace istakip3
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.aciklamabox = new System.Windows.Forms.RichTextBox();
            this.tamamlabuton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // aciklamabox
            // 
            this.aciklamabox.Location = new System.Drawing.Point(13, 13);
            this.aciklamabox.Name = "aciklamabox";
            this.aciklamabox.Size = new System.Drawing.Size(594, 96);
            this.aciklamabox.TabIndex = 0;
            this.aciklamabox.Text = "";
            // 
            // tamamlabuton
            // 
            this.tamamlabuton.BackColor = System.Drawing.Color.SteelBlue;
            this.tamamlabuton.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tamamlabuton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tamamlabuton.Location = new System.Drawing.Point(407, 116);
            this.tamamlabuton.Name = "tamamlabuton";
            this.tamamlabuton.Size = new System.Drawing.Size(199, 37);
            this.tamamlabuton.TabIndex = 1;
            this.tamamlabuton.Text = "TAMAMLA";
            this.tamamlabuton.UseVisualStyleBackColor = false;
            this.tamamlabuton.Click += new System.EventHandler(this.tamamlabuton_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 158);
            this.Controls.Add(this.tamamlabuton);
            this.Controls.Add(this.aciklamabox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İŞİ TAMAMLA";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox aciklamabox;
        private System.Windows.Forms.Button tamamlabuton;
    }
}