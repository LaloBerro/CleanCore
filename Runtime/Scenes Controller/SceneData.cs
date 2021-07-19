using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CleanCore.Scenes
{
    [CreateAssetMenu(fileName = "SceneData", menuName = "Scenes/SceneData")]
    public class SceneData : ScriptableObject
    {
#if UNITY_EDITOR
        public SceneAsset sceneAsset;
#endif

        [Header("Config")]
        public bool useLoadingSreen = true;
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