using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "Sounds", menuName = "Configs/Sounds")]
    public class SoundsConfig : ScriptableObject
    {
        public AudioClip TrapSound;
        public AudioClip KeyPickSound;
        public AudioClip ButtonPressSound;
        public AudioClip VictorySound;
    }
}