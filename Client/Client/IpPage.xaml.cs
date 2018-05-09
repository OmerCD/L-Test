using System;
using System.Net.Sockets;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LTest.Classes;

namespace Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IpPage : ContentPage
	{
        public static Socket Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public IpPage ()
		{
			InitializeComponent ();
        }
        private void Giris_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Ip.Text))
            {
                int deneme = 0;
                string ip = Ip.Text;
                while (!Socket.Connected)
                {
                    try
                    {
                        deneme++;
                        Socket.Connect(ip, 100);
                        Navigation.PushModalAsync(new NamePage());

                    }
                    catch (SocketException)
                    {
                        Info.Text = "Ağa " + deneme.ToString() + " defa bağlanılmaya çalışıldı ama bağlanamadı";
                    }
                }

            }
        }
    }
}