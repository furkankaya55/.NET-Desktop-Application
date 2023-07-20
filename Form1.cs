
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace istakip3
{
    public partial class Form1 : Form
    {
        private DBClass dBClass = new DBClass();
        public MySqlConnection connection;
        public UserClass userClass;
        public islerClass secilenIslerClass;
        public string ipAdres = string.Empty;

        public Form1()
        {
            InitializeComponent();

        }
        public string eskisifregonder;
        public string kullaniciadigonder;
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.CharacterCasing = CharacterCasing.Upper;
            timerLogin.Enabled = true;

        }
        public bool DbReconnect()
        {

            if (connection.State == ConnectionState.Open)

            {
                connection.Close();
            }



            try
            {
                connection.Open();
                return true;
            }

            catch (Exception)
            {
                return false;
            }

        }
        private void timerLogin_Tick(object sender, EventArgs e)
        {
            timerLogin.Enabled = false;
            dBClass.connectionString = dBClass.ConnectionStringGetir();
            connection = new MySqlConnection(dBClass.connectionString);
            dBClass.boolConnection = DbReconnect();

            if (dBClass.boolConnection)
            {
                timerLogin.Enabled = false;
                ipAdres = GetComputerIPAddress();
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button2.Enabled = true;
                button1.Enabled = true;
                textBox1.Focus();
            }

            else
            {
                timerLogin.Interval = 10000;
                timerLogin.Enabled = true;
                MessageBox.Show("Veritabanı Bağlantısı Kurulamadı... \r\n Lütfen Uygulamayı Kapatıp Tekrar Deneyin... \r\n Bağlantı Sorunu Tekrarlarsa Sistem Yöneticisine Haber Veriniz... ");

            }

        }
        private string GetComputerIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }


        private bool verileriKontrolEt()
        {
            if (textBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Kullanıcı Adı Boş Olamaz...");
                return false;
            }

            else if (textBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Şifre Boş Olamaz...");
                return false;
            }

            else
            {
                return true;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            bool checkPageData = verileriKontrolEt();

            if (checkPageData)
            {
                bool boolConnection = DbReconnect();

                if (boolConnection)
                {

                    userClass = null;
                    userClass = new UserClass();
                    userClass = dBClass.KullaniciGetir(textBox1.Text.Trim(), textBox2.Text.Trim(), connection);
                    

                    if (userClass.prsId == 0)
                    {
                        MessageBox.Show("Kullanıcı Adı ve Şifresi Uyumsuz...");
                    }
                    else
                    {
                        boolConnection = DbReconnect();

                        if (boolConnection)
                        {
                            Form2 changePassword = new Form2(this);
                            eskisifregonder = textBox2.Text;
                            kullaniciadigonder = textBox1.Text;
                            changePassword.Show();
                            Hide();
                        }

                    }
                }
            }
            //bool checkPageData = verileriKontrolEt();

            //if (checkPageData)
            //{
            //    bool boolConnection = DbReconnect();

            //    if (boolConnection)
            //    {
            //        if (userClass == null)
            //        {

            //            userClass = new UserClass();
            //            userClass = dBClass.KullaniciGetir(textBox1.Text.Trim(), textBox2.Text.Trim(), connection);

            //        }


            //        if (userClass.prsId == 0)
            //        {
            //            MessageBox.Show("Kullanıcı Adı ve Şifresi Uyumsuz...");

            //        }
            //        else
            //        {
            //            boolConnection = DbReconnect();

            //            if (boolConnection)
            //            {
            //                Form2 changePassword = new Form2(this);
            //                eskisifregonder = textBox2.Text;
            //                kullaniciadigonder = textBox1.Text;
            //                changePassword.Show();
            //                Hide();
            //            }
            //        }
            //    }
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool checkPageData = verileriKontrolEt();

            if (checkPageData)
            {
                bool boolConnection = DbReconnect();

                if (boolConnection)
                {
                   
                    userClass = null;
                    userClass = new UserClass();
                    userClass = dBClass.KullaniciGetir(textBox1.Text.Trim(), textBox2.Text.Trim(), connection);
                    

                    if (userClass.prsId == 0)
                    {
                        MessageBox.Show("Kullanıcı Adı ve Şifresi Uyumsuz...");
                    }
                    else
                    {

                        if (userClass.sifre == "12345678")
                        {
                            Form2 changePassword = new Form2(this);
                            eskisifregonder = textBox2.Text;
                            kullaniciadigonder = textBox1.Text;
                            changePassword.Show();
                            Hide();
                        }
                        else
                        {
                            boolConnection = DbReconnect();

                            if (boolConnection)
                            {
                                Form4 frm4 = new Form4(this, userClass);
                                frm4.Show();
                                Hide();
                            }
                        }
                    }
                }
            }
        }
    }
}