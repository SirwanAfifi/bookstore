using System;

namespace NonBlankStringList
{
    class Program
    {
        static void Main(string[] args)
        {
            NonBlankStringList lst = new NonBlankStringList();
            lst.Add("Item added at index 0");
            lst[0] = "Item changed at index 0";
            lst.Add("Item add at index 1");
            lst.Insert(2, "Item inserted at index 2");

            //lst.Add("   ");

            foreach (string item in lst)
                Console.WriteLine(item);

            Console.ReadLine();
        }
    }
}
