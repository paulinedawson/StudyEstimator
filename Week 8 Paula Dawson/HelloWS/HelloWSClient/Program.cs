using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HelloWSClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWS.Service1 ws = new HelloWS.Service1();
            string s = ws.HelloWorld();
            Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}
