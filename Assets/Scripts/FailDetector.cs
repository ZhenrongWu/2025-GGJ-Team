using Core;
using EasyTransition;
using UnityEngine;

public class FailDetector : MonoBehaviour
{
    [SerializeField] private string             sceneName;
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float              startDelay;

    private BubbleSpawner _bubbleSpawner;
    private BubbleWrecker _bubbleWrecker;
    private PassDetector  _passDetector;

    private bool _isTransitioning;

    private void Start()
    {
        _bubbleSpawner = FindFirstObjectByType<BubbleSpawner>();
        _bubbleWrecker = FindFirstObjectByType<BubbleWrecker>();
        _passDetector  = FindFirstObjectByType<PassDetector>();
    }

    private void Update()
    {
        if (_bubbleSpawner.CurrentBubbleCount == 0 &&
            !_bubbleWrecker.IsCharacter            &&
            !_passDetector.IsPassing)
        {
            if (_isTransitioning) return;

            TransitionManager.Instance().Transition(sceneName, transition, startDelay);
            _isTransitioning = true;
        }
    }
}