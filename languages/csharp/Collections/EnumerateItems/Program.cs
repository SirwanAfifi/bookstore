﻿using System;
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

            foreach (string day in daysOfWeek)
                Console.WriteLine(day);


            //DisplayItems(daysOfWeek);

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

        public static void DisplayItems2<T>(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
