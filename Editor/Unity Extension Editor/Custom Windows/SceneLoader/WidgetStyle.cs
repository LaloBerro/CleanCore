using UnityEngine;

namespace CleanCore.EditorExtensions.Widgets
{
	public class WidgetStyle
	{
        private static GUIStyle shadowBox = null;

		public static GUIStyle ShadowBox
        {
            get
            {
                if(null == shadowBox)
                {                    
                    shadowBox = new GUIStyle(GUI.skin.window);
                    shadowBox.padding = new RectOffset(0,0,0,0);
                }

                return shadowBox;
            }
        }

        private static GUIStyle buttonWithoutBackground = null;

        public static GUIStyle ButtonWithoutBackground
        {
            get
            {
                if (null == buttonWithoutBackground)
                {
                    buttonWithoutBackground = new GUIStyle(GUI.skin.button);                 
                }

                return buttonWithoutBackground;
            }
        }
    }
}