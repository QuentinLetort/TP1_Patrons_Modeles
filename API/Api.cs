using DataFlow;
using JobSystem;

namespace API
{
    public class Api
    {
        private IDataFlow flow;
        private int nbThread;
        private CommandExecutor commandExecutor;

        public Api()
        {
            nbThread = 1;
            commandExecutor = CommandExecutor.getInstance();
        }
        public int NbThread
        {
            get { return this.nbThread; }
            set { nbThread = value; }
        }
        public IDataFlow Flow
        {
            get { return this.flow; }
            set { flow = value; }
        }
        public void Send(string data) 
        {
            commandExecutor.AddTask(new WriteDataCommand(flow, data));
        }

        public void CreateConnection()
        {
            commandExecutor.Start(nbThread);
        }

        /*public chooseListener()
        {
            if (listener == true)
            {
                CommandExecutor.Subscribe();
            }
            else
            {
                CommandExecutor.Unsubscribe();
            }
        }*/

        public void CloseConnection()
        {
            commandExecutor.Shutdown();
        }
    }
}
