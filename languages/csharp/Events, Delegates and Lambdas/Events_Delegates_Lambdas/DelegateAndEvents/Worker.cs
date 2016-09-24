using System;

namespace DelegateAndEvents
{
    public delegate int WorkPerformedHandler(int hour, WorkType workType);

    public class Worker
    {
        public event WorkPerformedHandler WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            
        }
    }
}