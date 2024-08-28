using Project.Scripts.Hero;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Project.Scripts.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class EnemyController : UnitController
    {
        [Inject] private HeroController _heroController;
        
        private NavMeshAgent _agent;

        protected override void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            base.Awake();
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
                    transform.LookAt(_heroController.transform);
                    Attack();
                }
            }
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