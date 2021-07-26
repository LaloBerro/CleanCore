using UnityEngine;

namespace CleanCore.Extensions
{
	public static class StringExtension
	{
		public static string SetColorToDebug(this string text, Color color)
        {
			string output = string.Format("<color={0}>{1}</color>", color.ToHex(), text);

			return output;
        }
	}
}