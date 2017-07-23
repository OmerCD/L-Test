using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes
{
    class Testler
    {
        private int _test_id;
        public int test_id
        {
            get => _test_id;
            set => _test_id = value;
        }

        private int _sure;
        public int sure
        {
            get => _sure;
            set => _sure = value;
        }

        private int _soru_sayisi;
        public int soru_sayisi
        {
            get => _soru_sayisi;
            set => _soru_sayisi = value;
        }

        private int _cevap_sayisi;
        public int cevap_sayisi
        {
            get => _cevap_sayisi;
            set => _cevap_sayisi = value;
        }

        private string _test_adi;
        public string test_adi
        {
            get => _test_adi;
            set => _test_adi = value;
        }
    }
}
