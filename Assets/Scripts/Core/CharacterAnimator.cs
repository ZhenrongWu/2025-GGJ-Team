using UnityEngine;

namespace Core
{
    public class CharacterAnimator : MonoBehaviour
    {
        private BubbleSpawner _bubbleSpawner;
        private Animator      _animator;

        private void Start()
        {
            _bubbleSpawner = FindFirstObjectByType<BubbleSpawner>();
            _animator      = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetBool($"IsSpeaking", _bubbleSpawner.State == SpawnState.Start);
        }
    }
}