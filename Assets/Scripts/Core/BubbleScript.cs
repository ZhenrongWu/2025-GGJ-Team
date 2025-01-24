using UnityEngine;

namespace Core
{
    public class BubbleScript : MonoBehaviour
    {
        [SerializeField] private float maxSpeed    = 10;
        [SerializeField] private float force       = 10;
        [SerializeField] private float boundForce  = 10;
        [SerializeField] private float minDistance = 1f;
        [SerializeField] private float maxDistance = 10;

        private Rigidbody2D    _rigidbody2D;
        private SpriteRenderer _spriteRenderer;

        private Vector2 _originalPos;
        private int     _screenWidth;
        private int     _screenHeight;
        private Vector2 _screenBounds;
        private float   _spriteWidth;
        private float   _spriteHeight;

        private void Start()
        {
            _rigidbody2D    = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _originalPos = transform.localPosition;

            _screenWidth  = Screen.width;
            _screenHeight = Screen.height;

            if (Camera.main != null)
                _screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(_screenWidth, _screenHeight));

            _spriteWidth  = _spriteRenderer.bounds.size.x;
            _spriteHeight = _spriteRenderer.bounds.size.y;
        }

        private void Update()
        {
            if (Camera.main == null) return;

            if (SetScreenBounds()) return;

            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                var distance = Vector2.Distance(mouseWorldPos, _originalPos);
                distance = Mathf.Clamp(distance, minDistance, maxDistance);
                var forceMultiplier = 1 - distance / maxDistance;

                var forceDirection = -(mouseWorldPos - _originalPos).normalized;
                var finalForce     = forceDirection * forceMultiplier * force;

                if (_rigidbody2D.linearVelocity.magnitude <= maxSpeed)
                    _rigidbody2D.AddForce(finalForce);
            }
        }

        private bool SetScreenBounds()
        {
            if (transform.position.x > _screenBounds.x - _spriteWidth / 2)
            {
                _rigidbody2D.linearVelocity = Vector2.zero;

                if (_rigidbody2D.linearVelocity == Vector2.zero)
                    _rigidbody2D.AddForce(-_rigidbody2D.transform.right * boundForce);
                return true;
            }

            if (transform.position.x < -_screenBounds.x + _spriteWidth / 2)
            {
                _rigidbody2D.linearVelocity = Vector2.zero;
                if (_rigidbody2D.linearVelocity == Vector2.zero)
                    _rigidbody2D.AddForce(_rigidbody2D.transform.right * boundForce);
                return true;
            }

            if (transform.position.y > _screenBounds.y - _spriteHeight / 2)
            {
                _rigidbody2D.linearVelocity = Vector2.zero;
                if (_rigidbody2D.linearVelocity == Vector2.zero)
                    _rigidbody2D.AddForce(-_rigidbody2D.transform.up * boundForce);
                return true;
            }

            if (transform.position.y < -_screenBounds.y + _spriteHeight / 2)
            {
                _rigidbody2D.linearVelocity = Vector2.zero;
                if (_rigidbody2D.linearVelocity == Vector2.zero)
                    _rigidbody2D.AddForce(_rigidbody2D.transform.up * boundForce);
                return true;
            }

            return false;
        }
    }
}