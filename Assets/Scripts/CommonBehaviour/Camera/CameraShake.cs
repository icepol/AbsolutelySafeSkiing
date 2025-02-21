using UnityEngine;

namespace pixelook
{
    public class CameraShake : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        void OnEnable()
        {
            EventManager.AddListener(Events.GAME_OVER, OnGameOver);
            EventManager.AddListener(Events.FLAG_COLLISION, OnPlayerContact);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener(Events.GAME_OVER, OnGameOver);
            EventManager.RemoveListener(Events.FLAG_COLLISION, OnPlayerContact);
        }

        private void OnGameOver()
        {
            _animator.SetTrigger("ShakeBig");
        }
        
        private void OnPlayerContact()
        {
            _animator.SetTrigger("ShakeSmall");
        }
    }
}