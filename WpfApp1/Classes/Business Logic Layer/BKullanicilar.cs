using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Classes.EntityLayer;
using WpfApp1.Classes.FacedeLayer;

namespace WpfApp1.Classes.Business_Logic_Layer
{
    class BKullanicilar
    {
        public static int Insert(Kullanicilar item)
        {
            if (item.KullaniciAdi != null && item.KullaniciAdi.Trim().Length > 0 && item.KullaniciId > 0)
            {
                return FKullanicilar.Insert(item);
            }
            return -1;
        }

        public static int Update(Kullanicilar item)
        {
            if (item.KullaniciAdi != null && item.KullaniciAdi.Trim().Length > 0 && item.KullaniciId > 0)
            {
                return FKullanicilar.Update(item);
            }
            return -1;
        }

        public static int Delete(int kullaniciId)
        {
            if (kullaniciId > 0)
            {
                return FKullanicilar.Delete(kullaniciId);
            }
            return -1;
        }


        public static Kullanicilar Select(int kullaniciId)
        {
            if (kullaniciId > 0)
            {
                return FKullanicilar.Select(kullaniciId);
            }
            return null;
        }

        public static List<Kullanicilar> SelectAll()
        {
            return FKullanicilar.SelectAll();

        }
    }
}
