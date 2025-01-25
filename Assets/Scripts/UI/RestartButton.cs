using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class RestartButton : BaseButton
    {
        [SerializeField] private float duration = 1;

        protected override void HandleButtonClick()
        {
            Initiate.Fade(SceneManager.GetActiveScene().name, Color.black, duration);
        }
    }
}