using ltest.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Drawing;

namespace ltest.Classes
{
    public static class Global
    {
        private static GenelDurum _genelDurum;
        public enum GenelDurum
        {
            OdaOffline,
            OdaOnline,
            TestBaslatildi,
            TestBitirildi,
        };

        public static GenelDurum genelDurum { get => _genelDurum; set => _genelDurum = value; }

        public static void ChangeColour(SolidColorBrush solidColor)
        {
            
            Settings.Default.color = ToDrawingColor(solidColor);

            //SolidColorBrush a = ToMediaColor(Settings.Default.color);


            Application.Current.Resources["FireBrick"] = solidColor;
            Application.Current.Resources["FireBrickAnimation"] = solidColor;

            Application.Current.Resources["FireBrickMedium"] = solidColor;
            Application.Current.Resources["FireBrickMediumAnimation"] = solidColor;

            Application.Current.Resources["FireBrickSoft"] = solidColor;
            Application.Current.Resources["FireBrickSoftAnimation"] = solidColor;
        }

        public static System.Windows.Media.SolidColorBrush ToMediaColor(System.Drawing.Color color)
        {
            return new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
        }

        public static System.Drawing.Color ToDrawingColor(SolidColorBrush color)
        {
            return System.Drawing.Color.FromArgb(color.Color.A, color.Color.R, color.Color.G, color.Color.B);
        }
    }
}
