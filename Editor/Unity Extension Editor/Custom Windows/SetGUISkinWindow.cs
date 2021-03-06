using UnityEngine;
using UnityEditor;

namespace CleanCore.EditorExtensions.Windows
{
	public class SetGUISkinWindow : EditorWindow
	{
        private GUISkin _guiSkin;

        [MenuItem("Custom Editor/Editor/Change GUI Skin")]
        public static void ShowWindow()
        {
            GetWindowWithRect(typeof(SetGUISkinWindow), new Rect(Vector2.zero, new Vector2(200, 50)), false, "GUI Skin Changer");
        }

        private void OnGUI()
        {
            _guiSkin = (GUISkin)EditorGUILayout.ObjectField(_guiSkin, typeof(GUISkin), false);

            if (GUILayout.Button("Change"))
            {
                GUI.skin.window = null;
            }
        }
    }
}