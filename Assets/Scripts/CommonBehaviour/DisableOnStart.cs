using UnityEngine;

namespace pixelook
{
    public class DisableOnStart : MonoBehaviour
    {
        void Awake()
        {
            Destroy(gameObject);
        }
    }
}