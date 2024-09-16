using Infrastructure.Services.UIManagement.Windows;
using TMPro;
using UnityEngine;
using Zenject;

namespace UIControllers
{
    /// <summary>
    /// Timer of playing the game.
    /// I decided to add a maximum time, because the level itself is kinda easy and if the player is afk for a long time, the game will quit
    /// </summary>
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI TimerText;

        [Tooltip("Maximum time in hours")] 
        [SerializeField] private float MaxTime = 2f;

        private IWindowService _windowService;
        private float _elapsedTime;
        private bool _isPlaying;
        
        [Inject]
        private void Construct(IWindowService windowService)
        {
            _windowService = windowService;
        }

        private void OnEnable()
        {
            _windowService.OnWindowHandle += HandleTimer;
        }

        private void OnDisable()
        {
            _windowService.OnWindowHandle -= HandleTimer;
        }

        private void Start() =>
            StartTimer();

        private void Update()
        {
            if (_isPlaying)
            {
                SetProperTime();
            }
        }

        private void SetProperTime()
        {
            _elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(_elapsedTime / 60);
            int seconds = Mathf.FloorToInt(_elapsedTime % 60);
            TimerText.text = $"{minutes:00}:{seconds:00}";

            if (_elapsedTime > MaxTime * 3600)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
            }
        }

        private void HandleTimer(bool isOpened)
        {
            if (isOpened)
            {
                StopTimer();
            }
            else
            {
                StartTimer();
            }
        }

        private void StartTimer() =>
            _isPlaying = true;

        private void StopTimer() =>
            _isPlaying = false;
    }
}