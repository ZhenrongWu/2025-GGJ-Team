using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonTransition : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        [SerializeField] private Color  loadToColor = Color.black;
        [SerializeField] private float  duration    = 1f;

        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => { Initiate.Fade(sceneName, loadToColor, duration); });
        }
    }
}