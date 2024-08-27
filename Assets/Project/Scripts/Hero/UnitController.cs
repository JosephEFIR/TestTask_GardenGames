using Project.Scripts.Configs;
using UnityEngine;

namespace Project.Scripts.Hero
{
    public class UnitController : MonoBehaviour
    {
        [SerializeField] private UnitConfig _config;

        public UnitConfig Config => _config;
    }
}