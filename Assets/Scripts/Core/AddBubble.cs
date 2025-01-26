using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Core
{
    public class AddBubble : MonoBehaviour
    {
        public  string     words = "Hello";
        public  float      animationTime;
        public  float      spriteWidth;
        public  GameObject bubblePrefab;
        private float      _counter;
        public  GameObject character;

        public                   bool       isFinish;
        private                  GameObject _currBubble;
        [SerializeField] private int        index;

        private void Start()
        {
            isFinish                                           = false;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            index                                              = 0;
            _currBubble                                        = AddOneBubble(words, index);
            _counter                                           = 0;
            gameObject.GetComponent<BubbleTimer>().BubbleCount = words.Length;
            if (character == null) character = GameObject.Find("Character1");
        }

        private void Update()
        {
            _counter += Time.deltaTime;
            if (_currBubble != null)
            {
                //CurrBubble.transform.localScale = Vector3.one * Counter / AnimationTime;
            }

            if (_counter >= animationTime && index < words.Length)
            {
                //CurrBubble.transform.localScale = Vector3.one;
                _counter = 0;
                index++;
                _currBubble = AddOneBubble(words, index);
            }

            if (index >= words.Length || _currBubble == null)
            {
                //CurrBubble = null;
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

                if (character != null) character.GetComponent<Animator>().SetTrigger($"Speak");
                isFinish = true;
                enabled  = false;
            }
        }

        // Update is called once per frame
        private GameObject AddOneBubble(string words, int index)
        {
            Vector3 position;
            if (index >= this.words.Length) return null;
            if (index == 0)
                position = new Vector3(transform.position.x + spriteWidth * index, transform.position.y,
                                       transform.position.z);
            else
                position = new Vector3(_currBubble.transform.position.x - spriteWidth, transform.position.y,
                                       transform.position.z);
            var bubble = Instantiate(bubblePrefab, position, transform.rotation, gameObject.transform);
            var _textMesh = bubble.transform.GetChild(0).GetComponentInChildren<TextMeshPro>();
            if (_textMesh != null && index < this.words.Length) _textMesh.text = this.words[index] + "";
            Tween tween = bubble.transform.DOScale(Vector3.one, animationTime).SetEase(Ease.InOutBounce);
            bubble.transform.localScale = Vector3.zero;
            return bubble;
        }
    }
}