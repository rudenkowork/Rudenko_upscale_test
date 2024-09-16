using System;
using Infrastructure.Services.EventsManagement;
using Infrastructure.Services.Factories;
using UnityEngine;
using Zenject;

namespace GameControllers.Tools.Keys
{
    public class KeysService : MonoBehaviour
    {
        private const float KeyScale = 0.5f;
        private const float GroundOffset = 0.4f;

        public KeySpawner[] KeySpawners;
        public int NeededKeysAmount = 5;

        private int KeysAmount { get; set; }

        private IGameFactory _gameFactory;

        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void OnEnable()
        {
            GameplayEventBus.Instance.OnKeyPickedEvent += AddKey;
        }

        private void OnDisable()
        {
            GameplayEventBus.Instance.OnKeyPickedEvent -= AddKey;
        }

        private void Start()
        {
            SpawnKeys();
        }

        public bool IsEnoughKeys() => 
            NeededKeysAmount == KeysAmount;

        private void AddKey() => 
            KeysAmount++;

        private void SpawnKeys()
        {
            foreach (KeySpawner spawner in KeySpawners)
            {
                Vector3 position = spawner.transform.position + (Vector3.up * GroundOffset);
                Key key = _gameFactory.CreateKey(spawner.Prefab, position);
                key.transform.localScale = new Vector3(KeyScale, KeyScale, KeyScale);
                Destroy(spawner);
            }
        }
    }
}