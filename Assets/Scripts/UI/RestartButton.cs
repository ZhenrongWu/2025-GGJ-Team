using EasyTransition;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class RestartButton : BaseButton
    {
        [SerializeField] private TransitionSettings transition;
        [SerializeField] private float              startDelay;

        protected override void HandleButtonClick()
        {
            TransitionManager.Instance().Transition(SceneManager.GetActiveScene().name, transition, startDelay);
        }
    }
}