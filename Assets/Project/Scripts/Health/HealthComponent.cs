using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Project.Scripts.Configs;
using Project.Scripts.Hero;
using UniRx;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Health
{
    public abstract class HealthComponent : MonoBehaviour
    {
        [Inject] private AudioConfig _audioConfig;
        
        public readonly ReactiveProperty<int> CurrentHealth = new();
        public readonly ReactiveProperty<int> MaxHealth = new();

        private CancellationTokenSource _cancelToken;
        private UnitAnimator _animator;
        private AudioSource _audioSource;

        protected virtual void Awake()
        {
            _animator = GetComponent<UnitAnimator>();
            _audioSource = GetComponent<AudioSource>();
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
            
            _animator.SetTrigger(EAnimationType.GetDamage);
            _audioSource.clip = _audioConfig.AudioClips[EAudioClip.GetDamage];
            _audioSource.Play();
            
            if (CurrentHealth.Value <= 0)
            {
                _cancelToken = new CancellationTokenSource();
                CurrentHealth.Value = 0;
                Die();
            }
        }

        private void Die()
        {
            _animator.SetTrigger(EAnimationType.Die);
            _audioSource.clip = _audioConfig.AudioClips[EAudioClip.Die];
            _audioSource.Play();
            OnDie();
        }

        protected virtual void OnDie()
        {
            
        }

        private void OnDestroy()
        {
            _cancelToken?.Cancel();
            _cancelToken?.Dispose();
            _cancelToken = null;
        }
    }
}