using System;
using System.Collections.Concurrent;
using System.Threading;

namespace JobSystem 
{
    public class CommandExecutor
    {
        private Thread [] threads;
        private ConcurrentQueue<Command> commandQueue;
        private bool shutdown;
        
        public CommandExecutor(int nbThread) 
        {
            commandQueue = new ConcurrentQueue<Command>();
            threads = new Thread[nbThread];
            for(int i = 0; i<nbThread;i++) 
            {
                threads[i] = new Thread(Work);
            }
            shutdown = false;
        }
        private void Work() 
        {
            while(!shutdown) 
            {
                if(!commandQueue.IsEmpty && commandQueue.TryDequeue(out Command task))
                {
                    task.Execute();
                }
            }
        }
        public void Shutdown()
        {
            shutdown = true;
            foreach(Thread thread in threads)
            {
                thread.Join();
            }
        }

        public void AddTask(Command task)
        {
            commandQueue.Enqueue(task);
        }
    }
}