using System;
using DataFlow;

namespace JobSystem
{
    public class EndTaskListener : ITaskListener
    {
        public EndTaskListener()
        {
        }

        public void OnTaskDone(Command command)
        {
            Console.WriteLine("Task ", command.GetHashCode(), " has been executed.");
        }
    }
}
