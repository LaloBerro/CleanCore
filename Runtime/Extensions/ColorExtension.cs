using UnityEngine;

namespace CleanCore.Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Change the alpha channel of the color
        /// </summary>
        /// <param name="color"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static Color Alpha(this Color color, float alpha)
        {
            color.a = alpha;
            return color;
        }

        public static string ToHex(this Color color)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", color.r.ToByte(), color.g.ToByte(), color.b.ToByte());
        }
    }
}