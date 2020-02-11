using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Collections.Generic;
using DataFlow;

namespace JobSystem
{
    public class CommandExecutor
    {
        private static CommandExecutor instance;
        private Thread[] threads;
        private ConcurrentQueue<Command> commandQueue;
        private bool shutdown;
        private List<ITaskListener> _listeners = new List<ITaskListener>();

        private CommandExecutor()
        {
            commandQueue = new ConcurrentQueue<Command>();
            shutdown = true;
        }
        public void Start(int nbThread)
        {
            shutdown = false;
            threads = new Thread[nbThread];
            for (int i = 0; i < nbThread; i++)
            {
                Thread thread = new Thread(Work);
                thread.Start();
                threads[i] = thread;
            }
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
            while (!commandQueue.IsEmpty)
            {
                Thread.Sleep(1000);
            }
            if (!shutdown)
            {
                shutdown = true;
                foreach (Thread thread in threads)
                {
                    thread.Interrupt();
                }
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
        public static CommandExecutor getInstance()
        {
            if (instance == null)
            {
                instance = new CommandExecutor();
            }
            return instance;
        }
    }
}