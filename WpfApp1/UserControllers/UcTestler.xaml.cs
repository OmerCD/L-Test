using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Text.RegularExpressions;

namespace WpfApp1.UserControllers
{
    /// <summary>
    /// UcTestler.xaml etkileşim mantığı
    /// </summary>
    public partial class UcTestler : UserControl
    {
        public UcTestler()
        {
            InitializeComponent();
            baglanti = new SQLiteConnection("Data Source=C:\\Users\\Hasan\\Documents\\Visual Studio 2017\\Projects\\WpfApp1\\WpfApp1\\data.db");           
        }
        int soru, cevap;
        TextBox[] textbox;
        TextBox[,] cevaptextbox;
        DockPanel[] dockPanel;
        Label[] label;
        DockPanel[] dockPanel2;
        CheckBox[,] checkBox;
        Button[] buton;
        Separator[] sp;
        public static SQLiteConnection baglanti;
        SQLiteCommand komut;
        SQLiteDataReader oku;
        bool BosKontrol(TextBox txt)
        {
            if (String.IsNullOrEmpty(txt.Text))
            {
                return false;

            }
            else
            {
                return true;
            }
        }
        private void Ayarla_Click(object sender, RoutedEventArgs e)
        {
            soruDock.Children.Clear();
            soru = Convert.ToInt16(soruTextbox.Text);
            cevap = Convert.ToInt16(cevapTextbox.Text);
            dockPanel = new DockPanel[soru];
            label = new Label[soru]; 
            dockPanel2 = new DockPanel[soru];
            textbox = new TextBox[soru];
            sp = new Separator[soru];
            cevaptextbox = new TextBox[soru, cevap];
            checkBox = new CheckBox[soru, cevap];
            Binding myBinding = new Binding()
            {
                Path = new PropertyPath("soruDock")
            }; // Bir üst kontrolün genişliğini almanı sağlayan kod.
            for (int i = 0; i < soru; i++)//Kontroller Burada Tanımlandı.
            {
                dockPanel[i] = new DockPanel()
                {
                    Margin = new Thickness(0, 0, 0, 10),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Width = Double.NaN
                };
                label[i] = new Label()
                {
                    Content = "Soru " + (i + 1) + ":",
                    Style = FindResource("Label") as Style,
                    Width = 120,
                    Height = Double.NaN, // Auto için bunu yazdık. Niye acaba?
                    Background = Brushes.CornflowerBlue
                };
                textbox[i] = new TextBox()
                {
                    Style = FindResource("TextBox") as Style,
                    Name = $"SoruTextBox{i}"
                };
                dockPanel2[i] = new DockPanel()
                {
                    Name = $"stackPanel{i.ToString()}",
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Margin= new Thickness(0,5,5,0)
                };
                sp[i] = new Separator()
                {
                    Margin = new Thickness(0, 10, 0, 10)
                };
                for (int k = 0; k < cevap; k++)
                {
                    checkBox[i, k] = new CheckBox()
                    {
                        Name = $"Soru{i}Cevap{k}",
                        Margin = new Thickness(0, 5, 0, 5),
                    };
                    checkBox[i, k].Checked += new RoutedEventHandler(CheckBox_Checked);
                    cevaptextbox[i, k] = new TextBox()
                    {
                        Style = FindResource("TextBox") as Style,      
                        MinWidth=600,
                    };
                    checkBox[i, k].Content = cevaptextbox[i, k];
                }
            }
            for (int i = 0; i < soru; i++) // Kontroller Burada DockPanellere Eklendi.
            {
                DockPanel.SetDock(dockPanel[i], Dock.Top);
                DockPanel.SetDock(dockPanel2[i], Dock.Top);

                dockPanel[i].Children.Add(label[i]);
                dockPanel[i].Children.Add(textbox[i]);
                BindingOperations.SetBinding(textbox[i], WidthProperty, myBinding);
                soruDock.Children.Add(dockPanel[i]);
                soruDock.Children.Add(dockPanel2[i]);
                for (int k = 0; k < cevap; k++)
                {
                    DockPanel.SetDock(checkBox[i, k], Dock.Top);
                    dockPanel2[i].Children.Add(checkBox[i, k]);
                    
                }
                dockPanel2[i].Children.Add(sp[i]);
            }
        }

        private void Kaydet(object sender, RoutedEventArgs e)
        {
            string test = testTextbox.Text;
            int sure = Convert.ToInt32(sureTextbox.Text);
            if (baglanti.State==ConnectionState.Closed)
            {
                try
                {
                    baglanti.Open();
                    MessageBox.Show("Baglanti Sağlandı");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata Kodu: 0x04 " + ex.Message);
                }
            }
            komut = new SQLiteCommand("INSERT INTO testler(sure,soru_sayisi,cevap_sayisi,test_adi) VALUES(@sure,@soru,@cevap,@test); Select last_insert_rowid()", baglanti);
            komut.Parameters.AddWithValue("@test",test);
            komut.Parameters.AddWithValue("@sure", sure);
            komut.Parameters.AddWithValue("@soru", cevap);
            komut.Parameters.AddWithValue("@cevap", soru);
            //komut.ExecuteNonQuery();
            var sonuc = Convert.ToInt16(komut.ExecuteScalar());


            var soruSistemi = new Classes.SoruSistemi(sonuc);
            for (int i = 0; i < soru; i++)
            {
                var checkBoxes = new System.Collections.Generic.List<CheckBox>();
                for (int k = 0; k < cevap; k++)
                {
                    checkBoxes.Add(checkBox[i, k]);
                }
                soruSistemi.SoruEkle(textbox[i].Text, checkBoxes.ToArray());
            }

            soruSistemi.SorulariKaydet();
        }

        private void MenuClick(object sender, RoutedEventArgs e)
        {
        }

        private void SayiKontrol(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CheckBox_Checked(object sender, EventArgs e)
        {
        }
    }
}
