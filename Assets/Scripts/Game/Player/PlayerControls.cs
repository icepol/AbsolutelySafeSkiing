using pixelook;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private bool _isControlEnabled;
    
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }
    
    private void OnEnable()
    {
        EventManager.AddListener(Events.POST_GAME_STARTED, OnPostGameStarted);
        EventManager.AddListener(Events.GAME_OVER, OnGameOver);
    }
    
    private void OnDisable()
    {
        EventManager.RemoveListener(Events.POST_GAME_STARTED, OnPostGameStarted);
        EventManager.RemoveListener(Events.GAME_OVER, OnGameOver);
    }

    private void Update()
    {
        if (!_isControlEnabled) return;
        
        if (Input.anyKeyDown)
        {
            _playerMovement.ChangeOrientation();
        }
    }

    private void OnPostGameStarted()
    {
        _isControlEnabled = true;
    }
    
    private void OnGameOver()
    {
        _isControlEnabled = false;
    }
}
