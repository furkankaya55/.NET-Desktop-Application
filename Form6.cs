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
    public partial class Form6 : Form
    {
        private UserClass userClass2;
        private DBClass dBClass = new DBClass();
        private Form1 frm1;
        private Form4 frm4;
        private UserClass userClass;

        public Form6(Form4 form4, Form1 form1, UserClass userClass1)
        {
            InitializeComponent();
            this.frm4 = form4;
            this.frm1 = form1;
            this.userClass2 = userClass1;
        }

        private void tamamlabuton_Click(object sender, EventArgs e)
        {
            if (aciklamabox.Text.Length < 10)
            {
                MessageBox.Show("En az 10 karakter olacak şekilde açıklama girin");
            }
            else
            {
                bool boolConnection = frm1.DbReconnect();

                if (boolConnection)
                {
                    dBClass.isTakipListesiTamamla(frm4.secilenIslerClass.isId, aciklamabox.Text.Trim(), frm1.connection);
                    Close();
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
