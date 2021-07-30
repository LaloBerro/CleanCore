using UnityEngine;

namespace CleanCore.StaticSettings
{
	public static class CursorController
	{
        private static bool forceCursor = false;

        /// <summary>
        /// Set Cursor visible
        /// </summary>
        /// <param name="state"></param>
        public static void ShowCursor(bool state)
        {
            if (forceCursor && !state) return;

            Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = state;
        }

        public static void ForceCursor(bool state)
        {
            forceCursor = state;
        }
    }
}