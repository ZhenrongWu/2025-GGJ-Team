using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public enum SpawnState
    {
        Start,
        End
    }

    public class BubbleSpawner : MonoBehaviour
    {
        [SerializeField] private string      message         = "Hi";
        [SerializeField] private float       destroyInterval = 1;
        [SerializeField] private float       spawnInterval   = 1;
        [SerializeField] private float       spacing         = 1;
        [SerializeField] private GameObject  bubblePrefab;
        [SerializeField] private Transform[] spawnPoints;

        [Space] [SerializeField] private UnityEvent onCharacter2SpawnEvent;

        private BubbleController _bubbleController;

        private float _timer;
        private int   _currentBubbleCount;
        private int   _currentBubbleIndex;
        private int   _characterIndex;

        public  int  CurrentBubbleCount => _currentBubbleCount;
        private bool _isSpawnBubble;

        public bool IsSpawnBubble
        {
            get => _isSpawnBubble;
            set => _isSpawnBubble = value;
        }

        public SpawnState State { get; private set; } = SpawnState.Start;

        private void Start()
        {
            _bubbleController = FindFirstObjectByType<BubbleController>();

            _currentBubbleCount = message.Length;

            _bubbleController.transform.position = spawnPoints[_characterIndex].position;
            _bubbleController.transform.rotation = spawnPoints[_characterIndex].rotation;

            AddABubble(_currentBubbleIndex);
        }

        private void Update()
        {
            if (_isSpawnBubble)
            {
                _isSpawnBubble = false;
                SpawnBubble();
            }

            if (_currentBubbleIndex == message.Length)
            {
                State = SpawnState.End;

                StartCoroutine(SequentialBubbleState());

                return;
            }

            AddBubbleAtIntervals();
        }

        private void SpawnBubble()
        {
            onCharacter2SpawnEvent?.Invoke();

            State = SpawnState.Start;

            _currentBubbleIndex = 0;
            _currentBubbleCount = message.Length;

            _characterIndex++;
            _bubbleController.transform.position = spawnPoints[_characterIndex].position;
            _bubbleController.transform.rotation = spawnPoints[_characterIndex].rotation;

            AddABubble(_currentBubbleIndex);
        }

        private IEnumerator SequentialBubbleState()
        {
            foreach (var bubbleState in _bubbleController.GetComponentsInChildren<BubbleState>())
            {
                bubbleState.CanDestroy = true;
                yield return new WaitForSeconds(destroyInterval);
            }
        }

        private void AddBubbleAtIntervals()
        {
            _timer += Time.deltaTime;

            if (_timer >= spawnInterval)
            {
                _timer = 0;

                _currentBubbleIndex++;

                if (_currentBubbleIndex <= message.Length - 1)
                    AddABubble(_currentBubbleIndex);
            }
        }

        private void AddABubble(int bubbleIndex)
        {
            var x        = (_currentBubbleIndex - (_currentBubbleCount - 1) / 2f) * spacing;
            var position = new Vector2(x, 0);
            var clone    = Instantiate(bubblePrefab, _bubbleController.transform, true);
            clone.transform.localPosition = position;
            clone.transform.rotation      = Quaternion.identity;
            clone.transform.localScale    = Vector2.zero;

            var textMeshPro = clone.transform.GetChild(0).GetComponentInChildren<TextMeshPro>();
            textMeshPro.text = message[bubbleIndex].ToString();

            clone.transform.DOScale(Vector2.one, 1).SetEase(Ease.InOutBounce).SetLink(gameObject);
        }

        public void ReduceBubbleCount()
        {
            if (_currentBubbleCount > 0)
                _currentBubbleCount -= 1;
        }

        public void ReceiveMessage()
        {
            var newMessage = "";
            for (var i = message.Length - _currentBubbleCount; i < message.Length; i++)
                newMessage += message[i].ToString();

            message = newMessage;
        }
    }
}