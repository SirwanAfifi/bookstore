using System;
using System.Collections;
using System.Collections.Generic;

namespace Implement_Enumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            AllDaysOfWeek allDays = new AllDaysOfWeek();
            foreach (string allDay in allDays)
                Console.WriteLine(allDay);


            Console.ReadLine();
        }
    }

    public class AllDaysOfWeek : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            Console.WriteLine("Calling generic GetEnumerator");
            yield return "Monday";
            yield return "Tuesday";
            yield return "Wednesday";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
