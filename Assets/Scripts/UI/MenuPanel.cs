using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class MenuPanel : MonoBehaviour
    {
        [SerializeField] private RectTransform panel;
        [SerializeField] private float         duration = 1f;

        private bool _isActive;

        private void Start()
        {
            panel.localScale = Vector3.zero;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _isActive = !_isActive;

                if (_isActive)
                    ShowPopup();
                else
                    HidePopup();
            }
        }

        private void ShowPopup()
        {
            panel.DOScale(Vector3.one, duration).SetLink(gameObject);
        }

        private void HidePopup()
        {
            panel.DOScale(Vector3.zero, duration).SetLink(gameObject);
        }
    }
}