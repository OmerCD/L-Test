using System.Windows;
using System.Windows.Input;
using WpfApp1.Classes;
using WpfApp1.UserControllers;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public YanEkran YanEkran;
        public MainWindow()
        {
            InitializeComponent();
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            YanEkran= new YanEkran();
            YanEkran.Show();
            DatabaseManager.CreateDatabase();
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
                YanEkran.Left = loc.X-YanEkran.Width;
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

        private void Ayarlar(object sender, RoutedEventArgs e)
        {
            UserControlClass.ControlAdd(icerik, new UcBaslangic());
        }

        private void Buyult(object sender, RoutedEventArgs e)
        {
            if (WindowState==WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                anaGrid.Margin = new Thickness(0,0,0,7); // Niye büyüyünce Kenarlardan taşıyor? Entrasan bir sorun. Düzeltmek için eklendi
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

        private void anaGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var loc = PointToScreen(new Point(0, 0));
            YanEkran.Left = loc.X - YanEkran.Width;
            YanEkran.Top = loc.Y;
            UserControlClass.ControlAdd(icerik, new UcBaslangic());
        }
    }
}
