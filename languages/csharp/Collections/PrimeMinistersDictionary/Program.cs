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

            PrimeMinister pm;
            bool found = primeMinisters.TryGetValue("DC", out pm);
            if (found)
                Console.WriteLine("value is: " + pm.ToString() + "\r\n");
            Console.WriteLine("value was not in the dictionary");


            Console.ReadLine();
        }
    }
}
