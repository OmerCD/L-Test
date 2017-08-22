using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Classes;
using WpfApp1.UserControllers;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Colors.xaml
    /// </summary>
    public partial class Colors : Window
    {
        public Colors()
        {
            InitializeComponent();
        }

        private void ChangeColour(object sender, MouseButtonEventArgs e)
        {
            var ellipse = (Ellipse)e.Source;
            Application.Current.Resources["DarkColor"] = new ColorPallet().DarkColour(ellipse);
            Application.Current.Resources["DarkColorAnimasyon"] = new ColorPallet().DarkColour(ellipse);

            Application.Current.Resources["MediumColor"] = new ColorPallet().MediumColour(ellipse);
            Application.Current.Resources["MediumColorAnimasyon"] = new ColorPallet().MediumColour(ellipse);;

            MainWindow.Durum(ellipse.Name);
                //foreach (Window window in Application.Current.Windows)
                //{
                //    if (window.GetType() != typeof(MainWindow)) continue;
                //    ((MainWindow)window).UstBorder.Background = new ColorPallet().DarkColour(ellipse);
                //    ((MainWindow)window).UstBorderAlt.Background = new ColorPallet().MediumColour(ellipse);
                //    ((MainWindow) window).AltBorder.Background = new ColorPallet().MediumColour(ellipse);
                //    ((MainWindow)window).YanEkran.YanUstBorder.Background = new ColorPallet().DarkColour(ellipse);
                //    ((MainWindow)window).YanEkran.TextBlock.Background = new ColorPallet().MediumColour(ellipse);
                //}
        }

        private void Kapat(object sender, RoutedEventArgs e)
        {
            var blurEffect = new BlurEffect {Radius = 0.0};
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() != typeof(MainWindow)) continue;
                ((MainWindow)window).Effect = blurEffect;
            }
            Close();
        }
    }
}
