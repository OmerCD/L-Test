using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using LTest.Classes;
using LTest.Models.EntityLayer;
using LTest.Models.FacadeLayer;
using LTest.Properties;
using LTest.Views.UserControllers.KullaniciSayfasi;
using UcSkorListesi = LTest.Views.UserControllers.KullaniciSayfasi.UcSkorListesi;

namespace LTest.Views
{
    /// <summary>
    /// Interaction logic for KullaniciSayfasi.xaml
    /// </summary>
    public partial class KullaniciSayfasi : Window
    {
        private Listener _listener;
        private readonly List<StackPanel> _stackPanels = new List<StackPanel>();

        private readonly List<UcGirenKullanici> _ucGirenKullanici = new List<UcGirenKullanici>();
        private readonly List<Kullanici> _kullanicilar = new List<Kullanici>();
        private readonly List<Client> _clients = new List<Client>();

        private readonly List<SolidColorBrush> _colors;
        private readonly List<Path> _icons;

        private UcSoru _ucSoru;
        private List<Soru> _sorular;
        private UcSkor _ucSkor;
        private Test _test;
        private byte _soruIndex;

        private const int ColumnCount = 5;
        private int _count = 0;
        private int _panel = 0;
        private readonly string _testAdi;
        public KullaniciSayfasi(string testAdi)
        {
            InitializeComponent();
            _colors = Global.Colors();
            _icons = Global.Icons();
            _testAdi = testAdi;
        }

        //public static string ByteArrayToString(byte[] ba)
        //{
        //    string hex = BitConverter.ToString(ba);
        //    return hex.Replace("-", "");
        //}

        //public static string ToAddress(string address)
        //{
        //    char[] getIp = new IPAddress(long.Parse(address, System.Globalization.NumberStyles.AllowHexSpecifier)).ToString().ToCharArray();
        //    return new string(getIp);
        //}

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Static listeler olduğu için sıfırlıyorum.
                _ucGirenKullanici.Clear();
                _clients.Clear();
                //ipRow.Height = new GridLength(128);

                // Socket İşlemleri
                _listener = new Listener(100);
                _listener.SocketAccepted += new Listener.SocketAcceptedHandler(Listener_SocketAccepted);
                _listener.Start();

                // Kullanıcıların eklenmesi için stackpanel oluşturuyorum.
                for (int i = 0; i < ColumnCount; i++)
                {
                    _stackPanels.Add(new StackPanel());
                    KullaniciGrid.Children.Add(_stackPanels[i]);
                    Grid.SetColumn(_stackPanels[i], i);
                }
            }
            catch (SocketException k)
            {
                MessageBox.Show(k.ToString());
            }

            // Ip Adresi bulup, ekrana yazdırıyorum.
            var ipv4Addresses = Array.FindAll(
                Dns.GetHostEntry(string.Empty).AddressList,
                a => a.AddressFamily == AddressFamily.InterNetwork);

            // Son ip adresini çekiyorum. Makinede virtual box ya da başka emülatör var ise onun iplerini de çekiyor. Sonuncu ip bilgisayarın ip'si.
            IpAdresi.Text += " " + ipv4Addresses[ipv4Addresses.Length - 1].ToString();

