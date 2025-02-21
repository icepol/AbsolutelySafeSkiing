using UnityEngine;

namespace pixelook
{
    public class RemoveOnStart : MonoBehaviour
    {
        void Start()
        {
            Destroy(gameObject);
        }
    }
}