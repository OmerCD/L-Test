using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Client
{
    public class Giris:ContentPage
    {
        readonly Grid Grid01;
        readonly Grid Grid02;
        readonly Label Label01;
        readonly Frame Frame01;
        readonly StackLayout Stack01;
        readonly Entry Entry01;
        readonly Entry Entry02;
        readonly Button Button01;
        readonly StackLayout Stack02;
        readonly Label Label02;
        readonly Switch Sw01;
        readonly StackLayout Stack03;
        readonly Label label03;
        readonly Label label04;

        public Giris()
        {
            //readonly Grid Grid01;
            //readonly Grid Grid02;
            //readonly Label Label01;
            //readonly Frame Frame01;
            //readonly StackLayout Stack01;
            //readonly Entry Entry01;
            //readonly Entry Entry02;
            //readonly Button Button01;
            //readonly StackLayout Stack02;
            //readonly Label Label02;
            //readonly Switch Sw01;
            //readonly StackLayout Stack03;
            //readonly Label label03;
            //readonly Label label04;


            //        <Grid>
            //    <Grid HorizontalOptions = "Center" VerticalOptions="Center">
            //        <Grid.ColumnDefinitions>
            //            <ColumnDefinition Width = "250" />
            //        </ Grid.ColumnDefinitions >
            //        < Grid.RowDefinitions >
            //            < RowDefinition Height="70"/>
            //            <RowDefinition Height = "250" />
            //            < RowDefinition Height="20" />
            //        </Grid.RowDefinitions>
            //        <Label Grid.Column="0" Grid.Row= "0"  x:Name= "Label01" HorizontalTextAlignment= "Center" Text= "L-Test Uygulamasına Hoşgeldiniz!"
            //        VerticalOptions= "Start" HorizontalOptions= "Center"  FontFamily= "Titillium Web SemiBold" StyleClass= "Header" TextColor= "White" />
            //        < Frame CornerRadius= "15" BackgroundColor= "AntiqueWhite" Grid.Column= "0" Grid.Row= "1" >
            //            < StackLayout VerticalOptions= "Center" >
            //                < Entry x:Name= "Entry01"  Placeholder= "Kullanıcı Adı" HorizontalTextAlignment= "Center" HeightRequest= "50" WidthRequest= "200"
            //        HorizontalOptions= "Center" VerticalOptions= "Center" FontFamily= "Titillium Web SemiBold" TextColor= "Black" />
            //                < Entry x:Name= "Entry02" Placeholder= "Şifre" IsPassword= "true"  HorizontalTextAlignment= "Center" HeightRequest= "50" WidthRequest= "200"
            //        HorizontalOptions= "Center" VerticalOptions= "Center" FontFamily= "Titillium Web SemiBold" />
            //                < Button Text= "Giriş Yap" StyleClass= "Info" />
            //                < StackLayout Orientation= "Horizontal" HorizontalOptions= "Start" >
            //                    < Label Text= "Üyeliği Hatırla" Margin= "0,4,0,0" />
            //                    < Switch />
            //                </ StackLayout >
            //            </ StackLayout >
            //        </ Frame >
            //        < StackLayout Orientation= "Horizontal" HorizontalOptions= "Center" Grid.Column= "0" Grid.Row= "2" >
            //            < Label Text= "Şifremi Unuttum" StyleClass= "Inverse" />
            //            < Label Text= "Yeni Üyelik" Margin= "15,0,0,0" StyleClass= "Inverse" />
            //        </ StackLayout >
            //    </ Grid >
            //</ Grid >

            Grid01 = new Grid ();
            Grid02 = new Grid {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            ColumnDefinition Column01 = new ColumnDefinition
            {
                Width = new GridLength(20, GridUnitType.Star)
            };
            Grid02.ColumnDefinitions.Add(Column01);
           
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
