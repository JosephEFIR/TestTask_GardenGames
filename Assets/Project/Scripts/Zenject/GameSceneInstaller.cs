using Project.Scripts.Common;
using Project.Scripts.Configs;
using Project.Scripts.Factory;
using Project.Scripts.Hero;
using Project.Scripts.UI;
using UnityEngine;
using Zenject;


namespace Project.Scripts.Zenject
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private AudioConfig _audioConfig;
        public override void InstallBindings()
        {
            Container.BindInstance(_audioConfig).AsSingle();
        
            Container.BindInterfacesAndSelfTo<HeroController>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemySpawner>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyPool>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIManager>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<SceneLoader>().AsSingle().NonLazy();
        }
    }
}