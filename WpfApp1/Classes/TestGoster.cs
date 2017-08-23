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
        public readonly DockPanel[] DockPanel;
        public readonly Label[] Label;
        public readonly DockPanel[] DockPanel2;
        public readonly TextBox[] SoruTextBoxes;
        public readonly Separator[] Sp;
        public readonly TextBox[,] Cevaptextbox;
        public readonly CheckBox[,] CevapCheckBoxes;
        public TestGoster(int soru, int cevap)
        {
            _soru = soru;
            _cevap = cevap;
            DockPanel = new DockPanel[_soru];
            Label = new Label[_soru];
            DockPanel2 = new DockPanel[_soru];
            SoruTextBoxes = new TextBox[_soru];
            Sp = new Separator[_soru];
             Cevaptextbox = new TextBox[_soru, _cevap];
            CevapCheckBoxes = new CheckBox[_soru, _cevap];
        }

        public void ControlCreation()//Kontroller Burada Tanımlandı.
        {
            for (var i = 0; i < _soru; i++)
            {
                DockPanel[i] = new DockPanel
                {
                    Margin = new Thickness(0, 0, 0, 10),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Width = double.NaN
                };
                Label[i] = new Label
                {
                    Content = "Soru " + (i + 1) + ":",
                    Style = FindResource("Label") as Style,
                    Width = 120,
                    Height = double.NaN, // Auto için bunu yazdık. Niye acaba?Cevap : Onu öyle yapmışlar. Yapana sormak gerek.
                    Background = Brushes.CornflowerBlue
                };
                SoruTextBoxes[i] = new TextBox
                {
                    Style = FindResource("TextBox") as Style,
                    Name = $"SoruTextBox{i}"
                };
                DockPanel2[i] = new DockPanel
                {
                    Name = $"stackPanel{i}",
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Margin = new Thickness(0, 5, 5, 0)
                };
                Sp[i] = new Separator
                {
                    Margin = new Thickness(0, 10, 0, 10)
                };
                for (var k = 0; k < _cevap; k++)
                {
                    CevapCheckBoxes[i, k] = new CheckBox
                    {
                        Name = $"Soru{i}Cevap{k}",
                        Margin = new Thickness(0, 5, 0, 5)
                    };
                    //_checkBox[i, k].Checked += CheckBox_Checked;
                    Cevaptextbox[i, k] = new TextBox
                    {
                        Style = FindResource("TextBox") as Style,
                        MinWidth = 600
                    };
                    CevapCheckBoxes[i, k].Content = Cevaptextbox[i, k];
                }
            }
        }
        public (TextBox[] Sorular, CheckBox[,] Şıklar) AddControlsToDockPanel(BindingBase binding, DockPanel soruDock)
        {
            for (var i = 0; i < _soru; i++) // Kontroller Burada DockPanellere Eklendi.
            {
                System.Windows.Controls.DockPanel.SetDock(DockPanel[i], Dock.Top);
                System.Windows.Controls.DockPanel.SetDock(DockPanel2[i], Dock.Top);

                DockPanel[i].Children.Add(Label[i]);
                DockPanel[i].Children.Add(SoruTextBoxes[i]);
                BindingOperations.SetBinding(SoruTextBoxes[i], WidthProperty, binding);
                soruDock.Children.Add(DockPanel[i]);
                soruDock.Children.Add(DockPanel2[i]);
                for (var k = 0; k < _cevap; k++)
                {
                    System.Windows.Controls.DockPanel.SetDock(CevapCheckBoxes[i, k], Dock.Top);
                    DockPanel2[i].Children.Add(CevapCheckBoxes[i, k]);

                }
                DockPanel2[i].Children.Add(Sp[i]);
            }
            return (SoruTextBoxes, CevapCheckBoxes);
        }
    }
}
