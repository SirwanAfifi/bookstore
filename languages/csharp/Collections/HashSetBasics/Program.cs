using System;
using System.Collections.Generic;

namespace HashSetBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            var bigCities = new HashSet<string>
            { "New York", "Manchester", "Sheffield", "Paris" };
            bigCities.Add("Sheffield");
            bigCities.Add("Beijing");

            foreach (string city in bigCities)
                Console.WriteLine(city);

            Console.ReadLine();
        }
    }
}
