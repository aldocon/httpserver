using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace httpserver
{
    internal class HTTPEchoService1
    {

        private static readonly string RootCatalog = "c:/temp";
        public void StartServer()
        {
            string sSource;
            string sLog;
            string sEvent;

            sSource = "Server startet";
            sLog = "Application";
            sEvent = "Server Startet";
            EventLog.WriteEntry(sSource, sEvent);
            EventLog.WriteEntry(sSource, sEvent,
            EventLogEntryType.Warning, 500);

            TcpListener serverSocket = new TcpListener(8888);
            serverSocket.Start();


            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("maybe server");

            sSource = "Forspørgsel Modtaget";
            sLog = "Application";
            sEvent = "Request Modtaget";
            EventLog.WriteEntry(sSource, sEvent);
            EventLog.WriteEntry(sSource, sEvent,
            EventLogEntryType.Warning, 500);

            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            string message = sr.ReadLine();
            string answergood = "";


            string[] words = message.Split(' ');
            foreach (string word in words)
            {
                Console.WriteLine(word);



            }

            answergood = "<html><body>HTTP/1.0 200 OK</body></html>";

            sw.WriteLine(answergood);
            message = sr.ReadLine();


            if (words[1].Length > 1)
            {
                FileStream fs = new FileStream(RootCatalog + words[1], FileMode.Open, FileAccess.Read);

                fs.CopyTo(sw.BaseStream);
                fs.Flush();
                fs.Close();
                sSource = "Forspørgsel Sendt";
                sLog = "Application";
                sEvent = "Fil sendt";
                EventLog.WriteEntry(sSource, sEvent);
                EventLog.WriteEntry(sSource, sEvent,
                    EventLogEntryType.Warning, 601);
            }

            {
                ns.Close();
                connectionSocket.Close();
                serverSocket.Stop();
                sSource = "Server lukket";
                sLog = "Application";
                sEvent = "Server Stoppet";
                EventLog.WriteEntry(sSource, sEvent);
                EventLog.WriteEntry(sSource, sEvent,
                    EventLogEntryType.Warning, 501);


            }
        }


    }
}


            


