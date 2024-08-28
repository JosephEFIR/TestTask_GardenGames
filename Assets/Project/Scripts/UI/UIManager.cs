using System.Collections.Generic;
using Project.Scripts.UI.Screens;
using Sirenix.OdinInspector;
using UnityEngine;
using Screen = Project.Scripts.UI.Screens.Screen;

namespace Project.Scripts.UI
{
    public class UIManager : SerializedMonoBehaviour
    {
        [SerializeField] private EScreenType _startScreen;
        [SerializeField] private Dictionary<EScreenType,Screen> _screens;

        private Screen _currentScreen;

        private void Start()
        {
            SetScreen(_startScreen);
        }

        public void SetScreen(EScreenType screenType, bool hideCurrentScreen = false)
        {
            // _currentScreen.gameObject.SetActive(!hideCurrentScreen);
            
            _screens[screenType].gameObject.SetActive(true);
            _currentScreen = _screens[screenType];
        }
    }
}