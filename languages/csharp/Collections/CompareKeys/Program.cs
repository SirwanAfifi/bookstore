using System;
using System.Collections.Generic;

namespace CompareKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            var primeMinisters = new Dictionary<string, PrimeMinister>
            (new UncasedStringEqualityComparer())
            {
                { "JC", new PrimeMinister("James Callaghan", 1974) },
                { "MT", new PrimeMinister("Margaret Thatcher", 1979) },
                { "TB", new PrimeMinister("Tony Blair", 1997) }
            };

            Console.WriteLine(primeMinisters["tb"]);


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
