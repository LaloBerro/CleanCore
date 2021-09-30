using System.Runtime.CompilerServices;
using System;

namespace CleanCore.Extensions
{
	public static class BoolExtension
	{
		public static BoolAwaiter GetAwaiter(this bool value) => new BoolAwaiter(value);
	}

	public class BoolAwaiter : INotifyCompletion
	{
		private readonly bool _value;

		public bool IsCompleted => true;

		public BoolAwaiter(bool value) => _value = value;

		public bool GetResult() => _value;

		public void OnCompleted(Action continuation) { } // Never called
	}
}