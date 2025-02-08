using EasyTransition;
using UnityEngine;

namespace UI
{
    public class ResumeButton : BaseButton
    {
        [SerializeField] private string             sceneName = "MainMenu";
        [SerializeField] private TransitionSettings transition;
        [SerializeField] private float              startDelay;

        protected override void HandleButtonClick()
        {
            TransitionManager.Instance().Transition(sceneName, transition, startDelay);
        }
    }
}