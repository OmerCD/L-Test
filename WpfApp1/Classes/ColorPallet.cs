using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp1.Classes
{
    class ColorPallet
    {
        public Brush DarkColor(Ellipse item)
        {
            var renk = (SolidColorBrush)item.Fill;
            var r = renk.Color.R-60;
            var g = renk.Color.G-60;
            var b = renk.Color.B-60;
            var yeniRenk = new SolidColorBrush(Color.FromArgb(255, (byte)r, (byte)g, (byte)b));
            return yeniRenk;
        }
        public Brush DarkColorAnimasyon(Ellipse item)
        {
            var renk = (SolidColorBrush)item.Fill;
            var r = renk.Color.R - 30;
            var g = renk.Color.G - 30;
            var b = renk.Color.B - 30;
            var yeniRenk = new SolidColorBrush(Color.FromArgb(255, (byte)r, (byte)g, (byte)b));
            return yeniRenk;
        }


        public Brush MediumColor(Ellipse item)
        {
            var renk = (SolidColorBrush)item.Fill;
            var r = renk.Color.R - 20;
            var g = renk.Color.G - 20;
            var b = renk.Color.B - 20;
            var yeniRenk = new SolidColorBrush(Color.FromArgb(255, (byte)r, (byte)g, (byte)b));
            return yeniRenk;
        }
        public Brush MediumColorAnimasyon(Ellipse item)
        {
            var renk = (SolidColorBrush)item.Fill;
            var r = renk.Color.R - 10;
            var g = renk.Color.G - 10;
            var b = renk.Color.B - 10;
            var yeniRenk = new SolidColorBrush(Color.FromArgb(255, (byte)r, (byte)g, (byte)b));
            return yeniRenk;
        }

        public Brush SoftColor(Ellipse item)
        {
            var renk = (SolidColorBrush)item.Fill;
            var r = renk.Color.R;
            var g = renk.Color.G;
            var b = renk.Color.B;
            var yeniRenk = new SolidColorBrush(Color.FromArgb(255, (byte)r, (byte)g, (byte)b));
            return yeniRenk;
        }
    }
}
