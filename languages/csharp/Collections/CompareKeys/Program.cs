using System;
using System.Collections.Generic;

namespace CompareKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            var primeMinisters = new Dictionary<string, PrimeMinister>
            (StringComparer.InvariantCultureIgnoreCase)
            {
                { "JC", new PrimeMinister("James Callaghan", 1974) },
                { "MT", new PrimeMinister("Margaret Thatcher", 1979) },
                { "TB", new PrimeMinister("Tony Blair", 1997) }
            };

            Console.WriteLine(primeMinisters["tb"]);


            Console.ReadLine();
        }
    }
}
