using UnityEngine;

namespace UI
{
    public class ExitGameButton : BaseButton
    {
        protected override void HandleButtonClick()
        {
            Application.Quit();
        }
    }
}