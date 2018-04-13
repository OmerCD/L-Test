using ltest.Classes;
using ltest.Properties;
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

namespace ltest.UserControllers
{
    /// <summary>
    /// Interaction logic for UcAyarlar.xaml
    /// </summary>
    public partial class ChangeColor : UserControl
    {
        public ChangeColor()
        {
            InitializeComponent();
        }

        private void MouseUp(object sender, MouseButtonEventArgs e)
        {
            var ellipse = (Ellipse)e.Source;
            SolidColorBrush solidColor = (SolidColorBrush)ellipse.Fill;
            Global.ChangeColour(solidColor);
        }
    }
}
