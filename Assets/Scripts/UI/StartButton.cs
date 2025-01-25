using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StartButton : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        [SerializeField] private Color  loadToColor = Color.black;

        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => { Initiate.Fade(sceneName, loadToColor, 1.0f); });
        }
    }
}