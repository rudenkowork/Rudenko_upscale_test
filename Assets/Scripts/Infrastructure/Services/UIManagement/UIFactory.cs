using Infrastructure.Services.DataManagement;
using Infrastructure.Services.UIManagement.Windows;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.UIManagement
{
    /// <summary>
    /// UIFactory for all the UI elements. Although there is only one method now, but in real projects
    /// for future scalability, it is good practice to make an abstract factory
    /// </summary>
    public class UIFactory : IUIFactory
    {
        private readonly IStaticDataService _staticData;
        private readonly IInstantiator _instantiator;

        public UIFactory(IStaticDataService staticData, IInstantiator instantiator)
        {
            _staticData = staticData;
            _instantiator = instantiator;
        }

        public WindowBase CreateWindow(WindowType windowType, Transform parent)
        {
            WindowBase prefab = _staticData.GetWindow(windowType);
            WindowBase window = _instantiator.InstantiatePrefabForComponent<WindowBase>(prefab, parent);
            
            return window;
        }

    }
}