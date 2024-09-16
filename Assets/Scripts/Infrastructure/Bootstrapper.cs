using Infrastructure.Services.SceneManagement;
using Infrastructure.Services.SoundsManagement;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    /// <summary>
    /// Entrypoint MonoBehaviour, in bigger projects here could be a logic of
    /// initializing a global state machine or connecting with external resources etc
    /// </summary>
    public class Bootstrapper : MonoBehaviour
    {
        public LoadingCurtain LoadingCurtainPrefab;
        
        private IInitialSceneLoader _sceneLoader;

        [Inject]
        private void Construct(IInitialSceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        private void Start()
        {
            _sceneLoader.InitialLoad(LoadingCurtainPrefab, MusicManager.Instance.Play);
        }
    }
}