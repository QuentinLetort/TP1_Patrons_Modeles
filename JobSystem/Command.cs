namespace JobSystem
{
    public interface Command
    {
        void Execute();
    }
    public abstract class Command<T> : Command
    {
        protected T result;
        public T GetResult()
        {
            return result;
        }
        public abstract void Execute();
    }
}