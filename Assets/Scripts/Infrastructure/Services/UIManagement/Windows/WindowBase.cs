using Infrastructure.Services.SoundsManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Infrastructure.Services.UIManagement.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        [SerializeField] protected Button Quit;

        public void Destroyself() =>
            Destroy(gameObject);

        protected IUIHandlerService _uiHandlerService;
        protected ISoundService _soundService;

        [Inject]
        private void Construct(IUIHandlerService uiHandlerService, ISoundService soundService)
        {
            _uiHandlerService = uiHandlerService;
            _soundService = soundService;
        }

        private void OnEnable()
        {
            OnEnableAction();
        }

        private void OnDisable()
        {
            OnDisableAction();
        }

        protected virtual void OnEnableAction()
        {
            Quit.onClick.AddListener(QuitGame);
        }

        protected virtual void OnDisableAction()
        {
            Quit.onClick.RemoveListener(QuitGame);
        }
        
        public virtual void HandleAllButtons(bool isInteractable) => 
            Quit.interactable = isInteractable;

        private void QuitGame()
        {
            _soundService.PlayButtonPressSound(SoundsSource.Instance);
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}