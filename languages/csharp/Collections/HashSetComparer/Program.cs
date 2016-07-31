using System;
using System.Collections.Generic;

namespace HashSetComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            var bigCities = new HashSet<string>(StringComparer.CurrentCultureIgnoreCase)
            { "New York", "Manchester", "Sheffield", "Paris" };

            bigCities.Add("SHEFFIELD");
            bigCities.Add("BEIJING");

            foreach (string city in bigCities)
                Console.WriteLine(city);

            Console.ReadLine();
        }
    }
}
