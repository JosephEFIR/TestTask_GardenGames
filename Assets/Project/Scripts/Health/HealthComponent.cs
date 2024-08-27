using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Project.Scripts.Hero;
using UniRx;
using UnityEngine;

namespace Project.Scripts.Health
{
    public abstract class HealthComponent : MonoBehaviour
    {
        public readonly ReactiveProperty<int> CurrentHealth = new();
        public readonly ReactiveProperty<int> MaxHealth = new();

        private CancellationTokenSource _cancelToken;
        private UnitAnimator _animator;

        protected virtual void Awake()
        {
            _animator = GetComponent<UnitAnimator>();
        }

        protected abstract void Initialize();
        
        public void AddHealth(int value)
        {
            CurrentHealth.Value += value;
            CurrentHealth.Value = Math.Clamp(CurrentHealth.Value, 0, MaxHealth.Value);
        }

        public void GetDamage(int value)
        {
            CurrentHealth.Value -= value;
            if (CurrentHealth.Value <= 0)
            {
                _cancelToken = new CancellationTokenSource();
                CurrentHealth.Value = 0;
                Die().Forget();
            }
        }

        private async UniTaskVoid Die()
        {
            _animator.SetTrigger(EAnimationType.Die);
            await UniTask.Delay(500, cancellationToken: _cancelToken.Token);
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _cancelToken?.Cancel();
        }
    }
}