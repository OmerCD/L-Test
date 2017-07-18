using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Controls;

namespace WpfApp1.Classes
{
    internal class Server
    {
        private TcpListener _tcpDinleyici;
        private string _mesaj;
        public bool StartServer(int port)
        {
            try
            {
                _tcpDinleyici = new TcpListener(IPAddress.Any, port);
                _tcpDinleyici.Start();
                _tcpDinleyici.BeginAcceptTcpClient(ProcessEvents, _tcpDinleyici);
                _mesaj="Dinlenen Port: " + port ;
            }
            catch (Exception e)
            {
                _mesaj="Hata Gerçekleşti: 0x01 "+e;
                return false;
            }
            return true;
        }
        private void ProcessEvents(IAsyncResult asyn)
        {
            try
            {
                var dinlemeIslemi = (TcpListener)asyn.AsyncState;
                var tcpIstemci = dinlemeIslemi.EndAcceptTcpClient(asyn);
                var akis = tcpIstemci.GetStream();
                if (akis.CanRead)
                {
                    var akisOkuyucu = new StreamReader(akis);
                    _mesaj = akisOkuyucu.ReadToEnd();
                    akisOkuyucu.Close();
                }
                akis.Close();
                tcpIstemci.Close();
                _tcpDinleyici.BeginAcceptTcpClient(ProcessEvents, _tcpDinleyici);
            }
            catch (Exception e)
            {
                _mesaj="Hata Gerçekleşti: 0x02 "+e;
            }
        }
        public void Yazdir(Label lbl)
        {
            lbl.Content=_mesaj;
        }
    }
}
