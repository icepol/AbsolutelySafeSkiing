using pixelook;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float minMoveSpeed = 1f;
    [SerializeField] private float maxMoveSpeed = 10f;
    
    [SerializeField] private float moveSpeedIncrease = 1f;
    [SerializeField] private float directionChangeSlowdown = 0.25f;
    [SerializeField] private float hitSlowdown = 1.5f;
    
    [SerializeField] private float sideMoveSpeedMultiplier = 0.5f;
    
    private Player _player;
    
    private int _currentOrientationIndex;
    private float _initialPosition;
    private float _moveSpeed;
    
    public float MoveSpeed
    {
        get => _moveSpeed;
        set => _moveSpeed = Mathf.Clamp(value, minMoveSpeed, maxMoveSpeed);
    }

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        EventManager.AddListener(Events.FLAG_COLLISION, OnFlagCollision);
    }

    void Start()
    {
        MoveSpeed = minMoveSpeed;
        _initialPosition = transform.position.y;
    }
    
    // defines the order of player orientations
    private PlayerOrientation[] _playerOrientations = {
        PlayerOrientation.Left,
        PlayerOrientation.Right,
    };
    
    void Update()
    {
        if (!GameState.IsGameRunning) return;
        
        Move();
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(Events.FLAG_COLLISION, OnFlagCollision);
    }

    void Move()
    {
        var nextPosition = Vector3.down * (MoveSpeed * Time.deltaTime);

        switch (_playerOrientations[_currentOrientationIndex])
        {
            case PlayerOrientation.Left:
                MoveSpeed += moveSpeedIncrease * Time.deltaTime;
                nextPosition += Vector3.left * (MoveSpeed * Time.deltaTime * sideMoveSpeedMultiplier);
                break;
            case PlayerOrientation.Right:
                MoveSpeed += moveSpeedIncrease * Time.deltaTime;
                nextPosition += Vector3.right * (MoveSpeed * Time.deltaTime * sideMoveSpeedMultiplier);
                break;
            case PlayerOrientation.Straight:
                MoveSpeed += moveSpeedIncrease * Time.deltaTime;
                break;
        }
        
        transform.position += nextPosition;
        GameState.Distance = Mathf.Abs(transform.position.y - _initialPosition);
    }
    
    public void ChangeOrientation()
    {
        _currentOrientationIndex = (_currentOrientationIndex + 1) % _playerOrientations.Length;
        MoveSpeed -= directionChangeSlowdown;
        
        _player.Orientation = _playerOrientations[_currentOrientationIndex];
    }
    
    private void OnFlagCollision()
    {
        _moveSpeed -= hitSlowdown;
    }
}
