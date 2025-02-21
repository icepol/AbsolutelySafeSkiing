using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ObstacleConfiguration", menuName = "Add obstacle configuration", order = 0)]
    public class ObstacleConfiguration : ScriptableObject
    {
        [SerializeField] private Obstacle obstaclePrefab;
        [SerializeField] private float minDistanceToEnable = 25f;
        
        public Obstacle ObstaclePrefab => obstaclePrefab;
        
        public float MinDistanceToEnable => minDistanceToEnable;
    }
}