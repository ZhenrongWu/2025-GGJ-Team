using EasyTransition;
using UnityEngine;

public class PassDetector : MonoBehaviour
{
    [SerializeField] private string             sceneName;
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float              startDelay;

    private bool _isTransitioning;
    private bool _isPassing;
    public bool IsPassing => _isPassing;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Bubble")) return;
        if (_isTransitioning) return;

        TransitionManager.Instance().Transition(sceneName, transition, startDelay);
        _isTransitioning = true;
        _isPassing = true;
    }
}