using UnityEngine;

namespace Core
{
    public class ArrowBehavior : MonoBehaviour
    {
        public                   GameObject     Bubbles;
        public                   Transform      Target;
        [HideInInspector] public float          BubbleLifeTime;
        public                   float          Counter;
        public                   Vector3        Pos;
        [SerializeField] private AudioClip      ClickSound;
        [SerializeField] private AudioSource    Audio;
        [SerializeField] private SpriteRenderer Sprite;

        private bool        IsPlaying = false;
        private BubbleTimer _bubbleTimer;

        private void Start()
        {
            _bubbleTimer = Bubbles.GetComponent<BubbleTimer>();
            Counter      = 0;
            Audio        = GetComponent<AudioSource>();
        }

        private void Update()
        {
            Counter = _bubbleTimer.Counter;
            if (_bubbleTimer.BubbleCount > 0)
                Target = Bubbles.transform.GetChild(0);
            else if (Bubbles != null)
                Target = Bubbles.transform;
            else if (Target == null)
                gameObject.SetActive(false);
            else
                transform.position = Vector3.Lerp(transform.position, Target.position + Pos, 0.1f);

            Flash();
        }

        private void Flash()
        {
            if (Counter < BubbleLifeTime / 3)
            {
                //normal point
                float FlashSpeed = 8;
                if (Mathf.Sin(Counter * FlashSpeed) > 0)
                {
                    Sprite.enabled = true;
                    if (!IsPlaying)
                    {
                        Audio.PlayOneShot(ClickSound);
                        IsPlaying = true;
                    }
                }
                else
                {
                    Sprite.enabled = false;
                    IsPlaying      = false;
                }
            }
            else if (Counter < BubbleLifeTime * 2 / 3)
            {
                //faster point
                float FlashSpeed = 16;
                if (Mathf.Sin(Counter * FlashSpeed) > 0)
                {
                    Sprite.enabled = true;
                    if (!IsPlaying)
                    {
                        Audio.PlayOneShot(ClickSound);
                        IsPlaying = true;
                    }
                }
                else
                {
                    Sprite.enabled = false;
                    IsPlaying      = false;
                }
            }
            else if (Counter < BubbleLifeTime)
            {
                //urgent point
                float FlashSpeed = 30;
                if (Mathf.Sin(Counter * FlashSpeed) > 0)
                {
                    Sprite.enabled = true;
                    if (!IsPlaying)
                    {
                        Audio.PlayOneShot(ClickSound);
                        IsPlaying = true;
                    }
                }
                else
                {
                    Sprite.enabled = false;
                    IsPlaying      = false;
                }
            }
        }
    }
}