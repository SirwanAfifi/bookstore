using System;
using System.Windows.Forms;

namespace ArrayTyping
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] objArray = new object[3]
            {
                "Hello",
                4,
                new Button { Text = "Click me!"}
            };

            Type objArrType = objArray.GetType();

            foreach (var item in objArray)
                Console.WriteLine(item);

            Console.ReadLine();
        }
    }
}
