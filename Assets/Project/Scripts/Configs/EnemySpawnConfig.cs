using Project.Scripts.Enemy;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "EnemySpawnConfig",  menuName = "Configs/SpawnConfig")]
    public class EnemySpawnConfig : ScriptableObject
    {
        [LabelText("Префаб")]
        [SerializeField] private EnemyController _prefab;
        
        [LabelText("Размер пула")]
        [SerializeField] private int _poolSize;
        [LabelText("Враги на волне")]
        
        [SerializeField] private int _activeEnemiesStart; //TODO по другому не придумал как назвать

        [LabelText("Время между волнами")] 
        [SerializeField] private int _timeToNextWave;
        
        public EnemyController Prefab => _prefab;
        public int PoolSize => _poolSize;
        public int ActiveEnemiesStart => _activeEnemiesStart;
        public int TimeToNextWave => _timeToNextWave;
    }
}