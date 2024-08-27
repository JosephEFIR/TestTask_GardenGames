using System;
using Project.Scripts.Configs;
using Project.Scripts.Health;
using Project.Scripts.Hero;
using UniRx;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Triggers
{
    public class AttackTrigger : MonoBehaviour
    {
        [Inject] private HeroController _controller;
        private int _damage;
        private bool _isAttack;

        private CompositeDisposable _disposable = new();
        private void Start()
        {
            _damage = _controller.Config.UnitStats[EUnitStat.Damage];
            _controller.IsAttack.Subscribe(v => _isAttack = v).AddTo(_disposable);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isAttack && other.CompareTag("Enemy"))
            {
                HealthComponent enemyHealth = other.GetComponent<HealthComponent>();
                enemyHealth.GetDamage(_damage);
                Debug.Log("a");
            }
        }

        private void OnDestroy()
        {
            _disposable?.Clear();
        }
    }
}