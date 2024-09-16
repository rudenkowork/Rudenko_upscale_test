using Infrastructure.Services.DataManagement;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.SoundsManagement
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicManager : MonoBehaviour
    {
        private IAssetProvider _assetProvider;
        private AudioSource _audioSource;

        public static MusicManager Instance { get; private set; }

        [Inject]
        private void Construct(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        private void Awake() => 
            Instance = this;
        
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            AudioClip music = _assetProvider.LoadResource<AudioClip>(AssetPath.BackgroundMusicPath);
            SetBackgroundMusic(music);
        }

        public void Play() => 
            _audioSource.Play();

        public void Pause() =>
            _audioSource.Pause();

        private void SetBackgroundMusic(AudioClip music) => 
            _audioSource.clip = music;
    }
}