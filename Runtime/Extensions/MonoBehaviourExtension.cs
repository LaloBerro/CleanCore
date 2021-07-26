using System.Collections;
using UnityEngine;

namespace CleanCore.Extensions
{
	public static class MonoBehaviourExtension
	{
        /// <summary>
        /// Wait a determined time and ejecute a action
        /// </summary>
        /// <param name="mb"></param>
        /// <param name="time"></param>
        /// <param name="onTimeFinish"></param>
        public static void WaitTimeAndThenRun(this MonoBehaviour mb, float time, System.Action onTimeFinish)
        {
            mb.StartCoroutine(WaitTimeAndThenRun(time, onTimeFinish));
        }

        private static IEnumerator WaitTimeAndThenRun(float time, System.Action callback)
        {
            yield return new WaitForSeconds(time);
            callback.Invoke();
        }
    }
}