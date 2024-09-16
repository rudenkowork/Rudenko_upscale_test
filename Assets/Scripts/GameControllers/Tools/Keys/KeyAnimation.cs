using System.Collections;
using UnityEngine;

namespace GameControllers.Tools.Keys
{
    public class KeyAnimation : MonoBehaviour
    {
        [SerializeField] private float LevitationSpeed = 1f;
        [SerializeField] private float LevitationHeight = 0.05f;
        [SerializeField] private float RotationSpeed = 20f;   

        private Vector3 _startPosition;
        
        private void Start()
        {
            _startPosition = transform.position;
            
            StartCoroutine(Levitate());
            StartCoroutine(RotateObject());
        }

        private IEnumerator Levitate()
        {
            while (true)
            {
                float newY = _startPosition.y + Mathf.Sin(Time.time * LevitationSpeed) * LevitationHeight;
                transform.position = new Vector3(_startPosition.x, newY, _startPosition.z);

                yield return null;
            }
        }

        private IEnumerator RotateObject()
        {
            while (true)
            {
                transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
                
                yield return null;
            }
        }

        private void OnDestroy() => 
            StopAllCoroutines();
    }
}
