using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace httpserver
{
    internal class HTTPEchoService1
    {
       private static readonly string RootCatalog = "c:/temp"; 
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
            string rootcatalog = @"C:\Users\novak\Desktop\w3raw\httpserver";

            string[] words = message.Split(' ');
            sw.Write(words[1]);
            foreach (string word in words)
            {
                Console.WriteLine(word);
                
            }
            
            answer = "<html><body>HTTP/1.0 200 OK</body></html>";

            sw.WriteLine(answer);
            message = sr.ReadLine();

            FileStream fs = new FileStream(@"C:\temp\hej.txt",FileMode.Open,FileAccess.Read);

            fs.CopyTo(sw.BaseStream);

           fs.Flush();
           fs .Close();
           
            {



                ns.Close();
                connectionSocket.Close();
                serverSocket.Stop();




            }
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
            
