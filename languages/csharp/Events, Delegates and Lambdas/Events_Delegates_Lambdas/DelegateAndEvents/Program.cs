using System;

namespace DelegateAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();
            worker.WorkPerformed += (s, e) => Console.WriteLine(e.Hours + " " + e.WorkType);
            worker.WorkCompleted += (s, e) => Console.WriteLine("Worker is done");
            worker.DoWork(10, WorkType.Gold);
            Console.Read();
        }
    }
}
