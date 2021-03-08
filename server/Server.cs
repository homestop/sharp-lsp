using System;
using System.Net.Sockets;

namespace server
{
    class Server
    {
        public Config config { private set; get; }

        private TcpListener _listener; 
        private Socket _socket;

        public Server(IConfig config)
        {
            this.config = (Config)config;
        }

        public bool Listen ()
        {
            Console.WriteLine("Start listening on "
                              + config.address + ":"
                              + config.port);
            try
            {
                _listener = new TcpListener(config.address,
                                            config.port);
                _listener.Start();

                _socket = _listener.AcceptSocket();

                while (isLostConnection(_socket))
                {
                    Console.WriteLine("Accepted...");
                }

                Console.WriteLine("Connection was lost...");
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }

        private bool isLostConnection (Socket socket)
        {
            bool request = socket.Poll(100, SelectMode.SelectRead);
            bool active = socket.Available == 0;

            if (request && active)
                return false;
            else
                return true;
        }
    }
}
