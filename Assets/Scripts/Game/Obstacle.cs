using UnityEngine;

public enum ObstacleBounceDirection
{
    Left,
    Right,
    Random
}

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float bounceForce = 10f;
    [SerializeField] private ObstacleBounceDirection bounceDirection = ObstacleBounceDirection.Random;
    
    public ObstacleBounceDirection BounceDirection => bounceDirection;
}
