using UnityEngine;

namespace Core
{
    public class BubbleState : MonoBehaviour
    {
        [SerializeField] private float     interval = 1;
        [SerializeField] private AudioClip crackClip;

        private float         _timer;
        private Animator      _animator;
        private AudioSource   _audioSource;
        private BubbleSpawner _bubbleSpawner;
        private ArrowScript   _arrow;

        private bool _isTrigger;
        private bool _isActive;

        public bool IsActive
        {
            set => _isActive = value;
        }

        private void Start()
        {
            _animator      = GetComponent<Animator>();
            _audioSource   = GetComponent<AudioSource>();
            _bubbleSpawner = transform.parent.GetComponent<BubbleSpawner>();
            _arrow         = transform.GetChild(1).GetComponent<ArrowScript>();
        }

        private void Update()
        {
            if (!_isActive) return;

            IntervalCrackBubble();
            HandleAnimationEnd("Crack");

            _arrow.SetArrowEffect();
        }

        private void IntervalCrackBubble()
        {
            _timer += Time.deltaTime;

            if (_timer >= interval)
            {
                _timer = 0;

                TriggerCrackEffect();
                _arrow.DisableArrow();
            }
        }

        private void HandleAnimationEnd(string animationName)
        {
            var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= .95f && stateInfo.IsName(animationName))
            {
                _bubbleSpawner.ReduceBubbleCount();
                Destroy(gameObject);
            }
        }

        public void TriggerCrackEffect()
        {
            if (_isTrigger) return;

            _audioSource?.PlayOneShot(crackClip);
            _animator?.SetTrigger($"Crack");
            _isTrigger = true;
        }
    }
}