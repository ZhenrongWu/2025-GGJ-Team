using UnityEngine;

public class PassDetector : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private float  duration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Bubble")) return;

        Initiate.Fade(sceneName, Color.black, duration);
    }
}