using System;
using System.Collections.Generic;

namespace SortedListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var primeMinisters = new SortedList<string, PrimeMinister>
            {
                { "JC", new PrimeMinister("James Callaghan", 1974) },
                { "MT", new PrimeMinister("Margaret Thatcher", 1979) },
                { "TB", new PrimeMinister("Tony Blair", 1997) }
            };
            primeMinisters.Add("JM", new PrimeMinister("John Major", 1990));

            foreach (var pm in primeMinisters)
                Console.WriteLine(pm);

            Console.ReadLine();

        }
    }
}
