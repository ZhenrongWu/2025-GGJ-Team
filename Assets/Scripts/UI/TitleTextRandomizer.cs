using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UI
{
    public class TitleTextRandomizer : MonoBehaviour
    {
        [SerializeField] private Sprite[] sprites;

        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();

            _image.sprite = sprites[Random.Range(0, sprites.Length)];
        }
    }
}