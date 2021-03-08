using System.Net;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = new Config (){
                address = IPAddress.Parse("192.168.0.100"),
                port = 8080
            };

            Server server = new Server(config);
            server.Listen();
        }
    }
}
