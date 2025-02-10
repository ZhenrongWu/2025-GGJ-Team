using System.Collections;
using UnityEngine;

namespace Core
{
    public class BubbleWrecker : MonoBehaviour
    {
        private BubbleSpawner _bubbleSpawner;

        private bool _isCharacter;

        public bool IsCharacter
        {
            get => _isCharacter;
            set => _isCharacter = value;
        }

        private void Start()
        {
            _bubbleSpawner = FindFirstObjectByType<BubbleSpawner>();
        }

        private IEnumerator OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Bubble")) yield break;

            for (var i = 0; i < other.transform.parent.childCount; i++)
                other.transform.parent.GetChild(i).GetComponent<BubbleState>().TriggerCrackEffect();

            if (gameObject.CompareTag("Target")) yield break;

            _isCharacter = true;

            _bubbleSpawner.ReceiveMessage();

            yield return new WaitForSeconds(1f);
            _bubbleSpawner.IsSpawnBubble = true;
        }
    }
}