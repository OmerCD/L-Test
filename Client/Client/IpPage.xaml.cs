using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Client
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IpPage : ContentPage
	{
		public IpPage ()
		{
			InitializeComponent ();
        }
        public static Socket ClientSocket;
        private void Giris_Clicked(object sender, EventArgs e)
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string ip = Ip.Text;
            for (int i = 0; i < 10; i++)
            {
                if (!ClientSocket.Connected)
                {
                    try
                    {
                        ClientSocket.Connect(ip, 100);
                    }
                    catch (SocketException)
                    {
                        Durum.Text = i.ToString() + ". bağlantı denemesi";
                    }
                }
            }
            if (ClientSocket.Connected)
            {
                Navigation.PushModalAsync(new NamePage());
            }
        }
    }
}