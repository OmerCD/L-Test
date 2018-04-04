using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Classes;
using WpfApp1.Classes.Business_Logic_Layer;
using WpfApp1.Classes.EntityLayer;
using WpfApp1.Classes.FacedeLayer;

namespace ltest.UserControllers.UcTestler
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
        List<Testler> testler;
        private void TestCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var testler = BTestler.Select(TestCombobox.SelectedValue.ToString());
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
            var sorular = BSorular.SelectAll(testId);

            var i = 0;
            var q = 0;
            if (sorular == null) return;


            foreach (var item in sorular)
            {
                tst.soruTextBoxes[i].Text = item.Soru;
                var cevaplar = BCevaplar.SelectAll(item.SoruId);
                if (cevaplar == null) return;
                foreach (var item2 in cevaplar)
                {
                    _cevapTextBox[i, q].Text = item2.Cevap;
                    _cevapCheckBox[i, q].IsChecked = item2.Dogru == 1;
                    q++;
                }
                q = 0;
                i++;
            }
        }

        private void Duzelt(object sender, RoutedEventArgs e)
        {
            cevapSayisi = Convert.ToInt16(CevapTextbox.Text);
            soruSayisi = Convert.ToInt16(SoruTextbox.Text);
            var testId = testler[TestCombobox.SelectedIndex].TestId;
            var item = new Testler
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
                    var soru = new Sorular
                    {
                        TestId = testId,
                        Soru = _soruTextBox[i].Text
                    };
                    var soruId = FSorular.Update(soru);

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
                            FCevaplar.Update(cevap);
                        }
                    }
                }

            }
        }

        void TestAdiDoldur()
        {
            testler = new List<Testler>();
            testler = BTestler.SelectAll();
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
