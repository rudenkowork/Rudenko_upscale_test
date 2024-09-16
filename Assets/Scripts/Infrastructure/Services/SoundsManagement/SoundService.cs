using System;
using System.Collections;
using Configs;
using Infrastructure.Services.DataManagement;
using Infrastructure.Services.SceneManagement;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.SoundsManagement
{
    public class SoundService : ISoundService, IInitializable
    {
        private const float DefaultVolume = 0.4f;

        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IAssetProvider _assetProvider;
        
        private SoundsConfig _sounds;

        public SoundService(ICoroutineRunner coroutineRunner, IAssetProvider assetProvider)
        {
            _coroutineRunner = coroutineRunner;
            _assetProvider = assetProvider;
        }

        public void Initialize()
        {
            _sounds = _assetProvider.LoadResource<SoundsConfig>(AssetPath.SoundsConfigPath);
        }

        public void PlayOnTrapSound(AudioSource audioSource, Action onPlayed = null) => 
            PlaySound(_sounds.TrapSound, audioSource, onPlayed: onPlayed);

        public void PlayButtonPressSound(AudioSource audioSource) => 
            PlaySound(_sounds.ButtonPressSound, audioSource);
        
        public void PlayKeyPickSound(AudioSource audioSource) => 
            PlaySound(_sounds.KeyPickSound, audioSource);

        public void PlayVictorySound(AudioSource audioSource, Action onPlayed = null) =>
            PlaySound(_sounds.VictorySound, audioSource, onPlayed: onPlayed);

        private void PlaySound(AudioClip sound, AudioSource source, float volume = DefaultVolume,
            bool isLoop = false, Action onPlayed = null)
        {
            source.clip = sound;
            source.volume = volume;
            source.loop = isLoop;
            source.Play();

            if (onPlayed != null)
            {
                _coroutineRunner.StartCoroutine(WaitForSoundEnd(source, onPlayed));
            }
        }

        private IEnumerator WaitForSoundEnd(AudioSource source, Action onPlayed)
        {
            yield return new WaitWhile(() => source.isPlaying);
            onPlayed.Invoke();
        }
    }
}