using System;
using UnityEngine;

namespace Core
{
    public class BubbleState : MonoBehaviour
    {
        [SerializeField] private float interval = 1;

        private float         _timer;
        private Animator      _animator;
        private AudioSource   _audioSource;
        private BubbleSpawner _bubbleSpawner;

        private bool _isActive;

        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        private void Start()
        {
            _animator      = GetComponent<Animator>();
            _audioSource   = GetComponent<AudioSource>();
            _bubbleSpawner = transform.parent.GetComponent<BubbleSpawner>();
        }

        private void Update()
        {
            if (!_isActive) return;

            IntervalCrackBubble();
            HandleAnimationEnd("Crack");
        }

        private void IntervalCrackBubble()
        {
            _timer += Time.deltaTime;

            if (_timer >= interval)
            {
                _timer = 0;

                TriggerCrackEffect();
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
            _audioSource?.Play();
            _animator?.SetTrigger($"Crack");
        }
    }
}