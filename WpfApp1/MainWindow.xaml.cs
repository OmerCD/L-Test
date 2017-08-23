using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using WpfApp1.Classes;
using WpfApp1.UserControllers;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MainWindow _main;
        public YanEkran YanEkran;
        public MainWindow()
        {
            _main = this;
            InitializeComponent();
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            YanEkran= new YanEkran();
            YanEkran.Show();
            DatabaseManager.CreateDatabase();
        }
        public static void Durum(string drm)
        {
            _main.DurumLabel.Content = drm;
        }
        public static void Active(string active)
        {
            _main.ActiveLabel.Content = active;
            if (active=="Online")
            {
                _main.ActiveImage.Source = new BitmapImage(new Uri(@"/Images/Online.png", UriKind.Relative));
            }
            else if (active == "Abandoned")
            {
                _main.ActiveImage.Source = new BitmapImage(new Uri(@"/Images/Abandoned.png", UriKind.Relative));
            }
            else
            {
                _main.ActiveImage.Source = new BitmapImage(new Uri(@"/Images/Offline.png", UriKind.Relative));
            }
        }
        private void Kapat(object sender, RoutedEventArgs e)
        {
            Close();
            YanEkran.Close();
        }
        private void UstBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton==MouseButtonState.Pressed)
            {
                DragMove();
                var loc = PointToScreen(new Point(0, 0));
                YanEkran.Left = loc.X-YanEkran.Width-5;
                YanEkran.Top = loc.Y;
            }
        }

        private void Baglangic(object sender, RoutedEventArgs e)
        {
            UserControlClass.ControlAdd(icerik, new UcBaslangic());
        }

        private void Testler(object sender, RoutedEventArgs e)
        {
            UserControlClass.ControlAdd(icerik, new UcTestler());
        }
        private void Buyult(object sender, RoutedEventArgs e)
        {
            if (WindowState==WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                //AnaGrid.Margin = new Thickness(0,0,0,7); // Niye büyüyünce Kenarlardan taşıyor? Entrasan bir sorun. Düzeltmek için eklendi
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }
        private void Simge(object sender, RoutedEventArgs e)
        {
           WindowState = WindowState.Minimized;
        }

        private void AnaGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var loc = PointToScreen(new Point(0, 0));
            YanEkran.Left = loc.X - YanEkran.Width-5;
            YanEkran.Top = loc.Y;
            UserControlClass.ControlAdd(icerik, new UcBaslangic());
            Active("Offline");
        }

        private void Sonuclar(object sender, RoutedEventArgs e)
        {
            UserControlClass.ControlAdd(icerik, new UcSonuclar());
        }

        private void Colors(object sender, RoutedEventArgs e)
        {
            var blurEffect = new BlurEffect {Radius = 5.0};
            Effect = blurEffect;
            YanEkran.Effect = blurEffect;
            var colors = new Colors();
            colors.ShowDialog();
        }
    }
}
