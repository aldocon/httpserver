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
            string StatusLineGood = "";
            string answerbad = "";
            string ContentTypeHeader = "Content-Type: application/octet-stream";
            StatusLineGood = "HTTP/1.0 200 OK";

            answerbad = "HTTP/1.0 400 Bad Request";
            if (message == null)
            {
                return;
            }
            else
            {
                string[] words = message.Split(' ');
                foreach (string word in words)
                {
                    Console.WriteLine(word);

                }

                if (words[0] == "GET" || words[0] == "HEAD" || words[0] == "POST")
                {

                    string Filepath = RootCatalog + words[1];
                    FileInfo fi = new FileInfo(Filepath);
                    if (fi.Exists)
                    {
                        FileStream fs = new FileStream(Filepath, FileMode.Open, FileAccess.Read);
                        sw.WriteLine(StatusLineGood);
                        if (fi.Extension == ".html")
                        {
                            ContentTypeHeader = "Content-Type: text/html";
                        }
                        sw.WriteLine(ContentTypeHeader);
                        sw.WriteLine();
                        // Alt efter den tomme linje er body. 

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
                    else
                    {
                        sw.WriteLine(StatusLineGood);
                    }

                }
            }

            //string[] dots = message.split('.');
            //foreach (string dot in dots)
            //{
            //    sw.writeline(dots[1]);
            //}




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



            


