using UnityEngine;
using CleanCore.UtilConsts;
using CleanCore.Extensions;

public static class Console
{
    public static void Log(string message, string icon = Icons.PointerRightSmall, string iconColor = "#C1C1C1", string messageColor = "#C1C1C1", bool isBold = false)
    {
        if (isBold)
            message = message.MakeBold();

        message = message.SetColorOfString(messageColor);

        Debug.Log(Icons.Format(icon, iconColor) + " " + message);
    }

    /*public static void Log(string message, string icon = Icons.PointerRightSmall, string iconColor = "#C1C1C1")
    {
        Debug.Log(Icons.Format(icon, iconColor) + " " + message);
    }*/
}