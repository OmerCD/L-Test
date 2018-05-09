using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace LTest.Classes
{
    public static class ClientListener
    {
        private static Socket _socket;
        private static bool _listening=false;
        private static int _port;
        private static string _ip;

        public static bool Listening { get => _listening; set => _listening = value; }

        public static int Port { get => _port; set => _port = value; }

        public static Socket Socket { get => _socket; set => _socket = value; }

        public static string Ip { get => _ip; set => _ip = value; }


        public static bool Start()
        {
            if (_listening)return false;

            _listening = true;
            IAsyncResult result=_socket.BeginConnect(_ip, _port, null, null);
            return result.AsyncWaitHandle.WaitOne(5000, true);
        }

        public static void Stop()
        {
            if (!_listening)
                return;
            _listening = false;
            Socket.Close();
            Socket.Dispose();
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public static void SendObject(object obj)
        {
            try
            {
                BinaryFormatter _formatter = new BinaryFormatter();
                MemoryStream _memoryStream = new MemoryStream();
                _formatter.Serialize(_memoryStream, obj);
                byte[] buffer = _memoryStream.ToArray();
                _socket.Send(buffer);
            }
            catch (Exception)
            {

            }
        }




    }
}
