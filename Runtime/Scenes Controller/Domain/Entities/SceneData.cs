using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CleanCore.Scenes
{
    [System.Serializable]
    public class SceneData
    {

#if UNITY_EDITOR
        [System.NonSerialized]
        public SceneAsset sceneAsset;
#endif

        [Header("Config")]
        public bool useLoadingScreen = true;
        public bool isLockedScene;
        public bool removeLockedScenes;
        public bool isPrincipal;

        public SceneData[] scenesData;

        public string zoneName;
        public string nameScene;

        public SceneData[] GetAllScenesToOpen()
        {
            SceneData[] scenes = new SceneData[scenesData.Length + 1];

            scenes[scenesData.Length] = this;

            for (int i = 0; i < scenesData.Length; i++)
            {
                scenes[i] = scenesData[i];
            }

            return scenes;
        }
    }
}