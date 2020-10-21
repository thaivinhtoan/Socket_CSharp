using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProxyServer
{
    class WebServer
    {
        public static void ReceiveRequest(Socket _Server, string _Request)
        {
            byte[] _Buffer = System.Text.Encoding.ASCII.GetBytes(_Request);
            _Server.Send(_Buffer, _Buffer.Length, SocketFlags.None);
        }

        public static string SendResponse(Socket _Server)
        {
            string _Response = "";
            byte[] _Buffer = null;
            int _BytesRec;
            do
            {
                _Buffer = new byte[4096];
                _BytesRec = _Server.Receive(_Buffer, 1024, SocketFlags.None);
                _Response = Encoding.ASCII.GetString(_Buffer, 0, _BytesRec);
                _Buffer = null;
            } while (_BytesRec == 1024);
            return _Response;
        }
    }
}
