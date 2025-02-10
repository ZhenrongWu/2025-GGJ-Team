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
        private bool _canDestroy;

        public bool CanDestroy
        {
            set => _canDestroy = value;
        }

        private void Start()
        {
            _animator      = GetComponent<Animator>();
            _audioSource   = GetComponent<AudioSource>();
            _bubbleSpawner = FindFirstObjectByType<BubbleSpawner>();
            _arrow         = transform.GetChild(1).GetComponent<ArrowScript>();
        }

        private void Update()
        {
            HandleAnimationEnd("Crack");

            if (!_canDestroy) return;

            IntervalCrackBubble();

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
            if (stateInfo.normalizedTime >= .75f && stateInfo.IsName(animationName))
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