            //Eğer kullanıcı yoksa ekranda kullanıcıların beklendiğini gösteren döngü 
            while (_clients.Count < 1 && Global.GenelDurum != Global.Durum.TestBaslatildi)
            {
                await Bekle();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result= MessageBox.Show("Sayfayı Kapatırsanız, Odada Kapanacaktır. Kapatmak İstediğinizi Emin Misiniz?",
                    "Uyarı", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

            if (result==MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Global.GenelDurum = Global.Durum.OdaOffline;
                _listener.Stop();
                Anasayfa.Active("Offline");
            }
            //CustomMessageBox.Show("Merhaba Dünyalı");
        }

        #region Client İşlemleri
        void Listener_SocketAccepted(Socket e)
        {
            var rnd = new Random();
            _clients.Add(new Client(e));
            _clients[_count].Received += Client_Received;
            _clients[_count].Disconnected += (Client_Disconnected);
            Dispatcher.BeginInvoke(new Action(delegate
            {
                // TODO: Kullanıcının aldığını puanlar eklenecek.
                _kullanicilar.Add(new Kullanici());

                //Giren kullanıcıyla beraber bir UcGirenKullanici nesneyi türetiyor ve girdilerini ekliyorum.
                _ucGirenKullanici.Add(new UcGirenKullanici());
                _ucGirenKullanici[_count].Name.Text = "Bekleniyor...";
                _ucGirenKullanici[_count].EndPoint.Text = _clients[_count].GetEndPoint().ToString();
                _ucGirenKullanici[_count].Sira.Text = (_count + 1).ToString();
                _ucGirenKullanici[_count].SiraBorder.Background = _colors[rnd.Next(0, 3)];

                Info.Text = "Kullanıcı Sayısı: " + (_count + 1).ToString();

                _stackPanels[_panel].Children.Add(_ucGirenKullanici[_count]);
                _ucGirenKullanici[_count].PanelCount = _panel;
                _count++;
                _panel++;
                if (_panel == 5)
                {
                    _panel = 0;
                }
            }));
        }

        private void Client_Disconnected(Client sender)
        {
            _clients.Remove(sender);
            for (var i = 0; i < _ucGirenKullanici.Count; i++)
            {
                if (_ucGirenKullanici[i].EndPoint.Text != sender.GetEndPoint().ToString()) continue;
                _stackPanels[_ucGirenKullanici[i].PanelCount].Children.Remove(_ucGirenKullanici[i]);
                _ucGirenKullanici.RemoveAt(i);
            }
        }
        private void Client_Received(Client sender, byte[] data)
        {
            Dispatcher.BeginInvoke(new Action(delegate
            {
                for (var i = 0; i < _count; i++)
                {
                    if (_clients[i].GetId() != sender.GetId()) continue;
                    var incoming = Encoding.UTF8.GetString(data);
                    _kullanicilar[i].KullaniciAdi=_ucGirenKullanici[i].Name.Text = incoming;
                    break;
                }
            }));
        }
        #endregion

        #region Bekleniyor Yazısı
        int _k = 0;
        string _nokta = string.Empty;
        string _text = "Kullanıcılar Bekleniyor";
        async Task Bekle()
        {
            _nokta = _nokta + ".";
            Info.Text = _text + _nokta;
            _k++;
            if (_k > 10)
            {
                _k = 0;
                Info.Text = _text;
                _nokta = "";
            }
            await Task.Delay(100);
        }
        #endregion


        private void TestBaslat_Click(object sender, RoutedEventArgs e)
        {

            IpRow.Height = new GridLength(0);
            CountDownGrid.Visibility = Visibility.Visible;
            TestBaslatButton.Visibility = Visibility.Hidden;
            Global.GenelDurum = Global.Durum.TestBaslatildi;


            _test = FTest.Select(_testAdi);
            Info.Text = "Kullanıcı Sayısı: " + _count;

            _ucSoru = new UcSoru(_test.CevapSayisi);
            Sorular.Children.Add(_ucSoru);
            _sorular = FSoru.SelectAll(_test.TestId); // Tüm Sorular
            _ucSkor=new UcSkor();
            BaslangicGeriSayim();
        }

        private void SiradakiSoru_Click(object sender, RoutedEventArgs e)
        {
            SkorGoster();
        }

        private void SoruYazdir()
        {
            if (Global.GenelDurum == Global.Durum.TestBitti) return;
            SoruGeriSayim();
            var cevaplar = FCevap.SelectBySoruId(_sorular[_soruIndex].SoruId);
            _ucSoru.Soru.Text = _sorular[_soruIndex].SoruText;
            for (var i = 0; i < _ucSoru.textBlocks.Length; i++)
            {
                _ucSoru.textBlocks[i].Text = cevaplar[i].CevapText;
            }
            _soruIndex++;
        }

        #region Geri Sayımlar
        private DispatcherTimer _timer;
        private void BaslangicGeriSayim()
        {
            // Timer başlamadan süreyi yazdırdım.
            var sure = Settings.Default.BaslangicSure;
            AnimationRectangle.OpacityMask = new VisualBrush
            {
                Visual = _icons[sure]
            };
            CountDown.Content = sure;

            TimeSpan time;
            time = TimeSpan.FromSeconds(sure);
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                time = time.Add(TimeSpan.FromSeconds(-1));
                CountDown.Content = time.Seconds;
                if (time.Seconds < 0)
                {
                    _timer.Stop();
                    CountDownGrid.Visibility = Visibility.Hidden;
                    SonrakiSoru.Visibility = Visibility.Visible;
                    SoruYazdir();
                }
                else
                {
                    AnimationRectangle.OpacityMask = new VisualBrush
                    {
                        Visual = _icons[time.Seconds]
                    };
                    AnimationRectangle.Fill = _colors[time.Seconds];
                }
            }, Application.Current.Dispatcher);
            _timer.Start();
        }

        private void SoruGeriSayim()
        {
            if (_timer != null)
            {
                if (_timer.IsEnabled)
                {
                    _timer.Stop();
                }
            }
            _ucSoru.SureProgress.Maximum = _test.Sure;
            var time = TimeSpan.FromSeconds(_test.Sure);
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                _ucSoru.SureProgress.Value = time.Seconds;
                if (time.Seconds == 0)
                {
                    _timer.Stop();
                    SkorGoster();
                }
                time = time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            _timer.Start();
        }

        private DispatcherTimer _timerSkor;
        private void SkorGoster()
        {
            TimeSpan time;
            SonrakiSoru.Visibility = Visibility.Hidden;
            Info.Visibility = Visibility.Hidden;
            if (_soruIndex >= _sorular.Count)
            {
                Global.GenelDurum = Global.Durum.TestBitti;
                Sorular.Children.Clear();
                Sorular.Children.Add(new UcSkorListesi());
            }
            else
            {
                Sorular.Children.Clear();
                Sorular.Children.Add(_ucSkor);
                time = TimeSpan.FromSeconds(Settings.Default.SkorSure);
                _timerSkor = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    if (time.Seconds == 0)
                    {
                        _timerSkor.Stop();
                        SonrakiSoru.Visibility = Visibility.Visible;
                        Info.Visibility = Visibility.Visible;
                        Sorular.Children.Clear();
                        Sorular.Children.Add(_ucSoru);
                        SoruYazdir();
                    }
                    time = time.Add(TimeSpan.FromSeconds(-1));
                }, Application.Current.Dispatcher);
                _timerSkor.Start();
            }
        }

        #endregion
    }
}
