using System;
using System.Collections.Generic;
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
    /// Interaction logic for UcDuzenle.xaml
    /// </summary>
    public partial class UcDuzenle : UserControl
    {
        public UcDuzenle()
        {
            InitializeComponent();
        }

        int cevapSayisi;
        int soruSayisi;
        private TextBox[] _soruTextBox;
        private TextBox[,] _cevapTextBox;
        private CheckBox[,] _cevapCheckBox;
        List<Models.EntityLayer.Test> testler;
        private void TestCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Global.GenelDurum = Global.Durum.TestDuzenleSecildi;
            var testler = FTest.Select(TestCombobox.SelectedValue.ToString());
            int testId = Convert.ToInt16(testler.TestId);
            SureTextbox.Text = testler.Sure.ToString();
            SoruTextbox.Text = testler.SoruSayisi.ToString();
            CevapTextbox.Text = testler.CevapSayisi.ToString();

            var myBinding = new Binding // Bir üst kontrolün genişliğini almanı sağlayan kod.
            {
                Path = new PropertyPath("soruDock")
            };

            SoruStack.Children.Clear();
            var tst = new TestGoster(Convert.ToInt16(testler.SoruSayisi), Convert.ToInt16(testler.CevapSayisi));
            tst.ControlCreation();
            (_soruTextBox, _cevapTextBox, _cevapCheckBox) = tst.AddControlsToDockPanel(myBinding, SoruStack);
            var sorular = FSoru.SelectAll(testId);

            var i = 0;
            var q = 0;
            if (sorular == null) return;


            foreach (var item in sorular)
            {
                tst.SoruTextBoxes[i].Text = item.SoruText;
                var cevaplar = FCevap.SelectBySoruId(item.SoruId);
                if (cevaplar == null) return;
                foreach (var item2 in cevaplar)
                {
                    _cevapTextBox[i, q].Text = item2.CevapText;
                    _cevapCheckBox[i, q].IsChecked = item2.Dogru == 1;
                    q++;
                }
                q = 0;
                i++;
            }
        }

        private void Duzelt(object sender, RoutedEventArgs e)
        {
            if (Global.GenelDurum!=Global.Durum.TestDuzenleSecildi)
            {
                Views.Anasayfa.Durum("Herhangi bir test seçilmedi.", Global.Warning);
                return;
            }
            cevapSayisi = Convert.ToInt16(CevapTextbox.Text);
            soruSayisi = Convert.ToInt16(SoruTextbox.Text);
            var testId = testler[TestCombobox.SelectedIndex].TestId;
            Models.EntityLayer.Test item = new Models.EntityLayer.Test
            {
                TestId = testId,
                TestAdi = TestCombobox.SelectedValue.ToString(),
                CevapSayisi = cevapSayisi,
                SoruSayisi = soruSayisi,
                Sure = Convert.ToInt32(SureTextbox.Text)
            };

            if (testId >= 0)
            {
                for (var i = 0; i < soruSayisi; i++)
                {
                    var soru = new Soru
                    {
                        TestId = testId,
                        SoruText = _soruTextBox[i].Text
                    };
                    var soruId = FSoru.Update(soru);

                    if (soruId >= 0)
                    {
                        for (var j = 0; j < cevapSayisi; j++)
                        {
                            var cevap = new Cevap
                            {
                                SoruId = soruId,
                                CevapText = _cevapTextBox[i, j].Text,
                                Dogru = _cevapCheckBox[i, j].IsChecked == false ? 0 : 1
                            };
                            FCevap.Update(cevap);
                        }
                    }
                }

            }
        }
        void TestAdiDoldur()
        {
            testler = new List<Models.EntityLayer.Test>();
            testler = FTest.SelectAll();
            if (testler == null) return;
            foreach (var test in testler)
            {
                TestCombobox.Items.Add(test.TestAdi);
            }
        }
        private void SayiKontrol(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Duzelt_Loaded(object sender, RoutedEventArgs e)
        {
            TestAdiDoldur();
        }
    }
}
