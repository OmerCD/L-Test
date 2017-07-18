using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneApp.Codes;
using Xamarin.Forms;

namespace PhoneApp
{
    public partial class MainPage : ContentPage
    {
        private Connection _connection;
        public MainPage()
        {
            InitializeComponent();
            _connection= new Connection("192.168.1.67","OmerCD");
            BindingContext = _connection;
        }

        private void BtnConnect_OnClicked(object sender, EventArgs e)
        {
            if (_connection.RoomIP.Length<11 || _connection.UserId.Length<3)
            {
                DisplayAlert("Uyarı", "Bilgileri doğru ve eksiksiz giriniz.", "Tamam");
            }
            else
            {
                _connection.Connect();
            }
        }
    }
}
