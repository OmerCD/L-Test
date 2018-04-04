using ltest.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1;
using WpfApp1.Classes;
using WpfApp1.UserControllers;

namespace ltest.UserControllers.UcBaslangic
{
    /// <summary>
    /// Interaction logic for adim1.xaml
    /// </summary>
    public partial class adim1 : UserControl
    {
        public adim1()
        {
            InitializeComponent();
            GetColors();
        }
        public static Listener Listener;
        KullaniciSayfasi kullaniciSayfasi;
        List<StackPanel> stackPanels = new List<StackPanel>();
        public static List<UcGirenKullanici> User = new List<UcGirenKullanici>();
        public static List<Client> Clients = new List<Client>();
        List<SolidColorBrush> colors = new List<SolidColorBrush>();

        const int columnCount = 5;
        int count = 0;
        int panel = 0;
        Random rnd = new Random();

        private void OdayiOlustur(object sender, RoutedEventArgs e)
        {
            try
            {
                stackPanels.Clear();
                User.Clear();
                Clients.Clear();
                Listener = new Listener(100);
                Listener.SocketAccepted += new Listener.SocketAcceptedHandler(Listener_SocketAccepted);
                Listener.Start();
                MainWindow.Active("Online");
                MainWindow.Durum("Oda Oluşturuldu");
                if (kullaniciSayfasi==null)
                {
                    kullaniciSayfasi = new KullaniciSayfasi();
                    kullaniciSayfasi.Show();
                }
                kullaniciSayfasi.Visibility = Visibility.Visible;



                kullaniciSayfasi.Sorular.Children.Add(new UcSoru(12));



                for (int i = 0; i < columnCount; i++)
                {
                    stackPanels.Add(new StackPanel());
                    kullaniciSayfasi.Kullanicilar.Children.Add(stackPanels[i]);
                    Grid.SetColumn(stackPanels[i], i);
                }
            }
            catch (SocketException k)
            {
                MessageBox.Show(k.ToString());
            }
        }

        void GetColors()
        {
            colors.Add((SolidColorBrush)FindResource("Alizarin Crimson"));
            colors.Add((SolidColorBrush)FindResource("Aqua Forest"));
            colors.Add((SolidColorBrush)FindResource("Barberry"));
            colors.Add((SolidColorBrush)FindResource("Blaze Orange"));
        }

        void Listener_SocketAccepted(Socket e)
        {
            Clients.Add(new Client(e));
            Clients[count].Received += new Client.ClientReceivedHandler(Client_Received);
            Clients[count].Disconnected += (Client_Disconnected);
            Dispatcher.BeginInvoke(new Action(delegate
            {
                User.Add(new UcGirenKullanici());
                User[count].Name.Text = "Bekleniyor...";
                User[count].Status.Text = Clients[count].GetEndPoint().ToString();
                User[count].Sira.Text = (count + 1).ToString();
                User[count].SiraBorder.Background = colors[rnd.Next(0, 3)];
                
                kullaniciSayfasi.info.Text = "Kullanıcı Sayısı: " + (count + 1).ToString();

                stackPanels[panel].Children.Add(User[count]);
                User[count].PanelCount = panel;
                count++;
                panel++;
                if (panel > 5)
                {
                    panel = 0;
                }
            }));
        }

        private void Client_Disconnected(Client sender)
        {
            Clients.Remove(sender);
            for (int i = 0; i < User.Count; i++)
            {
                if (User[i].Status.Text == sender.GetEndPoint().ToString())
                {
                    stackPanels[User[i].PanelCount].Children.Remove(User[i]);
                    User.RemoveAt(i);
                }
            }
            //Dispatcher.BeginInvoke(new Action(delegate
            //{
            //    for (int i = 0; i < count; i++)
            //    {
            //        //Şimdilik BOŞ
            //    }
            //}
            //));
        }
        private void Client_Received(Client sender, byte[] data)
        {
            Dispatcher.BeginInvoke(new Action(delegate
            {
                for (int i = 0; i < count; i++)
                {
                    if (Clients[i].GetId() == sender.GetId())
                    {
                        var incoming = Encoding.UTF8.GetString(data);
                        //if (incoming == "Biz çıktık")
                        //{
                        //    Client_Disconnected(sender);
                        //    break;
                        //}
                        User[i].Name.Text = incoming;

                        break;
                    }
                }
            }));
        }

        private void KullaniciGoster(object sender, RoutedEventArgs e)
        {
            if (MainWindow.durum)
            {
                kullaniciSayfasi.Visibility = Visibility.Visible;
            }
        }
    }
}
