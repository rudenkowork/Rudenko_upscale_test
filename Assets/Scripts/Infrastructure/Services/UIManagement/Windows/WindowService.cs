using System;
using Infrastructure.Services.SoundsManagement;
using UnityEngine;

namespace Infrastructure.Services.UIManagement.Windows
{
    /// <summary>
    /// This service handles windows visibility
    /// </summary>
    public class WindowService : IWindowService
    {
        public event Action<bool> OnWindowHandle; 
        
        private readonly IUIFactory _uiFactory;

        private WindowBase _currentWindow;

        public WindowService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void CloseCurrentWindow()
        {
            if (_currentWindow == null) return;

            OnWindowHandle?.Invoke(false);
            MusicManager.Instance.Play();
            _currentWindow.Destroyself();
            _currentWindow = null;
        }

        public WindowBase Open(WindowType windowType, Transform parent)
        {
            CloseCurrentWindow();
            
            _currentWindow = _uiFactory.CreateWindow(windowType, parent);
            OnWindowHandle?.Invoke(true);
            MusicManager.Instance.Pause();
            
            return _currentWindow;
        }
    }
}