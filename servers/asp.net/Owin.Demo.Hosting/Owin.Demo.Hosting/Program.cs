using System;
using Microsoft.Owin.Hosting;

namespace Owin.Demo.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:12345"))
            {
                Console.WriteLine("Listening to port 12345");
                Console.WriteLine("Press Enter to end...");
                Console.ReadLine();
            }
        }
    }
}
