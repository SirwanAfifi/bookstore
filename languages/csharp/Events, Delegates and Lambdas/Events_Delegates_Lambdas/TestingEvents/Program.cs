using System;
using CommunicatingBetweenControls;
using CommunicatingBetweenControls.Models;

namespace TestingEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            // Object Sharing doesn't support multiple process
            // more info: http://stackoverflow.com/a/10016102/1646540
            //Mediator.GetInstance().OnJobChanged(null, new Job { Title = "FFF", EndDate = DateTime.MaxValue, ID = 1, StartDate = DateTime.MinValue });
            Console.Read();
        }
    }
}
