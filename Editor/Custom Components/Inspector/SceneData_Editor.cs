using UnityEngine;
using UnityEditor;

namespace CleanCore.EditorExtensions.CustomComponentInspector
{
    /*[CustomEditor(typeof(SceneData))]
    public class SceneData_Editor : Editor
    {
        private SceneAsset newScene = null;

        private bool viewOptions = true;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            

            DrawScene();

            DrawName();

            if (newScene)
            {
                EditorGUILayout.BeginVertical("Box");

                EditorGUI.indentLevel++;
                viewOptions = EditorGUILayout.Foldout(viewOptions, "Options");

                if (viewOptions)
                {
                    EditorGUI.indentLevel++;
                    DrawBool("useLoadingSreen", "Use Loading Screen");
                    DrawBool("isLockedScene", "Is locked scene");
                    DrawBool("removeLockedScenes", "Remove Open Scenes");
                    DrawBool("isPrincipal", "Set As Principal");
                    EditorGUI.indentLevel -= 3;
                }
                else
                    EditorGUI.indentLevel -= 2;

                EditorGUILayout.EndVertical();

                DrawSceneDataList();
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawScene()
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.BeginVertical("Box");

            EditorGUILayout.LabelField("Scene");
            newScene = EditorGUILayout.ObjectField(serializedObject.FindProperty("sceneAsset").objectReferenceValue, typeof(SceneAsset), false) as SceneAsset;

            DrawNamePrivate();

            EditorGUILayout.EndVertical();

            if (EditorGUI.EndChangeCheck())
            {
                if (newScene)
                {
                    string newPath = newScene.name;
                    var sceneNameProperty = serializedObject.FindProperty("nameScene");
                    sceneNameProperty.stringValue = newPath;

                    sceneNameProperty = serializedObject.FindProperty("sceneAsset");
                    sceneNameProperty.objectReferenceValue = newScene;
                }
                else
                {
                    var sceneNameProperty = serializedObject.FindProperty("sceneAsset");
                    sceneNameProperty.objectReferenceValue = null;
                }

            }
        }

        private void DrawName()
        {
            EditorGUILayout.BeginVertical("Box");
            EditorGUI.BeginChangeCheck();
            string zoneName = EditorGUILayout.TextField("Name", serializedObject.FindProperty("zoneName").stringValue);

            EditorGUILayout.EndVertical();

            if (EditorGUI.EndChangeCheck())
            {
                var property = serializedObject.FindProperty("zoneName");
                property.stringValue = zoneName;
            }
        }

        private void DrawNamePrivate()
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.BeginVertical("Box");

            EditorGUILayout.LabelField(serializedObject.FindProperty("nameScene").stringValue);

            EditorGUILayout.EndVertical();
        }

        private void DrawBool(string propertyName, string description)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.BeginVertical("Box");

            bool state = EditorGUILayout.Toggle(description, serializedObject.FindProperty(propertyName).boolValue);

            EditorGUILayout.EndVertical();

            if (EditorGUI.EndChangeCheck())
            {
                var property = serializedObject.FindProperty(propertyName);
                property.boolValue = state;
            }
        }

        private void DrawSceneDataList()
        {
            EditorGUI.indentLevel += 2;
            EditorGUILayout.BeginVertical("Box");

            var serializedObject = new SerializedObject(target);
            var property = serializedObject.FindProperty("scenesData");
            serializedObject.Update();
            EditorGUILayout.PropertyField(property, true);


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