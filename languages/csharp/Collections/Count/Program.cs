using System;
using System.Collections.Generic;
using System.Linq;

namespace Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek =  {
                                        "Monday",
                                        "Tuesday",
                                        "Wednesday",
                                        "Thursday",
                                        "Friday",
                                        "Saturday",
                                        "Sunday"
                                    };
            ICollection<string> collection = 
                (ICollection<string>) daysOfWeek;
            Console.WriteLine("Count() = " + collection.Count());
            Console.WriteLine("Count = " + daysOfWeek.Length);
            Console.WriteLine("Length = " + daysOfWeek.Length);
            Console.ReadLine();
        }
    }
}
