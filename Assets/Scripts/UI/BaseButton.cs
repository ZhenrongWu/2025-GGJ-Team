using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class BaseButton : MonoBehaviour
    {
        private Button _buttonComponent;

        protected virtual void Start()
        {
            _buttonComponent = GetComponent<Button>();

            if (_buttonComponent != null) _buttonComponent.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            HandleButtonClick();
        }

        protected abstract void HandleButtonClick();
    }
}