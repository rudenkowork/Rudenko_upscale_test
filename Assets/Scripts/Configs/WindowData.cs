using System;
using Infrastructure.Services.UIManagement;
using Infrastructure.Services.UIManagement.Windows;

namespace Configs
{
    [Serializable]
    public struct WindowData
    {
        public WindowType TypeId;
        public WindowBase Prefab;
    }
}