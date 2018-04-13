using ltest.Classes;
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
    /// Interaction logic for adim3.xaml
    /// </summary>
    public partial class adim3 : UserControl
    {
        public adim3()
        {
            InitializeComponent();
        }
        private void Bitir(object sender, RoutedEventArgs e)
        {
            Global.genelDurum = Global.GenelDurum.TestBitirildi;
        }
    }
}
