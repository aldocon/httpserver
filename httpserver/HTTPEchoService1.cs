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
    class HTTPEchoService1
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

            string message = "hello";
            string answer = "";
            while (message != null && message != "")
            {
                Console.WriteLine("client: " + message);
                //answer = message.ToUpper();
                //sw.WriteLine(answer);
                //message = sr.ReadLine();
                sw.WriteLine(message);

            }

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
            
