using System;
using CommunicatingBetweenControls.Models;
using CommunicatingBetweenControls;

namespace CommunicatingBetweenControls
{
    public sealed class Mediator
    {
        // static members
        private static readonly Mediator Instance = new Mediator();
        private Mediator() { }

        public static Mediator GetInstance()
        {
            return Instance;
        }

        // Instance functionality
        public event EventHandler<JobChangedEventArgs> JobChanged;

        public void OnJobChanged(object sender, Job job)
        {
            var jobChangedDelegate = JobChanged as EventHandler<JobChangedEventArgs>;
            if (jobChangedDelegate != null)
            {
                jobChangedDelegate(sender, new JobChangedEventArgs { Job = job });
            }
        }
    }
}