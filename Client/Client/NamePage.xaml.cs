using System;
using Xamarin.Forms;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Client
{
    public partial class NamePage : ContentPage
	{
		public NamePage()
		{
			InitializeComponent();
        }

        private void SendName_Clicked(object sender, EventArgs e)
        {
            int s=IpPage.ClientSocket.Send(Encoding.UTF8.GetBytes(Name.Text));
        }

        /*
         IpPage.ClientSocket.Close();
         IpPage.ClientSocket.Dispose();
         */
    }
}
