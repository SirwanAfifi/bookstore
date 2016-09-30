using System;

namespace DelegateAndEvents
{
    public delegate int BizRuleDelegate(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            BizRuleDelegate addDel = (x, y) => x + y;
            BizRuleDelegate multiplyDel = (x, y) => x * y;

            var data = new ProcessData();
            data.Process(2, 3, (x, y) => x * y);

            var worker = new Worker();
            worker.WorkPerformed += (s, e) => Console.WriteLine(e.Hours + " " + e.WorkType);
            worker.WorkCompleted += (s, e) => Console.WriteLine("Worker is done");
            worker.DoWork(10, WorkType.Gold);
            Console.Read();
        }
    }
}
