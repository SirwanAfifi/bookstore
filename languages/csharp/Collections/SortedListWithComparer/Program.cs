using System;
using System.Collections.Generic;

namespace SortedListWithComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            var primeMinisters = new SortedList<string, PrimeMinister>
            (new UncasedStringEqualityComparer())
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

    public class UncasedStringEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.ToUpper() == y.ToUpper();
        }

        public int GetHashCode(string obj)
        {
            return obj.ToUpper().GetHashCode();
        }
    }
}
