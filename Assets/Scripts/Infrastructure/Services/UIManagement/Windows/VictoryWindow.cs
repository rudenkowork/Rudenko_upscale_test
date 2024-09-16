using System;
using Infrastructure.Services.SceneManagement;
using Infrastructure.Services.SoundsManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Infrastructure.Services.UIManagement.Windows
{
    public class VictoryWindow : WindowBase
    {
        [SerializeField] private Button PlayAgain;
        
        private ISceneLoader _sceneLoader;

        [Inject]
        private void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        protected override void OnEnableAction()
        {
            base.OnEnableAction();
            PlayAgain.onClick.AddListener(PlayGameAgain);
            HandleAllButtons(isInteractable: false);
        }

        public override void HandleAllButtons(bool isInteractable)
        {
            base.HandleAllButtons(isInteractable);
            PlayAgain.interactable = isInteractable;
        }

        protected override void OnDisableAction()
        {
            base.OnDisableAction();
            PlayAgain.onClick.RemoveListener(PlayGameAgain);
        }
        
        private void PlayGameAgain()
        {
            _soundService.PlayButtonPressSound(SoundsSource.Instance);
            _sceneLoader.Reload(MusicManager.Instance.Play);
        }
    }
}