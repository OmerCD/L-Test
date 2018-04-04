using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Client
{

	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            MainPage= new NavigationPage(new IpPage());

        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
            IpPage.ClientSocket?.Send(Encoding.UTF8.GetBytes("Disconnected"));
            IpPage.ClientSocket?.Close();
		}

		protected override void OnResume ()
		{
            MainPage = new NavigationPage(new IpPage());
        }
    }
}
