using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Text;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect("192.168.0.100", 8080);

            int i = 0;

            StreamWriter writer = new StreamWriter(client.GetStream(),
                                                   Encoding.ASCII);

            while (i < 5)
            {
                i++;

                writer.Write("31123213j12o312ij31io32" + i);
                writer.Flush();

                Thread.Sleep(2000);
            }
            client.Close();
        }
    }
}
