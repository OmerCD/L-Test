using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entity;

namespace LTest.Classes
{
    public static class ClientListener
    {
        private static Socket _socket;
        private static bool _listening=false;
        private static int _port;
        private static string _ip;
        private static ClientKullanici _kullanici;

        public static bool Listening { get => _listening; set => _listening = value; }

        public static int Port { get => _port; set => _port = value; }

        public static Socket Socket { get => _socket;}

        public static string Ip { get => _ip; set => _ip = value; }

        public static ClientKullanici Kullanici { get => _kullanici; set => _kullanici = value; }

        public static bool Start()
        {

            if (_listening)return false;

            _listening = true;
            _port = 100;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IAsyncResult result =_socket.BeginConnect(_ip, _port, null, null);
            return result.AsyncWaitHandle.WaitOne(5000, true);
        }

        public static void Stop()
        {
            if (!_listening)
                return;
            _listening = false;
            _socket.Close();
            _socket.Dispose();
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public static void SendObject()
        {
            try
            {
                BinaryFormatter _formatter = new BinaryFormatter();
                MemoryStream _memoryStream = new MemoryStream();
                _formatter.Serialize(_memoryStream, _kullanici);
                byte[] buffer = _memoryStream.ToArray();
                _socket.Send(buffer);
            }
            catch (Exception)
            {

            }
        }

        public static object GetObject(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(data);
            return formatter.Deserialize(ms);
        }


        public static bool WaitForData()
        {
            Test test = null;
            Sure sure = null;
            List<Soru> sorular = null;
            List<Cevap> cevaplar = null;

            var ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;
            while (true)
            {
                Task.Factory.StartNew(() =>
                {
                    Object obj;
                    byte[] buf = new Byte[1024 * 1024 * 50];

                    var recData = Socket.Receive(buf);

                    obj = GetObject(buf);

                    if (obj.GetType() == typeof(Test))
                    {
                        test = (Test)obj;
                    }
                    else if (obj.GetType() == typeof(Sure))
                    {
                        sure = (Sure)obj;
                    }
                    else if (obj.GetType() == typeof(Soru))
                    {
                        sorular = (List<Soru>)obj;
                    }
                    else if (obj.GetType() == typeof(Cevap))
                    {
                        cevaplar = (List<Cevap>)obj;
                    }
                    Thread.Sleep(100);

                    byte[] textbuf = new byte[8192];
                    if (test != null && sure != null && sorular != null && cevaplar != null)
                    {
                        textbuf = Encoding.UTF8.GetBytes("Nesneler Alındı");
                        Socket.Send(textbuf);
                        ts.Cancel();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }, ct);
            }
        }

    }
}
