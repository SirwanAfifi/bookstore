using System;

namespace DelegateAndEvents
{
    public class ProcessData
    {
        public void Process(int x, int y, BizRuleDelegate del)
        {
            var result = del(x, y);
            Console.WriteLine(result);
        }

        public void ProcessAction(int x, int y, Action<int, int> action)
        {
            action(x, y);
            Console.WriteLine("Action has been processed");
        }
    }
}