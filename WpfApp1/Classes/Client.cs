using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ltest.Classes
{
    public class Client
    {
        private string id;
        private IPEndPoint endPoint;
        Socket socket;

        public string GetId()
        {
            return id;
        }

        private void SetId(string value)
        {
            id = value;
        }      

        public IPEndPoint GetEndPoint()
        {
            return endPoint;
        }

        private void SetEndPoint(IPEndPoint value)
        {
            endPoint = value;
        }

        public Client(Socket accepted)
        {
            socket = accepted;
            id = Guid.NewGuid().ToString();
            endPoint = (IPEndPoint)socket.RemoteEndPoint;
            socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, Callback, null);
        }

        void Callback(IAsyncResult ar)
        {

                socket.EndReceive(ar);
                byte[] buf = new byte[8192];
                int recData = socket.Receive(buf, buf.Length, 0);
                if (recData<buf.Length)
                {
                    Array.Resize<byte>(ref buf,recData);
                }
                Received?.Invoke(this, buf);
            socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, Callback, null);
        }

        public void Close()
        {
            socket.Close();
            socket.Dispose();
        }

        public delegate void ClientReceivedHandler(Client sender, byte[] data);
        public delegate void ClientDisconnectedHandler(Client sender);

        public event ClientReceivedHandler Received;
        public event ClientDisconnectedHandler Disconnected;
    }
}
