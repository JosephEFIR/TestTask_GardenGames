using Project.Scripts.UI.Screens;
using UnityEngine;
using Zenject;

namespace Project.Scripts.UI
{
    public class ResumeButton : BaseButton
    {
        [Inject] private UIManager _uiManager;
        [Inject] private MusicManager _musicManager;
        
        protected override void OnClick()
        {
            _uiManager.SetScreen(EScreenType.Game, true);
            Time.timeScale = 1;
        }
    }
}