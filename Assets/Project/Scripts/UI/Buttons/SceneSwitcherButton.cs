using Project.Scripts.Common;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Project.Scripts.UI
{
    public class SceneSwitcherButton : BaseButton
    {
        private SceneLoader _sceneLoader;

        [Inject]
        private void Init(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        [LabelText("Сцена которую надо загрузить")]
        [SerializeField] private ESceneType _nextScene;

        protected override void OnClick()
        {
            _sceneLoader.LoadScene(_nextScene);
        }
    }
}