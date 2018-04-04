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
using WpfApp1;
using WpfApp1.Classes;
using WpfApp1.Classes.Business_Logic_Layer;
using WpfApp1.Classes.EntityLayer;

namespace ltest.UserControllers.UcTestler
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
        int cevapSayisi;
        int soruSayisi;
        private TextBox[] _soruTextBox;
        private TextBox[,] _cevapTextBox;
        private CheckBox[,] _cevapCheckBox;
        List<Testler> testler;

        private void Olustur_Click(object sender, RoutedEventArgs e)
        {
            var myBinding = new Binding // Bir üst kontrolün genişliğini almanı sağlayan kod.
            {
                Path = new PropertyPath("soruDock")
            };
            _soru = Convert.ToInt16(SoruTextbox.Text);
            _cevap = Convert.ToInt16(CevapTextbox.Text);

            SoruStack.Children.Clear();
            var tst = new TestGoster(_soru, _cevap);
            tst.ControlCreation();
            (_soruTextBox, _cevapTextBox, _cevapCheckBox) = tst.AddControlsToDockPanel(myBinding, SoruStack);
        }

        private void Kaydet(object sender, RoutedEventArgs e)
        {
            cevapSayisi = Convert.ToInt16(CevapTextbox.Text);
            soruSayisi = Convert.ToInt16(SoruTextbox.Text);
            var item = new Testler
            {
                TestAdi = TestTextbox.Text,
                CevapSayisi = cevapSayisi,
                SoruSayisi = soruSayisi,
                Sure = Convert.ToInt32(SureTextbox.Text)
            };
            var testId = BTestler.Insert(item);
            if (testId >= 0)
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
                            BCevaplar.Insert(cevap);
                        }
                    }
                }
            }
            else
            {
                MainWindow.Durum(testId >= 0 ? "Test Kayıtları Başarılı" : "Kayıt Başarısız");
            }
            //TestAdiDoldur();
        }

        private void SayiKontrol(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
