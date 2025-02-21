using UnityEngine;

namespace pixelook
{
    public class SoundsManager : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        
        [SerializeField] private AudioClip directionChangedSound;
        [SerializeField] private AudioClip playerHitFlagSound;
        [SerializeField] private AudioClip playerPassedFlagsSound;
        [SerializeField] private AudioClip playerDiedSound;

        private void OnEnable()
        {
            EventManager.AddListener(Events.DIRECTION_CHANGED, OnDirectionChanged);
            EventManager.AddListener(Events.GAME_OVER, OnGameOver);
            EventManager.AddListener(Events.FLAG_COLLISION, OnFlagCollision);
            EventManager.AddListener(Events.FLAG_PASSED, OnFlagPassed);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener(Events.DIRECTION_CHANGED, OnDirectionChanged);
            EventManager.RemoveListener(Events.GAME_OVER, OnGameOver);
            EventManager.RemoveListener(Events.FLAG_COLLISION, OnFlagCollision);
            EventManager.RemoveListener(Events.FLAG_PASSED, OnFlagPassed);
        }
        
        private void OnDirectionChanged()
        {
            if (directionChangedSound && Settings.IsSfxEnabled)
                AudioSource.PlayClipAtPoint(directionChangedSound, targetTransform.position);
        }
        
        private void OnFlagCollision()
        {
            if (playerHitFlagSound && Settings.IsSfxEnabled)
                AudioSource.PlayClipAtPoint(playerHitFlagSound, targetTransform.position);
        }
        
        private void OnFlagPassed()
        {
            if (playerPassedFlagsSound && Settings.IsSfxEnabled)
                AudioSource.PlayClipAtPoint(playerPassedFlagsSound, targetTransform.position);
        }
        
        private void OnGameOver()
        {
            if (playerDiedSound && Settings.IsSfxEnabled)
                AudioSource.PlayClipAtPoint(playerDiedSound, targetTransform.position);
        }
    }
}