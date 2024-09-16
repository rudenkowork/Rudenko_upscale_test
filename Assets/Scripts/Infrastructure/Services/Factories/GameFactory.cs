using GameControllers.Tools.Keys;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IInstantiator _instantiator;

        public GameFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public Key CreateKey(GameObject prefab, Vector3 position)
        {
            Key instance = _instantiator.InstantiatePrefabForComponent<Key>(prefab, position, Quaternion.identity, null);

            return instance;
        }
    }
}