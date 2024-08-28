using Project.Scripts.UI.Screens;
using UnityEngine;
using Zenject;

namespace Project.Scripts.UI
{
    public class ResumeButton : BaseButton
    {
        [Inject] private UIManager _uiManager;
        [SerializeField] private AudioSource _audioSource;
        
        protected override void OnClick()
        {
            _uiManager.SetScreen(EScreenType.Game, true);
            _audioSource.volume = 0.5F;
            Time.timeScale = 1;
        }
    }
}