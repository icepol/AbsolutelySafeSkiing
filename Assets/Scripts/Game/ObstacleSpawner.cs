using System.Linq;
using pixelook;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private ObstacleConfiguration[] obstacleConfigurations;
    [SerializeField] private float spawnProbability = 1f;
    
    private void Start()
    {
        if (Random.value > spawnProbability) return;
        
        var prefab = GetPrefab();
        
        if (prefab == null) return;
        
        Instantiate(prefab, transform.position, Quaternion.identity, transform);
    }

    Obstacle GetPrefab()
    {
        var availableSegments = obstacleConfigurations
            .Where(configuration => configuration.MinDistanceToEnable < GameState.Distance)
            .ToArray();
        
        return availableSegments.Length == 0 
            ? null
            : availableSegments[Random.Range(0, availableSegments.Length)].ObstaclePrefab;
    }
}
