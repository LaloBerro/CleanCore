using UnityEngine;
using UnityEditor;
using UnityEditor.ShortcutManagement;
using System.Collections.Generic;
using CleanCore.EditorExtensions.Widgets;
using System;

namespace CleanCore.EditorExtensions.Windows.Scenes
{
	public class SceneSelectorGridWindow : EditorWindow
	{
        private static List<GUIContent> _scenesContent = new List<GUIContent>();


        [Shortcut("SceneSelector", null, KeyCode.S ,ShortcutModifiers.Shift)]
        public static void ShowWindow()
        {
            GetWindowWithRect(typeof(SceneSelectorGridWindow), new Rect(Vector2.zero, new Vector2(800,600)), false, "Scene Selector");
            CreateButtons();
        }  

        private void OnGUI()
        {
            //CreateButtons();

            Action[] actions = { new Action(() => Widget.CardButton("Main Menu", 200, 200, "Assets/Base Project/Editor/Textures/Scenes/test.png")),
            new Action(() => Widget.CardButton("Maian Menu", 200, 200, "Assets/Base Project/Editor/Textures/Scenes/test.png")),
            new Action(() => Widget.CardButton("Maiaan Menu", 200, 200, "Assets/Base Project/Editor/Textures/Scenes/test.png")),
            new Action(() => Widget.CardButton("Maiaasdn Menu", 200, 200, "Assets/Base Project/Editor/Textures/Scenes/test.png"))};

            Widget.Grid(actions, 200, 200, 850, 600);

            //Widget.CardButton("Maiaasdn Menu", 10, 200, "Assets/Base Project/Editor/Textures/Scenes/test.png");

            //paletteIndex = GUILayout.SelectionGrid(paletteIndex, scenesContent.ToArray(), 2 , new GUIStyle(GUI.skin.window), GUILayout.Width(this.position.width), GUILayout.Height(this.position.height));
        }

        private static void CreateButtons()
        {
            _scenesContent.Clear();

            _scenesContent.Add(new GUIContent(""));

            string[] guids = AssetDatabase.FindAssets("t:SceneAsset", null);

            Scene[] scenes = new Scene[guids.Length];

            for (int i = 0; i < scenes.Length; i++)
            {
                string scenePath = AssetDatabase.GUIDToAssetPath(guids[i]);
                scenes[i] = new Scene(scenePath);

                _scenesContent.Add(new GUIContent(scenes[i].Name));
            }
        } 
    }
}

public class Scene
{
    public string path;

    private string name;

    public string Name
    {
        get
        {
            if (string.IsNullOrEmpty(name))
                name = GetSceneName(path);

            return name;
        }
    }

    public Scene(string path)
    {
        this.path = path;
    }

    private string GetSceneName(string _path)
    {
        char[] path = _path.ToCharArray();
        string sceneName = "";

        for (int i = path.Length - 1; i >= 0; i--)
        {
            if (path[i] == '/')
                break;
            sceneName += path[i];
        }

        path = sceneName.ToCharArray();
        sceneName = "";

        for (int i = path.Length - 1; i >= 0; i--)
        {
            if (path[i] == '.')
                break;
            sceneName += path[i];
        }

        return sceneName;
    }
}