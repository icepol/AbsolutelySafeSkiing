using System.Collections.Generic;
using System.Linq;
using pixelook;
using ScriptableObjects;
using UnityEngine;

public class PathSpawner : MonoBehaviour
{
    [SerializeField] private PathSegmentConfiguration[] pathSegmentConfigurations;
    [SerializeField] private float spawnDistance = 10f;
    
    [SerializeField] private int spawnCount = 5;
    [SerializeField] private float removeDistance = 10f;
    
    private Transform _playerTransform;
    
    private List<PathSegment> _currentPathSegments;
    
    void Awake()
    {
        _currentPathSegments = new List<PathSegment>();
    }
    
    void Start()
    {
        _playerTransform = FindAnyObjectByType<Player>().transform;
    }
    
    void FixedUpdate()
    {
        RemoveOldPathSegments();
        SpawnIfRequired();
    }
    
    void SpawnIfRequired()
    {
        // nothing to do if there are no path segments
        if (_currentPathSegments.Count >= spawnCount) return;
        
        var nextPathSegmentPrefab = GetNextPathSegmentPrefab();
        var spawnedPathSegment = Instantiate(nextPathSegmentPrefab, GetNextPosition(), Quaternion.identity, transform);

        _currentPathSegments.Add(spawnedPathSegment);
    }
    
    PathSegment GetNextPathSegmentPrefab()
    {
        var availableSegments = pathSegmentConfigurations
            .Where(configuration => configuration.MinDistanceToEnable < GameState.Distance)
            .ToArray();
        
        return availableSegments.Length == 0 
            ? pathSegmentConfigurations[0].PathSegmentPrefab 
            : availableSegments[Random.Range(0, availableSegments.Length)].PathSegmentPrefab;
    }
    
    Vector3 GetNextPosition()
    {
        if (_currentPathSegments.Count == 0)
        {
            return Vector3.up * spawnDistance;
        }
        
        var lastPathSegment = _currentPathSegments[^1];
        return lastPathSegment.transform.position + Vector3.right * lastPathSegment.XOffset + Vector3.down * lastPathSegment.Height;
    }
    
    void RemoveOldPathSegments()
    {
        if (!GameState.IsGameRunning) return;
        
        // nothing to do if there are no path segments
        if (_currentPathSegments.Count == 0) return;
        
        var firstPathSegment = _currentPathSegments[0];

        if (_playerTransform.position.y + removeDistance > firstPathSegment.transform.position.y) return;
        
        _currentPathSegments.RemoveAt(0);
        
        Destroy(firstPathSegment.gameObject);
    }
}
