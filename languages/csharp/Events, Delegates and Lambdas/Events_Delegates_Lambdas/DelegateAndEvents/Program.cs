using System;

namespace DelegateAndEvents
{
    public delegate void WorkPerformedHandler(int hour, WorkType workType);

    class Program
    {
        static void Main(string[] args)
        {
            WorkPerformedHandler del = WorkPerformed1;
            del += WorkPerformed2;

            DoWork(del);


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
