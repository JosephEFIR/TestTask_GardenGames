using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI.Screens
{
    public enum EScreenType
    {
        None,
        Victory,
        Failed,
        Game,
        Pause,
    }
    
    public class Screen : MonoBehaviour
    {
        [SerializeField] private EScreenType _sreenType;
        [SerializeField] private Image _backGround;
        
        public EScreenType ScreenType => _sreenType;

        private void Start()
        {
            _backGround.DOFade(1F, 2);
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
        }
    }
}