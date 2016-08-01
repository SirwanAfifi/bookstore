using System;
using System.Collections.Generic;

namespace EnumerateItems
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = {
                            "Monday",
                            "Tuesday",
                            "Wednesday",
                            "Thursday",
                            "Friday",
                            "Saturday",
                            "Sunday"
                        };

            DisplayItems("Hello World!");

            Console.ReadLine();
        }

        public static void DisplayItems<T>(IEnumerable<T> collection)
        {
            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                bool moreItems = enumerator.MoveNext();
                while (moreItems)
                {
                    T item = enumerator.Current;
                    Console.WriteLine(item);
                    moreItems = enumerator.MoveNext();
                }
            }
        }
    }
}
