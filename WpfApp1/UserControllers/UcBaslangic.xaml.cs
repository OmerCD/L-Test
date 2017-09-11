using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Classes;
using WpfApp1.Classes.Business_Logic_Layer;
using WpfApp1.Classes.EntityLayer;

namespace WpfApp1
{
    /// <summary>
    /// ucBaslangic.xaml etkileşim mantığı
    /// </summary>
    public partial class UcBaslangic : UserControl
    {
        public UcBaslangic()
        {
            InitializeComponent();
        }
        private void OdayiOlustur(object sender, RoutedEventArgs e)
        {
            var sunucu = new Server();
            sunucu.StartServer(3333);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            List<Testler> testler = BTestler.SelectAll();
            if (testler != null)
            {
                foreach (Testler item in testler)
                {
                    TestAdiComboBox.Items.Add(item.TestAdi);
                }
            }

        }

        private void TestiBaslat(object sender, RoutedEventArgs e)
        {
            var testler = BTestler.Select(TestAdiComboBox.SelectedValue.ToString());
            int testId = Convert.ToInt16(testler.TestId);
            int soruSayisi = Convert.ToInt16(testler.SoruSayisi);
            int cevapSayisi = Convert.ToInt16(testler.CevapSayisi);
            string[] sorular = new string[soruSayisi];
            string[,] cevaplar = new string[soruSayisi, cevapSayisi];


            var sorularVeri = BSorular.SelectAll(testId);
            if (sorularVeri == null) return;

            int i = 0, q = 0;
            foreach (var item in sorularVeri)
            {
                sorular[i] = item.Soru;
                var cevaplarVeri = BCevaplar.SelectAll(item.SoruId);
                if (cevaplarVeri == null) return;
                foreach (var item2 in cevaplarVeri)
                {
                    cevaplar[i, q] = item2.Cevap;
                    q++;
                }
                q = 0;
                i++;
            }
            TxtDonustur txt = new TxtDonustur();
            txt.Yazdir(sorular, cevaplar, TestAdiComboBox.SelectedValue.ToString());

        }
    }
}
