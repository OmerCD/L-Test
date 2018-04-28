using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using LTest.Classes;
using LTest.Models.EntityLayer;
using LTest.Models.FacadeLayer;

namespace LTest.Views.UserControllers.AnasayfaPages.Test
{
    /// <summary>
    /// Interaction logic for UcOlustur.xaml
    /// </summary>
    public partial class UcOlustur : UserControl
    {
        public UcOlustur()
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

            if (SoruTextbox.Text==string.Empty || CevapTextbox.Text==string.Empty || SureTextbox.Text == string.Empty || TestTextbox.Text==string.Empty)
            {
                Views.Anasayfa.Durum("Lütfen tüm alanları doldurun", Global.Warning);
                return;
            }
            Global.GenelDurum = Global.Durum.TestOlusturuldu;

            _soru = Convert.ToInt16(SoruTextbox.Text);
            _cevap = Convert.ToInt16(CevapTextbox.Text);
            SoruStack.Children.Clear();
            var tst = new TestGoster(_soru, _cevap);
            tst.ControlCreation();
            (_soruTextBox, _cevapTextBox, _cevapCheckBox) = tst.AddControlsToDockPanel(myBinding, SoruStack);
        }

        private void Kaydet(object sender, RoutedEventArgs e)
        {
            if (Global.GenelDurum!=Global.Durum.TestOlusturuldu)
            {
                Views.Anasayfa.Durum("Kaydedilecek bir şey yok!", Global.Warning);
                return;
            }

            var item = new Models.EntityLayer.Test
            {
                TestAdi = TestTextbox.Text,
                CevapSayisi = _cevap,
                SoruSayisi = _soru,
                Sure = Convert.ToInt32(SureTextbox.Text)
            };
            var testId = FTest.Insert(item);
            if (testId >= 0)
            {
                for (var i = 0; i < _soru; i++)
                {
                    var soru = new Soru
                    {
                        TestId = testId,
                        SoruText = _soruTextBox[i].Text
                    };
                    var soruId = FSoru.Insert(soru);

                    if (soruId >= 0)
                    {
                        for (var j = 0; j < _cevap; j++)
                        {
                            var cevap = new Cevap
                            {
                                SoruId = soruId,
                                TestId = testId,
                                CevapText = _cevapTextBox[i, j].Text,
                                Dogru = _cevapCheckBox[i, j].IsChecked == false ? 0 : 1
                            };
                            FCevap.Insert(cevap);
                        }
                    }
                }
            }
            Views.Anasayfa.Durum(testId >= 0 ? "Test Kayıtları Başarılı" : "Kayıt Başarısız", Global.Failed);
            SoruStack.Children.Clear();

        }

        private void SayiKontrol(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
