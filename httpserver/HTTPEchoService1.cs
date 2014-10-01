using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            

            string[] words = message.Split(' ');
            sw.Write(words[1]);
            foreach (string word in words)
            {
                Console.WriteLine(word);
                
            }

            
            answer = "<html><body>HTTP/1.0 200 OK</body></html>";

            sw.WriteLine(answer);
            message = sr.ReadLine();




           if (words[1].Length > 1)
           {
               FileStream fs = new FileStream(RootCatalog + words[1], FileMode.Open, FileAccess.Read);
           fs.CopyTo(sw.BaseStream);

           fs.Flush();
           fs .Close();
           }
           
           
           
         

            
           
            {



                ns.Close();
                connectionSocket.Close();
                serverSocket.Stop();


            }
        }
    }
}


            
