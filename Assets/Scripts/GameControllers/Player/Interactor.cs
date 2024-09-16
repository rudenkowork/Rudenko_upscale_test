using GameControllers.Tools;
using UnityEngine;

namespace GameControllers.Player
{
    /// <summary>
    /// Dedicated to a player component that provides an interaction with interactable objects on scene marked by Interactable layer
    /// </summary>
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private float InteractionRadius = 0.4f;
        [SerializeField] private Transform InteractionPoint;
        [SerializeField] private LayerMask InteractableMask;
        
        private readonly Collider[] _interactableColliders = new Collider[1];

        private void Update()
        {
            if (TryInteraction(out IInteractable interactable))
            {
                interactable?.Interact(this);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(InteractionPoint.position, InteractionRadius);
        }

        public void ClearInteractables()
        {
            _interactableColliders[0] = null;
        }

        private bool TryInteraction(out IInteractable interactable)
        {
            int hit = Physics.OverlapSphereNonAlloc(InteractionPoint.position, InteractionRadius, _interactableColliders, InteractableMask);
            interactable = _interactableColliders[0]?.GetComponent<IInteractable>();
            
            return hit > 0;
        }
    }
}