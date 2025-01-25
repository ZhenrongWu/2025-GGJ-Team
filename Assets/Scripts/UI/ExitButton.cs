using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ExitButton : MonoBehaviour
    {
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Application.Quit);
        }
    }
}