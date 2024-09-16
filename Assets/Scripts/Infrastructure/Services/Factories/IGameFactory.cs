using GameControllers.Tools.Keys;
using UnityEngine;

namespace Infrastructure.Services.Factories
{
    public interface IGameFactory
    {
        Key CreateKey(GameObject prefab, Vector3 position);
    }
}