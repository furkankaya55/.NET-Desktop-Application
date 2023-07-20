using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace istakip3
{
    public class UserClass
    {
        public int prsId { get; set; }
        public string personelAdSoyad { get; set; }
        public string kisaltma { get; set; }
        public string sifre { get; set; }
        public int baskanlikId { get; set; }
        public int subeId { get; set; }
        public int seflikId { get; set; }
        public bool aktiflik { get; set; }
        public int yetkiSeviyeId { get; set; }
    }
}
