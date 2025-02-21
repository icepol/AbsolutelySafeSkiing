using System;
using System.Collections;
using pixelook;
using UnityEngine;
using UnityEngine.UI;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] private Sprite faceOkSprite;
    [SerializeField] private Sprite faceSpeedSprite;
    [SerializeField] private Sprite faceHitSprite;
    [SerializeField] private Sprite faceDeadSprite;
    
    [SerializeField] private float speedThreshold = 5f;
    
    [SerializeField] private float resetTime = 1f;
    
    private PlayerMovement _playerMovement;
    private Image _image;
    
    private Vector3 _initialPosition;
    private bool _isFrozen;

    private void Awake()
    {
        _playerMovement = FindFirstObjectByType<PlayerMovement>();
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        EventManager.AddListener(Events.DIRECTION_CHANGED, OnDirectionChanged);
        EventManager.AddListener(Events.FLAG_COLLISION, OnFlagCollision);
        EventManager.AddListener(Events.GAME_OVER, OnPlayerDied);
    }

    void Start()
    {
        _image.sprite = faceOkSprite;
    }

    private void FixedUpdate()
    {
        if (!GameState.IsGameRunning) return;
        
        UpdateCamera();
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(Events.DIRECTION_CHANGED, OnDirectionChanged);
        EventManager.RemoveListener(Events.FLAG_COLLISION, OnFlagCollision);
        EventManager.RemoveListener(Events.GAME_OVER, OnPlayerDied);
    }
    
    private void OnDirectionChanged()
    {
        _image.sprite = faceSpeedSprite;
        
        StartCoroutine(WaitAndReset());
    }
    
    private void OnFlagCollision()
    {
        _image.sprite = faceHitSprite;
        
        StopAllCoroutines();
        StartCoroutine(WaitAndReset());
    }
    
    private void OnPlayerDied()
    {
        _image.sprite = faceDeadSprite;
    }
    
    private void UpdateCamera()
    {
        if (_isFrozen) return;
        
        _image.sprite = _playerMovement.MoveSpeed > speedThreshold ? faceSpeedSprite : faceOkSprite;
    }
    
    IEnumerator WaitAndReset()
    {
        _isFrozen = true;
            
        yield return new WaitForSeconds(resetTime);
        
        _isFrozen = false;
        
        UpdateCamera();
    }
}
