using System;
using UnityEngine;

namespace Core
{
    public class BubbleState : MonoBehaviour
    {
        private Animator    _animator;
        private AudioSource _audioSource;

        private void Start()
        {
            _animator    = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            HandleAnimationEnd("Crack");
        }

        private void HandleAnimationEnd(string animationName)
        {
            var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= .95f && stateInfo.IsName(animationName))
                Destroy(gameObject);
        }

        public void TriggerCrackEffect()
        {
            _audioSource?.Play();
            _animator?.SetTrigger($"Crack");
        }
    }
}