using System.Net;

namespace server
{
    interface IConfig
    {
    }

    class Config : IConfig
    {
        public IPAddress address;
        public int port;
    }
}
