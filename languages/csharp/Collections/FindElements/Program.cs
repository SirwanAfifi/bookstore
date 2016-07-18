using System;

namespace FindElements
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
            //int indexOfTues = Array.IndexOf(daysOfWeek, "Tuesday");
            /*int indexOfW = Array.FindIndex(daysOfWeek, x => x[0] == 'W');
            Console.WriteLine(indexOfW);
            Console.WriteLine(daysOfWeek[indexOfW]);*/
            string[] allWith6Chars = Array.FindAll(
                daysOfWeek, x => x.Length == 6);
            foreach (string item in allWith6Chars)
                Console.WriteLine(item);

            Console.ReadLine();
        }
    }
}
