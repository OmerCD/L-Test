using Client.M_Classes;
using Client.M_CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Client
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestSayfasi : ContentPage
	{
		public TestSayfasi ()
		{
            InitializeComponent ();
            TestGoster testGoster = new TestGoster(5, 6);
            testGoster.ControlCreation();
            ScrollView.Content= testGoster.FullStack;
            Sure.Maximum = 50;
            Sure.Minimum = 0;
            Sure.Value = 50;
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                if (Sure.Minimum == Sure.Value)
                {
                    return false;
                }
                Sure.Value--;
                return true;
            });

        }
	}
}