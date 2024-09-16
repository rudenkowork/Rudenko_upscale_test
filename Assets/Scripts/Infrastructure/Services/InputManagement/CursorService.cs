using System;
using Infrastructure.Services.UIManagement.Windows;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.InputManagement
{
    public class CursorService : ICursorService, IInitializable, IDisposable
    {
        private readonly IWindowService _windowService;

        public CursorService(IWindowService windowService)
        {
            _windowService = windowService;
        }

        public void Initialize()
        {
            _windowService.OnWindowHandle += HandleCursor;
        }

        public void Dispose()
        {
            _windowService.OnWindowHandle -= HandleCursor;
        }

        public void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void UnlockCursor()
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        private void HandleCursor(bool isOpened)
        {
            if (isOpened)
            {
                UnlockCursor();
            }
            else
            {
                LockCursor();
            }
        }
    }
}