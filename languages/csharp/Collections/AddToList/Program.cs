using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

            var copy = new ReadOnlyCollection<string>(presidents);

            BadCode(copy);

            foreach (string president in presidents)
                Console.WriteLine(president);

            Console.ReadLine();
        }

        static void BadCode(IList<string> lst)
        {
            lst.RemoveAt(2);
        }
    }
}
