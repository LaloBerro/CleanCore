using CleanCore.Extensions;

namespace CleanCore.UtilConsts
{
    public class Icons
    {
        public const string Plus = "＋";
        public const string RightArrow = "→";
        public const string LeftArrow = "←";
        public const string Check = "✓";
        public const string Cross = "╳";
        public const string Point = "◉";
        public const string ArrowHeadRight = "➤";
        public const string PointerRightBig = "►";
        public const string PointerRightSmall = "▸";

        public static string Format(string icon, string hexColor)
        {
            return icon.SetColorOfString(hexColor).MakeBold();
        }
    }
}