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
        public Brush DarkColour(Ellipse item)
        {
            var renk = (SolidColorBrush)item.Fill;
            var r = renk.Color.R-60;
            var g = renk.Color.G-60;
            var b = renk.Color.B-60;
            var yeniRenk = new SolidColorBrush(Color.FromArgb(255, (byte)r, (byte)g, (byte)b));
            return yeniRenk;
        }
        public Brush DarkColourAnimasyon(Ellipse item)
        {
            var renk = (SolidColorBrush)item.Fill;
            var r = renk.Color.R - 30;
            var g = renk.Color.G + 30;
            var b = renk.Color.B + 30;
            var yeniRenk = new SolidColorBrush(Color.FromArgb(255, (byte)r, (byte)g, (byte)b));
            return yeniRenk;
        }


        public Brush MediumColour(Ellipse item)
        {
            var renk = (SolidColorBrush)item.Fill;
            var r = renk.Color.R - 30;
            var g = renk.Color.G - 30;
            var b = renk.Color.B - 30;
            var yeniRenk = new SolidColorBrush(Color.FromArgb(255, (byte)r, (byte)g, (byte)b));
            return yeniRenk;
        }
        public Brush MediumColourAnimasyon(Ellipse item)
        {
            var renk = (SolidColorBrush)item.Fill;
            var r = renk.Color.R - 15;
            var g = renk.Color.G - 15;
            var b = renk.Color.B - 15;
            var yeniRenk = new SolidColorBrush(Color.FromArgb(255, (byte)r, (byte)g, (byte)b));
            return yeniRenk;
        }

        public Brush LightColour(Ellipse item)
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
