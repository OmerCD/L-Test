using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Client
{
    public class Giris:ContentPage
    {
        readonly Label Label01;
        readonly Entry Entry01;
        readonly Entry Entry02;
        readonly Button Button01;
        public Giris()
        {
            BackgroundColor = Color.LightBlue;
            StackLayout layout = new StackLayout
            {
                BackgroundColor = Color.LightGray
            };
            Frame frame = new Frame
            {
                CornerRadius = 10,
                OutlineColor = Color.WhiteSmoke,
                Padding = 0
            };
            Label01 = new Label
            {
                Text = "Merhaba, L-Test Uygulamasına Hoşgeldiniz!",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                FontFamily = "Titillium Web SemiBold",
                //StyleClass = 
            };

            Entry01 = new Entry
            {
                Placeholder = "Kullanıcı Adı",
                FontFamily = "Titillium Web SemiBold",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 50,
                WidthRequest = 200,
               HorizontalTextAlignment = TextAlignment.Center
            };

            Entry02 = new Entry
            {
                Placeholder = "Şifre",
                FontFamily = "Titillium Web SemiBold",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 50,
                WidthRequest = 200,
                IsPassword = true,
                HorizontalTextAlignment = TextAlignment.Center
            };

           Button01 = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 50,
                WidthRequest = 200,
                Text = "Onayla",
            };
            Button01.Clicked += (object sender, EventArgs e) => {
                Button01_Clicked(sender, e);
            };
            void Button01_Clicked(object sender, EventArgs e)
            {
                Entry02.Placeholder = "Çalıştı";
            }

            layout.Children.Add(Label01);
            layout.Children.Add(Entry01);
            layout.Children.Add(Entry02);
            layout.Children.Add(Button01);
            layout.Spacing = 10;
            frame.Parent = layout;
            Content = layout;
        }
        public async Task Animasyon ()
        {
            const uint animasyonSuresi = 2700;
            Easing easing = Easing.SpringOut;
            await Task.WhenAll(
                Label01.FadeTo(1, animasyonSuresi, easing),
                Entry01.FadeTo(1, animasyonSuresi, easing),
                Entry02.FadeTo(1, animasyonSuresi, easing),
                Button01.FadeTo(1, animasyonSuresi, easing)
            );
        }
    }
}
