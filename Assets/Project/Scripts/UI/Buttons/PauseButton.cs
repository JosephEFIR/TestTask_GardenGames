using Project.Scripts.UI.Screens;
using UnityEngine;
using Zenject;

namespace Project.Scripts.UI
{
    public class PauseButton : BaseButton
    {
        [Inject] private UIManager _uiManager;
        [SerializeField] private AudioSource _audioSource;
        protected override void OnClick()
        {
            _uiManager.SetScreen(EScreenType.Pause, true);
            Time.timeScale = 0;
        }
    }
}