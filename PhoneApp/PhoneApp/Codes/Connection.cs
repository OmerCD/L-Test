using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sockets.Plugin;

namespace PhoneApp.Codes
{
    class Connection
    {
        // ReSharper disable once InconsistentNaming
        public Connection(string roomIP = "", string userId = "")
        {
            RoomIP = roomIP;
            UserId = userId;

        }

        // ReSharper disable once InconsistentNaming
        public string RoomIP { get; set; }
        public string UserId { get; set; }
        private TcpSocketClient _client;

        public async void Connect()
        {
            _client= new TcpSocketClient();
            var address = RoomIP;
            var port = 3333;

            await _client.ConnectAsync(address, port);

            var message = Encoding.UTF8.GetBytes(UserId);
            await _client.WriteStream.WriteAsync(message, 0, message.Length);
            await _client.WriteStream.FlushAsync();
        }
    }
   
}
