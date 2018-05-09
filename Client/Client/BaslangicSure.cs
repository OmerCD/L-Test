using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Client
{
	public class BaslangicSure : ContentPage
	{
        private Label label = new Label
        {
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions=LayoutOptions.Center,
            FontSize= Device.GetNamedSize(NamedSize.Medium, typeof(Label))
        };
        public BaslangicSure (Sure sure)
		{
            Content = new StackLayout {
				Children = {
                    label,
				}
			};

            sure.BaslangicSure -= 1;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                label.Text = "Lütfen bekleyin " + sure.BaslangicSure + " saniye sonra oyun başlayacak.";
                sure.BaslangicSure--;
                if (sure.BaslangicSure==0)
                {
                    Navigation.PushModalAsync(new Soru(NamePage.Test));
                    return false;
                }
                return true; // True = Repeat again, False = Stop the timer
            });
        }
    }
}