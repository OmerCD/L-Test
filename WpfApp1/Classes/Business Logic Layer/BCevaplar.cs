using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Classes.EntityLayer;
using WpfApp1.Classes.FacedeLayer;

namespace WpfApp1.Classes.Business_Logic_Layer
{
    class BCevaplar
    {
        public static List<Cevaplar> SelectAll(int soruId)
        {
            return FCevaplar.SelectAll(soruId);
        }
        public static int Insert(Cevaplar item)
        {
            return FCevaplar.Insert(item);
        }
    }
}
