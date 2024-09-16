using GameControllers.Player;
using GameControllers.Tools.Keys;
using Infrastructure.Services.InputManagement;
using Infrastructure.Services.SoundsManagement;
using Infrastructure.Services.UIManagement.Windows;
using Zenject;

namespace GameControllers.Tools.PushPanels
{
    public class VictoryPushPanel : PushPanel
    {
        protected override float PushedPosition { get; set; } = -0.05f;
        protected override bool AbleToPush { get; set; }

        private IWindowService _windowService;
        private IInputService _inputService;
        private ISoundService _soundService;
        private KeysService _keysService;

        [Inject]
        public void Construct(
            IWindowService windowService,
            IInputService inputService,
            ISoundService soundService,
            KeysService keysService
        )
        {
            _windowService = windowService;
            _inputService = inputService;
            _soundService = soundService;
            _keysService = keysService;
        }

        public override void Interact(Interactor interactor)
        {
            CheckPushPossibility();
            base.Interact(interactor);
        }

        protected override void TriggerPanelAction()
        {
            WindowBase window = _windowService.Open(WindowType.VICTORY, UIRoot);
            _soundService.PlayVictorySound(SoundsSource.Instance, () => window.HandleAllButtons(true));
            _inputService.DisableAll();
        }

        private void CheckPushPossibility()
        {
            AbleToPush = _keysService.IsEnoughKeys();
        }
    }
}