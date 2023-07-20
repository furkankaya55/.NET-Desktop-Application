using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace istakip3
{
    class DBClass
    {
        private string server;
        private string database;
        private string user;
        private string password;
        private string port;
        private string sslM;
        public string connectionString;
        public bool boolConnection = false;
        private Form4 frm4;


        internal string ConnectionStringGetir()
        {
            server = "192.168.7.174";        // local test için 
            database = "ıstakıp";
            user = "isTakipUser";
            password = "sbb_5561";
            port = "3306";
            sslM = "none";

            return string.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);
        }


        internal ArrayList BaskanlikListesiGetir(ArrayList baskanlikListesi, MySqlConnection connection)
        {
            string query = "SELECT * FROM ıstakıp.baskanlik;";

            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                BaskanlikClass baskanlikClass = new BaskanlikClass();
                baskanlikClass.baskanlikId = reader.GetInt32(0);
                baskanlikClass.baskanlikAdi = reader.GetString(1);
                baskanlikListesi.Add(baskanlikClass);
            }

            return baskanlikListesi;

        }

        internal ArrayList SubeListesiGetir(ArrayList subeListesi, MySqlConnection connection)
        {
            string query = "SELECT * FROM ıstakıp.subeler;";

            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                SubeClass subeClass = new SubeClass();
                subeClass.subeId = reader.GetInt32(0);
                subeClass.subeAdi = reader.GetString(1);
                subeClass.baskanlikId = reader.GetInt32(2);
                subeListesi.Add(subeClass);
            }

            return subeListesi;
        }

        internal string YetkiSeviyeAdiGetir(int yetkiSeviyeId, ArrayList yetkiSeviyesiListesi)
        {
            string yetkiSeviyeAdi = string.Empty;

            for (int i = 0; i < yetkiSeviyesiListesi.Count; i++)
            {
                if (yetkiSeviyeId == ((YetkiSeviyesiClass)(yetkiSeviyesiListesi[i])).yetkiSeviyesiId)
                {
                    yetkiSeviyeAdi = ((YetkiSeviyesiClass)(yetkiSeviyesiListesi[i])).yetkiSeviyesiAdi;
                    break;
                }
            }

            return yetkiSeviyeAdi.ToUpper();
        }

        internal ArrayList SeflikListesiGetir(ArrayList seflikListesi, MySqlConnection connection)
        {
            string query = "SELECT * FROM ıstakıp.seflikler;";

            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                SeflikClass seflikClass = new SeflikClass();
                seflikClass.seflikId = reader.GetInt32(0);
                seflikClass.seflikAdi = reader.GetString(1);
                seflikClass.subeId = reader.GetInt32(2);
                seflikListesi.Add(seflikClass);
            }

            return seflikListesi;
        }

        internal ArrayList YetkiSeviyesiListesiGetir(ArrayList yetkiSeviyesiListesi, MySqlConnection connection)
        {
            string query = "SELECT * FROM ıstakıp.yetkiseviyesi;";

            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                YetkiSeviyesiClass yetkiSeviyesiClass = new YetkiSeviyesiClass();
                yetkiSeviyesiClass.yetkiSeviyesiId = reader.GetInt32(0);
                yetkiSeviyesiClass.yetkiSeviyesiAdi = reader.GetString(1);
                yetkiSeviyesiListesi.Add(yetkiSeviyesiClass);
            }

            return yetkiSeviyesiListesi;
        }

        internal void yeniIsEkle(DateTime now, UserClass userClass, string selectedText, int secilenSubeId, int secilenSeflikId, MySqlConnection connection)
        {
            try
            {
                string query = string.Empty;
                string formatForMySql = now.ToString("yyyy-MM-dd HH:mm:ss");

                query = "INSERT INTO ıstakıp.isler (kayitTarihi, kayitEden, isDetay, isiYapan, tamamlanmaTarihi, aciklama, baskanlikId, subeId, seflikId, yetkiSeviyeId) VALUES ";
                query = query + "('" + formatForMySql + "', " + userClass.prsId + ", '" + selectedText + "', null, null, null, " + userClass.baskanlikId + ", " + secilenSubeId + ", " + secilenSeflikId + ", " + userClass.yetkiSeviyeId + ");";

                var cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

            }
        }

        internal void secilenIsiGuncelle(int isId, string yetkiDetay, int secilenSubeId, int secilenSeflikId, MySqlConnection connection)
        {
            try
            {
                string query = string.Empty;

                query = "UPDATE ıstakıp.isler SET subeId = " + secilenSubeId + ", seflikId = " + secilenSeflikId + ", isDetay = '" + yetkiDetay + "' WHERE isId = " + isId;
                                    
                var cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        }

        internal ArrayList isTakipListesiGetir(string query, MySqlConnection connection)
        {
            ArrayList isler = new ArrayList();
            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                islerClass isClass = new islerClass();

                isClass.isId = reader.GetInt32(0);
                isClass.kayitTarihi = reader.GetDateTime(1);
                isClass.kayitEden = reader.GetString(2);
                isClass.isDetay = reader.GetString(3);

                if (reader["isiYapan"] == DBNull.Value)
                {
                    isClass.isiYapan = "";
                }
                else
                {
                    isClass.isiYapan = reader.GetString(4);
                }

                if (reader["tamamlanmaTarihi"] == DBNull.Value)
                {
                    isClass.tamamlanmaTarihi = "";

                }
                else
                {
                    isClass.tamamlanmaTarihi = reader.GetString(5);
                }

                if (reader["aciklama"] == DBNull.Value)
                {

                    isClass.aciklama = "";
                }
                else
                {
                    isClass.aciklama = reader.GetString(6);
                }

                isClass.baskanlikId = reader.GetInt32(7);

                if (reader["subeId"] == DBNull.Value)
                {
                    isClass.subeId = -1;
                }
                else
                {
                    isClass.subeId = reader.GetInt32(8);
                }

                if (reader["seflikId"] == DBNull.Value)
                {
                    isClass.seflikId = -1;
                }
                else
                {
                    isClass.seflikId = reader.GetInt32(9);
                }

                isClass.yetkiSeviyeId = reader.GetInt32(10);

                isler.Add(isClass);
            }
            return isler;
        }


        internal UserClass KullaniciGetir(string userName, string password, MySqlConnection connection)
        {
            string query = string.Empty;

            //query = "SELECT PE.personelId, PE.personelAdi, PE.personelSoyadi, PE.kisaltma, PE.sifre, PE.baskanlikId, PE.subeId, PE.seflikId, PE.aktiflik, PE.yetkiSeviyeId, GROUP_CONCAT(PY.yetkiId SEPARATOR ',') AS yetkiler FROM aractakip.personel PE LEFT JOIN aracTakip.personelYetki PY ON PY.personelId = PE.personelId WHERE PE.kisaltma = '" + userName +"' and PE.sifre = '" + password + "'"; 

            query = "SELECT PE.personelId, CONCAT(PE.personelAdi, ' ', PE.personelSoyAdi) as personelAdSoyAd, PE.sifre, PE.kisaltma, PE.baskanlikId, PE.subeId, PE.seflikId, PE.aktiflik, PE.yetkiSeviyeId";
            query = query + " FROM ıstakıp.personel PE ";
            //query = "SELECT P.prsId, P.personelAdSoyad, P.password, P.kisaltma, YP.yetkiId, Y.yetkiAdi FROM ıstakıp.personel P ";
            //query = query + " LEFT JOIN ıstakıp.yetkipersonel YP ON YP.prsId = P.prsId";
            //query = query + " LEFT JOIN ıstakıp.yetki Y ON Y.yetkiId = YP.yetkiId";
            query = query + " WHERE PE.kisaltma = '" + userName + "' AND PE.sifre = '" + password + "'; ";


            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();

            UserClass user = new UserClass();

            while (reader.Read())
            {
                user.prsId = reader.GetInt32(0);
                user.personelAdSoyad = reader.GetString(1);
                user.sifre = reader.GetString(2);
                user.kisaltma = reader.GetString(3);
                user.baskanlikId = reader.GetInt32(4);
                user.subeId = reader.GetInt32(5);
                user.seflikId = reader.GetInt32(6);
                user.aktiflik = reader.GetBoolean(7);
                user.yetkiSeviyeId = reader.GetInt32(8);
            }
            return user;
        }
        internal string SifreDegistir(int prsId, string password, MySqlConnection connection)
        {
            try
            {
                string query = string.Empty;

                query = "UPDATE ıstakıp.personel SET sifre = '" + password + "'";
                query = query + " WHERE personelId = " + prsId + ";";

                var cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();

                return query;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        internal void isTakipListesiUpdate(int isId, int prsId, MySqlConnection connection)
        {
            try
            {
                string query = string.Empty;

                query = "UPDATE ıstakıp.isler SET isiYapan = " + prsId;
                query = query + " WHERE isId = " + isId + ";";

                var cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
        }

        internal void isTakipListesiUpdate2(int isId, int prsId, MySqlConnection connection)
        {
            try
            {
                string query = string.Empty;

                query = "UPDATE ıstakıp.isler SET isiYapan = " + prsId;
                query = query + " WHERE isId = " + isId + ";";

                var cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
        }

        internal string SubeAdiGetir(ArrayList subeListesi, int subeId)
        {
            string subeAdi = string.Empty;

            for (int i = 0; i < subeListesi.Count; i++)
            {
                if (subeId == ((SubeClass)(subeListesi[i])).subeId)
                {
                    subeAdi = ((SubeClass)(subeListesi[i])).subeAdi;
                    break;
                }
            }

            return subeAdi;
        }

        internal void isTakipListesiTamamla(int isId, string aciklama, MySqlConnection connection)
        {

            try
            {
                string query = string.Empty;
                DateTime Tarih = DateTime.Now;
                string formatForMySql = Tarih.ToString("yyyy-MM-dd HH:mm:ss");

                query = "UPDATE ıstakıp.isler ";
                query = query + "SET tamamlanmaTarihi = '" + formatForMySql + "', aciklama = '" + aciklama + "' ";
                query = query + "WHERE isId = " + isId + ";";

                var cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
        }

        internal void yeniIsEkle2(DateTime now, int prsId, int yetkiId, string yetkiDetay, MySqlConnection connection)
        {


            try
            {
                string query = string.Empty;
                string formatForMySql = now.ToString("yyyy-MM-dd HH:mm:ss");

                query = "INSERT INTO ıstakıp.subeisler (kayitTarihi2, kayitEden2, isYetki2, isDetay2, isiYapan2, tamamlanmaTarihi2) VALUES ";
                query = query + "('" + formatForMySql + "', " + prsId + ", " + yetkiId + ", '" + yetkiDetay + "', null, null );";

                var cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

            }
        }

        internal string SeflikAdiGetir(ArrayList seflikListesi, int seflikId)
        {
            string seflikAdi = string.Empty;

            for (int i = 0; i < seflikListesi.Count; i++)
            {
                if (seflikId == ((SeflikClass)(seflikListesi[i])).seflikId)
                {
                    seflikAdi = ((SeflikClass)(seflikListesi[i])).seflikAdi;
                    break;
                }
            }

            return seflikAdi;
        }
    }
}