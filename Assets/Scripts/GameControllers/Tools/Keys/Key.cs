using GameControllers.Player;
using Infrastructure.Services.EventsManagement;
using Infrastructure.Services.SoundsManagement;
using UnityEngine;
using Zenject;

namespace GameControllers.Tools.Keys
{
    public class Key : MonoBehaviour, IInteractable
    {
        private ISoundService _soundService;

        [Inject]
        private void Construct(ISoundService soundService)
        {
            _soundService = soundService;
        }
        
        public void Interact(Interactor interactor)
        {
            _soundService.PlayKeyPickSound(SoundsSource.Instance);
            GameplayEventBus.Instance.OnKeyPickedEvent?.Invoke();
            interactor.ClearInteractables();
            Destroy(gameObject);
        }
    }
}