using System;
using System.Net;
using System.Net.Sockets;

namespace LTest.Classes
{
    public class Client
    {
        private string _id;
        private IPEndPoint _endPoint;
        private readonly Socket _socket;

        public string GetId()
        {
            return _id;
        }

        private void SetId(string value)
        {
            _id = value;
        }      

        public IPEndPoint GetEndPoint()
        {
            return _endPoint;
        }

        private void SetEndPoint(IPEndPoint value)
        {
            _endPoint = value;
        }

        public Client(Socket accepted)
        {
            _socket = accepted;
            _id = Guid.NewGuid().ToString();
            _endPoint = (IPEndPoint)_socket.RemoteEndPoint;
            _socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, Callback, null);
        }

        void Callback(IAsyncResult ar)
        {

                _socket.EndReceive(ar);
                var buf = new byte[8192];
                var recData = _socket.Receive(buf, buf.Length, 0);
                if (recData<buf.Length)
                {
                    Array.Resize<byte>(ref buf,recData);
                }
                Received?.Invoke(this, buf);
            _socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, Callback, null);
        }

        public void Close()
        {
            _socket.Close();
            _socket.Dispose();
        }

        public delegate void ClientReceivedHandler(Client sender, byte[] data);
        public delegate void ClientDisconnectedHandler(Client sender);

        public event ClientReceivedHandler Received;
        public event ClientDisconnectedHandler Disconnected;


    }
}
