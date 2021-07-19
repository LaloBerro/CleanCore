using CleanCore.Patterns;
using CleanCore.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CleanCore.Scenes
{
    public class ScenesController : Singleton<ScenesController>, IProgressiveTask
    {
        #region Vars

        [Header("Header")]
        [SerializeField] private  SceneData loadingScreenData;

        [Header("Debug")]
        [SerializeField] private int _progress;    

        [SerializeField] private SceneData _currentSceneData;
        [SerializeField] private SceneData _principalScene;

        [SerializeField] private List<SceneData> _openScenes = new List<SceneData>();
        private List<AsyncOperation> _operations;

        public int Progress { get => _progress; }

        #endregion

        #region Methods

        #region Build-In

        private void Awake()
        {
            PassTroughScenes();
            InitVariables();
        }

        #endregion

        #region Init Vars

        private void InitVariables()
        {
            _operations = new List<AsyncOperation>();
        }

        #endregion

        #region Custom

        #region Public

        /// <summary>
        /// Get the current scene data
        /// </summary>
        /// <returns></returns>
        public SceneData GetCurrentScene()
        {
            return _currentSceneData;
        }

        #endregion

        #region Load Scene

        /// <summary>
        /// Set and run the SceneLoaderData
        /// </summary>
        /// <param name="sceneData"></param>
        public void LoadScene(SceneData sceneData)
        {
            _operations.Clear();

            _currentSceneData = sceneData;

            StartCoroutine(LoadProcess());
        }
        
        private IEnumerator LoadProcess()
        {
            yield return StartCoroutine(LoadLoadingScreen());

            RemoveOpenScenes();

            OpenScenes();

            yield return StartCoroutine(WaitToAllOperationsDone());

            UnloadLoadingScreen();

            SetPrincipalScene();

            OnAllOperationsDone();
        }

        private IEnumerator LoadLoadingScreen()
        {
            if (_currentSceneData.useLoadingSreen == false) yield return null;

            AsyncOperation loadLoadingOperation = SceneManager.LoadSceneAsync(loadingScreenData.nameScene, LoadSceneMode.Additive);

            yield return new WaitUntil(() => loadLoadingOperation.isDone);
        }

        #region Remove Scene

        private void RemoveOpenScenes() 
        {
            for (int i = 0; i < _openScenes.Count; i++)
            {
                if (CantRemoveThisScene(_openScenes[i])) continue;

                RemoveScene(_openScenes[i]);

                i--;
            }
        }

        private void RemoveScene(SceneData openScene)
        {
            AsyncOperation removeSceneOperation = SceneManager.UnloadSceneAsync(openScene.nameScene);

            _operations.Add(removeSceneOperation);

            _openScenes.Remove(openScene);
        }

        private bool CantRemoveThisScene(SceneData sceneData)
        {
            return sceneData.isLockedScene && !_currentSceneData.removeLockedScenes;
        }

        #endregion

        #region Open Scene

        private void OpenScenes()
        {
            SceneData[] scenesToLoad = _currentSceneData.GetAllScenesToOpen();
            
            foreach(var sceneData in scenesToLoad)
            {
                if (IsThisSceneOpen(sceneData)) continue;

                OpenScene(sceneData);
            }
        }

        private bool IsThisSceneOpen(SceneData sceneData)
        {
            return _openScenes.Contains(sceneData);
        }

        private void OpenScene(SceneData sceneData)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneData.nameScene, LoadSceneMode.Additive);

            _operations.Add(operation);

            _openScenes.Add(sceneData);

            if (sceneData.isPrincipal) _principalScene = sceneData;
        }

        #endregion

        private IEnumerator WaitToAllOperationsDone()
        {
            int operationsCount = _operations.Count;
            float totalProgress = 0;

            foreach (var operation in _operations)
                while (!operation.isDone)
                {
                    totalProgress += operation.progress;

                    _progress = Mathf.RoundToInt(totalProgress / operationsCount);

                    yield return null;
                }
        }

        private void UnloadLoadingScreen()
        {
            if (_currentSceneData.useLoadingSreen)
                SceneManager.UnloadSceneAsync(loadingScreenData.nameScene);
        }

        private void SetPrincipalScene()
        {
            if (_principalScene)
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(_principalScene.nameScene));
        }

        private void OnAllOperationsDone()
        {
            Debug.Log("All scene are loaded");
        }

        #endregion

        #endregion

        #endregion
    }
}