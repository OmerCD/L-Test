using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes.EntityLayer
{
    class Kullanicilar
    {
        private int _kullanici_id;
        public int kullanici_id
        {
            get => _kullanici_id;
            set => _kullanici_id = value;
        }

        private string _kullanici_adi;
        public string kullanici_adi
        {
            get => _kullanici_adi;
            set => _kullanici_adi= value;
        }

    }
}
