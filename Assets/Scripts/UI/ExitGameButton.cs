using UnityEngine;

namespace UI
{
    public class ExitGameButton : BaseButton
    {
        protected override void HandleButtonClick()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
                Application.OpenURL(Application.absoluteURL);
            else
                Application.Quit();
        }
    }
}