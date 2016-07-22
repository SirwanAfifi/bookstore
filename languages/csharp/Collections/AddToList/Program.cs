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
            presidents.Add("Barack Obama");

            string firstElem = presidents[0];

            foreach (string president in presidents)
                Console.WriteLine(president);

            Console.ReadLine();
        }
    }
}
