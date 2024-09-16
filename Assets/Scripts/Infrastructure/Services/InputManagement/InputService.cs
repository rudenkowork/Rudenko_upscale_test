using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Infrastructure.Services.InputManagement
{
    /// <summary>
    /// Service that provides user input using events
    /// Here is one of SOLID principles is used clearly: Interface Segregation
    /// </summary>
    public class InputService : IInputService, IMovementInput, IUIInput, PlayerInput.ICharacterControlsActions,
        PlayerInput.IUIControlsActions
    {
        public event Action<Vector2> MoveEvent;
        public event Action<Vector2> LookEvent;
        public event Action RunEvent;
        public event Action JumpEvent;
        public event Action RunCancelledEvent;
        public event Action PauseEvent;

        private readonly PlayerInput _playerInput;

        public InputService()
        {
            _playerInput = new PlayerInput();

            _playerInput.CharacterControls.SetCallbacks(this);
            _playerInput.UIControls.SetCallbacks(this);

            SetGameplay();
        }

        public void SetGameplay()
        {
            _playerInput.CharacterControls.Enable();
            _playerInput.UIControls.Enable();
        }

        public void SetUI()
        {
            _playerInput.CharacterControls.Disable();
        }

        public void DisableAll()
        {
            _playerInput.CharacterControls.Disable();
            _playerInput.UIControls.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                JumpEvent?.Invoke();
            }
        }

        public void OnRun(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                RunEvent?.Invoke();
            }
            else if (context.canceled)
            {
                RunCancelledEvent?.Invoke();
            }
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            LookEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                PauseEvent?.Invoke();
            }
        }
    }
}