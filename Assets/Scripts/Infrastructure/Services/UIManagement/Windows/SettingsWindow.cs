using Infrastructure.Services.SoundsManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Services.UIManagement.Windows
{
    public class SettingsWindow : WindowBase
    {
        [SerializeField] private Button Resume;

        protected override void OnEnableAction()
        {
            base.OnEnableAction();
            Resume.onClick.AddListener(ResumeGame);
        }

        protected override void OnDisableAction()
        {
            base.OnDisableAction();
            Resume.onClick.RemoveListener(ResumeGame);
        }

        private void ResumeGame()
        {
            _soundService.PlayButtonPressSound(SoundsSource.Instance);
            _uiHandlerService.HandleSettingsWindow();
        }
    }
}