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
            switch (sonuc)
            {
                case true:
                    Sonuc.Text = "✓&#10;Doğru Cevap, Tebrikler!";
                    StackLayout.BackgroundColor = Color.FromHex("#d9534f");
                    break;
                case false:
                    Sonuc.Text = "✗&#10;Yanlış Cevap, Dikkatli Ol!";
                    StackLayout.BackgroundColor = Color.FromHex("#5cb85c");
                    break;
                default:
                    Sonuc.Text = "⚫&#10;Sonuç Bekleniyor!";
                    StackLayout.BackgroundColor = Color.FromHex("#F7F7F7");
                    break;
            }
            StackLayout.Children.Add(Sonuc);
            Content = StackLayout;
        }
	}
}