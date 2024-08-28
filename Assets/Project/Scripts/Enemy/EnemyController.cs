using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Project.Scripts.Hero;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Random = UnityEngine.Random;

namespace Project.Scripts.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyController : UnitController
    {
        [Inject] private HeroController _heroController;
        
        private NavMeshAgent _agent;
        private UnitAnimator _animator;

        private int _comboCount = 4;
        private CancellationTokenSource _reloadToken;
        private int _coolDown = 500;
        private int comboID = 0;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<UnitAnimator>();
        }
        
        private void Update()
        {
            if (_heroController != null)
            {
                float distanceToTarget = Vector3.Distance(transform.position, _heroController.transform.position);
                
                if (distanceToTarget > 1F)
                {
                    Move();
                }
                else
                {
                    _agent.SetDestination(transform.position);
                    Attack();
                }
            }
        }

        private void Attack()
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
            comboID = Random.Range(0, _comboCount + 1);
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

        private void Move()
        {
            _animator.SetMoveSpeed(Mathf.Abs(_agent.velocity.magnitude));
            _agent.speed = 1;
            _agent.SetDestination(_heroController.transform.position);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}