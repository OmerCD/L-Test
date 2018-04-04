using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace ltest.UserControllers.UcBaslangic
{
    /// <summary>
    /// Interaction logic for adim2.xaml
    /// </summary>
    public partial class adim2 : UserControl
    {
        public adim2()
        {
            InitializeComponent();
        }

        private void TestiBaslat(object sender, RoutedEventArgs e)
        {

            //foreach (var item in clients)
            //{
            //    ipList.Items.Add(item.GetId());
            //}

            //ipList.Items.Add(sockets.Count.ToString());
            //var test = BTestler.Select(TestAdiComboBox.SelectedValue.ToString());
            //int testId = Convert.ToInt16(test.TestId);
            //int soruSayisi = Convert.ToInt16(test.SoruSayisi);
            //int cevapSayisi = Convert.ToInt16(test.CevapSayisi);
            //string[] sorular = new string[soruSayisi];
            //string[,] cevaplar = new string[soruSayisi, cevapSayisi];


            //var sorularVeri = BSorular.SelectAll(testId);
            //if (sorularVeri == null) return;

            //int i = 0, q = 0;
            //foreach (var item in sorularVeri)
            //{
            //    sorular[i] = item.Soru;
            //    var cevaplarVeri = BCevaplar.SelectAll(item.SoruId);
            //    if (cevaplarVeri == null) return;
            //    foreach (var item2 in cevaplarVeri)
            //    {
            //        cevaplar[i, q] = item2.Cevap;
            //        q++;
            //    }
            //    q = 0;
            //    i++;
            //}
            //TxtDonustur txt = new TxtDonustur();
            //txt.Yazdir(sorular, cevaplar, TestAdiComboBox.SelectedValue.ToString());

        }

        private void TestAdiComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var test = BTestler.Select(TestAdiComboBox.SelectedValue.ToString());
            //Sure.Text = test.Sure.ToString();
        }
    }
}
