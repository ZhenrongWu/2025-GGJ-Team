using System;
using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class TitleAnimation : MonoBehaviour
    {
        [SerializeField] private float endValue = 1;
        [SerializeField] private float duration = .5f;
        [SerializeField] private Ease  easeType;

        private void Start()
        {
            GetComponent<RectTransform>().DOAnchorPosY(endValue, duration)
                                         .SetLoops(-1, LoopType.Yoyo)
                                         .SetEase(easeType)
                                         .SetLink(gameObject);
        }
    }
}