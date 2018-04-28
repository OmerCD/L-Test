using System;
using System.Net;
using System.Net.Sockets;
using System.Windows;

namespace LTest.Classes
{
    public class Listener
    {
        Socket _socket;
        private bool _listening;
        private int _port;

        public bool GetListening()
        {
            return _listening;
        }

        private void SetListening(bool value)
        {
            _listening = value;
        }

        public int GetPort()
        {
            return _port;
        }

        private void SetPort(int value)
        {
            _port = value;
        }

        public Listener(int port)
        {
            SetPort(port);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            if (GetListening())
                return;

            _socket.Bind(new IPEndPoint(0, _port));
            _socket.Listen(0);
            _socket.BeginAccept(Callback, null);
            SetListening(true);
        }

        public void Stop()
        {
            if (!GetListening())
                return;
            _socket.Close();
            _socket.Dispose();
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        void Callback(IAsyncResult ar)
        {
            try
            {
                var socket = this._socket.EndAccept(ar);
                SocketAccepted?.Invoke(socket);
                _socket.BeginAccept(Callback, null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public delegate void SocketAcceptedHandler(Socket e);
        public event SocketAcceptedHandler SocketAccepted;
    }
}
