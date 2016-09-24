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

            int finalHours = del1(10, WorkType.Gold);
            Console.WriteLine(finalHours);

            Console.Read();
        }

        static int WorkPerformed1(int hour, WorkType workType)
        {
            Console.WriteLine("WorkPerformed1 called " + hour.ToString());
            return hour + 1;
        }

        static int WorkPerformed2(int hour, WorkType workType)
        {
            Console.WriteLine("WorkPerformed2 called " + hour.ToString());
            return hour + 2;
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
