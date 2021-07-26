using CleanCore.Patterns.Command;

namespace CleanCore.Processor
{
    public interface IProcess : IProgressiveTask, IActionDoneTask, IExecute, IDoneTask
    {
    }
}