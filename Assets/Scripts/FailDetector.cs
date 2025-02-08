using Core;
using EasyTransition;
using UnityEngine;

public class FailDetector : MonoBehaviour
{
    [SerializeField] private BubbleSpawner      bubbleSpawner;
    [SerializeField] private PassDetector       passDetector;
    [SerializeField] private string             sceneName;
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float              startDelay;

    private bool _isTransitioning;

    private void Update()
    {
        if (bubbleSpawner.CurrentCount == 0 && !passDetector.IsPassing)
        {
            if (_isTransitioning) return;

            TransitionManager.Instance().Transition(sceneName, transition, startDelay);
            _isTransitioning = true;
        }
    }
}