using System;
using Xamarin.Forms;
using Entity;
using LTest.Classes;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using System.Collections.Generic;

namespace Client
{
    public partial class NamePage : ContentPage
	{
        byte[] receivedBuf = new Byte[1024*1024*50];
        public static Test Test=null;
        public static List<Soru> Sorular = new List<Soru>();
        public static List<Cevap> Cevaplar = new List<Cevap>();
        public static Sure Sure=null;
        public static Kullanici Kullanici;
        object obj;
        public NamePage()
		{
			InitializeComponent();

        }
        private void SendName_Clicked(object sender, EventArgs e)
        {
            Kullanici = new Kullanici
            {
                KullaniciAdi = Name.Text,
                Sorular=new List<Kullanici.SoruOzellikleri>()
            };
            SendObject(Kullanici);
            Bekle();
        }

        public static object GetObject(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(data);
            return formatter.Deserialize(ms);
        }
        public static void SendObject(object obj)
        {
            try
            {
                BinaryFormatter _formatter = new BinaryFormatter();
                MemoryStream _memoryStream = new MemoryStream();
                _formatter.Serialize(_memoryStream, obj);
                byte[] buffer = _memoryStream.ToArray();
                IpPage.Socket.Send(buffer);
            }
            catch (Exception)
            {

            }
        }
        void Bekle()
        {
            while (true)
            {
                try
                {
                    var buf = new byte[8192];
                    var recData = IpPage.Socket.Receive(buf);

                    obj = GetObject(buf);

                    if (obj.GetType() == typeof(Test))
                    {
                        Test = (Test)obj;
                    }
                    else if (obj.GetType() == typeof(Sure))
                    {
                        Sure = (Sure)obj;
                    }
                    else if (obj.GetType()==typeof(Soru))
                    {
                        Sorular = (List<Soru>)obj;
                    }
                    else if (obj.GetType() == typeof(Cevap))
                    {
                        Cevaplar = (List<Cevap>)obj;
                    }
                    if (Test!=null && Sure!=null)
                    {
                        break;
                    }
                }
                catch (Exception)
                {

                }
            }
            Navigation.PushModalAsync(new BaslangicSure(Sure));
        }
    }
}
