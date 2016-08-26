using System;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] colorOptions = { "Red", "Espresso", "White", "Navy" };

            for (int i = 0; i < colorOptions.Length; i++)
            {
                colorOptions[i] = colorOptions[i].ToLower();
            }

            foreach (var color in colorOptions)
            {
                Console.WriteLine($"The color is {color}");
            }

            Console.ReadLine();
        }
    }
}
