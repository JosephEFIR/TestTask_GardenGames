using Project.Scripts.Enemy;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Factory
{
    public sealed class EnemyFactory
    {
        [Inject] private DiContainer _container;

        public EnemyController Create(EnemyController enemy, Vector3 pos, Quaternion rot, Transform parent)
        {
            return _container.InstantiatePrefabForComponent<EnemyController>(enemy,pos,rot,parent);
        }
    }
}