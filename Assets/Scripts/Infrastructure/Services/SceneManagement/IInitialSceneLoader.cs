using System;

namespace Infrastructure.Services.SceneManagement
{
    public interface IInitialSceneLoader
    {
        void InitialLoad(LoadingCurtain loadingCurtain, Action onLoaded = null);
    }
}