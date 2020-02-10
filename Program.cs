using System;
using DataFlow;
using JobSystem;

namespace TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataFlow[] flows = new IDataFlow[20];
            for (int i = 0; i < flows.Length; i++)
            {
                IDataFlow flow = new ConsoleFlow();
                if (i % 2 == 0)
                {
                    flow = new CompressionDecorator(flow);
                }
                if (i % 4 == 0)
                {
                    flow = new EncryptionDecorator(flow);
                }
                flows[i] = flow;

            }
            CommandExecutor cmdExecutor = CommandExecutor.getInstance();
            cmdExecutor.Start(5);
            for (int i = 0; i < flows.Length; i++)
            {
                string data = "data" + i;
                cmdExecutor.AddTask(new WriteDataCommand(flows[i], data));
            }
            
        }
    }
}
