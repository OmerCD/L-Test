using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Classes
{
    class Server
    {
        private TcpListener tcpDinleyici;
        private string mesaj;
        public bool StartServer(int port)
        {
            try
            {
                tcpDinleyici = new TcpListener(IPAddress.Any, port);
                tcpDinleyici.Start();
                tcpDinleyici.BeginAcceptTcpClient(new AsyncCallback(this.ProcessEvents), tcpDinleyici);
                mesaj="Dinlenen Port: " + port ;
            }
            catch (Exception e)
            {
                mesaj="Hata Gerçekleşti: 0x01 "+e.ToString();
                return false;
            }
            return true;
        }
        private void ProcessEvents(IAsyncResult asyn)
        {
            try
            {
                TcpListener dinlemeIslemi = (TcpListener)asyn.AsyncState;
                TcpClient tcpIstemci = dinlemeIslemi.EndAcceptTcpClient(asyn);
                NetworkStream akis = tcpIstemci.GetStream();
                if (akis.CanRead)
                {
                    StreamReader akisOkuyucu = new StreamReader(akis);
                    mesaj = akisOkuyucu.ReadToEnd();
                    akisOkuyucu.Close();
                }
                akis.Close();
                tcpIstemci.Close();
                tcpDinleyici.BeginAcceptTcpClient(new AsyncCallback(this.ProcessEvents), tcpDinleyici);
            }
            catch (Exception e)
            {
                mesaj="Hata Gerçekleşti: 0x02 "+e.ToString();
            }
        }
        public void Yazdir(Label lbl)
        {
            lbl.Content=mesaj;
        }
    }
}
