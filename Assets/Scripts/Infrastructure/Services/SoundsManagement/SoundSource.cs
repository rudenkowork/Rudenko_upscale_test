using UnityEngine;

namespace Infrastructure.Services.SoundsManagement
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundsSource : MonoBehaviour
    {
        public static AudioSource Instance { get; private set; }

        private void Awake() =>
            Instance = GetComponent<AudioSource>();
    }
}