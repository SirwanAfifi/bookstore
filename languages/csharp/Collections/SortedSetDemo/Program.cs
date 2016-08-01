using System;
using System.Collections.Generic;

namespace SortedSetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var bigCities = new SortedSet<string>(new UncasedStringComparer())
            { "New York", "Manchester", "Sheffield", "Paris" };

            bigCities.Add("Sheffield");
            bigCities.Add("Beijing");

            foreach (string city in bigCities)
                Console.WriteLine(city);


            Console.ReadLine();
        }
    }

    class UncasedStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, 
                StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
