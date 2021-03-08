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

            StreamWriter writer = new StreamWriter(client.GetStream(),
                                                   Encoding.ASCII);
            Stream reader = client.GetStream();

            byte[] resived;
            
            string json =  @"{
'jsonrpc': '2.0',
'id': 1,
'method': 'textDocument'
}";

            while (true)
            {
                // writer.Write(Console.ReadLine());
                writer.Write(json);
                writer.Flush();

                resived = new byte[client.ReceiveBufferSize];
                reader.Read(resived, 0, client.ReceiveBufferSize);

                string msg = Encoding.ASCII.GetString(resived);
                Console.WriteLine("Recived : " + msg);
                Thread.Sleep(2000);
            }
            client.Close();
        }
    }
}
