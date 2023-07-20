using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace istakip3
{
    public partial class Form2 : Form
    {
        private Form1 frm1;

        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.frm1 = form1;
            yenisifre.Focus();
        }


        private void iptalbuton_Click(object sender, EventArgs e)
        {
            Hide();
            frm1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            eskisifre.Text = frm1.eskisifregonder;
            kullaniciadi.Text = frm1.kullaniciadigonder;
            
        }



        private void onaylabuton_Click(object sender, EventArgs e)
        {
            string sifre1 = yenisifre.Text;
            string sifre2 = sifredogrula.Text;
            if (sifre1.Length > 3 && sifre1.Equals(sifre2) && !sifre1.Equals(frm1.eskisifregonder))
            {

                bool boolConnection = frm1.DbReconnect();

                if (boolConnection)
                {
                    DBClass dBClass = new DBClass();
                    string checkPageData = dBClass.SifreDegistir(frm1.userClass.prsId, sifre1, frm1.connection);
                    Hide();
                    frm1.Show();
                    frm1.textBox2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Şifre Değiştirirken Hata Oluştu.Yeni Şifreniz en az 4 karakterden oluşmalı, ve eski şifreyle aynı olmamalıdır");
            }


        }


    }
}
