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
            var sure = this.FindByName<RadialProgressBar>("Sure");
            sure.Value = 60;
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                if (sure.Minimum == sure.Value)
                {
                    return false;
                }
                sure.Value--;
                return true;
            });           
           this.FindByName<ScrollView>("ScrollView").Content= testGoster.FullStack;
            
        }
	}
}