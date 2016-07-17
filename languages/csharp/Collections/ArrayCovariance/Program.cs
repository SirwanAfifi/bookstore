using System;

namespace ArrayCovariance
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] objArr = new object[3];
            string[] daysOfWeek = {
                                        "Monday",
                                        "Tuesday",
                                        "Wednesday",
                                        "Thursday",
                                        "Friday",
                                        "Saturday",
                                        "Sunday"
                                    };
            objArr[0] = 3;
            Console.WriteLine("objArr[0] = " + objArr[0]);

            object[] objArr2 = daysOfWeek;
            objArr2[0] = 3;
            Console.WriteLine("obj2Arr[0] = " + objArr2[0]);

            Console.ReadLine();
        }
    }
}
