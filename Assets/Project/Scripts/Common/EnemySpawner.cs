using System;
using System.Collections.Generic;
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

        private CompositeDisposable _disposable = new();
        

        private void Start()
        {
            _enemyPool.Init(_enemyFactory,_enemySpawnConfig,_spawnPoints);
            _enemyPool.ActiveEnemies.Subscribe(v =>
            {
                Debug.Log(v);
                if (v <= 0)
                {
                    _enemyPool.ActivateEnemies();
                }
            }).AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable?.Clear();
        }
    }
}