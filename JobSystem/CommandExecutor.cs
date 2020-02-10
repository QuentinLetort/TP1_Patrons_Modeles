using System.Collections.Concurrent;
using System.Threading;
using System.Collections.Generic;
using DataFlow;

namespace JobSystem
{
    public class CommandExecutor
    {
        private Thread[] threads;
        private ConcurrentQueue<Command> commandQueue;
        private bool shutdown;
        private List<ITaskListener> _listeners = new List<ITaskListener>();

        public CommandExecutor(int nbThread)
        {
            commandQueue = new ConcurrentQueue<Command>();
            threads = new Thread[nbThread];
            for (int i = 0; i < nbThread; i++)
            {
                threads[i] = new Thread(Work);
            }
            shutdown = false;
        }
        private void Work()
        {
            while (!shutdown)
            {
                if (!commandQueue.IsEmpty && commandQueue.TryDequeue(out Command task))
                {
                    task.Execute();
                    Notify(task);
                }
            }
        }
        public void Shutdown()
        {
            shutdown = true;
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }

        public void AddTask(Command task)
        {
            commandQueue.Enqueue(task);
        }

        public void Subscribe(ITaskListener taskListener)
        {
            _listeners.Add(taskListener);
        }

        public void Unsubscribe(ITaskListener taskListener)
        {
            _listeners.Remove(taskListener);
        }

        public void Notify(Command command)
        {
            foreach (ITaskListener taskListener in _listeners)
            {
                taskListener.OnTaskDone(command);
            }
        }
    }
}