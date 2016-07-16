using System;

namespace ForeachReadOnly
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
            MakeDaysPlural(daysOfWeek);
            foreach (var day in daysOfWeek)
            {
                Console.WriteLine(day);
            }

            Console.ReadLine();
        }

        static void MakeDaysPlural(string[] daysOfWeek)
        {
            for (int i = 0; i < daysOfWeek.Length; i++)
            {
                string day = daysOfWeek[i];
                daysOfWeek[i] = day + "s";
            }
        }

        /*static void MakeDaysPlural2(string[] daysOfWeek)
        {
            foreach (var day in daysOfWeek)
            {
                day = day + "s";
            }
        }*/
    }
}
