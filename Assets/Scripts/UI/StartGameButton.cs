using EasyTransition;
using UnityEngine;

namespace UI
{
    public class StartGameButton : BaseButton
    {
        [SerializeField] private string             sceneName = "Level01";
        [SerializeField] private TransitionSettings transition;
        [SerializeField] private float              startDelay;

        protected override void HandleButtonClick()
        {
            TransitionManager.Instance().Transition(sceneName, transition, startDelay);
        }
    }
}