using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace httpserver
{
    internal class HTTPEchoService1
    {
        public void StartServer()
        {
            TcpListener serverSocket = new TcpListener(8888);
            serverSocket.Start();

            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("maybe server");

            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            string message = sr.ReadLine();
            string answer = "";
            

            Console.WriteLine("Client: " + message);
            answer = "<html><body>HTTP/1.0 200 OK</body></html>";
            sw.WriteLine(answer);
            message = sr.ReadLine();


            ns.Close();
            connectionSocket.Close();
            serverSocket.Stop();

            


        }
    }
}

//string[] lines = { "HTTP/1.0 200 OK", 
                        // "HTTP/1.0 200 OK" };
            
          //  Console.WriteLine("maybe this works?");
          //  Console.WriteLine();
          //  foreach (string line in lines)
            //    Console.WriteLine(line);

         //   Console.WriteLine();

            
          //  Console.Out.NewLine = "\r\n\r\n";
          
           // Console.WriteLine("I think it does");
          //  Console.WriteLine();
         //   foreach (string line in lines)
// Console.WriteLine(line);
            
