using System;
using System.Collections.Generic;

namespace SetEquals
{
    class Program
    {
        static void Main(string[] args)
        {
            var bigCities = new HashSet<string>
            { "New York", "Manchester", "Sheffield", "Paris" };

            var citiesInUk = new HashSet<string>
            { "Sheffield", "Ripon", "Truro", "Manchester" };

            var bigCitiesArr = new string[]
            { "New York", "Manchester", "Sheffield", "Paris" };

            bool areEqual = bigCities.SetEquals(bigCitiesArr);
            Console.WriteLine("bigCities = bigCitiesArr? " + areEqual);

            bool areEqualUk = citiesInUk.SetEquals(bigCitiesArr);
            Console.WriteLine("citiesInUk = bigCitiesArr? " + areEqualUk);

            Console.ReadLine();
        }
    }
}
