using System;
using System.Text;

namespace EnumerateArray
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
            // this is best done using for, not foreach
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < daysOfWeek.Length; i++)
            {
                sb.Append(daysOfWeek[i]);
                if (i < daysOfWeek.Length - 2)
                    sb.Append(", ");
                else if (i == daysOfWeek.Length - 2)
                    sb.Append(" and ");
            }
            Console.WriteLine(sb.ToString());

            Console.ReadLine();

        }
    }
}
