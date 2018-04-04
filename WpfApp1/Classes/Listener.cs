using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace WpfApp1.Classes
{
    public class Listener
    {
        Socket _socket;
        private bool listening;
        private int port;

        public bool GetListening()
        {
            return listening;
        }

        private void SetListening(bool value)
        {
            listening = value;
        }

        public int GetPort()
        {
            return port;
        }

        private void SetPort(int value)
        {
            port = value;
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

            _socket.Bind(new IPEndPoint(0, port));
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
            Socket _socket = this._socket.EndAccept(ar);
            SocketAccepted?.Invoke(_socket);
            this._socket.BeginAccept(Callback, null);
        }

        public delegate void SocketAcceptedHandler(Socket e);
        public event SocketAcceptedHandler SocketAccepted;
    }
}
