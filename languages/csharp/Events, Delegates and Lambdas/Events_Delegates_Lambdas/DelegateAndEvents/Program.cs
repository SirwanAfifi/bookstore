using System;

namespace DelegateAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);

            del1 += del2;

            del1(10, WorkType.Gold);

            Console.Read();
        }

        static void WorkPerformed1(int hour, WorkType workType)
        {
            Console.WriteLine("WorkPerformed1 called " + hour.ToString());
        }

        static void WorkPerformed2(int hour, WorkType workType)
        {
            Console.WriteLine("WorkPerformed2 called " + hour.ToString());
        }

        static void DoWork(WorkPerformedHandler del)
        {
            del(15, WorkType.Gold);
        }
    }

    public enum WorkType
    {
        Gold,
        Other
    }
}
