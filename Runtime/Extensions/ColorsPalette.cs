using UnityEngine;

namespace CleanCore.Common
{
	public static class ColorsPalette
	{
		private static Color color;

		public static Color Pink { get { ColorUtility.TryParseHtmlString("#fc0377", out color); return color; } }

		public static Color Violet { get { ColorUtility.TryParseHtmlString("#a103fc", out color); return color; } }		
	}
}