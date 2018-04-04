using System.Collections.Generic;
using WpfApp1.Classes.EntityLayer;
using WpfApp1.Classes.FacedeLayer;

namespace WpfApp1.Classes.Business_Logic_Layer
{
    class BTestler
    {
        public static int Insert(Testler item)
        {
            // Stringler için null ve trim ardından length kontrolü, integer için 0'dan büyük kontrolü yeterli.
            if (item.TestAdi != null && item.TestAdi.Trim().Length > 0 && item.CevapSayisi > 0 && item.SoruSayisi > 0 && item.Sure > 0)
            {
                return FTestler.Insert(item);
            }
            return -1;
        }

        public static int Update(Testler item)
        {
            if (item.TestAdi != null && item.TestAdi.Trim().Length > 0 && item.CevapSayisi > 0 && item.SoruSayisi > 0 && item.Sure > 0 && item.TestId > 0)
            {
                return FTestler.Update(item);
            }
            return -1;
        }

        public static int Delete(int testId)
        {
            return testId > 0 ? FTestler.Delete(testId) : -1;
        }

        public static Testler Select(string testId)
        {
            return FTestler.Select(testId);
        }

        public static List<Testler> SelectAll()
        {
            return FTestler.SelectAll();
        }
    }
}
