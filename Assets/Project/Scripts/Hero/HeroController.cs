using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Project.Scripts.Hero
{
    public class HeroController : UnitController
    {
        [SerializeField] private int _comboCount;
        private UnitAnimator _animator;

        private CancellationTokenSource _reloadToken;
        private int _coolDown = 500;
        private int comboID = 0;
        
        public readonly ReactiveProperty<bool> IsAttack = new();
        private void Awake()
        {
            _animator = GetComponent<UnitAnimator>();
        }

        private void Start()
        {
            IsAttack.Value = false;
        }

        public void Attack()
        {
            if (_reloadToken == null)
            {
                IsAttack.Value = true;
                _animator.SetTrigger(EAnimationType.Attack);
                SetCombo();
                
                Reload().Forget();
            }
        }

        private void SetCombo()
        {
            if (comboID > _comboCount)
            {
                comboID = 0;
            }
            comboID++;
            _animator.SetAnimID(comboID);
        }


        private async UniTaskVoid Reload()
        {
            _reloadToken = new CancellationTokenSource();
            await UniTask.Delay(_coolDown, cancellationToken: _reloadToken.Token);
            StopTick();
        }

        private void StopTick()
        {
            IsAttack.Value = false;
            _reloadToken?.Cancel();
            _reloadToken?.Dispose();
            _reloadToken = null;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
            }
        }
    }
}