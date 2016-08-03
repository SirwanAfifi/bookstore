using System;
using System.Collections.Generic;

namespace Covariance
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello, World!";
            object obj = str;

            var strList = new List<string> { "Monday", "Tuesday" };
            IEnumerable<object> objEnum = strList;

            /*
               var strList = new string[] { "Monday", "Tuesday" };
               object[] objectList = strList;
             */

            Console.ReadLine();
        }
    }
}
