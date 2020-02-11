using DataFlow;
using System.Threading;

namespace JobSystem
{
    public class WriteDataCommand : Command
    {
        IDataFlow flow;
        string data;

        public WriteDataCommand(IDataFlow flow, string data)
        {
            this.flow = flow;
            this.data = data;
        }
        public void Execute()
        {
            Thread.Sleep(500);
            flow.WriteData(data);
        }
    }
}