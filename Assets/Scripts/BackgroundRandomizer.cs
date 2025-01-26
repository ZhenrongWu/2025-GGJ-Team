using UnityEngine;

public class BackgroundRandomizer : MonoBehaviour
{
    [SerializeField] private Sprite[] backgroundImages;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.sprite = backgroundImages[Random.Range(0, backgroundImages.Length)];
    }
}