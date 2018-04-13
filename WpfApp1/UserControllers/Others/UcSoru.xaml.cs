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
            int gridCount = Convert.ToInt16(Math.Ceiling((decimal)cevapSayisi / 2));

            Border[] borders = new Border[cevapSayisi];
            TextBlock[] textBlocks = new TextBlock[cevapSayisi];
            Rectangle[] rectangles = new Rectangle[cevapSayisi];
            Viewbox[] viewboxes = new Viewbox[cevapSayisi];
            DockPanel[] dpViewBox = new DockPanel[cevapSayisi];
            List<Path> icons = new List<Path>();
            List<SolidColorBrush> colors = new List<SolidColorBrush>();
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

            #region Set Icons
            icons.Add((Path)FindResource("Square"));
            icons.Add((Path)FindResource("Rectangle"));
            icons.Add((Path)FindResource("Triangle"));
            icons.Add((Path)FindResource("Pentagon"));
            icons.Add((Path)FindResource("Hexagon"));
            icons.Add((Path)FindResource("Rhombus"));
            icons.Add((Path)FindResource("Parallelogram"));
            icons.Add((Path)FindResource("Asteriks"));
            #endregion

            #region Set Colors
            colors.Add(Brushes.Red);
            colors.Add(Brushes.CornflowerBlue);
            colors.Add(Brushes.Orange);
            colors.Add(Brushes.MediumVioletRed);
            colors.Add(Brushes.ForestGreen);
            colors.Add(Brushes.Gold);
            colors.Add(Brushes.HotPink);
            colors.Add(Brushes.Teal);
            #endregion

            for (int i = 0; i < cevapSayisi; i++)
            {
                borders[i] = new Border
                {
                    Style = FindResource("BorderStyle") as Style,
                    Background = colors[i],
                };


                //      < Rectangle Style = "{DynamicResource IconBox}" Margin = "16,0,0,0" >

                // < Rectangle.OpacityMask >

                //     < VisualBrush Stretch = "Fill" Visual = "{StaticResource Setting}" />

                //    </ Rectangle.OpacityMask >

                //</ Rectangle >
                viewboxes[i] = new Viewbox
                {
                    MinHeight=24,
                    Stretch=Stretch.Uniform,
                };
                dpViewBox[i] = new DockPanel();

                textBlocks[i] = new TextBlock
                {
                    Style = FindResource("TextBlock") as Style,
                    FontFamily = new FontFamily("Cabin"),
                    Text = "asdasdfgsdfsdfsdasdasdasdasdfgsdfsdfsdasdasdfgsdfsdfsdasdasdfgsdfsdfsd",
                    TextWrapping = TextWrapping.Wrap,
                    Height = Double.NaN,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Width = 400
                };

                rectangles[i] = new Rectangle
                {
                    Style = FindResource("IconBox") as Style,
                    Margin = new Thickness(16,0,16, 0),
                    Width=32,
                    Height=32,
                    Fill= Brushes.White,
                    OpacityMask = new VisualBrush
                    {
                        Stretch=Stretch.Fill,
                        Visual = icons[i]
                    }
                };

            }

            int borderColumn = 0;

            for (int i = 0; i < cevapSayisi; i++)
            {
                dpViewBox[i].Children.Add(rectangles[i]);
                dpViewBox[i].Children.Add(textBlocks[i]);
                viewboxes[i].Child = dpViewBox[i];
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
