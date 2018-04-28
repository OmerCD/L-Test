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
            string ip = Ip.Text;
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IAsyncResult result = ClientSocket.BeginConnect(ip, 100,null,null);
            bool success = result.AsyncWaitHandle.WaitOne(5000, true);
            if (!ClientSocket.Connected)
            {
                ClientSocket.Close();
                Durum.Text = "Bağlantı Başarısız.";
            }
            else
            {
                ClientSocket.EndConnect(result);
                Navigation.PushModalAsync(new NamePage());
            }
        }
    }
}