using UnityEngine;

public class BackgroundRandomrizer : MonoBehaviour
{
    public Sprite[] Backgrounds;
    public SpriteRenderer BackgroundRenderer;
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        BackgroundRenderer.sprite = Backgrounds[Random.Range(0, Backgrounds.Length-1)];
    }
}
