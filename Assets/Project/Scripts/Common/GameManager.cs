using Cysharp.Threading.Tasks;
using Project.Scripts.Factory;
using Project.Scripts.Health;
using Project.Scripts.Hero;
using Project.Scripts.UI;
using Project.Scripts.UI.Screens;
using UniRx;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Common
{
    public class GameManager : MonoBehaviour
    {
        [Inject] private EnemyPool _enemyPool;
        [Inject] private UIManager _uiManager;
        [Inject] private HeroController _controller;

        private HeroHealth _heroHealth;
        private CompositeDisposable _disposable = new();
        
        private async void Start()
        {
            await UniTask.Delay(100); //TODO по другому пока что никак
            _heroHealth = _controller.GetComponent<HeroHealth>(); //TODO а че не в awake?

            _heroHealth.CurrentHealth.Subscribe(v =>
            {
                if (v <= 0)
                {
                    _uiManager.SetScreen(EScreenType.Failed);
                }
            }).AddTo(_disposable);
            
            _enemyPool.EnemiesCount.Subscribe(v =>
            {
                if (v <= 0)
                {
                    _uiManager.SetScreen(EScreenType.Victory);
                }
            }).AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable?.Clear();
        }
    }
}