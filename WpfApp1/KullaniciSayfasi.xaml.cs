using ltest.UserControllers.UcBaslangic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1;
using WpfApp1.Classes;
using WpfApp1.UserControllers;
using System.Net.Sockets;

namespace ltest
{
    /// <summary>
    /// Interaction logic for KullaniciSayfasi.xaml
    /// </summary>
    public partial class KullaniciSayfasi : Window
    {
        public KullaniciSayfasi()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IPAddress[] ipv4Addresses = Array.FindAll(
                Dns.GetHostEntry(string.Empty).AddressList,
                a => a.AddressFamily == AddressFamily.InterNetwork);
            foreach (var item in ipv4Addresses)
            {
                ipadresi.Text = ipadresi.Text + " " + item;
            }
            while (adim1.Clients.Count<1)
            {
                await Bekle();
            }
        }
        int _k = 0;
        string _nokta=string.Empty;
        string _text = "Kullanıcılar Bekleniyor";
        public async Task Bekle()
        {
            _nokta = _nokta + ".";
            info.Text = _text + _nokta;
            _k++;
            if (_k>10)
            {
                _k = 0;
                info.Text = _text;
                _nokta = "";
            }
            await Task.Delay(100);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            if (MessageBox.Show("Sayfayı Kapatırsanız, Odada Kapanacaktır. Kapatmak İstediğinizi Emin Misiniz?", "Uyarı", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No)==MessageBoxResult.Yes)
            {
                this.Visibility = Visibility.Hidden;
                adim1.Listener.Stop();
                MainWindow.Active("Offline");
            }
        }
    }
}
