using System.Collections;
using GameControllers.Player;
using UnityEngine;

namespace GameControllers.Tools.PushPanels
{
    /// <summary>
    /// Base class for all panels that can be pushed by the Interactor
    /// After it is pushed, some action is invoked that is defined in child classes
    /// </summary>
    public abstract class PushPanel : MonoBehaviour, IInteractable
    {
        private const float PushSpeed = 0.4f;

        [SerializeField] protected Transform UIRoot;

        protected virtual float PushedPosition { get; set; } = 0f;
        protected abstract bool AbleToPush { get; set; }

        private bool _isPushed;

        public virtual void Interact(Interactor interactor)
        {
            if (!_isPushed)
            {
                if (AbleToPush)
                {
                    StartCoroutine(Push());
                }
            }
        }

        private IEnumerator Push()
        {
            _isPushed = true;

            while (transform.position.y > PushedPosition)
            {
                float x = transform.position.x;
                float y = (transform.position.y - Time.deltaTime * PushSpeed) < PushedPosition
                    ? PushedPosition
                    : (transform.position.y - Time.deltaTime * PushSpeed);
                float z = transform.position.z;
                transform.position = new Vector3(x, y, z);

                yield return null;
            }

            TriggerPanelAction();
        }

        protected abstract void TriggerPanelAction();
    }
}