using UnityEngine;

namespace Core
{
    public class BubbleController : MonoBehaviour
    {
        [SerializeField] private float maxSpeed      = 10;
        [SerializeField] private float maxForce      = 50;
        [SerializeField] private float minDistance   = 1;
        [SerializeField] private float maxDistance   = 10;
        [SerializeField] private float inputCooldown = .2f;

        private BubbleSpawner _bubbleSpawner;
        private Rigidbody2D   _rigidbody2D;
        private Camera        _mainCamera;

        private float _nextInputTime;

        private void Start()
        {
            _bubbleSpawner = FindFirstObjectByType<BubbleSpawner>();
            _rigidbody2D   = GetComponent<Rigidbody2D>();
            _mainCamera    = Camera.main;

            SetRigidbodyFreezeAll();
        }

        private void Update()
        {
            if (_bubbleSpawner.State != SpawnState.End) return;

            _rigidbody2D.constraints = RigidbodyConstraints2D.None;
            HandlePlayerInput();
        }

        private void HandlePlayerInput()
        {
            if (!Input.GetMouseButtonDown(0) || Time.time < _nextInputTime) return;

            _nextInputTime = Time.time + inputCooldown;

            Vector2 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 localPosition      = transform.localPosition;

            var distance = Vector2.Distance(mouseWorldPosition, localPosition);
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
            var forceMultiplier = 1 - distance / maxDistance;

            var forceDirection = -(mouseWorldPosition - localPosition).normalized;
            var finalForce     = forceDirection * (forceMultiplier * maxForce);

            if (_rigidbody2D.linearVelocity.magnitude < maxSpeed)
                _rigidbody2D.AddForce(finalForce);
        }

        // UnityEvent Callback
        public void SetRigidbodyFreezeAll()
        {
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}