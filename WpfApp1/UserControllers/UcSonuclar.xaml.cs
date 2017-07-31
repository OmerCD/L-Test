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

namespace WpfApp1.UserControllers
{
    /// <summary>
    /// Interaction logic for UcSonuclar.xaml
    /// </summary>
    public partial class UcSonuclar : UserControl
    {
        public UcSonuclar()
        {
            InitializeComponent();
            var col = new DataGridTextColumn
            {
                Header = "Column1",
                Binding = new Binding("[0]")
            };
            DataGrid1.Columns.Add(col);

            col = new DataGridTextColumn
            {
                Header = "Column2",
                Binding = new Binding("[1]")
            };
            DataGrid1.Columns.Add(col);

            col = new DataGridTextColumn
            {
                Header = "Column3",
                Binding = new Binding("[2]")
            };
            DataGrid1.Columns.Add(col);

            //dataGrid1.ad

            var rows = new List<object>();

            var value = new string[3];

            value[0] = "hello";
            value[1] = "world";
            value[2] = "the end";
            rows.Add(value);

            DataGrid1.ItemsSource = rows;
        }
    }
}
