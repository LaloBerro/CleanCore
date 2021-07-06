using UnityEditor;
using UnityEngine;

namespace CleanCore.EditorExtensions.Widgets
{
	public class Widget
	{
        public static void CardButton(string header, float width, float height, string texturePath = "")
        {
            Texture2D texture = EditorGUIUtility.Load(texturePath) as Texture2D;

            GUILayout.BeginVertical(WidgetStyle.ShadowBox, GUILayout.Width(width), GUILayout.Height(height), GUILayout.MinWidth(0));

            
            var labelStyle = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold, fontSize = 15 ,richText = true };
            EditorGUILayout.LabelField(header , labelStyle, GUILayout.Width(width - 10));

            var buttonStyle = new GUIStyle(GUI.skin.button);
            if (GUILayout.Button(texture, buttonStyle,GUILayout.Width(width-10), GUILayout.Height(height - 10))) { }
            
            GUILayout.EndVertical();
        }

        public static void Grid(System.Action[] toDraw, float cellWidth, float cellHeight, float windowWidth, float windowHeight)
        {
            GUILayout.Space(20);

            GUILayout.BeginVertical();
                GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                        for (int i = 0; i < toDraw.Length; i++)
                        {
                
                            toDraw[i].Invoke();
                
                        }
                    GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }
    }
}