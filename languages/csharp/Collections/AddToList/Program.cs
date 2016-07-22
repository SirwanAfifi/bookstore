using System;
using System.Collections.Generic;

namespace AddToList
{
    class Program
    {
        static void Main(string[] args)
        {
            var presidents = new List<string>
            {
                "Jimmy Carter",
                "Ronald Regan",
                "George HW Bush",
                "Bill Clinton",
                "George W Bush"
            };

            presidents.Add("Barack Obama");

            foreach (string president in presidents)
                Console.WriteLine(president);

            Console.ReadLine();
        }
    }
}
