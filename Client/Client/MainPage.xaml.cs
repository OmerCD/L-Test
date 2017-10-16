using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Client
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void Giris_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new TestSayfasi();
        }
    }
}
