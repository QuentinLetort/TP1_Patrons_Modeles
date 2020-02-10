using System;

namespace Api
{
    public class Api
    {
        private IDataFlow fluxMessage;
        private int nbThread;
        private bool listener;


        public Api(IDataFlow flux, int nbThread, bool listener)
        {
            fluxMessage = flux;
            nbThread = nbThread;
            listener = listener;
        }

        public CreateConnection()
        {
            CommandExecutor.CommandExecutor(nbThread);
        }

        public chooseListener()
        {
            if(listener == true)
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
        }
    }
}
