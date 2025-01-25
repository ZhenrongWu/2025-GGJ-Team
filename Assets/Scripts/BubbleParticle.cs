using UnityEngine;

public class BubbleParticle : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        _animator.SetTrigger($"pop");
    }
}