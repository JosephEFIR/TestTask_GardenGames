using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Project.Scripts.Configs;
using UniRx;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Factory
{
    public class EnemySpawner : MonoBehaviour
    {
        [Inject] private EnemyFactory _enemyFactory;
        [Inject] private EnemyPool _enemyPool;
        
        [SerializeField] private EnemySpawnConfig _enemySpawnConfig;
        [SerializeField] private List<Transform> _spawnPoints = new();

        public readonly ReactiveProperty<int> TimeToNextWave = new();

        private CancellationTokenSource _cancellationToken;
        private CompositeDisposable _disposable = new();
        

        private void Start()
        {
            _enemyPool.Init(_enemyFactory,_enemySpawnConfig,_spawnPoints);
            
            _enemyPool.ActiveEnemies.Subscribe(v =>
            {
                if (v <= 0)
                {
                    ActivateEnemies().Forget();
                }
            }).AddTo(_disposable);
        }

        private async UniTaskVoid ActivateEnemies()
        {
            _cancellationToken = new CancellationTokenSource();
            TimeToNextWave.Value = _enemySpawnConfig.TimeToNextWave;

            while (TimeToNextWave.Value > 0)
            {
                await UniTask.Delay(1000, cancellationToken:_cancellationToken.Token);
                TimeToNextWave.Value -= 1;
            }

            _enemyPool.ActivateEnemies();
            TimeToNextWave.Value = 0;
            _cancellationToken?.Cancel();
        }

        private void OnDestroy()
        {
            _cancellationToken?.Cancel();
            _disposable?.Clear();
        }
    }
}