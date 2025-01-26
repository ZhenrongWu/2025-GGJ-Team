using Unity.VisualScripting;
using UnityEngine;

namespace Core
{
    public class BubbleController : MonoBehaviour
    {
        [Header("Control Settings")] [SerializeField]
        private float maxSpeed = 10;

        [SerializeField] private float maxForce      = 50;
        [SerializeField] private float boundForce    = 10;
        [SerializeField] private float minDistance   = 1;
        [SerializeField] private float maxDistance   = 10;
        [SerializeField] private float inputCooldown = .2f;

        [Header("Bubble Settings")] [Space(10)] [Range(0, 5)] [SerializeField]
        public int bubbleCount;

        public                    float      bubbleLifeTime;
        [HideInInspector] public  float      counter;
        [SerializeField]  private GameObject bubble;

        private Rigidbody2D    _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private Camera         _mainCamera;

        private float   _spriteWidth;
        private float   _spriteHeight;
        private Vector2 _screenBounds;
        private float   _nextInputTime;

        private void Start()
        {
            _rigidbody2D    = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _mainCamera     = Camera.main;

            _spriteWidth  = _spriteRenderer.bounds.size.x;
            _spriteHeight = _spriteRenderer.bounds.size.y;

            if (_mainCamera != null)
                _screenBounds = _mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        }

        private void Update()
        {
            counter += Time.deltaTime;
            if (counter >= bubbleLifeTime)
            {
                if (bubbleCount > 0)
                {
                    bubbleCount--;
                    transform.GetChild(0).GetComponent<BubbleStateController>().DestoryBubble();
                }

                counter = 0;
            }

            HandlePlayerInput();
            UpdatePositionToMidPoint();
            if (transform.childCount == 0) gameObject.SetActive(false);
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

        // private void CheckAndBounceAtBounds()
        // {
        //     var localPosition = transform.localPosition;
        //     var direction     = Vector2.zero;
        //
        //     if (localPosition.x + _spriteWidth / 2 + _spriteWidth * (bubbleCount - 1) > _screenBounds.x)
        //         direction = Vector2.left;
        //
        //     if (localPosition.x - _spriteWidth / 2 < -_screenBounds.x)
        //         direction = Vector2.right;
        //
        //     if (localPosition.y + _spriteHeight / 2 > _screenBounds.y)
        //         direction = Vector2.down;
        //     if (localPosition.y - _spriteHeight / 2 < -_screenBounds.y)
        //         direction = Vector2.up;
        //
        //     if (direction == Vector2.zero) return;
        //
        //     _rigidbody2D.linearVelocity = Vector2.zero;
        //     _rigidbody2D.AddForce(direction * boundForce);
        // }

        private void UpdatePositionToMidPoint()
        {
            var count = transform.childCount;
            if (count == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                var midPoint = (transform.GetChild(0).position + transform.GetChild(count - 1).position) / 2;
                var Dir = transform.position - midPoint;
                for (var i = 0; i < count; i++) transform.GetChild(i).position += Dir * Time.deltaTime;
            }
        }
    }
}