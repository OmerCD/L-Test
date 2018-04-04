using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Net.Sockets;
using WpfApp1.Classes;
using WpfApp1.Classes.Business_Logic_Layer;
using WpfApp1.Classes.EntityLayer;
using System.Net;
using System.Text;
using ltest;
using ltest.Classes;
using WpfApp1.UserControllers;
using ltest.UserControllers.UcBaslangic;

namespace WpfApp1
{
    /// <summary>
    /// ucBaslangic.xaml etkileşim mantığı
    /// </summary>
    public partial class UcBaslangic : UserControl
    {
        PermanentTrigger permanent = new PermanentTrigger();

        public UcBaslangic() 
        {
            InitializeComponent();
        }


        private void UcOdaBaslat(object sender, RoutedEventArgs e)
        {
            permanent.Change(dockPanel, (Button)sender);
            UserControlClass.ControlAdd(anaMenuIcerik, new adim1());
        }

        private void UcTestBaslat(object sender, RoutedEventArgs e)
        {
            permanent.Change(dockPanel, (Button)sender);
            UserControlClass.ControlAdd(anaMenuIcerik, new adim2());
        }

        private void UcBitir(object sender, RoutedEventArgs e)
        {
            permanent.Change(dockPanel, (Button)sender);
            UserControlClass.ControlAdd(anaMenuIcerik, new adim3());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UserControlClass.ControlAdd(anaMenuIcerik, new adim1());
        }
    }
}
