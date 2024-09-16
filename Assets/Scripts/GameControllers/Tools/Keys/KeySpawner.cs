using Configs;
using Extensions;
using Infrastructure.Services.DataManagement;
using UnityEngine;
using Zenject;

namespace GameControllers.Tools.Keys
{
    public class KeySpawner : MonoBehaviour
    {
        public GameObject Prefab { get; private set; }

        private IAssetProvider _assetProvider;

        [Inject]
        private void Construct(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        private void Awake()
        {
            KeyData keyData = _assetProvider.LoadResource<KeysConfig>(AssetPath.KeysConfigPath).Keys.PickRandom();
            Prefab = keyData.Prefab;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.6f);
        }
    }
}