using System;

namespace Infrastructure.Services.InputManagement
{
    public interface IUIInput
    {
        event Action PauseEvent;
    }
}