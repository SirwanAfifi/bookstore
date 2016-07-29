using System;
using System.Collections.Generic;

namespace KeyedCollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var primeMinisters = new SortedDictionary<string, PrimeMinister>
            {
                { "JC", new PrimeMinister("James Callaghan", 1974) },
                { "MT", new PrimeMinister("Margaret Thatcher", 1979) },
                { "TB", new PrimeMinister("Tony Blair", 1997) }
            };
            primeMinisters.Add("JM", new PrimeMinister("John Major",
                1990));

            Console.WriteLine("Tony is " + primeMinisters["TB"]);

            Console.ReadLine();
        }
    }
}
