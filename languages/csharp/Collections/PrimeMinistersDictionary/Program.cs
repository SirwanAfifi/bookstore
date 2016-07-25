using System;
using System.Collections.Generic;

namespace PrimeMinistersDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var primeMinisters = new Dictionary<string, PrimeMinister>
            {
                { "JC", new PrimeMinister("James Callaghan", 1976) },
                { "MT", new PrimeMinister("Margaret Thatcher", 1979) },
                { "TB", new PrimeMinister("Tony Blair", 1997) }
            };

            foreach (var pm in primeMinisters)
                Console.WriteLine(pm.Key + ",       " + pm.Value);





            Console.ReadLine();
        }
    }
}
