using System;

namespace DelegateAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();
            worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            {
                Console.WriteLine(e.Hours + " " + e.WorkType);
            };
            worker.WorkCompleted += delegate {
                Console.WriteLine("Worker is done");
            };
            worker.DoWork(10, WorkType.Gold);
            Console.Read();
        }
    }
}
