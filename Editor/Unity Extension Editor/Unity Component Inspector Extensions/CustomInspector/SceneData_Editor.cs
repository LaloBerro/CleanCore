using CleanCore.Scenes;
using UnityEngine;

namespace UnityEditor
{
    /*[CustomPropertyDrawer(typeof(SceneData))]
    public class SceneData_Editor : PropertyDrawer
    {
        private SceneAsset newScene = null;

        private bool viewOptions = true;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            // Draw label
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // Don't make child fields be indented
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            //// Calculate rects
            var amountRect = new Rect(position.x, position.y, 30, position.height);
            //var unitRect = new Rect(position.x + 35, position.y, 50, position.height);
            //var nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

            //// Draw fields - passs GUIContent.none to each so they are drawn without labels
            //EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("sceneAsset"), GUIContent.none);
            //EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("unit"), GUIContent.none);
            //EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), GUIContent.none);

            // Set indent back to what it was

            property.serializedObject.Update();

            DrawScene(property);


            DrawName(property);

            if (newScene)
            {              
                EditorGUILayout.BeginVertical("Box");

                EditorGUI.indentLevel++;
                viewOptions = EditorGUILayout.Foldout(viewOptions, "Options");

                if (viewOptions)
                {
                    EditorGUI.indentLevel++;
                    DrawBool("useLoadingScreen", "Use Loading Screen", property);
                    DrawBool("isLockedScene", "Is Locked Scene", property);
                    DrawBool("removeLockedScenes", "Remove Locked Scenes", property);
                    DrawBool("isPrincipal", "Set As Principal", property);
                    EditorGUI.indentLevel -= 3;
                }
                else
                    EditorGUI.indentLevel -= 2;

                EditorGUILayout.EndVertical();

                DrawSceneDataList(property);
            }

            property.serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }

        private void DrawScene(SerializedProperty property)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.BeginVertical("Box");

            EditorGUILayout.LabelField("Scene");
            newScene = EditorGUILayout.ObjectField(property.FindPropertyRelative("sceneAsset").objectReferenceValue, typeof(SceneAsset), false) as SceneAsset;

            DrawNamePrivate(property);

            EditorGUILayout.EndVertical();

            if (EditorGUI.EndChangeCheck())
            {
                if (newScene)
                {
                    string newPath = newScene.name;
                    var sceneNameProperty = property.FindPropertyRelative("nameScene");
                    sceneNameProperty.stringValue = newPath;

                    sceneNameProperty = property.FindPropertyRelative("sceneAsset");
                    sceneNameProperty.objectReferenceValue = newScene;
                }
                else
                {
                    var sceneNameProperty = property.FindPropertyRelative("sceneAsset");
                    sceneNameProperty.objectReferenceValue = null;
                }

            }
        }

        private void DrawName(SerializedProperty property)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.BeginVertical("Box");

            string zoneName = EditorGUILayout.TextField("Name", property.FindPropertyRelative("zoneName").stringValue);

            EditorGUILayout.EndVertical();

            if (EditorGUI.EndChangeCheck())
            {
                property.FindPropertyRelative("zoneName").stringValue = zoneName;
            }
        }

        private void DrawNamePrivate(SerializedProperty property)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.BeginVertical("Box");

            EditorGUILayout.LabelField(property.FindPropertyRelative("nameScene").stringValue);

            EditorGUILayout.EndVertical();
        }

        private void DrawBool(string propertyName, string description, SerializedProperty property)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.BeginVertical("Box");

            bool state = EditorGUILayout.Toggle(description, property.FindPropertyRelative(propertyName).boolValue);

            EditorGUILayout.EndVertical();

            if (EditorGUI.EndChangeCheck())
            {
                property.FindPropertyRelative(propertyName).boolValue = state;
            }
        }

        private void DrawSceneDataList(SerializedProperty property)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.BeginVertical("Box");

            if (EditorGUI.EndChangeCheck())
            {
                var serializedObject = property;
                var propertys = serializedObject.FindPropertyRelative("scenesData");
                serializedObject.serializedObject.Update();
                EditorGUILayout.PropertyField(propertys, true);
            }

            EditorGUILayout.EndVertical();
        }

        private void HorizontalRect(float height)
        {
            Rect rect = EditorGUILayout.GetControlRect(false, 10);

            rect.height = height;

            EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
        }
    }*/
}