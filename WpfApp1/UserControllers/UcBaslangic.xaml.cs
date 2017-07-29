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
            foreach (Testler item in testler)
            {
                TestAdiComboBox.Items.Add(item.TestAdi);
            }
        }
    }
}
