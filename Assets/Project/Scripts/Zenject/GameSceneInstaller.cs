using Project.Scripts.Hero;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<HeroController>().FromComponentsInHierarchy().AsSingle();
    }
}