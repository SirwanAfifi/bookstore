using System;
using System.Collections.Generic;

namespace AddToList
{
    class Program
    {
        static void Main(string[] args)
        {
            var presidents = new List<string>(12)
            {
                "Jimmy Carter",
                "Ronald Regan",
                "George HW Bush",
                "Bill Clinton",
                "George W Bush"
            };
            Console.WriteLine("Before:");
            Console.WriteLine("Count = " + presidents.Count);
            Console.WriteLine("Capacity = " + presidents.Capacity + "\r\n");
            presidents.Add("Barack Obama");
            presidents.Add("Bill Gates");
            presidents.Add("Steven Spielberg");
            presidents.Add("Aaron Skonnard");

            presidents.RemoveAt(6);

            Console.WriteLine("After:");
            Console.WriteLine("Count = " + presidents.Count);
            Console.WriteLine("Capacity = " + presidents.Capacity + "\r\n");
            foreach (string president in presidents)
                Console.WriteLine(president);

            Console.ReadLine();
        }
    }
}
