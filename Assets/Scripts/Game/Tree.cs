using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tree : MonoBehaviour
{
    [SerializeField] private Sprite[] treeSprites;
    
    [SerializeField] private Grass grass;
    
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        var obstacle = GetComponent<Obstacle>();
        
        grass.transform.position = new Vector3(
            grass.transform.position.x + (obstacle.BounceDirection == ObstacleBounceDirection.Left ? 1.5f : -1.5f), 
            grass.transform.position.y, 
            grass.transform.position.z);
        
        grass.gameObject.SetActive(obstacle.BounceDirection != ObstacleBounceDirection.Random);
        
        _spriteRenderer.sprite = treeSprites[Random.Range(0, treeSprites.Length)];
    }
}
