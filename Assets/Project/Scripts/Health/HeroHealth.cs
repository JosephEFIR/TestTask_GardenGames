using Project.Scripts.Configs;
using Project.Scripts.Hero;

namespace Project.Scripts.Health
{
    public sealed class HeroHealth : HealthComponent
    {
        private HeroController _heroController;

        protected override void Awake()
        {
            _heroController = GetComponent<HeroController>();
            base.Awake();
        }

        private void Start()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            MaxHealth.Value = _heroController.Config.UnitStats[EUnitStat.Health];
            CurrentHealth.Value = MaxHealth.Value;
        }
    }
}