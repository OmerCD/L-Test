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
    /// Interaction logic for UcSoru.xaml
    /// </summary>
    public partial class UcSoru : UserControl
    {
        public UcSoru(int cevapSayisi)
        {
            InitializeComponent();
            Border[] borders = new Border[cevapSayisi];
            TextBlock[] textBlocks = new TextBlock[cevapSayisi];
            int gridCount = Convert.ToInt16(Math.Ceiling((decimal)cevapSayisi / 2));

            Viewbox[] viewboxes = new Viewbox[cevapSayisi];
            Grid[] grids = new Grid[gridCount];

            for (int i = 0; i < gridCount; i++)
            {
                Cevaplar.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < gridCount; i++)
            {
                grids[i] = new Grid();
                grids[i].SetValue(Grid.RowProperty, i);

                grids[i].ColumnDefinitions.Add(new ColumnDefinition());
                grids[i].ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < cevapSayisi; i++)
            {
                borders[i] = new Border
                {
                    Style = FindResource("BorderStyle") as Style,
                    Background = Brushes.CornflowerBlue
                };

                viewboxes[i] = new Viewbox
                {
                    MinHeight=24,
                    Stretch=Stretch.Uniform,
                };
                textBlocks[i] = new TextBlock
                {
                    Style = FindResource("TextBlock") as Style,
                    FontFamily = new FontFamily("Cabin"),
                    Text = "asdasdfgsdfsdfsdasdasdfgsdfsdfsdasdasdfgsdfsdfsdasdasdfgsdfsdfsdasdasdfgsdfsdfsdasdasdfgsdfsdfsd",
                    TextWrapping = TextWrapping.Wrap,
                    Height = Double.NaN,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Width = 400
                };
            }

            int borderColumn = 0;

            for (int i = 0; i < cevapSayisi; i++)
            {
                viewboxes[i].Child = textBlocks[i];
                borders[i].SetValue(Grid.ColumnProperty, borderColumn);
                borderColumn++;
                if (borderColumn==2)
                {
                    borderColumn = 0;
                }
            }


            int j = 0;
            for (int i = 0; i < gridCount; i++)
            {
                for (int k = j; k < j + 2; k++)
                {
                    borders[k].Child = viewboxes[k];
                    grids[i].Children.Add(borders[k]);
                }
                j = j + 2;
                Cevaplar.Children.Add(grids[i]);
            }
        }
    }
}
