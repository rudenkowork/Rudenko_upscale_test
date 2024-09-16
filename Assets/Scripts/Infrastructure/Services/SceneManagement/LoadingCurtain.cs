using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Services.SceneManagement
{
    public class LoadingCurtain : MonoBehaviour
    {
        public Image LoadingProgress;

        public void Open()
        {
            LoadingProgress.fillAmount = 0;
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
            LoadingProgress.fillAmount = 1;
        }
    }
}