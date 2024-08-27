using Cysharp.Threading.Tasks;
using Project.Scripts.Configs;
using Project.Scripts.Enemy;

namespace Project.Scripts.Health
{
    public class EnemyHealth : HealthComponent
    {
        private EnemyController _enemyController;

        protected override void Awake()
        {
            _enemyController = GetComponent<EnemyController>();
            base.Awake();
        }

        private void Start()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            MaxHealth.Value = _enemyController.Config.UnitStats[EUnitStat.Health];
            CurrentHealth.Value = MaxHealth.Value;
        }
        
    }
}