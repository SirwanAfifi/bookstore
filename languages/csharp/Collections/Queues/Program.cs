using System;
using System.Collections.Generic;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> tasks = new Queue<string>();

            tasks.Enqueue("do the washing up");
            tasks.Enqueue("Finish the C# Collections Pluralsight course");
            tasks.Enqueue("Buy some chocolate");
            tasks.Enqueue("Buy some more chocolate");

            Console.WriteLine("\r\nAll TASKS:");
            foreach (string title in tasks)
                Console.WriteLine(title);

            string nextTask = tasks.Peek();
            Console.WriteLine("\r\nThe next task is " + nextTask);

            Console.WriteLine("\r\nAll TASKS:");
            foreach (string title in tasks)
                Console.WriteLine(title);

            Console.ReadLine();
        }
    }
}
