using UnityEngine;

namespace Core
{
    public class ArrowScript : MonoBehaviour
    {
        [SerializeField] private float     interval = 1;
        [SerializeField] private AudioClip timerClip;

        private AudioSource    _audioSource;
        private SpriteRenderer _spriteRenderer;

        private float _timer;

        private void Start()
        {
            _audioSource    = GetComponent<AudioSource>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetArrowEffect()
        {
            _timer += Time.deltaTime;

            if (_timer >= interval)
            {
                _timer                  = 0;
                _spriteRenderer.enabled = !_spriteRenderer.enabled;
                _audioSource?.PlayOneShot(timerClip);
            }
        }

        public void DisableArrow()
        {
            _spriteRenderer.gameObject.SetActive(false);
        }
    }
}