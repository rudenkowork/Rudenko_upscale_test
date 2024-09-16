using System;
using UnityEngine;

namespace Infrastructure.Services.UIManagement.Windows
{
    public interface IWindowService
    {
        event Action<bool> OnWindowHandle;
        void CloseCurrentWindow();
        WindowBase Open(WindowType windowType, Transform parent);
    }
}