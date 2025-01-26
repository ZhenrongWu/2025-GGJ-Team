using UnityEngine;

namespace Core
{
    public class BoundsDetector : MonoBehaviour
    {
        [SerializeField] private GameObject up, down;

        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = GetComponent<Camera>();

            down.transform.position = _mainCamera.ScreenToWorldPoint(Vector2.zero);
            up.transform.position   = _mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        }
    }
}