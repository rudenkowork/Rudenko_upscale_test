using GameControllers.Tools.Keys;
using Infrastructure.Services.Factories;
using Infrastructure.Services.InputManagement;
using Zenject;

namespace Infrastructure.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public KeysService KeysService;
        
        public override void InstallBindings()
        {
            BindInputService();
            BindCursorService();
            BindGameFactory();
            BindKeysService();
        }

        private void BindKeysService()
        {
            Container
                .Bind<KeysService>()
                .FromInstance(KeysService)
                .AsSingle();
        }

        private void BindGameFactory()
        {
            Container
                .Bind<IGameFactory>()
                .To<GameFactory>()
                .AsSingle();
        }

        private void BindCursorService()
        {
            Container
                .Bind<IInitializable>()
                .To<CursorService>()
                .AsCached();

            Container
                .Bind<ICursorService>()
                .To<CursorService>()
                .AsCached();
        }

        private void BindInputService()
        {
            Container
                .BindInterfacesTo<InputService>()
                .AsSingle();
        }
        
        
    }
}