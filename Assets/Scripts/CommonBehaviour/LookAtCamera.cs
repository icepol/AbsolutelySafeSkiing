using UnityEngine;

namespace pixelook
{
    public class LookAtCamera : MonoBehaviour
    {
        [SerializeField] private bool keepYPosition = true;
        [SerializeField] private bool correctYRotation = true;

        Camera _mainCamera;

        void Start()
        {
            _mainCamera = Camera.main;
        }

        private void LateUpdate()
        {
            var whereToLook = _mainCamera.transform.position;

            if (keepYPosition)
                whereToLook.y = transform.position.y;

            transform.LookAt(whereToLook);

            if (correctYRotation)
            {
                // Rotate 180 degrees to face the camera correctly
                transform.Rotate(0, 180, 0);
            }
        }
    }
}