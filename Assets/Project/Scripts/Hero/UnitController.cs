using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Project.Scripts.Configs;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Scripts.Hero
{
    public class UnitController : MonoBehaviour
    {
        [SerializeField] private UnitConfig _config;
        
        public UnitConfig Config => _config;
        
        public readonly ReactiveProperty<bool> IsAttack = new();
        
        private int _comboCount = 4;
        private CancellationTokenSource _reloadToken;
        protected UnitAnimator _animator;
        private int _coolDown = 500;
        private int comboID = 0;

        protected virtual void Awake()
        {
            _animator = GetComponent<UnitAnimator>();
        }

        protected void Start()
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
        
        protected void SetCombo()
        {
            comboID = Random.Range(0, _comboCount + 1);
            _animator.SetAnimID(comboID);
        }
        
        protected async UniTaskVoid Reload()
        {
            _reloadToken = new CancellationTokenSource();
            await UniTask.Delay(_coolDown, cancellationToken: _reloadToken.Token);
            StopTick();
        }

        protected void StopTick()
        {
            IsAttack.Value = false;
            _reloadToken?.Cancel();
            _reloadToken?.Dispose();
            _reloadToken = null;
        }
    }
}