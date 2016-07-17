using System;
using System.Collections.Generic;
using System.Linq;

namespace SortArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            //var comparer = new StringLengthComparer();

            var orderedEnumerable = daysOfWeek.OrderBy(p => p.Length);

            //Array.Sort(daysOfWeek, comparer);

            foreach (string day in orderedEnumerable)
                Console.WriteLine(day);

            Console.ReadLine();
        }
    }

    class StringLengthComparer : IComparer<String>
    {
        public int Compare(string x, string y)
        {
            return x.Length.CompareTo(y.Length);
        }
    }
}
