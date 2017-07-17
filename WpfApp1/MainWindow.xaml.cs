using System.Windows;
using System.Windows.Input;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public YanEkran yanEkran;
        public MainWindow()
        {
            InitializeComponent();
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            yanEkran= new YanEkran();
            yanEkran.Show();
        }
        private void Kapat(object sender, RoutedEventArgs e)
        {
            this.Close();
            yanEkran.Close();
        }
        private void UstBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton==MouseButtonState.Pressed)
            {
                this.DragMove();
                var loc = this.PointToScreen(new Point(0, 0));
                yanEkran.Left = loc.X-yanEkran.Width;
                yanEkran.Top = loc.Y;
            }
        }

        private void Baglangic(object sender, RoutedEventArgs e)
        {
            Classes.UserControlClass.ControlAdd(icerik, new ucBaslangic());
        }

        private void Testler(object sender, RoutedEventArgs e)
        {
            Classes.UserControlClass.ControlAdd(icerik, new UserControllers.UcTestler());
        }

        private void Ayarlar(object sender, RoutedEventArgs e)
        {
            Classes.UserControlClass.ControlAdd(icerik, new ucBaslangic());
        }

        private void Buyult(object sender, RoutedEventArgs e)
        {
            if (this.WindowState==WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                anaGrid.Margin = new Thickness(0,0,0,7); // Niye büyüyünce Kenarlardan taşıyor? Entrasan bir sorun. Düzeltmek için eklendi
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
        private void Simge(object sender, RoutedEventArgs e)
        {
           this.WindowState = WindowState.Minimized;
        }

        private void anaGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var loc = this.PointToScreen(new Point(0, 0));
            yanEkran.Left = loc.X - yanEkran.Width;
            yanEkran.Top = loc.Y;
            Classes.UserControlClass.ControlAdd(icerik, new ucBaslangic());
        }
    }
}
