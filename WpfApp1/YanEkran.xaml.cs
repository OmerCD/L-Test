using System.Windows;
using WpfApp1.UserControllers;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for YanEkran.xaml
    /// </summary>
    public partial class YanEkran : Window
    {
        public YanEkran()
        {
            InitializeComponent();          
        }
        
        private void Kapat(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i < 10; i++)
            {
                AnaStack.Children.Add(new UcGirenKullanici());
            }
        }
    }
}
