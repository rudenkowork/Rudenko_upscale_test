using System;

namespace Infrastructure.Services.EventsManagement
{
    /// <summary>
    /// In some bigger projects I would make more advanced event bus, but for a test one, a singleton option is fine
    /// Moreover, it only has one event
    /// </summary>
    public class GameplayEventBus
    {
        private GameplayEventBus()
        {
        }

        public static GameplayEventBus Instance => _instance ??= new GameplayEventBus();

        private static GameplayEventBus _instance;
        
        public Action OnKeyPickedEvent;
    }
}