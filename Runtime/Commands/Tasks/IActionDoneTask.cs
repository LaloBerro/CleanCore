using System;

namespace CleanCore.Tasks
{
	public interface IActionDoneTask
    {
        Action OnDone { get; set; }
    }
}