using System;

namespace Infrastructure.Services.SceneManagement
{
    public interface ISceneLoader
    {
        void Load(SceneType name, Action onLoaded = null);
        void Reload(Action callback = null);
    }
}