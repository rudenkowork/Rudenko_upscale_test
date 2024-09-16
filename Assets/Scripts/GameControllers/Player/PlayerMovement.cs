using Infrastructure.Services.InputManagement;
using UnityEngine;
using Zenject;

namespace GameControllers.Player
{
    /// <summary>
    /// Player movement using new input system and character controller
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        private const float BoostMultiplier = 1.5f;
        private const float Gravity = -14f;
        private const float JumpHeight = 0.8f;

        [SerializeField] private float MovementSpeed = 4f;

        private IMovementInput _movementInput;
        private CharacterController _characterController;
        private Vector2 _movementInputVector;
        private Vector3 _currentMovement;
        private Vector3 _verticalVelocity;
        private bool _isMoving;
        private bool _isRunning;
        private bool _isGrounded;

        [Inject]
        private void Construct(IMovementInput movementInput)
        {
            _movementInput = movementInput;
        }

        private void OnEnable()
        {
            _movementInput.MoveEvent += Move;
            _movementInput.RunEvent += Run;
            _movementInput.RunCancelledEvent += StopRunning;
            _movementInput.JumpEvent += Jump;
        }

        private void OnDisable()
        {
            _movementInput.MoveEvent -= Move;
            _movementInput.RunEvent -= Run;
            _movementInput.RunCancelledEvent -= StopRunning;
            _movementInput.JumpEvent -= Jump;
        }

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void FixedUpdate() => 
            HandleMovement();

        private void HandleMovement()
        {
            _isGrounded = _characterController.isGrounded;

            if (_isGrounded && _verticalVelocity.y < 0)
            {
                _verticalVelocity.y = -2f;
            }

            _verticalVelocity.y += Gravity * Time.fixedDeltaTime;

            _currentMovement = transform.right * _movementInputVector.x + transform.forward * _movementInputVector.y;

            float movementSpeed = _isRunning ? MovementSpeed * BoostMultiplier : MovementSpeed;
            
            if (_isMoving)
            {
                // Move
                _characterController.Move((_currentMovement * movementSpeed + _verticalVelocity) * Time.fixedDeltaTime);
            }
            else
            {
                // Jump
                _characterController.Move(_verticalVelocity * Time.fixedDeltaTime);
            }
        }

        private void Move(Vector2 movementInput)
        {
            _movementInputVector = movementInput;
            _isMoving = movementInput.x != 0 || movementInput.y != 0;
        }

        private void Run()
        {
            _isRunning = true;
        }

        private void StopRunning()
        {
            _isRunning = false;
        }

        private void Jump()
        {
            if (_isGrounded)
            {
                _verticalVelocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
            }
        }
    }
}
