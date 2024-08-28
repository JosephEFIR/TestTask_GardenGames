using System;
using Cysharp.Threading.Tasks;
using Project.Scripts.Configs;
using Project.Scripts.Health;
using Project.Scripts.Hero;
using UniRx;
using UnityEngine;

namespace Project.Scripts.Triggers
{
    public class AttackTrigger : MonoBehaviour
    {
        [SerializeField] private UnitController _controller;
        private int _damage;
        private bool _isAttack;

        private CompositeDisposable _disposable = new();
        private bool _unitHasDamaged; //Что бы урон не наносился несколько раз

        private void Start()
        {
            _damage = _controller.Config.UnitStats[EUnitStat.Damage];
            _controller.IsAttack.Subscribe(v => _isAttack = v).AddTo(_disposable);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isAttack && other.gameObject.tag != _controller.gameObject.tag)
            {
                if (!_unitHasDamaged)
                {
                    if (other.TryGetComponent<HealthComponent>(out HealthComponent healthComponent))
                    {
                        HealthComponent enemyHealth = other.GetComponent<HealthComponent>();
                        enemyHealth.GetDamage(_damage);
                        _unitHasDamaged = true;
                        ResetDamageFlag().Forget();
                    }
                }
            }
        }

        private async UniTaskVoid ResetDamageFlag()
        {
            await UniTask.Delay(1000);
            _unitHasDamaged = false;
        }

        private void OnDestroy()
        {
            _disposable?.Clear();
        }
    }
}