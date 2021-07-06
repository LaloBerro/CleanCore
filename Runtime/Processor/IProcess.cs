using CleanCore.Tasks;

namespace CleanCore.Processor
{
    public interface IProcess : IProgressiveTask, IActionDoneTask, IExecute, IDoneTask
    {
    }
}