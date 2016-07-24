using System;
using System.Collections.Generic;

namespace Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> books = new Stack<string>();

            books.Push("Programming WPF");
            books.Push("The Philosophy Book");
            books.Push("Heat and Thermodynamics");
            books.Push("Harry Potter and Chamber of Secrets");

            Console.WriteLine("All Books:");
            foreach (string title in books)
                Console.WriteLine(title);

            string topItem = books.Peek();
            Console.WriteLine("\r\nTop item is: " + topItem);

            Console.WriteLine("\r\nAll Books:");
            foreach (string title in books)
                Console.WriteLine(title);

            Console.ReadLine();
        }
    }
}
