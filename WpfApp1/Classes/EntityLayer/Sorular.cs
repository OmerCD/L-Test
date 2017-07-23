using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes.EntityLayer
{
    class Sorular
    {
        private int _soru_id;
        public int soru_id
        {
            get => _soru_id;
            set => _soru_id = value;
        }

        private int _test_id;
        public int test_id
        {
            get => _test_id;
            set => _test_id = value;
        }

        private string _soru;
        public string soru
        {
            get => _soru;
            set => _soru = value;
        }
    }
}
