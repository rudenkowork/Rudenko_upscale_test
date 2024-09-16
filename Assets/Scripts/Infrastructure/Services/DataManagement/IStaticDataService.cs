using Infrastructure.Services.UIManagement;
using Infrastructure.Services.UIManagement.Windows;

namespace Infrastructure.Services.DataManagement
{
    public interface IStaticDataService
    {
        WindowBase GetWindow(WindowType windowType);
    }
}