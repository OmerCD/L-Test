using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;


namespace WpfApp1.Classes
{
    class TestGoster:FrameworkElement
    {
        private static int _soru;
        private static int _cevap;
        public readonly Border[] borders;
        public readonly StackPanel[] stackPanels;
        public readonly DockPanel[] dockPanelSoru;
        public readonly Label[] label;
        public readonly DockPanel[] dockPanelCevap;
        public readonly TextBox[] soruTextBoxes;
        public readonly TextBox[,] cevapTextboxes;
        public readonly CheckBox[,] cevapCheckBoxes;
        public TestGoster(int soru, int cevap)
        {
            _soru = soru;
            _cevap = cevap;
            borders = new Border[_soru];
            stackPanels = new StackPanel[_soru];
            dockPanelSoru = new DockPanel[_soru];
            label = new Label[_soru];
            dockPanelCevap = new DockPanel[_soru];
            soruTextBoxes = new TextBox[_soru];
            cevapTextboxes = new TextBox[_soru, _cevap];
            cevapCheckBoxes = new CheckBox[_soru, _cevap];
        }

        public void ControlCreation()//Kontroller Burada Tanımlandı.
        {
            for (var i = 0; i < _soru; i++)
            {
                stackPanels[i] = new StackPanel();
                borders[i] = new Border
                {
                    Style = FindResource("BorderStyle") as Style,
                    Padding=new Thickness(20)
                };
                dockPanelSoru[i] = new DockPanel
                {
                    Margin = new Thickness(0, 0, 0, 10),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Width = double.NaN
                };
                label[i] = new Label
                {
                    Content = "Soru " + (i + 1) + ":",
                    Style = FindResource("Label") as Style,
                    Width = 120,
                    Foreground = Brushes.Black,
                    Height = double.NaN, // Auto için bunu yazdık. Niye acaba?Cevap : Onu öyle yapmışlar. Yapana sormak gerek.
                    Background = (SolidColorBrush)FindResource("FireBrickSoft")
            };
                soruTextBoxes[i] = new TextBox
                {
                    Style = FindResource("TextBox") as Style,
                    FontFamily = new FontFamily("Titillium Web SemiBold"),
                    Name = $"SoruTextBox{i}",
                    Height=double.NaN
                };


                dockPanelCevap[i] = new DockPanel
                {
                    Name = $"stackPanel{i}",
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Margin = new Thickness(0, 5, 5, 0)
                };
                for (var k = 0; k < _cevap; k++)
                {
                    cevapCheckBoxes[i, k] = new CheckBox
                    {
                        Name = $"Soru{i}Cevap{k}",
                        Margin = new Thickness(0, 5, 0, 5)
                    };
                    //_checkBox[i, k].Checked += CheckBox_Checked;
                    cevapTextboxes[i, k] = new TextBox
                    {
                        Style = FindResource("TextBox") as Style,
                        MinWidth = 600,
                        Height = double.NaN,
                        
                    };
                    cevapCheckBoxes[i, k].Content = cevapTextboxes[i, k];
                }
            }
        }
        public (TextBox[] Sorular,TextBox[,] Cevaplar, CheckBox[,] Şıklar) AddControlsToDockPanel(BindingBase binding, StackPanel stack)
        {
            for (var i = 0; i < _soru; i++) // Kontroller Burada DockPanellere Eklendi.
            {
                System.Windows.Controls.DockPanel.SetDock(dockPanelSoru[i], Dock.Top);
                System.Windows.Controls.DockPanel.SetDock(dockPanelCevap[i], Dock.Top);

                dockPanelSoru[i].Children.Add(label[i]);
                dockPanelSoru[i].Children.Add(soruTextBoxes[i]);
                BindingOperations.SetBinding(soruTextBoxes[i], WidthProperty, binding);
                stackPanels[i].Children.Add(dockPanelSoru[i]);
                stackPanels[i].Children.Add(dockPanelCevap[i]);
                borders[i].Child=stackPanels[i];
                stack.Children.Add(borders[i]);
                for (var k = 0; k < _cevap; k++)
                {
                    System.Windows.Controls.DockPanel.SetDock(cevapCheckBoxes[i, k], Dock.Top);
                    dockPanelCevap[i].Children.Add(cevapCheckBoxes[i, k]);

                }
            }
            return (soruTextBoxes,cevapTextboxes, cevapCheckBoxes);
        }
    }
}
