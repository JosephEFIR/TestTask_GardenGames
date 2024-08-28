using System.Threading;
using UnityEngine;

namespace Project.Scripts.Hero
{
    public sealed class HeroController : UnitController
    {
        [SerializeField] private int _comboCount;
        private UnitAnimator _animator;

        private CancellationTokenSource _reloadToken;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
            }
        }
    }
}