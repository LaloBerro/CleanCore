using UnityEngine;
using UnityEngine.Events;

namespace CleanCore.StaticSettings
{
	public static class PauseController
	{
		public static bool isPause;

		public static UnityEvent<bool> onPause;

		public static void Pause(bool pauseState)
        {
			isPause = pauseState;

			onPause.Invoke(isPause);
			
			Time.timeScale = isPause ? 0 : 1;
		}
	}
}