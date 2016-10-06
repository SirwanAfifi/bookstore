using System;
using CommunicatingBetweenControls.Models;

namespace CommunicatingBetweenControls
{
    public class JobChangedEventArgs : EventArgs
    {
        public Job Job { get; set; }
    }
}