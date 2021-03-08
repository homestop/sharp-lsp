using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect("192.168.0.100", 8080);

            int i = 0;

            while (i < 5)
            {
                Console.WriteLine("Waiting");

                Thread.Sleep(2000);
                i++;
            }
            client.Close();
        }
    }
}
