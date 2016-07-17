using System;
using System.Linq;

namespace ArrayCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] squares = { 1, 4, 9, 16 };

            int[] copy = squares.ToArray();

            foreach (var value in copy)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine(string.Format(
                "squares == copy? {0}", squares == copy));

            Console.ReadLine();
        }
    }
}
