using System.Collections.Generic;
using System.Linq;
using Configs;
using Infrastructure.Services.UIManagement;
using Infrastructure.Services.UIManagement.Windows;
using Zenject;

namespace Infrastructure.Services.DataManagement
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetProvider;
        
        private Dictionary<WindowType, WindowBase> _windows;

        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
            
            InitData();
        }

        private void InitData()
        {
            _windows = _assetProvider.LoadResource<WindowsConfig>(AssetPath.WindowsConfigPath).WindowsArray
                .ToDictionary(window => window.TypeId, window => window.Prefab);
        }

        public WindowBase GetWindow(WindowType windowType) => 
            _windows.GetValueOrDefault(windowType);
    }
}