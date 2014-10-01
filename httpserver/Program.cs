using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace httpserver
{
    class Program
    {
        private static void Main(string[] args)
        
        {

        while (true)
            {
                HTTPEchoService1 HTTPServer1 = new HTTPEchoService1();
                Thread myThread = new Thread(new ThreadStart(HTTPServer1.StartServer));
                HTTPServer1.StartServer();

            }
        }



    }

   
        }
    




