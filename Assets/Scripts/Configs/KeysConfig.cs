using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "Keys", menuName = "Configs/Keys")]
    public class KeysConfig : ScriptableObject
    {
        public List<KeyData> Keys;
    }
}