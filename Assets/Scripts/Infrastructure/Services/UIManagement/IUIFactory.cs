using Infrastructure.Services.UIManagement.Windows;
using UnityEngine;

namespace Infrastructure.Services.UIManagement
{
    public interface IUIFactory
    {
        WindowBase CreateWindow(WindowType windowType, Transform parent);
    }
}