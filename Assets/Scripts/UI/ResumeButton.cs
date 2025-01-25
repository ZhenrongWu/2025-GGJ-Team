using UnityEngine;

namespace UI
{
    public class ResumeButton : BaseButton
    {
        [SerializeField] private string sceneName = "MainMenu";
        [SerializeField] private float  duration  = 1;

        protected override void HandleButtonClick()
        {
            Initiate.Fade(sceneName, Color.black, duration);
        }
    }
}