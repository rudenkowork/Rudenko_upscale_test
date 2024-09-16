using Infrastructure.Services.UIManagement;
using Infrastructure.Services.UIManagement.Windows;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class UIInstaller : MonoInstaller
    {
        public Transform UIRoot;

        public override void InstallBindings()
        {
            BindUIFactory();
            BindWindowService();
            BindUIHandlerService();
        }

        private void BindUIFactory()
        {
            Container
                .Bind<IUIFactory>()
                .To<UIFactory>()
                .AsSingle();
        }

        private void BindWindowService()
        {
            Container
                .Bind<IWindowService>()
                .To<WindowService>()
                .AsSingle();
        }

        private void BindUIHandlerService()
        {
            Container
                .BindInterfacesTo<UIHandlerService>()
                .AsSingle()
                .WithArguments(UIRoot);
        }
    }
}