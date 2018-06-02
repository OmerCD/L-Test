using Entity;
using LTest.Classes;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Client
{
    public class SoruGoster : ContentPage
	{
        List<Button> buttons=new List<Button>();
        List<Rectangle> rectangles = new List<Rectangle>();
        List<Color> colors = new List<Color>();
        int cevap=99;
        double sure=0;
        public SoruGoster(Test test)
		{
            int gridRowCount = Convert.ToInt16(Math.Ceiling((decimal)test.CevapSayisi / 2));
            int gridColumnCount = 2;
            // Grid
            Grid mainGrid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)  },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                }
            };

            for (int i = 0; i < gridRowCount; i++)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition {
                    Height = new GridLength(1, GridUnitType.Star)
                });
            }

            // COLORS ADD

            colors.Add(Color.Red);
            colors.Add(Color.CornflowerBlue);
            colors.Add(Color.Orange);
            colors.Add(Color.MediumVioletRed);
            colors.Add(Color.ForestGreen);
            colors.Add(Color.Gold);
            colors.Add(Color.HotPink);
            colors.Add(Color.Teal);

            // OTHER COMPENENTS
            for (int i = 0; i < test.CevapSayisi; i++)
            {
                buttons.Add(new Button
                {
                    HorizontalOptions=LayoutOptions.FillAndExpand,
                    VerticalOptions=LayoutOptions.FillAndExpand,
                    BackgroundColor=colors[i],
                });

                buttons[i].Clicked += new EventHandler(Button_Clicked);
            }

            // ADDING COMPENENTS TO STACKLAYOUTS
            byte btnIndex = 0;
            for (int i = 0; i < gridRowCount; i++)
            {
                for (int k = 0; k < gridColumnCount; k++)
                {
                    if (btnIndex>=test.CevapSayisi)
                    {
                        break;
                    }
                    Grid.SetRow(buttons[btnIndex], i);
                    Grid.SetColumn(buttons[btnIndex], k);
                    btnIndex++;
                }
            }

            for (int i = 0; i < test.CevapSayisi; i++)
            {
                mainGrid.Children.Add(buttons[i]);
            }

            Content = mainGrid;

            Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
            {
                sure += 0.1;
                if (sure>=test.Sure)
                {
                    ClientListener.Kullanici.Sorular.Add(new ClientKullanici.SoruOzellikleri
                    {
                        Cevap = 99,
                        CevapSuresi = sure,
                    });
                    ClientListener.SendObject();

                    return false;
                }
                return true; // True = Repeat again, False = Stop the timer
            });
        }

        public static byte soruIndex = 0;
        private void Button_Clicked(object sender, EventArgs e)
        {
            // Soruya Ait Cevapları Bul
            List<Cevap> cevaplar = new List<Cevap>();
            int soruId = NamePage.Sorular[soruIndex++].SoruId;
            foreach (Cevap cevap in NamePage.Cevaplar)
            {
                if (cevap.SoruId==soruId)
                {
                    cevaplar.Add(cevap);
                }
            }

            Button button = (Button)sender;

            // Tıklanılan butonun indexini bul ve Hangi Cevabın verildiğini tespit et.
            int cevapIndex = buttons.IndexOf(button);

            bool sonuc = Convert.ToBoolean(cevaplar[cevapIndex].Dogru);

            NamePage.Kullanici.Sorular.Add(new ClientKullanici.SoruOzellikleri {
                Cevap = cevap,
                CevapSuresi = sure,

            });

            // Cevabı Gönder
            NamePage.SendObject(NamePage.Kullanici);

            // Bekleme Ekranını AÇ
            Navigation.PushModalAsync(new SoruSonuc(sonuc));

        }
    }
}