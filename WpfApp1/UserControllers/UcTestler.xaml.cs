using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfApp1.Classes;

namespace WpfApp1.UserControllers
{
    /// <summary>
    /// UcTestler.xaml etkileşim mantığı
    /// </summary>
    public partial class UcTestler
    {
        public UcTestler()
        {
            InitializeComponent();
        }

        private int _soru, _cevap;
        private TextBox[] _textbox;
        private TextBox[,] _cevaptextbox;
        private DockPanel[] _dockPanel;
        private Label[] _label;
        private DockPanel[] _dockPanel2;
        private CheckBox[,] _checkBox;
        private Separator[] _sp;
        private void Olustur_Click(object sender, RoutedEventArgs e)
        {
            void AssignControlValues()
            {
                _soru = Convert.ToInt16(SoruTextbox.Text);
                _cevap = Convert.ToInt16(CevapTextbox.Text);
                _dockPanel = new DockPanel[_soru];
                _label = new Label[_soru];
                _dockPanel2 = new DockPanel[_soru];
                _textbox = new TextBox[_soru];
                _sp = new Separator[_soru];
                _cevaptextbox = new TextBox[_soru, _cevap];
                _checkBox = new CheckBox[_soru, _cevap];
            }
            bool ErrorControl()
            {
                
                {
                    if (TestTextbox.Text.Length < 1)
                    {
                        MessageBox.Show("Test Adı boş bırakılamaz", "Uyarı");
                        return true;
                    }
                    if (SureTextbox.Text.Length < 2)
                    {
                        MessageBox.Show("En az 10 dakikalık bir süre girmelisiniz.", "Uyarı");
                        return true;
                    }
                    if (SoruTextbox.Text.Length < 1)
                    {
                        MessageBox.Show("Soru sayısını giriniz.", "Uyarı");
                        return true;
                    }
                    if (CevapTextbox.Text.Length < 1)
                    {
                        MessageBox.Show("Cevap sayısını giriniz.", "Uyarı");
                        return true;
                    }
                    if (Convert.ToInt32(CevapTextbox.Text) < 2)
                    {
                        MessageBox.Show("Her bir soru için cevap sayısı en az 2 olmalıdır.", "Uyarı");
                        return true;
                    }
                    return false;
                    }
                    }
            void ControlCreation(int i)
            {
                _dockPanel[i] = new DockPanel
                {
                    Margin = new Thickness(0, 0, 0, 10),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Width = double.NaN
                };
                _label[i] = new Label
                {
                    Content = "Soru " + (i + 1) + ":",
                    Style = FindResource("Label") as Style,
                    Width = 120,
                    Height = double.NaN, // Auto için bunu yazdık. Niye acaba?
                    Background = Brushes.CornflowerBlue
                };
                _textbox[i] = new TextBox
                {
                    Style = FindResource("TextBox") as Style,
                    Name = $"SoruTextBox{i}"
                };
                _dockPanel2[i] = new DockPanel
                {
                    Name = $"stackPanel{i}",
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Margin = new Thickness(0, 5, 5, 0)
                };
                _sp[i] = new Separator
                {
                    Margin = new Thickness(0, 10, 0, 10)
                };
                for (var k = 0; k < _cevap; k++)
                {
                    _checkBox[i, k] = new CheckBox
                    {
                        Name = $"Soru{i}Cevap{k}",
                        Margin = new Thickness(0, 5, 0, 5)
                    };
                    _checkBox[i, k].Checked += CheckBox_Checked;
                    _cevaptextbox[i, k] = new TextBox
                    {
                        Style = FindResource("TextBox") as Style,
                        MinWidth = 600
                    };
                    _checkBox[i, k].Content = _cevaptextbox[i, k];
                }
            }
            void AddControlsToDockPanel(BindingBase binding, int i)
            {
                DockPanel.SetDock(_dockPanel[i], Dock.Top);
                DockPanel.SetDock(_dockPanel2[i], Dock.Top);

                _dockPanel[i].Children.Add(_label[i]);
                _dockPanel[i].Children.Add(_textbox[i]);
                BindingOperations.SetBinding(_textbox[i], WidthProperty, binding);
                soruDock.Children.Add(_dockPanel[i]);
                soruDock.Children.Add(_dockPanel2[i]);
                for (var k = 0; k < _cevap; k++)
                {
                    DockPanel.SetDock(_checkBox[i, k], Dock.Top);
                    _dockPanel2[i].Children.Add(_checkBox[i, k]);

                }
                _dockPanel2[i].Children.Add(_sp[i]);
            }
            if (ErrorControl()) return;
            soruDock.Children.Clear();
            AssignControlValues();
            var myBinding = new Binding
            {
                Path = new PropertyPath("soruDock")
            }; // Bir üst kontrolün genişliğini almanı sağlayan kod.
            for (var i = 0; i < _soru; i++)//Kontroller Burada Tanımlandı.
            {
                ControlCreation(i);
            }
            for (var i = 0; i < _soru; i++) // Kontroller Burada DockPanellere Eklendi.
            {
                AddControlsToDockPanel(myBinding, i);
            }
        }
        private void Kaydet(object sender, RoutedEventArgs e)
        {
            int AddQuestion(string testAdi, int süre)
            {
                using (var komut =
                    new SQLiteCommand(
                        "INSERT INTO testler(sure,soru_sayisi,cevap_sayisi,test_adi) VALUES(@sure,@soru,@cevap,@test); Select last_insert_rowid()",
                        DatabaseManager.Baglanti))
                {
                    komut.Parameters.AddWithValue("@test", testAdi);
                    komut.Parameters.AddWithValue("@sure", süre);
                    komut.Parameters.AddWithValue("@soru", _cevap);
                    komut.Parameters.AddWithValue("@cevap", _soru);
                    return Convert.ToInt32(komut.ExecuteScalar());
                }
            }
            SoruSistemi SoruSistemiOlustur(short testId)
            {
                var soruSis = new SoruSistemi(testId);
                for (var i = 0; i < _soru; i++)
                {
                    var checkBoxes = new List<CheckBox>();
                    for (var k = 0; k < _cevap; k++)
                    {
                        checkBoxes.Add(_checkBox[i, k]);
                    }
                    soruSis.SoruEkle(_textbox[i].Text, checkBoxes.ToArray());
                }

                return soruSis;
            }
            var test = TestTextbox.Text;
            var sure = Convert.ToInt32(SureTextbox.Text);
            if (DatabaseManager.Baglanti.State == ConnectionState.Closed)
            {
                try
                {
                    DatabaseManager.Baglanti.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata Kodu: 0x04 " + ex.Message);
                }
            }

            var sonuc = Convert.ToInt16(AddQuestion(test, sure));
            var soruSistemi = SoruSistemiOlustur(sonuc);

            soruSistemi.SorulariKaydet();
        }

        private void SayiKontrol(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DaraltGenislet(object sender, RoutedEventArgs e)
        {
            if (OlusturMenu.Visibility==Visibility.Visible)
            {
                GridLength g2 = new GridLength(35, GridUnitType.Pixel);
                OlusturMenu.Visibility = Visibility.Hidden;
                Column0.Width = g2;
                //DaraltGenisletButton.Background = new ImageBrush(new BitmapImage(new Uri(@"/Images/Genislet.png", UriKind.Relative)));
            }
            else
            {
                GridLength g2 = new GridLength(200, GridUnitType.Pixel);
                OlusturMenu.Visibility = Visibility.Visible;
                Column0.Width = g2;
            }
        }

        private void CheckBox_Checked(object sender, EventArgs e)
        {
        }
    }
}
