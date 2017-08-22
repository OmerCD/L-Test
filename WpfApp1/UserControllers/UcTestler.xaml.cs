using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfApp1.Classes;
using WpfApp1.Classes.Business_Logic_Layer;
using WpfApp1.Classes.EntityLayer;
using WpfApp1.Classes.FacedeLayer;

namespace WpfApp1.UserControllers
{
    /// <summary>
    /// UcTestler.xaml etkileşim mantığı
    /// </summary>
    public partial class UcTestler
    {
        public UcTestler()
        {
            InitializeComponent();
        }

        private int _cevap;
        private int _soru;
        private void Olustur_Click(object sender, RoutedEventArgs e)
        {                    
            var myBinding = new Binding // Bir üst kontrolün genişliğini almanı sağlayan kod.
            {
                Path = new PropertyPath("soruDock")
            }; 
            _soru = Convert.ToInt16(SoruTextbox.Text);
            _cevap = Convert.ToInt16(CevapTextbox.Text);

            SoruDock.Children.Clear();
            var tst = new TestGoster(_soru, _cevap);
            tst.ControlCreation();
            tst.AddControlsToDockPanel(myBinding, SoruDock);
        }
        private void Kaydet(object sender, RoutedEventArgs e)
        {
            var item = new Testler
            {
                TestAdi = TestTextbox.Text,
                CevapSayisi = Convert.ToInt16(CevapTextbox.Text),
                SoruSayisi = Convert.ToInt16(SoruTextbox.Text),
                Sure = Convert.ToInt16(SureTextbox.Text)
            };
            MainWindow.Durum(BTestler.Insert(item) > 0 ? "Kayıt Başarılı" : "Kayıt Başarısız");

            //var soru=new Sorular
            //{
            //       TestId = item.TestId,
            //       Soru = ;
            //}
            //SoruSistemi SoruSistemiOlustur(short testId)
            //{
            //    var soruSis = new SoruSistemi(testId);
            //    for (var i = 0; i < _soru; i++)
            //    {
            //        var checkBoxes = new List<CheckBox>();
            //        for (var k = 0; k < _cevap; k++)
            //        {
            //            checkBoxes.Add(_checkBox[i, k]);
            //        }
            //        soruSis.SoruEkle(_textbox[i].Text, checkBoxes.ToArray());
            //    }

            //    return soruSis;
            //}
            //var test = TestTextbox.Text;
            //var sure = Convert.ToInt32(SureTextbox.Text);
            //if (DatabaseManager.Baglanti.State == ConnectionState.Closed)
            //{
            //    try
            //    {
            //        DatabaseManager.Baglanti.Open();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Hata Kodu: 0x04 " + ex.Message);
            //    }
            //}

            //var sonuc = Convert.ToInt16(AddQuestion(test, sure));
            //var soruSistemi = SoruSistemiOlustur(sonuc);

            //soruSistemi.SorulariKaydet();
        }

        private void SayiKontrol(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var testler = BTestler.SelectAll();
            if (testler!=null)
            {
                foreach (var item in testler)
                {
                    TestDuzeltCombobox.Items.Add(item.TestAdi);
                }
            }
        }

        private void TestDuzeltCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var testler = BTestler.Select(TestDuzeltCombobox.SelectedValue.ToString());
            int testId = Convert.ToInt16(testler.TestId);
            SureDuzeltTextbox.Text = testler.Sure.ToString();
            SoruDuzeltTextbox.Text = testler.SoruSayisi.ToString();
            CevapDuzeltTextbox.Text = testler.CevapSayisi.ToString();

            int soruSayisi= Convert.ToInt16(testler.SoruSayisi);
            int cevapSayisi = Convert.ToInt16(testler.CevapSayisi);

            var myBinding = new Binding // Bir üst kontrolün genişliğini almanı sağlayan kod.
            {
                Path = new PropertyPath("soruDock")
            };

            SoruDock.Children.Clear();
            var tst = new TestGoster(soruSayisi, cevapSayisi);
            tst.ControlCreation();
            tst.AddControlsToDockPanel(myBinding, SoruDock);

            var sorular= BSorular.SelectAll(testId);
            var i = 0;
            foreach (var item in sorular)
            {
                tst.Textbox[i].Text = item.Soru;
                i++;
            }
        }
    }
}
