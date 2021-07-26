using System;

namespace CleanCore.Patterns.Command
{
	public interface IActionDoneTask
    {
        Action OnDone { get; set; }
    }
}