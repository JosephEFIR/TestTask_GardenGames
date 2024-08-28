using Project.Scripts.Enemy;
using UnityEngine;

namespace Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "EnemySpawnConfig",  menuName = "Configs/SpawnConfig")]
    public class EnemySpawnConfig : ScriptableObject
    {
        [SerializeField] private EnemyController _prefab;
        [SerializeField] private int _poolSize;
        [SerializeField] private int _activeEnemiesStart; //TODO по другому не придумал как назвать
        
        public EnemyController Prefab => _prefab;
        public int PoolSize => _poolSize;
        public int ActiveEnemiesStart => _activeEnemiesStart;
    }
}