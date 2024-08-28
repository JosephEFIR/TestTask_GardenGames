using Project.Scripts.Configs;
using UniRx;
using UnityEngine;

namespace Project.Scripts.Hero
{
    public class UnitController : MonoBehaviour
    {
        [SerializeField] private UnitConfig _config;

        public UnitConfig Config => _config;
        
        public readonly ReactiveProperty<bool> IsAttack = new();
    }
}