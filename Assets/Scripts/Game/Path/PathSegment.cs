using UnityEngine;

public class PathSegment : MonoBehaviour
{
    [SerializeField] private float height;
    [SerializeField] private float xOffset;
    
    public float Height => height;
    public float XOffset => xOffset;
}
