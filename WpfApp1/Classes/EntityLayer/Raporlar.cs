using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes.EntityLayer
{
    class Raporlar
    {
        private int _rapor_id;
        public int rapor_id
        {
            get => _rapor_id;
            set => _rapor_id = value;
        }

        private int _test_id;
        public int test_id
        {
            get => _test_id;
            set => _test_id = value;
        }

        private int _kullanici_id;
        public int kullanici_id
        {
            get => _kullanici_id;
            set => _kullanici_id = value;
        }

        private int _dogru_sayisi;
        public int dogru_sayisi
        {
            get => _dogru_sayisi;
            set => _dogru_sayisi = value;
        }

        private int _yanlis_sayisi;
        public int yanlis_sayisi
        {
            get => _yanlis_sayisi;
            set => _yanlis_sayisi = value;
        }
    }
}
