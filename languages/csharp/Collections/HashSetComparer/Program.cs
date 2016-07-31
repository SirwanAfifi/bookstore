using System;
using System.Collections.Generic;

namespace HashSetComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            var bigCities = new HashSet<string>(new UncasedStringEqualityComparer())
            { "New York", "Manchester", "Sheffield", "Paris" };

            bigCities.Add("SHEFFIELD");
            bigCities.Add("BEIJING");

            foreach (string city in bigCities)
                Console.WriteLine(city);

            Console.ReadLine();
        }
    }

    public class UncasedStringEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.ToUpper() == y.ToUpper();
        }

        public int GetHashCode(string obj)
        {
            return obj.ToUpper().GetHashCode();
        }
    }
}
