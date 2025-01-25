using System;
using UnityEngine;

namespace Core
{
    public class BubbleAnimation : MonoBehaviour
    {
        private Animator         _animator;
        private Camera           _mainCamera;
        private BubbleController _bubbleController;

        private void Start()
        {
            _animator         = GetComponent<Animator>();
            _bubbleController = transform.parent.GetComponent<BubbleController>();
            _mainCamera       = Camera.main;
        }

        private void Update()
        {
            HandleAnimationEnd("Bubble_Cracked");

            if (!Input.GetMouseButtonDown(0)) return;

            Vector2 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

            var hit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero);

            if (hit.collider == null || hit.collider.gameObject != gameObject) return;
            if (gameObject.CompareTag("Bubble"))
                _animator.SetTrigger($"IsCracked");
        }

        private void HandleAnimationEnd(string animationName)
        {
            var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 1 && stateInfo.IsName(animationName))
            {
                if (_bubbleController.ExtraBubbleCount > 0) _bubbleController.ExtraBubbleCount--;

                Destroy(gameObject);
            }
        }
    }
}