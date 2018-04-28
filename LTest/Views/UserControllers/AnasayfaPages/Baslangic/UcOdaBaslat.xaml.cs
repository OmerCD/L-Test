﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using LTest.Classes;
using LTest.Models.EntityLayer;
using LTest.Models.FacadeLayer;

namespace LTest.Views.UserControllers.AnasayfaPages
{
    /// <summary>
    /// Interaction logic for adim1.xaml
    /// </summary>
    public partial class UcOdaBaslat : UserControl
    {
        public UcOdaBaslat()
        {
            InitializeComponent();
            ShowColumnChart();
            //BindData();
        }
        private Models.EntityLayer.Test _test;
        List<Kullanici> _kullanicilar = new List<Kullanici>();

        //void BindData()
        //{
        //    kullanicilar.Add(new Kullanici {
        //        KullaniciAdi="Hasan",
        //        OyunSayisi=25,
        //        Puan=50
        //    });

        //    kullanicilar.Add(new Kullanici
        //    {
        //        KullaniciAdi = "Mahmut",
        //        OyunSayisi = 5,
        //        Puan = 25
        //    });

        //    kullanicilar.Add(new Kullanici
        //    {
        //        KullaniciAdi = "Melisa",
        //        OyunSayisi = 15,
        //        Puan = 85
        //    });
        //    enCokKazanan.DataContext = kullanicilar;
        //}

        private void OdayiOlustur(object sender, RoutedEventArgs e)
        {
            if (TestAdiComboBox.SelectedValue==null)
            {
                Views.Anasayfa.Durum("Lütfen bir test seçin!", Global.Warning);
                return;
            }

            // Seçilmiş Olan Test Combobox'dan alınıyor.
            //Testler test = BTestler.Select(TestAdiComboBox.SelectedValue.ToString());


            // Anasayfa Alt Bar Bilgilendirme
            Views.Anasayfa.Active("Online");
            Views.Anasayfa.Durum("Oda Oluşturuldu", Global.Done);

            // Diğer Formlardan Test Durumu Hakkında Bilgi Edinmek İçin Oluşturuldu
            Global.GenelDurum = Global.Durum.OdaOnline;

            var kullaniciSayfasi = new Views.KullaniciSayfasi(_test.TestAdi);
            kullaniciSayfasi.ShowDialog();


        }
        private void KullaniciGoster(object sender, RoutedEventArgs e)
        {

        }

        List<Models.EntityLayer.Test> testler;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            testler = new List<Models.EntityLayer.Test>();
            testler = FTest.SelectAll();
            if (testler == null) return;
            foreach (var test in testler)
            {
                TestAdiComboBox.Items.Add(test.TestAdi);
            }
        }

        private void TestAdiComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _test = FTest.Select(TestAdiComboBox.SelectedValue.ToString());
            Sure.Text = _test.Sure.ToString();
            SoruSayisi.Text = _test.SoruSayisi.ToString();
            CevapSayisi.Text = _test.CevapSayisi.ToString();
        }

        private void ShowColumnChart()
        {
            List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("Developer", 60),
                new KeyValuePair<string, int>("Misc", 20),
                new KeyValuePair<string, int>("Tester", 50),
                new KeyValuePair<string, int>("QA", 30),
                new KeyValuePair<string, int>("Project Manager", 40)
            };

            //Setting data for column chart
            columnChart.DataContext = valueList;

            // Setting data for pie chart
            pieChart.DataContext = valueList;

            //Setting data for area chart
            //areaChart.DataContext = valueList;

            //Setting data for bar chart
            barChart.DataContext = valueList;

            //Setting data for line chart
            //lineChart.DataContext = valueList;
        }
    }
}