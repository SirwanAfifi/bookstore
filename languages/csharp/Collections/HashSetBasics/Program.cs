using System;
using System.Collections.Generic;

namespace HashSetBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            var bigCities = new List<string>
            { "New York", "Manchester", "Sheffield", "Paris" };

            if (!bigCities.Contains("Shefield"))
                bigCities.Add("Shefield");
            if (!bigCities.Contains("Beijing"))
                bigCities.Add("Beijing");

            foreach (string city in bigCities)
                Console.WriteLine(city);

            Console.ReadLine();
        }
    }
}
