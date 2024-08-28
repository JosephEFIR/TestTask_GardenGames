using Project.Scripts.Common;
using Zenject;


namespace Project.Scripts.Zenject
{
    public class MenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>().AsSingle().NonLazy(); //todo project Context почему то не может подвязать этот компонент
        }
    }
}