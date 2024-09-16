using System;
using System.Collections;
using Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.Services.SceneManagement
{
    public class SceneLoader : ISceneLoader, IInitialSceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IInstantiator _instantiator;
        
        private LoadingCurtain _loadingCurtain;

        public SceneLoader(ICoroutineRunner coroutineRunner, IInstantiator instantiator)
        {
            _coroutineRunner = coroutineRunner;
            _instantiator = instantiator;
        }
        
        public void Load(SceneType name, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));

        public void Reload(Action callback = null)
        {
            _coroutineRunner.StartCoroutine(ReloadScene(callback));
        }
        
        private IEnumerator ReloadScene(Action callback)
        {
            AsyncOperation waitSceneLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

            while (!waitSceneLoad.isDone)
            {
                _loadingCurtain.Open();
                _loadingCurtain.LoadingProgress.fillAmount = waitSceneLoad.progress;
                yield return new WaitForEndOfFrame();
            }
            
            _loadingCurtain.Close();
            callback?.Invoke();
        }

        public void InitialLoad(LoadingCurtain loadingCurtain, Action onLoaded = null)
        {
            _loadingCurtain = _instantiator.InstantiatePrefabForComponent<LoadingCurtain>(loadingCurtain);
            Load(SceneType.GAMEPLAY, onLoaded);
        }

        private IEnumerator LoadScene(SceneType nextScene, Action onLoaded)
        {
            if (SceneManager.GetActiveScene().name == nextScene.ToStringFormat())
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitSceneLoad = SceneManager.LoadSceneAsync(nextScene.ToStringFormat());

            while (!waitSceneLoad.isDone)
            {
                _loadingCurtain.Open();
                _loadingCurtain.LoadingProgress.fillAmount = waitSceneLoad.progress;
                yield return new WaitForEndOfFrame();
            }
            
            _loadingCurtain.Close();

            onLoaded?.Invoke();
        }
    }
}