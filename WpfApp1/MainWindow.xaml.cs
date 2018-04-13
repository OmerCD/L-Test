using ltest.Classes;
using ltest.Properties;
using ltest.UserControllers;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;
using WpfApp1.Classes;
using WpfApp1.UserControllers;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        static MainWindow _main;
        public static bool durum;
        PermanentTrigger permanent = new PermanentTrigger();
        public MainWindow()
        {
            _main = this;
            InitializeComponent();

            Global.ChangeColour(Global.ToMediaColor(Settings.Default.color));

            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
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
                durum = true;
                _main.ActiveLabel.Foreground = new SolidColorBrush(Colors.DarkGreen);
                ImageBehavior.SetAnimatedSource(_main.ActiveImage, new BitmapImage(new Uri(@"/Images/online.gif", UriKind.Relative)));
                ImageBehavior.SetRepeatBehavior(_main.ActiveImage, RepeatBehavior.Forever);
                Global.genelDurum = Global.GenelDurum.OdaOnline;
            }
            else if(active=="Offline")
            {
                durum = false;
                _main.ActiveLabel.Foreground = new SolidColorBrush(Colors.Black);
                ImageBehavior.SetAnimatedSource(_main.ActiveImage, new BitmapImage(new Uri(@"/Images/offline.gif", UriKind.Relative)));
                Global.genelDurum = Global.GenelDurum.OdaOffline;
            }

        }
        private void Kapat(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void UstBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton==MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        #region Menü Buttonları       
        private void Baglangic(object sender, RoutedEventArgs e)
        {
            //permanent.ChangeStack(menuStack,(Button)sender);
            UserControlClass.ControlAdd(icerik, new UcBaslangic());
        }

        private void Testler(object sender, RoutedEventArgs e)
        {
            //permanent.ChangeStack(menuStack, (Button)sender);
            UserControlClass.ControlAdd(icerik, new UcTestler());
        }

        private void Sonuclar(object sender, RoutedEventArgs e)
        {
            //permanent.ChangeStack(menuStack, (Button)sender);
            UserControlClass.ControlAdd(icerik, new UcSonuclar());
        }

        private void Toggle(object sender, RoutedEventArgs e)
        {
            switch (sideBar.MaxWidth)
            {
                case max:
                    sideBar.MaxWidth = min;
                    break;
                default:
                    sideBar.MaxWidth = max;
                    break;
            }
        }

        private void Renkler(object sender, RoutedEventArgs e)
        {
        }


        private void Ayarlar(object sender, RoutedEventArgs e)
        {
            UserControlClass.ControlAdd(icerik, new ChangeColor());
        }
        #endregion

        private void Buyult(object sender, RoutedEventArgs e)
        {
            if (WindowState==WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
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
            UserControlClass.ControlAdd(icerik, new UcBaslangic());
            Active("Offline");

            //for (var i = 0; i < 10; i++)
            //{
            //    KullaniciStack.Children.Add(new UcGirenKullanici());
            //}
        }


        /// <summary>
        /// Her çözünürlük değişikliğinde pencere genişliğini alır ve buna göre dizaynı şekillendirir. Temel olarak 3 farklı dizayn şekli var.
        ///         
        /// Dizayn Tasarımı 1 --> min 1024px genişlik ve max yok  --> 
        /// Sol Menü 320 px - Iconlar 16px,  16 px margin var
        /// 
        /// Dizayn Tasarımı 2 --> max 1024px genişlik min 768px 
        /// Sol Menü 48 px - Iconlar 16px, 16 px Margin var
        /// 
        /// Dizayn Tasarımı 3 --> max 768px min 360px
        /// Menü Üstte taşınıyor.
        /// Sol Menü 48 px - Icon 16 px, 16 px margin var.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        const int min = 53; // +5 Margin
        const int max = 320;
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double width = ActualWidth;

            //Dizayn 1 --> Genişlik 1024'ten büyük ise
            if (width > 1024)
            {
                sideBar.MaxWidth = max;
            }
            // Dizayn 2 --> Genişlik 768'e eşit veya büyükse ve 1024'e eşit veya küçükse
            else if (width <= 1024)
            {
                sideBar.MaxWidth = min;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
