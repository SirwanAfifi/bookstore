using System;
using System.Collections.Generic;

namespace LinkedListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var presidents = new LinkedList<string>();
            presidents.AddLast("JFK");
            presidents.AddLast("Lyndon B Johnson");
            presidents.AddLast("Richard Nixon");
            presidents.AddLast("Jimmy Carter");

            presidents.RemoveFirst();

            LinkedListNode<string> item = presidents.Find("Richard Nixon");

            presidents.AddAfter(item, "Gerlad Ford");

            foreach (string president in presidents)
                Console.WriteLine(president);

            Console.ReadLine();
        }
    }
}
