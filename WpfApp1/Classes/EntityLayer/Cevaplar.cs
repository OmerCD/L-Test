using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes.EntityLayer
{
    class Cevaplar
    {
        private int _cevap_id;
        public int cevap_id
        {
            get => _cevap_id;
            set => _cevap_id = value;
        }

        private int _soru_id;
        public int soru_id
        {
            get => _soru_id;
            set => _soru_id = value;
        }

        private string _cevap;
        public string cevap
        {
            get => _cevap;
            set => _cevap = value;
        }

        private int _dogru;
        public int dogru
        {
            get => _dogru;
            set => _dogru = value;
        }
    }
}
