using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class StartGameButton : BaseButton
    {
        [SerializeField] private string sceneName = "Level01";
        [SerializeField] private float  duration  = 1;

        protected override void HandleButtonClick()
        {
            Initiate.Fade(sceneName, Color.black, duration);
        }
    }
}