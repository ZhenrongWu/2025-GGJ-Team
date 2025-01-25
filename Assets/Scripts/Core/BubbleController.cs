using UnityEngine;

namespace Core
{
    public class BubbleController : MonoBehaviour
    {
        [SerializeField] private float maxSpeed      = 10;
        [SerializeField] private float maxForce      = 50;
        [SerializeField] private float boundForce    = 10;
        [SerializeField] private float minDistance   = 1;
        [SerializeField] private float maxDistance   = 10;
        [SerializeField] private float inputCooldown = .2f;

        [Space(10)] [Range(0, 5)] [SerializeField]
        private int extraBubbleCount;

        [SerializeField] private GameObject bubble;

        private Rigidbody2D    _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private Camera         _mainCamera;

        private float   _spriteWidth;
        private float   _spriteHeight;
        private Vector2 _screenBounds;
        private float   _nextInputTime;

        public int ExtraBubbleCount
        {
            get => extraBubbleCount;
            set => extraBubbleCount = value;
        }

        private void Start()
        {
            _rigidbody2D    = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _mainCamera     = Camera.main;

            _spriteWidth  = _spriteRenderer.bounds.size.x;
            _spriteHeight = _spriteRenderer.bounds.size.y;

            if (_mainCamera != null)
                _screenBounds = _mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            CreateBubbles();
        }

        private void CreateBubbles()
        {
            for (var i = 1; i <= extraBubbleCount; i++)
            {
                var position = new Vector2(transform.position.x + _spriteWidth * i, transform.position.y);
                Instantiate(bubble, position, Quaternion.identity, gameObject.transform);
            }
        }

        private void Update()
        {
            HandlePlayerInput();
            CheckAndBounceAtBounds();
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

        private void CheckAndBounceAtBounds()
        {
            var localPosition = transform.localPosition;
            var direction     = Vector2.zero;

            if (localPosition.x + _spriteWidth / 2 + _spriteWidth * extraBubbleCount > _screenBounds.x)
                direction = Vector2.left;
            if (localPosition.x - _spriteWidth / 2 < -_screenBounds.x)
                direction = Vector2.right;
            if (localPosition.y + _spriteHeight / 2 > _screenBounds.y) direction  = Vector2.down;
            if (localPosition.y - _spriteHeight / 2 < -_screenBounds.y) direction = Vector2.up;

            if (direction == Vector2.zero) return;

            _rigidbody2D.linearVelocity = Vector2.zero;
            _rigidbody2D.AddForce(direction * boundForce);
        }
    }
}