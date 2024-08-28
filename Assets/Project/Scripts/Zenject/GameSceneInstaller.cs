using Project.Scripts.Factory;
using Project.Scripts.Hero;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<HeroController>().FromComponentsInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<EnemyFactory>().AsSingle();
        Container.BindInterfacesAndSelfTo<EnemyPool>().AsSingle();
    }
}