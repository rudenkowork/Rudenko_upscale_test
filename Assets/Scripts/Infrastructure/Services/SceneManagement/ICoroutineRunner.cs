using System.Collections;
using UnityEngine;

namespace Infrastructure.Services.SceneManagement
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}