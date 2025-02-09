using UnityEngine;

public class BackgroundRandomizer : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}