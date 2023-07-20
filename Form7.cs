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
    public partial class Form7 : Form

    {
        private ArrayList isTakipListesi;
        private UserClass userClass;
        private DBClass dBClass = new DBClass();
        private Form1 frm1;
        private Form4 frm4;

        public Form7(UserClass userClass1, Form1 frm1, Form4 frm4)
        {
            InitializeComponent();
            this.userClass = userClass1;
            this.frm1 = frm1;
            this.frm4 = frm4;
        }

        public void SorguGridDoldur()
        {
            isTakipListesi = null;
            isTakipListesi = new ArrayList();

            string query = isListesiQueryGetir(userClass.yetkiSeviyeId);

            if (query.Trim() != "")
            {
                bool boolConnection = frm1.DbReconnect();

                if (boolConnection)
                {
                    isTakipListesi = dBClass.isTakipListesiGetir(query, frm1.connection);
                }

                isListesiniEkranaYaz(isTakipListesi);

            }
            dataGridView2.ReadOnly = true;
        }

        private string isListesiQueryGetir(int id)
        {
            string query = string.Empty;

            stopDate.Value = stopDate.Value.AddDays(1);

           
            string startDate1 = startDate.Value.ToString("yyyy-MM-dd HH:mm:ss").Substring(0,10);
            string stopDate1 = stopDate.Value.ToString("yyyy-MM-dd HH:mm:ss").Substring(0,10);

            //switch (id)
            //{
            //    case 1:


            //        query = "SELECT I.isId, I.kayitTarihi, P1.personelAdSoyad as kayitEden, Y.yetkiAdi, I.isDetay, P2.personelAdSoyad as isiYapan, I.tamamlanmaTarihi, I.aciklama from ıstakıp.isler I ";
            //        query = query + "LEFT JOIN ıstakıp.personel P1 on P1.prsId = I.kayitEden ";
            //        query = query + "LEFT JOIN ıstakıp.personel P2 on P2.prsId = I.isiYapan ";
            //        query = query + "LEFT JOIN ıstakıp.yetki Y on Y.yetkiId = I.isYetki ";
            //        query = query + "WHERE I.kayitTarihi between '" + startDate1 + "' and '" + stopDate1 + "' " ;
            //        query = query + "ORDER BY 1 desc limit 1000;";


            //        break;
            //    default:


            //        query = "SELECT I.isId, I.kayitTarihi, P1.personelAdSoyad as kayitEden, Y.yetkiAdi , I.isDetay, P2.personelAdSoyad as isiYapan, I.tamamlanmaTarihi, I.aciklama  from ıstakıp.isler I ";
            //        query = query + "LEFT JOIN ıstakıp.personel P1 on P1.prsId = I.kayitEden ";
            //        query = query + "LEFT JOIN ıstakıp.personel P2 on P2.prsId = I.isiYapan ";
            //        query = query + "LEFT JOIN ıstakıp.yetki Y on Y.yetkiId = I.isYetki ";
            //        query = query + "WHERE I.isYetki = " + id + " and I.kayitTarihi between '" + startDate1 + "' and '" + stopDate1 + "' ";
            //        query = query + "ORDER BY 1 desc limit 1000;";

            //        break;
            //}



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
                        query = query + "WHERE I.kayitTarihi between '" + startDate1 + "' and '" + stopDate1 + "' and I.yetkiSeviyeId = 0 or I.seflikId = " + userClass.seflikId + " ";
                        query = query + "ORDER BY 1 desc limit 500; ";
                    }
                    else
                    {
                        query = "SELECT I.isId, I.kayitTarihi,  CONCAT(P1.personelAdi, ' ', P1.personelSoyAdi) as kayitEden, I.isDetay, CONCAT(P2.personelAdi, ' ', P2.personelSoyAdi) as isiYapan, I.tamamlanmaTarihi, I.aciklama, I.baskanlikId, I.subeId, I.seflikId, I.yetkiSeviyeId from ıstakıp.isler I ";
                        query = query + "LEFT JOIN ıstakıp.personel P1 on P1.personelId = I.kayitEden ";
                        query = query + "LEFT JOIN ıstakıp.personel P2 on P2.personelId = I.isiYapan ";
                        query = query + "WHERE I.kayitTarihi between '" + startDate1 + "' and '" + stopDate1 + "' and I.yetkiSeviyeId = 0 or I.subeId = " + userClass.subeId + " ";
                        query = query + "ORDER BY 1 desc limit 500; ";
                    }
                    break;

                case 3:
                    if (userClass.prsId != 14)
                    {
                        query = "SELECT I.isId, I.kayitTarihi,  CONCAT(P1.personelAdi, ' ', P1.personelSoyAdi) as kayitEden, I.isDetay, CONCAT(P2.personelAdi, ' ', P2.personelSoyAdi) as isiYapan, I.tamamlanmaTarihi, I.aciklama, I.baskanlikId, I.subeId, I.seflikId, I.yetkiSeviyeId from ıstakıp.isler I ";
                        query = query + "LEFT JOIN ıstakıp.personel P1 on P1.personelId = I.kayitEden ";
                        query = query + "LEFT JOIN ıstakıp.personel P2 on P2.personelId = I.isiYapan ";
                        query = query + "WHERE I.kayitTarihi between '" + startDate1 + "' and '" + stopDate1 + "' and I.yetkiSeviyeId >= " + id + " and I.subeId = " + userClass.subeId + " ";
                        query = query + "ORDER BY 1 desc limit 500; ";
                    }
                    else
                    {   // personel Mesut Şahin ise
                        query = "SELECT I.isId, I.kayitTarihi,  CONCAT(P1.personelAdi, ' ', P1.personelSoyAdi) as kayitEden, I.isDetay, CONCAT(P2.personelAdi, ' ', P2.personelSoyAdi) as isiYapan, I.tamamlanmaTarihi, I.aciklama, I.baskanlikId, I.subeId, I.seflikId, I.yetkiSeviyeId from ıstakıp.isler I ";
                        query = query + "LEFT JOIN ıstakıp.personel P1 on P1.personelId = I.kayitEden ";
                        query = query + "LEFT JOIN ıstakıp.personel P2 on P2.personelId = I.isiYapan ";
                        query = query + "WHERE I.kayitTarihi between '" + startDate1 + "' and '" + stopDate1 + "' and I.yetkiSeviyeId >= " + id + " and I.subeId in (13,14,16)";
                        query = query + "ORDER BY 1 desc limit 500; ";
                    }
                    break;
                case 4:

                    query = "SELECT I.isId, I.kayitTarihi,  CONCAT(P1.personelAdi, ' ', P1.personelSoyAdi) as kayitEden, I.isDetay, CONCAT(P2.personelAdi, ' ', P2.personelSoyAdi) as isiYapan, I.tamamlanmaTarihi, I.aciklama, I.baskanlikId, I.subeId, I.seflikId, I.yetkiSeviyeId from ıstakıp.isler I ";
                    query = query + "LEFT JOIN ıstakıp.personel P1 on P1.personelId = I.kayitEden ";
                    query = query + "LEFT JOIN ıstakıp.personel P2 on P2.personelId = I.isiYapan ";
                    query = query + "WHERE I.kayitTarihi between '" + startDate1 + "' and '" + stopDate1 + "' and I.yetkiSeviyeId = " + id + " ";
                    query = query + "ORDER BY 1 desc limit 500; ";

                    break;
            }


            stopDate.Value = stopDate.Value.AddDays(-1);

            return query;
        }

        private void isListesiniEkranaYaz(ArrayList isTakipListe)
        {
            dataGridView2.Rows.Clear();
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
                        }
                        else
                        {
                            strIsiYapan = "";
                        }
                    }
                }
                else
                {
                    if (((islerClass)isTakipListe[i]).tamamlanmaTarihi == "")
                    {
                        if (((islerClass)isTakipListe[i]).isiYapan == userClass.personelAdSoyad)
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
                    }
                    else
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
                        }
                        else
                        {
                            if (strIsiYapan == "TAMAMLANDI" || strIsiYapan == "İŞİ AL" || strIsiYapan == "İŞİ TAMAMLA")
                            {
                                strDuzenle = "";
                            }
                            else if (strIsiYapan == "")
                            {
                                strDuzenle = "DÜZENLE";
                            }
                        }
                    }
                }

                string subeAdi = string.Empty;

                if (userClass.yetkiSeviyeId == 4)
                {
                    subeAdi = dBClass.SubeAdiGetir(frm4.SubeListesi, ((islerClass)isTakipListe[i]).subeId);
                }
                else
                {
                    if (((islerClass)isTakipListe[i]).seflikId == -1)
                    {
                        subeAdi = dBClass.SubeAdiGetir(frm4.SubeListesi, ((islerClass)isTakipListe[i]).subeId);
                    }
                    else
                    {
                        subeAdi = dBClass.SeflikAdiGetir(frm4.SeflikListesi, ((islerClass)isTakipListe[i]).seflikId);
                    }
                }

                dataGridView2.Rows.Add(((islerClass)isTakipListe[i]).isId,
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



                if (dataGridView2.Rows.Count > 1)
                {
                    dataGridView2.CurrentCell.Selected = false;
                }
            }








            //////dataGridView2.Rows.Clear();
            //////string strIsiYapan = string.Empty;
            //////string strDuzenle = string.Empty;

            //////for (int i = 0; i < isTakipListe.Count; i++)
            //////{
            //////    //if (((islerClass)isTakipListe[i]).isiYapan.ToString().Trim() == "")
            //////    //{
            //////    //    strIsiYapan = "İŞİ AL";

            //////    //}
            //////    //else
            //////    //{
            //////    //    if (((islerClass)isTakipListe[i]).tamamlanmaTarihi == "")
            //////    //    {
            //////    //        if (((islerClass)isTakipListe[i]).isiYapan == userClass1.personelAdSoyad)
            //////    //        {
            //////    //            strIsiYapan = "İŞİ TAMAMLA";
            //////    //        }
            //////    //        else
            //////    //        {
            //////    //            strIsiYapan = "";
            //////    //        }
            //////    //    }
            //////    //    else
            //////    //    {
            //////    //        strIsiYapan = "TAMAMLANDI";
            //////    //    }

            //////    //}

            //////    //if (userClass1.yetkiId == 1 && ((islerClass)isTakipListe[i]).tamamlanmaTarihi == "")
            //////    //{
            //////    //    strDuzenle = "DÜZENLE";
            //////    //}
            //////    //else
            //////    //{
            //////    //    strDuzenle = "";
            //////    //}

            //////    ////////dataGridView2.Rows.Add(((islerClass)isTakipListe[i]).isId,
            //////    ////////        ((islerClass)isTakipListe[i]).kayitTarihi,
            //////    ////////        ((islerClass)isTakipListe[i]).kayitEden,
            //////    ////////        ((islerClass)isTakipListe[i]).isYetki,
            //////    ////////        ((islerClass)isTakipListe[i]).isDetay,
            //////    ////////        ((islerClass)isTakipListe[i]).isiYapan,
            //////    ////////        ((islerClass)isTakipListe[i]).tamamlanmaTarihi,
            //////    ////////        ((islerClass)isTakipListe[i]).aciklama,
            //////    ////////        strIsiYapan,
            //////    ////////        strDuzenle);
            //////}

            //////if (dataGridView2.Rows.Count > 1)
            //////{
            //////    dataGridView2.CurrentCell.Selected = false;
            //////}
        }


        private void Form7_Load(object sender, EventArgs e)
        {
            var col1 = new DataGridViewTextBoxColumn();
            var col2 = new DataGridViewTextBoxColumn();
            var col3 = new DataGridViewTextBoxColumn();
            var col4 = new DataGridViewTextBoxColumn();
            var col5 = new DataGridViewTextBoxColumn();
            var col6 = new DataGridViewTextBoxColumn();
            var col7 = new DataGridViewTextBoxColumn();
            var col8 = new DataGridViewTextBoxColumn();
            
            col1.HeaderText = "NO";
            col1.Name = "isno";

            col2.HeaderText = "KAYIT TARİHİ";
            col2.Name = "tarih";

            col3.HeaderText = "KAYIT EDEN";
            col3.Name = "kayiteden";

            col4.HeaderText = "İŞ GRUBU";
            col4.Name = "isgrubu";

            col5.HeaderText = "  İŞ DETAYI  ";
            col5.Name = "isdetay";

            col6.HeaderText = "İŞİN SAHİBİ";
            col6.Name = "issahip";

            col7.HeaderText = "BİTİŞ TARİHİ";
            col7.Name = "tamamlamatarih";

            col8.HeaderText = "  AÇIKLAMA  ";
            col8.Name = "aciklama";

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.EnableHeadersVisualStyles = false;

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle = style;

            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { col1, col2, col3, col4, col5, col6, col7, col8 });
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (startDate.Value >= stopDate.Value)
            {
                MessageBox.Show("Başlangıç tarihi Bitiş tarihinden büyük olamaz.");
            }   
            else
            {
                
                SorguGridDoldur();
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application uyg = new Microsoft.Office.Interop.Excel.Application();
            uyg.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook kitap = uyg.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)kitap.Sheets[1];
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[1, i + 1];
                myRange.Value2 = dataGridView2.Columns[i].HeaderText;
                myRange.EntireColumn.ColumnWidth = 20;

                var boldformat = sheet1.get_Range("A1", "T1");
                var m_objfont = boldformat.Font;
                m_objfont.Bold = true;

                var verformat = sheet1.get_Range("A1", "T1");
                verformat.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                myRange.BorderAround2(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
                myRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                myRange.Borders.Weight = 1d;

            }

            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
               
                for (int j = 0; j < dataGridView2.Rows.Count; j++)
                {
                    
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];

                    if (dataGridView2[i, j].Value == null) myRange.Value2 = "";
                    else myRange.Value2 = dataGridView2[i, j].Value.ToString();
                    
                    
                    myRange.Cells.Style.WrapText = true;
                    myRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    myRange.Cells.EntireColumn.AutoFit();

                    myRange.BorderAround2(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
                    myRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    myRange.Borders.Weight = 1d;


                }
            }

            
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
