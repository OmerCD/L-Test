using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Client
{
	public class SoruSonuc : ContentPage
	{
        public Label Sonuc = new Label
        {
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Center,
            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
        };

        public StackLayout StackLayout = new StackLayout();

        public SoruSonuc(bool sonuc)
		{
            StackLayout.Children.Add(Sonuc);
            Content = StackLayout;
        }
	}
}