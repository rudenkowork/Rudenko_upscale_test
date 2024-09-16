using System;
using UnityEngine;

namespace Infrastructure.Services.SoundsManagement
{
    public interface ISoundService
    {
        void PlayOnTrapSound(AudioSource audioSource, Action onPlayed = null);
        void PlayButtonPressSound(AudioSource audioSource);
        void PlayKeyPickSound(AudioSource audioSource);
        void PlayVictorySound(AudioSource audioSource, Action onPlayed = null);
    }
}