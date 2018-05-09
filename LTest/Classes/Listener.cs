using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;

namespace LTest.Classes
{
    public class Listener
    {
        private Socket _socket;
        private bool _listening;
        private List<Client> clients;

        public bool Listening() => _listening;

        private void Listening(bool value) => _listening = value;

        public int Port { get; }

        public List<Client> Clients { get => clients; set => clients = value; }

        public Listener(int port)
        {
            Port = port;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            if (Listening())
                return;
            _listening = true;
            _socket.Bind(new IPEndPoint(0, Port));
            _socket.Listen(0);
            _socket.BeginAccept(Callback, null);
        }

        public void Stop()
        {
            if (!Listening())
                return;
            _listening = false;
            _socket.Close();
            _socket.Dispose();
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void Callback(IAsyncResult ar)
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

        public void SendObject(object obj)
        {
            BinaryFormatter _formatter = new BinaryFormatter();
            MemoryStream _memoryStream = new MemoryStream();
            _formatter.Serialize(_memoryStream, obj);
            byte[] buffer = _memoryStream.ToArray();
            foreach (var client in clients)
            {
                client.Socket.Send(buffer);
            }
        }

        public void SendText(string text)
        {
            foreach (var client in clients)
            {
                client.Socket.Send(Encoding.UTF8.GetBytes(text));
            }
        }

        public object GetObject(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(data);
            if (ms!=null)
            {
                return formatter.Deserialize(ms);
            }
            else
            {
                return null;
            }
        }

        public delegate void SocketAcceptedHandler(Socket e);
        public event SocketAcceptedHandler SocketAccepted;
    }
}
