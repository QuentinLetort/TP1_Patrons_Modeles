using DataFlow;
using JobSystem;

namespace Api
{
    public class Api
    {
        private IDataFlow flow;
        private int nbThread;
        private CommandExecutor commandExecutor;

        public Api()
        {
            nbThread = 1;
            commandExecutor = null;
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
            commandExecutor.AddTask(null);
        }

        /*public void CreateConnection()
        {
            commandExecutor.
        }

        public chooseListener()
        {
            if (listener == true)
            {
                CommandExecutor.Subscribe();
            }
            else
            {
                CommandExecutor.Unsubscribe();
            }
        }

        public CloseConnection()
        {
            CommandExecutor.Shutdown();
        }*/
    }
}
