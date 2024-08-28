using System.Collections.Generic;
using Project.Scripts.Configs;
using Project.Scripts.Enemy;
using UniRx;
using UnityEngine;

namespace Project.Scripts.Factory
{
    public class EnemyPool
    {
        private EnemyFactory _enemyFactory;
        private EnemySpawnConfig _config;
        private EnemyController _prefab;
        
        private List<EnemyController> _enemies = new();
        private List<Transform> _spawnPoints;
        public ReactiveProperty<int> ActiveEnemies = new();

        private int _activeEnemiesStart;
        private Transform _currentSpawnPoint;
        private int _spawnPointID = 0;

        public void Init(EnemyFactory factory, EnemySpawnConfig config, List<Transform> spawnPoints)
        {
            _enemyFactory = factory;
            _config = config;
            _spawnPoints = spawnPoints;
            _activeEnemiesStart = _config.ActiveEnemiesStart;

            _prefab = _config.Prefab;
            CreatePool();
        }

        private void CreatePool()
        {
            for (int i = 0; i < _config.PoolSize; i++)
            {
                SetNextPos();
                EnemyController enemy = _enemyFactory.Create(_prefab, _currentSpawnPoint.position, Quaternion.identity, _currentSpawnPoint);
                _enemies.Add(enemy);
                enemy.gameObject.SetActive(false);
            }
        }

        public void ActivateEnemies()
        {
            for (int i = 0; i < _activeEnemiesStart; i++)
            {
                _enemies[i].gameObject.SetActive(true);
                ActiveEnemies.Value++;
            }
        }

        public void RemoveEnemy(EnemyController enemy)
        {
            _enemies.Remove(enemy);
            ActiveEnemies.Value--;
        }

        private void SetNextPos()
        {
            if (_spawnPointID >= _spawnPoints.Count)
            {
                _spawnPointID = 0;
            }
            
            _currentSpawnPoint = _spawnPoints[_spawnPointID];
            _spawnPointID++;
        }
    }
}