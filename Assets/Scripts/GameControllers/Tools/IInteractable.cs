using GameControllers.Player;

namespace GameControllers.Tools
{
    /// <summary>
    /// Interface that defines all objects that can interact with Interactor
    /// </summary>
    public interface IInteractable
    {
        public void Interact(Interactor interactor);
    }
}