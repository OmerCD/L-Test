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
using System.Windows.Shapes;
using WpfApp1.Classes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for YanEkran.xaml
    /// </summary>
    public partial class YanEkran : Window
    {
        public YanEkran()
        {
            InitializeComponent();          
        }
        
        private void Kapat(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                AnaStack.Children.Add(new UserControllers.UcGirenKullanici());
            }
        }
    }
}
