using System;
using System.Net.Sockets;
using System.Text;

using message;

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

        public void Listen ()
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
                    using (MessageSerializer serializer = new MessageSerializer())
                    {
                        var json = Request(_socket);
                        var method = serializer.getMethod(json); 

                        Message request = MessageProvider.GetMessage(method);
                        request.json = json;
                        request.Parse();
                        request.Action();
                        
                        Console.WriteLine("Request method : " + request.method);

                        Response(request.responce, _socket);
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Connection was lost...");
            _socket.Close();
            _listener.Stop();
        }

        private string Request(Socket socket)
        {
            byte[] bytes = new byte[1024];
                
            return Encoding.ASCII.GetString(bytes, 0, socket.Receive(bytes));
        }

        private void Response (string message, Socket socket)
        {
            // TODO: Here must be implemented lsp protocol messages 

            socket.Send(new ASCIIEncoding().GetBytes(message));
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
