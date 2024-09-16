using Infrastructure.Services.InputManagement;
using Infrastructure.Services.UIManagement.Windows;
using UnityEngine;
using Zenject;

namespace GameControllers.Player
{
    /// <summary>
    /// Handles player rotation according to the mouse movement
    /// </summary>
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private float MouseSensitivity = 110f;
        [SerializeField] private Transform Camera;

        private ICursorService _cursorService;
        private IWindowService _windowService;
        private IMovementInput _movementInput;
        private float _xRotation;
        private bool _isPlaying;
        private float _mouseX = 0f;
        private float _mouseY = 0f;

        [Inject]
        private void Construct(ICursorService cursorService, IWindowService windowService, IMovementInput movementInput)
        {
            _cursorService = cursorService;
            _windowService = windowService;
            _movementInput = movementInput;
        }

        private void OnEnable()
        {
            _windowService.OnWindowHandle += HandlePlaymode;
            _movementInput.LookEvent += SetMouseDirection;
        }

        private void OnDisable()
        {
            _windowService.OnWindowHandle -= HandlePlaymode;
            _movementInput.LookEvent -= SetMouseDirection;
        }

        private void Awake()
        {
            _cursorService.LockCursor();
            _isPlaying = true;
            _xRotation = Camera.localRotation.eulerAngles.x;
        }

        private void Update()
        {
            if (_isPlaying)
            {
                HandleRotation();
            }
        }

        private void SetMouseDirection(Vector2 mouseDirection)
        {
            _mouseX = mouseDirection.x * MouseSensitivity * Time.deltaTime;
            _mouseY = mouseDirection.y * MouseSensitivity * Time.deltaTime;
        }

        private void HandlePlaymode(bool isOpened) => 
            _isPlaying = !isOpened;

        private void HandleRotation()
        {
            _mouseX = Mathf.Clamp(_mouseX, -1f, 1f);
            _mouseY = Mathf.Clamp(_mouseY, -1f, 1f);
            
            _xRotation -= _mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
            
            Camera.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * _mouseX);
        }
    }
}