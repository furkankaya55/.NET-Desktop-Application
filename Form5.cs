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
    public partial class Form5 : Form
    {
        private string durum;
        private Form4 frm4;
        private Form1 frm1;
        private UserClass userClass;
        private islerClass secilenIslerClass;
        private DBClass dBClass = new DBClass();

        public Form5(Form4 form4, Form1 form1, string strDurum, UserClass userClass1)
        {
            InitializeComponent();
            this.durum = strDurum;
            this.frm4 = form4;
            this.frm1 = form1;
            this.userClass = userClass1;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();

            if (userClass.yetkiSeviyeId == 4)
            {   // sube isimleri dolacak

                for (int i = 0; i < frm4.SubeListesi.Count; i++)
                {
                    if (((SubeClass)frm4.SubeListesi[i]).baskanlikId == userClass.baskanlikId)
                    {
                        comboBox1.Items.Add(((SubeClass)frm4.SubeListesi[i]).subeId + " - " + ((SubeClass)frm4.SubeListesi[i]).subeAdi);
                    }
                }                
            }
            else
            {   // yetkiseviyeId = 3 ve varsa şeflikler dolacak

                int subeId = userClass.subeId;
                //bool seflikVar = false;

                //for (int j = 0; j < frm4.SeflikListesi.Count; j++)
                //{
                //    if (((SeflikClass)frm4.SeflikListesi[j]).subeId == userClass.subeId)
                //    {
                //        seflikVar = true;
                //        break;
                //    }
                //}

                //if (seflikVar)
                //{

                if (userClass.prsId != 14)
                {
                    for (int j = 0; j < frm4.SeflikListesi.Count; j++)
                    {
                        if (((SeflikClass)frm4.SeflikListesi[j]).subeId == userClass.subeId)
                        {
                            comboBox1.Items.Add(((SeflikClass)frm4.SeflikListesi[j]).seflikId + " - " + ((SeflikClass)frm4.SeflikListesi[j]).seflikAdi);
                        }
                    }
                } else
                {
                    for (int j = 0; j < frm4.SeflikListesi.Count; j++)
                    {
                        if (((SeflikClass)frm4.SeflikListesi[j]).subeId == 13 ||
                            ((SeflikClass)frm4.SeflikListesi[j]).subeId == 14 ||
                            ((SeflikClass)frm4.SeflikListesi[j]).subeId == 16)
                        {
                            comboBox1.Items.Add(((SeflikClass)frm4.SeflikListesi[j]).seflikId + " - " + ((SeflikClass)frm4.SeflikListesi[j]).seflikAdi);
                        }
                    }
                }



                //} else
                //{
                //    string subeAdi = dBClass.SubeAdiGetir(frm4.SubeListesi, subeId);
                //    comboBox1.Items.Add(subeId + " - " + subeAdi);
                //}
            }

            if (durum.Equals("0"))
            {
                onayButon.Text = "EKLE";
            } else if (durum.Equals("1"))
            {
                richTextBox1.Text = frm4.secilenIslerClass.isDetay;

                if (userClass.yetkiSeviyeId == 4) {
                    comboSec(frm4.secilenIslerClass.subeId);
                } else
                {
                    comboSec(frm4.secilenIslerClass.seflikId);
                }

                onayButon.Text = "DÜZENLE";
            }
        }

        private void comboSec(int secilenId)
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (comboBox1.Items[i].ToString().Contains(secilenId.ToString()))
                {
                    comboBox1.SelectedIndex = i;
                    break;
                }
            }
        }

        private void onayButon_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Trim().Length < 10)
            {
                MessageBox.Show("İş detayını girin.Minimum 10 karakter olmalıdır.");
            }
            else if(comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("İş grubu seçin");
            }
            else
            {
                bool boolConnection = frm1.DbReconnect();

                if (boolConnection)
                {
                    string secilenId = comboBox1.SelectedItem.ToString().Trim().Substring(0, comboBox1.SelectedItem.ToString().Trim().IndexOf(" -"));

                    if (onayButon.Text.Equals("EKLE"))
                    {
                        if (userClass.yetkiSeviyeId == 3)
                        {
                            dBClass.yeniIsEkle(DateTime.Now, userClass, richTextBox1.Text.Trim(), userClass.subeId, Convert.ToInt32(secilenId), frm1.connection);
                        } else
                        {
                            dBClass.yeniIsEkle(DateTime.Now, userClass, richTextBox1.Text.Trim(), Convert.ToInt32(secilenId), -1, frm1.connection);
                        }
                    }
                    else if (onayButon.Text.Equals("DÜZENLE"))
                    {
                        if (userClass.yetkiSeviyeId == 3)
                        {
                            //bool seflikVar = false;

                            //for (int j = 0; j < frm4.SeflikListesi.Count; j++)
                            //{
                            //    if (((SeflikClass)frm4.SeflikListesi[j]).subeId == userClass.subeId)
                            //    {
                            //        seflikVar = true;
                            //        break;
                            //    }
                            //}

                            //if (seflikVar)
                            //{
                                dBClass.secilenIsiGuncelle(frm4.secilenIslerClass.isId, richTextBox1.Text.Trim(), userClass.subeId, Convert.ToInt32(secilenId), frm1.connection);
                            //} else
                            //{
                            //    dBClass.secilenIsiGuncelle(frm4.secilenIslerClass.isId, richTextBox1.Text.Trim(), userClass.subeId, -1, frm1.connection);
                            //}
                        }
                        else
                        {
                            dBClass.secilenIsiGuncelle(frm4.secilenIslerClass.isId, richTextBox1.Text.Trim(), Convert.ToInt32(secilenId), -1, frm1.connection);
                        }
                    }

                    Close();
                }
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

   
}
