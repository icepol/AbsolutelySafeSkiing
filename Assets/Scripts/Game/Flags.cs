using pixelook;
using UnityEngine;

public class Flags : MonoBehaviour
{
    [SerializeField] private float minDistanceToEnable = 25f;
    
    private void Start()
    {
        if (GameState.Distance < minDistanceToEnable)
            gameObject.SetActive(false);
    }
}
