using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PathSegmentConfiguration", menuName = "Add path segment configuration", order = 0)]
    public class PathSegmentConfiguration : ScriptableObject
    {
        [SerializeField] private PathSegment pathSegmentPrefab;
        [SerializeField] private float minDistanceToEnable = 25f;
        
        public PathSegment PathSegmentPrefab => pathSegmentPrefab;
        
        public float MinDistanceToEnable => minDistanceToEnable;
    }
}