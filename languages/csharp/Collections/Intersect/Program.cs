using System;
using System.Collections.Generic;
using System.Linq;

namespace Intersect
{
    class Program
    {
        static void Main(string[] args)
        {
            var bigCities = new HashSet<string>
            { "New York", "Manchester", "Sheffield", "Paris" };

            string[] citiesInUk =
            { "Sheffield", "Ripon", "Truro", "Manchester" };

            bigCities.UnionWith(citiesInUk);
            foreach (string city in bigCities)
                Console.WriteLine(city);

            Console.ReadLine();
        }
    }
}
