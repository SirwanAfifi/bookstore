using System;
using System.Linq;

namespace ReverseArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = 
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            var reverse = daysOfWeek.Reverse();

            //Array.Reverse(daysOfWeek);

            foreach (string day in daysOfWeek)
                Console.WriteLine(day);

            Console.ReadLine();
        }
    }
}
