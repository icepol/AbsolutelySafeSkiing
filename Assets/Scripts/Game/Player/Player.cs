using System;
using pixelook;
using UnityEngine;

public enum PlayerOrientation
{
    Left,
    Straight,
    Right
}

public class Player : MonoBehaviour
{
    [SerializeField] private ParticleSystem snowTrail;
    [SerializeField] private ParticleSystem changeDirectionSnowPrefab;
    [SerializeField] private ParticleSystem playerDiedParticles;
    
    private PlayerOrientation _orientation = PlayerOrientation.Straight;
    
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        
        snowTrail.Stop();
    }

    private void OnEnable()
    {
        EventManager.AddListener(Events.GAME_STARTED, OnGameStarted);
        EventManager.AddListener(Events.DIRECTION_CHANGED, OnDirectionChanged);
    }
    
    private void OnDisable()
    {
        EventManager.RemoveListener(Events.GAME_STARTED, OnGameStarted);
        EventManager.RemoveListener(Events.DIRECTION_CHANGED, OnDirectionChanged);
    }

    public PlayerOrientation Orientation
    {
        get => _orientation;
        
        set
        {
            if (_orientation == value) return;
            
            _orientation = value;
            
            EventManager.TriggerEvent(Events.DIRECTION_CHANGED);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Obstacle>()) OnCollisionWithObstacle();
        if (other.GetComponent<Flag>()) OnCollisionWithFlag();
        if (other.GetComponent<Flags>()) OnCollisionWithFlags();
    }

    private void OnDirectionChanged()
    {
        switch (_orientation)
        {
            case PlayerOrientation.Left:
                _spriteRenderer.flipX = true;
                break;
            case PlayerOrientation.Right:
                _spriteRenderer.flipX = false;
                break;
            case PlayerOrientation.Straight:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        Instantiate(changeDirectionSnowPrefab, transform.position, Quaternion.identity);
    }
    
    private void OnCollisionWithObstacle()
    {
        EventManager.TriggerEvent(Events.GAME_OVER);
        
        Instantiate(playerDiedParticles, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
    }
    
    private void OnCollisionWithFlag()
    {
        EventManager.TriggerEvent(Events.FLAG_COLLISION);
    }
    
    private void OnCollisionWithFlags()
    {
        // fired when player passes the flags without contact
        GameState.FlagsPassed += 1;
        
        EventManager.TriggerEvent(Events.FLAG_PASSED);
    }

    private void OnGameStarted()
    {
        snowTrail.Play();
    }
}
