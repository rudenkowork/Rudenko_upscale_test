using GameControllers.Tools.Keys;
using Infrastructure.Services.EventsManagement;
using TMPro;
using UnityEngine;
using Zenject;

namespace UIControllers
{
    /// <summary>
    /// UI representation of collected by the player keys.
    /// It it was a real project, I would transfer the logic of counting keys in a separate class, because
    /// that info may have been used not only here
    /// </summary>
    public class KeysCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI KeysCount;
        
        private KeysService _keysService;
        private int _neededKeysAmount;
        private int _keysAmount;

        [Inject]
        private void Construct(KeysService keysService)
        {
            _keysService = keysService;
        }
        
        private void OnEnable()
        {
            GameplayEventBus.Instance.OnKeyPickedEvent += PickKey;
        }

        private void OnDisable()
        {
            GameplayEventBus.Instance.OnKeyPickedEvent -= PickKey;
        }

        private void Start()
        {
            _neededKeysAmount = _keysService.NeededKeysAmount;
            SetUI();
        }

        private void PickKey()
        {
            _keysAmount++;
            SetUI();
        }

        private void SetUI()
        {
            KeysCount.text = $"{_keysAmount}/{_neededKeysAmount}";

            if (_keysAmount == _neededKeysAmount)
            {
                KeysCount.color = Color.green;
            }
        }
    }
}