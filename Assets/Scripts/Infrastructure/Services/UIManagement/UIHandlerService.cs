using System;
using Infrastructure.Services.InputManagement;
using Infrastructure.Services.UIManagement.Windows;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.UIManagement
{
    public class UIHandlerService : IUIHandlerService, IInitializable, IDisposable
    {
        private readonly IWindowService _windowService;
        private readonly IInputService _inputService;
        private readonly IUIInput _uiInput;
        private readonly Transform _uiRoot;

        private bool _settingsOpened;

        public UIHandlerService(IUIInput uiInput, IInputService inputService, IWindowService windowService, Transform uiRoot)
        {
            _uiInput = uiInput;
            _inputService = inputService;
            _windowService = windowService;
            _uiRoot = uiRoot;
        }

        public void Initialize()
        {
            _uiInput.PauseEvent += HandleSettingsWindow;
        }

        public void Dispose()
        {
            _uiInput.PauseEvent -= HandleSettingsWindow;
        }

        public void HandleSettingsWindow()
        {
            if (_settingsOpened)
            {
                _windowService.CloseCurrentWindow();
                _settingsOpened = false;
                _inputService.SetGameplay();
            }
            else
            {
                _windowService.Open(WindowType.SETTINGS, _uiRoot);
                _settingsOpened = true;
                _inputService.SetUI();
            }
        }
    }
}