using System;

namespace DelegateAndEvents
{
    public delegate int BizRuleDelegate(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            var data = new ProcessData();
            BizRuleDelegate addDel = (x, y) => x + y;
            BizRuleDelegate multiplyDel = (x, y) => x * y;
            data.Process(2, 3, (x, y) => x * y);

            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultiplyDel = (x, y) => x * y;
            data.ProcessFunc(10, 5, funcAddDel);
            data.ProcessFunc(10, 5, funcMultiplyDel);

            Action<int, int> myAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine(x * y);
            data.ProcessAction(2, 3, myAction);

            var worker = new Worker();
            worker.WorkPerformed += (s, e) => Console.WriteLine(e.Hours + " " + e.WorkType);
            worker.WorkCompleted += (s, e) => Console.WriteLine("Worker is done");
            worker.DoWork(10, WorkType.Gold);
            Console.Read();
        }
    }
}
