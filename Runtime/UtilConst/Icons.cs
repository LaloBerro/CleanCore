using CleanCore.Extensions;

namespace CleanCore.UtilsConst
{
    public class Icons
    {
        public const string Plus = "＋";
        public const string RightArrow = "→";
        public const string Check = "✓";
        public const string Cross = "╳";

        public static string Format(string icon, string hexColor)
        {
            return icon.SetColorOfString(hexColor).MakeBold();
        }
    }
}