using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Classes.EntityLayer;
using WpfApp1.Classes.FacedeLayer;

namespace WpfApp1.Classes.Business_Logic_Layer
{
    class BSorular
    {
        public static List<Sorular> SelectAll(int testId)
        {
            return FSorular.SelectAll(testId);
        }
    }
}
