using UnityEngine;

public class RandomizeEnabled : MonoBehaviour
{
    [SerializeField] private float enabledChance = 0.5f;
    
    void Start()
    {
        if (Random.value < enabledChance)
        {
            gameObject.SetActive(false);
        }
    }
}
