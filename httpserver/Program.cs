using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace httpserver
{
    class Program
    {
        static void Main(string[] args)
        {
            HTTPEchoService1 HTTPServer1 = new HTTPEchoService1();
            HTTPServer1.StartServer();
        }
    }
}
