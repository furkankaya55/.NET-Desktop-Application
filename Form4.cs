using System;
using System.Collections;
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
    public partial class Form4 : Form
    {
        private UserClass userClass1;
        private Form1 frm1;
        private ArrayList isTakipListesi;
        private DBClass dBClass = new DBClass();
        public islerClass secilenIslerClass;
        public string isdetayeski;
        private UserClass userClass;
        public ArrayList BaskanlikListesi = new ArrayList();
        public ArrayList SubeListesi = new ArrayList();
        public ArrayList SeflikListesi = new ArrayList();
        public ArrayList YetkiSeviyesiListesi = new ArrayList();

        public Form4(Form1 form1, UserClass userClass)
        {
            InitializeComponent();
            this.userClass1 = userClass;
            this.frm1 = form1;
            this.userClass = userClass;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if(userClass.prsId != 19)
            {
                panel11.Dispose();
            }


            timer1.Enabled = true;

            bool boolConnection = frm1.DbReconnect();
            if (boolConnection)
            {
                BaskanlikListesi = dBClass.BaskanlikListesiGetir(BaskanlikListesi, frm1.connection);
            }

            boolConnection = frm1.DbReconnect();
            if (boolConnection)
            {
                SubeListesi = dBClass.SubeListesiGetir(SubeListesi, frm1.connection);
            }

            boolConnection = frm1.DbReconnect();
            if (boolConnection)
            {
                SeflikListesi = dBClass.SeflikListesiGetir(SeflikListesi, frm1.connection);
            }

            boolConnection = frm1.DbReconnect();
            if (boolConnection)
            {
                YetkiSeviyesiListesi = dBClass.YetkiSeviyesiListesiGetir(YetkiSeviyesiListesi, frm1.connection);
            }

            kullaniciadiana.Text = userClass1.personelAdSoyad;
            isgrup.Text = dBClass.YetkiSeviyeAdiGetir(userClass.yetkiSeviyeId, YetkiSeviyesiListesi);
            timerDoldur.Enabled = true;

            if (userClass1.yetkiSeviyeId != 3 && userClass1.yetkiSeviyeId != 4)
            {
                panel3.Dispose();
            }

            var col1 = new DataGridViewTextBoxColumn();
            var col2 = new DataGridViewTextBoxColumn();
            var col3 = new DataGridViewTextBoxColumn();
            var col4 = new DataGridViewTextBoxColumn();
            var col5 = new DataGridViewTextBoxColumn();
            var col6 = new DataGridViewTextBoxColumn();
            var col7 = new DataGridViewTextBoxColumn();
            var col8 = new DataGridViewTextBoxColumn();
            var col9 = new DataGridViewLinkColumn();
            var col10 = new DataGridViewLinkColumn();

            col1.HeaderText = "NO";
            col1.Name = "isno";

            col2.HeaderText = "KAYIT TARİHİ";
            col2.Name = "tarih";

            col3.HeaderText = "KAYIT EDEN";
            col3.Name = "kayiteden";

            col4.HeaderText = "İŞİN ŞUBESİ";
            col4.Name = "isinsubesi";

            col5.HeaderText = "İŞ DETAYI";
            col5.Name = "isdetay";

            col6.HeaderText = "İŞİN SAHİBİ";
            col6.Name = "issahip";

            col7.HeaderText = "BİTİŞ TARİHİ";
            col7.Name = "tamamlamatarih";

            col8.HeaderText = "AÇIKLAMA";
            col8.Name = "aciklama";

            col9.HeaderText = "İŞİ AL";
            col9.Name = "isial";

            col10.HeaderText = "DÜZENLE";
            col10.Name = "duzelt";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = style;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { col1, col2, col3, col4, col5, col6, col7, col8, col9, col10 });
            GridDoldur();
            this.WindowState = FormWindowState.Maximized;
        }

        private void datarenk()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                if (Convert.ToString(dataGridView1.Rows[i].Cells[8].Value) == "TAMAMLANDI")
                {
                    renk.BackColor = Color.LightGreen;
                    renk.ForeColor = Color.Black;
                }
                else if (Convert.ToString(dataGridView1.Rows[i].Cells[5].Value) == "")
                {
                    renk.BackColor = Color.LightSkyBlue;
                    renk.ForeColor = Color.Black;
                }
                else 
                {
                    renk.BackColor = Color.Moccasin;
                    renk.ForeColor = Color.Black;
                }
                dataGridView1.Rows[i].DefaultCellStyle = renk;

            }
        }

        public void GridDoldur()
        {
            isTakipListesi = null;
            isTakipListesi = new ArrayList();

            string query = isListesiQueryGetir(userClass1.yetkiSeviyeId);

            if (query.Trim() != "")
            {
                bool boolConnection = frm1.DbReconnect();

                if (boolConnection)
                {
                    isTakipListesi = dBClass.isTakipListesiGetir(query, frm1.connection);
                }

                isListesiniEkranaYaz(isTakipListesi);

            }
            dataGridView1.ReadOnly = true;
            if (dataGridView1.Columns.Count > 0)
            {
                int genislik = dataGridView1.Width;

                dataGridView1.Columns[0].Width = 3 * (genislik / 100);
                dataGridView1.Columns[1].Width = 8 * (genislik / 100);
                dataGridView1.Columns[2].Width = 8 * (genislik / 100);
                dataGridView1.Columns[3].Width = 13 * (genislik / 100);
                dataGridView1.Columns[4].Width = 21 * (genislik / 100);
                dataGridView1.Columns[5].Width = 12 * (genislik / 100);
                dataGridView1.Columns[6].Width = 8 * (genislik / 100);
                dataGridView1.Columns[7].Width = 16 * (genislik / 100);
                dataGridView1.Columns[8].Width = 6 * (genislik / 100);
                dataGridView1.Columns[9].Width = 5 * (genislik / 100);

            }
            datarenk();
        }

        private string isListesiQueryGetir(int id)
        {
            string query = string.Empty;

            switch (id)
            {
                case -1:
                case 1:
                case 2:
                    break;

                case 0:
                    if (userClass.seflikId != -1)
                    {
                        query = "SELECT I.isId, I.kayitTarihi,  CONCAT(P1.personelAdi, ' ', P1.personelSoyAdi) as kayitEden, I.isDetay, CONCAT(P2.personelAdi, ' ', P2.personelSoyAdi) as isiYapan, I.tamamlanmaTarihi, I.aciklama, I.baskanlikId, I.subeId, I.seflikId, I.yetkiSeviyeId from ıstakıp.isler I ";
                        query = query + "LEFT JOIN ıstakıp.personel P1 on P1.personelId = I.kayitEden ";
                        query = query + "LEFT JOIN ıstakıp.personel P2 on P2.personelId = I.isiYapan ";
                        query = query + "WHERE I.yetkiSeviyeId = 0 or I.seflikId = " + userClass.seflikId + " ";
                        query = query + "ORDER BY 1 desc limit 500; ";
                    } else
                    {
                        query = "SELECT I.isId, I.kayitTarihi,  CONCAT(P1.personelAdi, ' ', P1.personelSoyAdi) as kayitEden, I.isDetay, CONCAT(P2.personelAdi, ' ', P2.personelSoyAdi) as isiYapan, I.tamamlanmaTarihi, I.aciklama, I.baskanlikId, I.subeId, I.seflikId, I.yetkiSeviyeId from ıstakıp.isler I ";
                        query = query + "LEFT JOIN ıstakıp.personel P1 on P1.personelId = I.kayitEden ";
                        query = query + "LEFT JOIN ıstakıp.personel P2 on P2.personelId = I.isiYapan ";
                        query = query + "WHERE I.yetkiSeviyeId = 0 or I.subeId = " + userClass.subeId + " ";
                        query = query + "ORDER BY 1 desc limit 500; ";
                    }
                    break;

                case 3:
                    if (userClass.prsId != 14)
                    {
                        query = "SELECT I.isId, I.kayitTarihi,  CONCAT(P1.personelAdi, ' ', P1.personelSoyAdi) as kayitEden, I.isDetay, CONCAT(P2.personelAdi, ' ', P2.personelSoyAdi) as isiYapan, I.tamamlanmaTarihi, I.aciklama, I.baskanlikId, I.subeId, I.seflikId, I.yetkiSeviyeId from ıstakıp.isler I ";
                        query = query + "LEFT JOIN ıstakıp.personel P1 on P1.personelId = I.kayitEden ";
                        query = query + "LEFT JOIN ıstakıp.personel P2 on P2.personelId = I.isiYapan ";
                        query = query + "WHERE I.yetkiSeviyeId >= " + id + " and I.subeId = " + userClass.subeId + " ";
                        query = query + "ORDER BY 1 desc limit 500; ";
                    } else
                    {   // personel Mesut Şahin ise
                        query = "SELECT I.isId, I.kayitTarihi,  CONCAT(P1.personelAdi, ' ', P1.personelSoyAdi) as kayitEden, I.isDetay, CONCAT(P2.personelAdi, ' ', P2.personelSoyAdi) as isiYapan, I.tamamlanmaTarihi, I.aciklama, I.baskanlikId, I.subeId, I.seflikId, I.yetkiSeviyeId from ıstakıp.isler I ";
                        query = query + "LEFT JOIN ıstakıp.personel P1 on P1.personelId = I.kayitEden ";
                        query = query + "LEFT JOIN ıstakıp.personel P2 on P2.personelId = I.isiYapan ";
                        query = query + "WHERE I.yetkiSeviyeId >= " + id + " and I.subeId in (13,14,16)";
                        query = query + "ORDER BY 1 desc limit 500; ";
                    }
                    break;
                case 4:

                    query = "SELECT I.isId, I.kayitTarihi,  CONCAT(P1.personelAdi, ' ', P1.personelSoyAdi) as kayitEden, I.isDetay, CONCAT(P2.personelAdi, ' ', P2.personelSoyAdi) as isiYapan, I.tamamlanmaTarihi, I.aciklama, I.baskanlikId, I.subeId, I.seflikId, I.yetkiSeviyeId from ıstakıp.isler I ";
                    query = query + "LEFT JOIN ıstakıp.personel P1 on P1.personelId = I.kayitEden ";
                    query = query + "LEFT JOIN ıstakıp.personel P2 on P2.personelId = I.isiYapan ";
                    query = query + "WHERE I.yetkiSeviyeId = " + id + " ";
                    query = query + "ORDER BY 1 desc limit 500; ";

                    break;
            }

            return query;
        }

        private void isListesiniEkranaYaz(ArrayList isTakipListe)
        {
            dataGridView1.Rows.Clear();
            string strIsiYapan = string.Empty;
            string strDuzenle = string.Empty;
            string strSil = string.Empty;

            for (int i = 0; i < isTakipListe.Count; i++)
            {
                if (((islerClass)isTakipListe[i]).isiYapan.ToString().Trim() == "")
                {
                    if (userClass.yetkiSeviyeId == 4)
                    {
                        strIsiYapan = "";
                    }
                    else
                    {
                        if (userClass.yetkiSeviyeId != ((islerClass)isTakipListe[i]).yetkiSeviyeId)
                        {
                            if (userClass.yetkiSeviyeId == 0)
                            {
                                if (((islerClass)isTakipListe[i]).seflikId != -1)
                                {
                                    strIsiYapan = "İŞİ AL";
                                }
                                else
                                {
                                    strIsiYapan = "";
                                }
                            }
                            else
                            {
                                //if(((islerClass)isTakipListe[i]).isiYapan.Trim() == "")
                                //{
                                //    strIsiYapan = "İŞİ AL";
                                //} else
                                //{
                                //    strIsiYapan = "";
                                //}


                                if (((islerClass)isTakipListe[i]).yetkiSeviyeId == 4 && ((islerClass)isTakipListe[i]).seflikId != -1)
                                {
                                    strIsiYapan = "";
                                }
                                else
                                {
                                    strIsiYapan = "İŞİ AL";

                                }
                            }
                        } else
                        {
                            strIsiYapan = "";
                        }
                    }
                }
                else
                {
                    if (((islerClass)isTakipListe[i]).tamamlanmaTarihi == "")
                    {
                        if (((islerClass)isTakipListe[i]).isiYapan == userClass1.personelAdSoyad)
                        {

                            if (userClass.yetkiSeviyeId == 4)
                            {
                                strIsiYapan = "";
                            }
                            else
                            {
                                strIsiYapan = "İŞİ TAMAMLA";
                            }
                        }
                        else
                        {
                            strIsiYapan = "";
                        }
                    }
                    else
                    {
                        strIsiYapan = "TAMAMLANDI";
                    }
                }

                if (userClass.yetkiSeviyeId == ((islerClass)isTakipListe[i]).yetkiSeviyeId)
                {
                    if (strIsiYapan != "TAMAMLANDI")
                    {
                        strDuzenle = "DÜZENLE";
                    } else
                    {
                        strDuzenle = "";
                    }
                }
                else
                {

                    if (userClass.yetkiSeviyeId == 0)
                    {
                        if (((islerClass)isTakipListe[i]).seflikId != -1)
                        {
                            strDuzenle = "";
                        }
                        else
                        {
                            strDuzenle = "DÜZENLE";
                        }
                    }
                    else
                    {
                        if (userClass.yetkiSeviyeId == 4)
                        {
                            if (((islerClass)isTakipListe[i]).yetkiSeviyeId == 4 && ((islerClass)isTakipListe[i]).seflikId != -1)
                            {
                                strDuzenle = "DÜZENLE";
                            }
                            else
                            {
                                strDuzenle = "";
                            }
                        } else
                        {
                            if (strIsiYapan == "TAMAMLANDI" || strIsiYapan == "İŞİ AL" || strIsiYapan == "İŞİ TAMAMLA")
                            {
                                strDuzenle = "";
                            } else if (strIsiYapan == "")
                            {
                                strDuzenle = "DÜZENLE";
                            }
                        }
                    }
                }

                string subeAdi = string.Empty;

                if (userClass.yetkiSeviyeId == 4)
                {
                    subeAdi = dBClass.SubeAdiGetir(SubeListesi, ((islerClass)isTakipListe[i]).subeId);
                }
                else
                {
                    if (((islerClass)isTakipListe[i]).seflikId == -1)
                    {
                        subeAdi = dBClass.SubeAdiGetir(SubeListesi, ((islerClass)isTakipListe[i]).subeId);
                    } else
                    {
                        subeAdi = dBClass.SeflikAdiGetir(SeflikListesi, ((islerClass)isTakipListe[i]).seflikId);
                    }
                }

                dataGridView1.Rows.Add(((islerClass)isTakipListe[i]).isId,
                        ((islerClass)isTakipListe[i]).kayitTarihi,
                        ((islerClass)isTakipListe[i]).kayitEden,
                        subeAdi,
                        ((islerClass)isTakipListe[i]).isDetay,
                        ((islerClass)isTakipListe[i]).isiYapan,
                        ((islerClass)isTakipListe[i]).tamamlanmaTarihi,
                        ((islerClass)isTakipListe[i]).aciklama,
                        strIsiYapan,
                        strDuzenle,
                        strSil);



                if (dataGridView1.Rows.Count > 1)
                {
                    dataGridView1.CurrentCell.Selected = false;
                }
            }
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            //frm1.Close();
            timer1.Enabled = false;
            timerDoldur.Enabled = false;
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool boolConnection = frm1.DbReconnect();
            if (boolConnection)
            {
                if (e.ColumnIndex == 8)
                {
                    if (e.RowIndex != -1)
                    {

                        string ifade = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

                        if (ifade == "İŞİ AL")
                        {

                            DialogResult confirmResult = MessageBox.Show("İşi almak istiyor musunuz?", "ONAY", MessageBoxButtons.YesNo);
                            if (confirmResult == DialogResult.Yes)
                            {

                                secilenIslerClass = (islerClass)isTakipListesi[e.RowIndex];
                                if (secilenIslerClass != null)
                                {
                                    if (userClass.yetkiSeviyeId == 3)
                                    {
                                        DialogResult confirmResult2 = MessageBox.Show("İşi aktarmak için EVET, işi üzerinize almak için HAYIR seçimini yapınız", "ONAY", MessageBoxButtons.YesNo);
                                        if (confirmResult2 == DialogResult.Yes)
                                        {
                                            Form5 duzenle = new Form5(this, frm1, "1", userClass);
                                            duzenle.ShowDialog();
                                        }
                                        else
                                        {
                                            dBClass.isTakipListesiUpdate2(secilenIslerClass.isId, userClass.prsId, frm1.connection);
                                        }
                                    }
                                    else if (userClass.yetkiSeviyeId == 0)
                                    {
                                        dBClass.isTakipListesiUpdate2(secilenIslerClass.isId, userClass1.prsId, frm1.connection);
                                    }
                                }


                                    //     GridDoldur();


                                    //secilenIslerClass = (islerClass)isTakipListesi[e.RowIndex];
                                    //if (secilenIslerClass != null)
                                    //{
                                    //    dBClass.isTakipListesiUpdate2(secilenIslerClass.isId, userClass1.prsId, frm1.connection);
                                    //    
                                    //}
                                }
                        }
                        else if (ifade == "İŞİ TAMAMLA")
                        {
                            secilenIslerClass = (islerClass)isTakipListesi[e.RowIndex];
                            if (secilenIslerClass != null)
                            {
                                Form6 aciklama = new Form6(this, frm1, userClass1);
                                aciklama.ShowDialog();

                          //      GridDoldur();
                            }
                        }

                        GridDoldur();
                    }
                }
                else if (e.ColumnIndex == 9)
                {
                    if (e.RowIndex != -1)
                    {
                        secilenIslerClass = (islerClass)isTakipListesi[e.RowIndex];
                        if (secilenIslerClass != null)
                        {
                            Form5 duzenle = new Form5(this, frm1, "1", userClass1);
                            duzenle.ShowDialog();

                            GridDoldur();
                        }
                    }
                }
                else if (e.ColumnIndex == 10)
                {
                    if (e.RowIndex != -1)
                    {
                        DialogResult confirmResult = MessageBox.Show("İşi silmek istiyor musunuz?", "ONAY", MessageBoxButtons.YesNo);
                        if (confirmResult == DialogResult.Yes)
                        {
                           
                            
                            //if(this.dataGridView1.SelectedRows.Count > 0)
                            //{
                            //    dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                         
                        }
                    }
                }
            }
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            secilenIslerClass = new islerClass();
            Form5 isekle = new Form5(this, frm1, "0", userClass1);
            isekle.ShowDialog();
            GridDoldur();
        }

        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            if (dataGridView1.Columns.Count > 0)
            {
                int genislik = dataGridView1.Width;

                dataGridView1.Columns[0].Width = 3 * (genislik / 100);
                dataGridView1.Columns[1].Width = 8 * (genislik / 100);
                dataGridView1.Columns[2].Width = 8 * (genislik / 100);
                dataGridView1.Columns[3].Width = 13 * (genislik / 100);
                dataGridView1.Columns[4].Width = 21 * (genislik / 100);
                dataGridView1.Columns[5].Width = 12 * (genislik / 100);
                dataGridView1.Columns[6].Width = 8 * (genislik / 100);
                dataGridView1.Columns[7].Width = 16 * (genislik / 100);
                dataGridView1.Columns[8].Width = 6 * (genislik / 100);
                dataGridView1.Columns[9].Width = 5 * (genislik / 100);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 raporla = new Form7(userClass1, frm1, this);
            raporla.ShowDialog();
            GridDoldur();
        }

        private void timerDoldur_Tick(object sender, EventArgs e)
        {
            GridDoldur();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            frm1.Show();
            Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            GridDoldur();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.Left > -340)
            {
                label1.Left -= 1;
            }
            else
            {
                label1.Left = this.Width;
            }
        }   
    }
}
  