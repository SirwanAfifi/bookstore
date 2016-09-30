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
    }
}