using UnityEngine;

namespace CleanCore.Extensions
{
	public static class FloatExtension
	{
        public static byte ToByte(this float f)
        {
            f = Mathf.Clamp01(f);
            return (byte)(f * 255);
        }
    }
}