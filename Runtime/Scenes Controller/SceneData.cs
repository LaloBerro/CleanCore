using System;
using UnityEngine;

namespace CleanCore.Scenes
{
    [System.Serializable]
    public class SceneData
    {
        public string nameScene;
        public bool useLoadingScreen = true;
        public bool isLockedScene;
        public bool removeLockedScenes;
        public bool isPrincipal;

        public SceneDataSO[] scenesData;

        public SceneData[] GetAllScenesToOpen()
        {
            SceneData[] scenes = new SceneData[scenesData.Length + 1];

            for (int i = 0; i < scenesData.Length; i++)
            {
                scenes[i] = scenesData[i].SceneData;
            }

            return scenes;
        }
    }
}