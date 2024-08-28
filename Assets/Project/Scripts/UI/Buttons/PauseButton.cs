using Project.Scripts.UI.Screens;
using UnityEngine;
using Zenject;

namespace Project.Scripts.UI
{
    public class PauseButton : BaseButton
    {
        [Inject] private UIManager _uiManager;
        protected override void OnClick()
        {
            _uiManager.SetScreen(EScreenType.Pause, true);
            Time.timeScale = 0;
        }
    }
}