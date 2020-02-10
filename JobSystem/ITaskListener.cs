using DataFlow;

namespace JobSystem
{
    public interface ITaskListener
    {
        void OnTaskDone(Command command);
    }
}
