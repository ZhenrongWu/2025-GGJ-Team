using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace Core
{
    public class BubbleSpawner : MonoBehaviour
    {
        [SerializeField] private string     words           = "Hello";
        [SerializeField] private float      destroyInterval = 1;
        [SerializeField] private float      spawnInterval   = 1;
        [SerializeField] private float      spacing         = 1;
        [SerializeField] private GameObject bubblePrefab;

        public static event Action<BubbleSpawner> OnCharacterEvent;

        private Rigidbody2D _rigidbody2D;
        private Animator    _characterAnimator;
        private Transform   _bubbleSpawnPoint;

        private float _timer;
        private int   _currentCount;
        private int   _currentIndex;
        public  int   CurrentCount => _currentCount;

        private void Start()
        {
            OnCharacterEvent?.Invoke(this);

            _rigidbody2D = GetComponent<Rigidbody2D>();

            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            _currentCount            = words.Length;

            AddABubble(_currentIndex);
        }

        private void Update()
        {
            if (_currentIndex == words.Length)
            {
                _rigidbody2D.constraints = RigidbodyConstraints2D.None;
                _characterAnimator.SetTrigger($"Finish");

                StartCoroutine(SequentialBubbleState());

                return;
            }

            AddBubbleAtIntervals();
        }

        private IEnumerator SequentialBubbleState()
        {
            foreach (var bubbleState in GetComponentsInChildren<BubbleState>())
            {
                bubbleState.IsActive = true;
                yield return new WaitForSeconds(destroyInterval);
            }
        }

        private void AddBubbleAtIntervals()
        {
            _timer += Time.deltaTime;

            if (_timer >= spawnInterval)
            {
                _timer = 0;

                _currentIndex++;

                if (_currentIndex <= words.Length - 1)
                    AddABubble(_currentIndex);
            }
        }

        private void AddABubble(int index)
        {
            var position = new Vector2(_bubbleSpawnPoint.transform.position.x + spacing * index, transform.position.y);
            var clone    = Instantiate(bubblePrefab, position, transform.rotation, gameObject.transform);
            clone.transform.localScale = Vector2.zero;

            var textMeshPro = clone.transform.GetChild(0).GetComponentInChildren<TextMeshPro>();
            textMeshPro.text = words[index].ToString();

            clone.transform.DOScale(Vector2.one, 1).SetEase(Ease.InOutBounce).SetLink(gameObject);
        }

        public void ReduceBubbleCount()
        {
            if (_currentCount > 0)
                _currentCount -= 1;
        }

        public void SetCharacter(Animator animator, Transform bubbleSpawnPoint)
        {
            _characterAnimator = animator;
            _bubbleSpawnPoint  = bubbleSpawnPoint;
        }
    }
}