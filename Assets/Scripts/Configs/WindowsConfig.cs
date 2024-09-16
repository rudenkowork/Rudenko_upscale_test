using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "Windows", menuName = "Configs/Windows")]
    public class WindowsConfig : ScriptableObject
    {
        public WindowData[] WindowsArray;
    }
}