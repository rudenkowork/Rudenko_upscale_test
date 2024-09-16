using UnityEngine;

namespace Infrastructure.Services.DataManagement
{
    public interface IAssetProvider
    {
        TResource LoadResource<TResource>(string path) where TResource : Object;
    }
}