using System.Collections.Generic;
using System.Threading;

namespace ProxyServer
{
    static class Data
    {
        public static List<string> _BlockedSite = new List<string>();
        public static volatile bool _IsRunning = true;
        public static List<Thread> _Threads = new List<Thread>();
        public static List<string> _ShowListView = new List<string>();
        public const string _FileBlackList = "blacklist.conf";

        public static bool IsBlockedSite(string _Url)
        {
            foreach (var item in _BlockedSite)
            {
                if (_Url.ToLower().Contains(item.ToLower()))
                    return true;
            }
            return false;
        }

        public static void RemoveBlockSite(string _Url)
        {

            while (_BlockedSite.Remove(_Url.ToLower())) { }
        }
    }
}
