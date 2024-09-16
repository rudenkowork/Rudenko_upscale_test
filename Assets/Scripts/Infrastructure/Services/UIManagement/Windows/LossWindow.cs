using Infrastructure.Services.SceneManagement;
using Infrastructure.Services.SoundsManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Infrastructure.Services.UIManagement.Windows
{
    public class LossWindow : WindowBase
    {
        [SerializeField] private Button TryAgain;

        private ISceneLoader _sceneLoader;

        [Inject]
        private void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        protected override void OnEnableAction()
        {
            base.OnEnableAction();
            TryAgain.onClick.AddListener(TryGameAgain);
            HandleAllButtons(isInteractable: false);
        }

        protected override void OnDisableAction()
        {
            base.OnDisableAction();
            TryAgain.onClick.RemoveListener(TryGameAgain);
        }

        public override void HandleAllButtons(bool isInteractable)
        {
            base.HandleAllButtons(isInteractable);
            TryAgain.interactable = isInteractable;
        }

        private void TryGameAgain()
        {
            _soundService.PlayButtonPressSound(SoundsSource.Instance);
            _sceneLoader.Reload(MusicManager.Instance.Play);
        }
    }
}