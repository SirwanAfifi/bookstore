using System;
using System.Collections.Generic;

namespace Enumerate_While_Changing
{
    class Program
    {
        static void Main(string[] args)
        {
            var days = new string[]
            {
                "Monday",
                "Tuesday",
                "Wednesday"
            };

            foreach (string day in days)
            {
                days[1] = "2nd day";
                Console.WriteLine(day);
            }

            Console.ReadLine();
        }
    }
}
