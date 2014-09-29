using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace httpserver
{
    class HTTPEchoService1
    {
        public void StartServer()
        {
            TcpListener serverSocket = new TcpListener(8888);
            serverSocket.Start();

            string[] lines = { "HTTP/1.0 200 OK", 
                         "HTTP/1.0 200 OK" };
            
            Console.WriteLine("maybe this works?");
            Console.WriteLine();
            foreach (string line in lines)
                Console.WriteLine(line);

            Console.WriteLine();

            
            Console.Out.NewLine = "\r\n\r\n";
          
            Console.WriteLine("I think it does maybe");
            Console.WriteLine();
            foreach (string line in lines)
                Console.WriteLine(line);
            
        }
    }
}
