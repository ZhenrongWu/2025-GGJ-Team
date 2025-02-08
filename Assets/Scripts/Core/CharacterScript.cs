using UnityEngine;

namespace Core
{
    public class CharacterScript : MonoBehaviour
    {
        [SerializeField] private Transform bubbleSpawnPoint;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            BubbleSpawner.OnCharacterEvent += BindCharacterEvent;
        }

        private void OnDisable()
        {
            BubbleSpawner.OnCharacterEvent -= BindCharacterEvent;
        }

        private void BindCharacterEvent(BubbleSpawner bubbleSpawner)
        {
            bubbleSpawner.SetCharacter(_animator, bubbleSpawnPoint);
        }
    }
}