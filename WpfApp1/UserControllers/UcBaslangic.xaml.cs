using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Net.Sockets;
using System.IO;
using WpfApp1.Classes;

namespace WpfApp1
{
    /// <summary>
    /// ucBaslangic.xaml etkileşim mantığı
    /// </summary>
    public partial class ucBaslangic : UserControl
    {
        public ucBaslangic()
        {
            InitializeComponent();
        }
        private void OdayiOlustur(object sender, RoutedEventArgs e)
        {
            Server sunucu = new Server();
            sunucu.StartServer(1234);
        }
    }
}
