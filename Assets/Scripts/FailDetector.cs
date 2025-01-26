using Core;
using UnityEngine;

public class FailDetector : MonoBehaviour
{
    [SerializeField] private BubbleSpawner bubbleSpawner;
    [SerializeField] private string        sceneName;
    [SerializeField] private float         duration;

    private void Update()
    {
        if (bubbleSpawner.CurrentCount == 0) Initiate.Fade(sceneName, Color.black, duration);
    }
}