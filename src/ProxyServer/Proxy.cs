using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyServer
{
    class Proxy
    {
        Socket _Server;
        Thread _Listen;

        public Proxy(int _Port = 8888)
        {
            Data._IsRunning = true;

            //Load file blacklist.conf
            if (!File.Exists(Data._FileBlackList))
            {
                Data._ShowListView.Add("blacklist.conf does not exist yet. Create file!");
                using (File.Create(Data._FileBlackList)) { } ;
            }
            else
            {
                string[] lines = File.ReadAllLines(Data._FileBlackList);
                Data._BlockedSite = lines.ToList<string>();
            }

            //Create Server
            _Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint _LocalEndPoint = new IPEndPoint(IPAddress.Loopback, _Port);
            _Server.Bind(_LocalEndPoint);
            _Server.Listen(100);
            
            Data._ShowListView.Add("Waiting for client on port " + _Server.LocalEndPoint);

            //new Thread(new ThreadStart(Listen)).Start();
            _Listen = new Thread(Listen);
            Data._Threads.Add(_Listen);
            _Listen.IsBackground = true;
            _Listen.Start();
        }

        public void Listen()
        {
            while (Data._IsRunning)
            {
                try
                {
                    Socket _client = _Server.Accept();
                    if (_client != null)
                    {
                        RequestHandler _RequestHandler = new RequestHandler(_client);
                        Thread thread = new Thread(new ThreadStart(_RequestHandler.Handler));
                        Data._Threads.Add(thread);
                        thread.IsBackground = true;
                        thread.Start();
                    }
                }
                catch (SocketException)
                {
                    Data._ShowListView.Add("Server closed");
                }

            }
        }

        public string GetLocal()
        {
            return _Server.LocalEndPoint.ToString();
        }

        public void CloseServer()
        {
            Data._IsRunning = false;
            foreach (var item in Data._Threads)
            {
                if (item.IsAlive)
                {
                    item.Interrupt();
                }
            }
            _Server.Close();
        }        
    }
}
