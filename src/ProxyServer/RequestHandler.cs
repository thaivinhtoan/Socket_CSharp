using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyServer
{
    class RequestHandler
    {
        private Socket _Client;

        public RequestHandler(Socket _Client)
        {
            this._Client = _Client;
        }

        public void Handler()
        {
            string _Request = ReceiveRequest();
            if (_Request == string.Empty) return;
           
            string _RequestLine = _Request.Split('\n')[0];
            Data._ShowListView.Add("Http request for " + _RequestLine);

            if (_Request.Contains("CONNECT"))
            {
                Data._ShowListView.Add("Program does not support for https");
                HandlerHttpsRequest();
                return;
            }

            string _Host = GetHost(_Request);
            if (_Host == string.Empty)
            {
                Data._ShowListView.Add("Host is invalid");
                return;
            }
            if (Data.IsBlockedSite(_Host))
            {
                Data._ShowListView.Add("Request for blocked site");
                ResponseBlockedSite();
                return;
            }
            int _Port = 80;

            Socket _WebServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress[] addresslist = Dns.GetHostAddresses(_Host);
            IPEndPoint remoteEP = new IPEndPoint(addresslist[0], _Port);
            _WebServer.Connect(remoteEP);

            WebServer.ReceiveRequest(_WebServer, _Request);

            byte[] buffer = new byte[512];
            int read;
            do
            {
                read = _WebServer.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                if (read > 0)
                {
                    try
                    {
                        _Client.Send(buffer, 0, read, SocketFlags.None);
                    }
                    catch
                    {
                        break;
                    }
                }
            } while (read > 0);

            Data._ShowListView.Add("Http response success for request " + _RequestLine);

            _WebServer.Shutdown(SocketShutdown.Both);
            _WebServer.Close();
            _Client.Shutdown(SocketShutdown.Both);
            _Client.Close();
        }

        private void HandlerHttpsRequest()
        {
            String line = "HTTP/1.0 200 Connection establishe" +
                    "User-Agent: ProxyServer/1.0\r\n" +
                    "\r\n";
            byte[] buffer = Encoding.ASCII.GetBytes(line);
            NetworkStream network = new NetworkStream(_Client);
            network.Write(buffer, 0, buffer.Length);
            network.Flush();
            network.Close();
            _Client.Shutdown(SocketShutdown.Both);
            _Client.Close();
        }

        private void ResponseBlockedSite()
        {
            String line = "HTTP/1.0 403 Access Forbidden \r\n" +
                    "User-Agent: ProxyServer/1.0\r\n" +
                    "\r\n";
            byte[] buffer = Encoding.ASCII.GetBytes(line);
            NetworkStream network = new NetworkStream(_Client);
            network.Write(buffer, 0, buffer.Length);
            network.Flush();
            network.Close();
            _Client.Shutdown(SocketShutdown.Both);
            _Client.Close();
        }

        private int GetPort(string request)
        {
            return Convert.ToInt32(request.Split('\n')[0].Split(' ')[1].Split(':')[1]);
        }

        private void SendResponse(string _Response)
        {
            byte[] _Buffer = Encoding.ASCII.GetBytes(_Response);
            _Client.Send(_Buffer, _Buffer.Length, SocketFlags.None);
        }

        private string GetHost(string _Request)
        {
            string _Host = "";
            string[] _Tokens = _Request.Split('\n');
            for (int i = 1; i < _Tokens.Length; i++)
            {
                string[] _HeaderElement = _Tokens[i].Split(':');
                if (_HeaderElement.Length >= 2)
                {
                    if (_HeaderElement[0].ToLower().Equals("host"))
                    {
                        _Host = _HeaderElement[1].Trim();
                        break;
                    }
                }
            }
            return _Host;
        }

        private string ReceiveRequest()
        {
            string _Request = "";
            byte[] _Buffer = null;
            int _BytesRec;
            do
            {
                _Buffer = new byte[4096];
                try
                {
                    _BytesRec = _Client.Receive(_Buffer, 1024, SocketFlags.None);
                }
                catch
                {
                    return "";
                }
                _Request += Encoding.ASCII.GetString(_Buffer, 0, _BytesRec);
                _Buffer = null;
            } while (_BytesRec == 1024);
            return _Request;
        }
    }
}
