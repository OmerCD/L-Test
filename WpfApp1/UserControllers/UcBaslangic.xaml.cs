using System.Windows;
using System.Windows.Controls;
using WpfApp1.Classes;

namespace WpfApp1
{
    /// <summary>
    /// ucBaslangic.xaml etkileşim mantığı
    /// </summary>
    public partial class UcBaslangic : UserControl
    {
        public UcBaslangic()
        {
            InitializeComponent();
        }
        private void OdayiOlustur(object sender, RoutedEventArgs e)
        {
            var sunucu = new Server();
            sunucu.StartServer(3333);
        }
    }
}
