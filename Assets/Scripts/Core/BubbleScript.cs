using UnityEngine;

namespace Core
{
    public class BubbleScript : MonoBehaviour
    {
        [SerializeField] private float maxSpeed      = 10;
        [SerializeField] private float maxForce      = 50;
        [SerializeField] private float boundForce    = 10;
        [SerializeField] private float minDistance   = 1;
        [SerializeField] private float maxDistance   = 10;
        [SerializeField] private float inputCooldown = .2f;

        private Rigidbody2D    _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private Animator       _animator;
        private Camera         _mainCamera;

        private float   _spriteHalfWidth;
        private float   _spriteHalfHeight;
        private Vector2 _screenBounds;
        private float   _nextInputTime;

        private void Start()
        {
            _rigidbody2D    = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator       = GetComponent<Animator>();
            _mainCamera     = Camera.main;

            _spriteHalfWidth  = _spriteRenderer.bounds.size.x / 2;
            _spriteHalfHeight = _spriteRenderer.bounds.size.y / 2;

            if (_mainCamera != null)
                _screenBounds = _mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        }

        private void Update()
        {
            HandleAnimationEnd();
            HandlePlayerInput();
            CheckAndBounceAtBounds();
        }

        private void HandleAnimationEnd()
        {
            var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 1 && stateInfo.IsName("Bubble_Cracked"))
                Destroy(gameObject);
        }

        private void HandlePlayerInput()
        {
            if (!Input.GetMouseButtonDown(0) || Time.time < _nextInputTime) return;

            _nextInputTime = Time.time + inputCooldown;

            Vector2 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 localPosition      = transform.localPosition;

            var hitCollider = Physics2D.OverlapPoint(mouseWorldPosition);
            if (hitCollider != null && hitCollider.CompareTag("Bubble"))
            {
                _animator.SetTrigger($"IsCracked");
            }
            else
            {
                var distance = Vector2.Distance(mouseWorldPosition, localPosition);
                distance = Mathf.Clamp(distance, minDistance, maxDistance);
                var forceMultiplier = 1 - distance / maxDistance;

                var forceDirection = -(mouseWorldPosition - localPosition).normalized;
                var finalForce     = forceDirection * (forceMultiplier * maxForce);

                if (_rigidbody2D.linearVelocity.magnitude < maxSpeed)
                    _rigidbody2D.AddForce(finalForce);
            }
        }

        private void CheckAndBounceAtBounds()
        {
            var localPosition = transform.localPosition;
            var direction     = Vector2.zero;

            if (localPosition.x > _screenBounds.x  - _spriteHalfWidth) direction  = Vector2.left;
            if (localPosition.x < -_screenBounds.x + _spriteHalfWidth) direction  = Vector2.right;
            if (localPosition.y > _screenBounds.y  - _spriteHalfHeight) direction = Vector2.down;
            if (localPosition.y < -_screenBounds.y + _spriteHalfHeight) direction = Vector2.up;

            if (direction == Vector2.zero) return;

            _rigidbody2D.linearVelocity = Vector2.zero;
            _rigidbody2D.AddForce(direction * boundForce);
        }
    }
}