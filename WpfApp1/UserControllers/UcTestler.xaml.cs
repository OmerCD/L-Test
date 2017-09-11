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
        private TextBox[] _soruTextBox;
        private TextBox[,] _cevapTextBox;
        private CheckBox[,] _cevapCheckBox;
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
            (_soruTextBox, _cevapTextBox, _cevapCheckBox) = tst.AddControlsToDockPanel(myBinding, SoruDock);
        }
        private void Kaydet(object sender, RoutedEventArgs e)
        {
            var cevapSayisi=Convert.ToInt16(CevapTextbox.Text);
            var soruSayisi = Convert.ToInt16(SoruTextbox.Text);
            var item = new Testler
            {
                TestAdi = TestTextbox.Text,
                CevapSayisi = cevapSayisi,
                SoruSayisi = soruSayisi,
                Sure = Convert.ToInt16(SureTextbox.Text)
            };
            var testId = BTestler.Insert(item);
            if (testId>= 0)
            {
                for (var i = 0; i < soruSayisi; i++)
                {
                    var soru = new Sorular
                    {
                        TestId = testId,
                        Soru = _soruTextBox[i].Text
                    };
                    var soruId = BSorular.Insert(soru);

                    if (soruId >= 0)
                    {
                        for (var j = 0; j < cevapSayisi; j++)
                        {
                            var cevap = new Cevaplar
                            {
                                SoruId = soruId,
                                Cevap = _cevapTextBox[i, j].Text,
                                Dogru = _cevapCheckBox[i, j].IsChecked == false ? 0 : 1
                            };
                            MainWindow.Durum(BCevaplar.Insert(cevap) >= 0 ? "Tüm Kayıtlar Başarılı" : "Kayıt Başarısız");
                        }
                    }
                    else
                    {
                        MainWindow.Durum(soruId >= 0 ? "Soru Kayıtları Başarılı" : "Kayıt Başarısız");
                    }
                }
            }
            else
            {
                MainWindow.Durum(testId >= 0 ? "Test Kayıtları Başarılı" : "Kayıt Başarısız");
            }

            //TODO: Kullanıcılara göndermek için XML dosyası oluşturulacak.
            var testler = BTestler.SelectAll();
            if (testler == null) return;
            foreach (var test in testler)
            {
                TestDuzeltCombobox.Items.Add(test.TestAdi);
            }
        }

        private void SayiKontrol(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var testler = BTestler.SelectAll();
            if (testler == null) return;
            foreach (var item in testler)
            {
                TestDuzeltCombobox.Items.Add(item.TestAdi);
            }
        }

        private void TestDuzeltCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var testler = BTestler.Select(TestDuzeltCombobox.SelectedValue.ToString());
            int testId = Convert.ToInt16(testler.TestId);
            SureDuzeltTextbox.Text = testler.Sure.ToString();
            SoruDuzeltTextbox.Text = testler.SoruSayisi.ToString();
            CevapDuzeltTextbox.Text = testler.CevapSayisi.ToString();

            var myBinding = new Binding // Bir üst kontrolün genişliğini almanı sağlayan kod.
            {
                Path = new PropertyPath("soruDock")
            };

            SoruDock.Children.Clear();
            var tst = new TestGoster(Convert.ToInt16(testler.SoruSayisi), Convert.ToInt16(testler.CevapSayisi));
            tst.ControlCreation();
            (_soruTextBox, _cevapTextBox, _cevapCheckBox) = tst.AddControlsToDockPanel(myBinding, SoruDock);
            var sorular= BSorular.SelectAll(testId);

            var i = 0;
            var q = 0;
            if (sorular == null) return;


            foreach (var item in sorular)
            {
                tst.SoruTextBoxes[i].Text = item.Soru;
                var cevaplar = BCevaplar.SelectAll(item.SoruId);
                if (cevaplar == null) return;
                foreach (var item2 in cevaplar)
                {
                    _cevapTextBox[i,q].Text = item2.Cevap;
                    _cevapCheckBox[i,q].IsChecked = item2.Dogru == 1;
                    q++;
                }
                q = 0;
                i++;
            }
        }
    }
}
