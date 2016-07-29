using System;
using System.Collections.Generic;

namespace SortedListWithComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            var primeMinisters = new SortedList<string, PrimeMinister>
            (new UncasedStringComparer())
            {
                { "JC", new PrimeMinister("James Callaghan", 1974) },
                { "MT", new PrimeMinister("Margaret Thatcher", 1979) },
                { "TB", new PrimeMinister("Tony Blair", 1997) }
            };
            primeMinisters.Add("JM", new PrimeMinister("John Major",
                1990));

            Console.WriteLine("tony is " + primeMinisters["tb"]);

            Console.ReadLine();
        }
    }

    public class UncasedStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y,
                StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
