using Project.Scripts.Hero;
using Zenject;

namespace Project.Scripts.UI
{
    public sealed class AttackButton : BaseButton
    {
        [Inject] private HeroController _controller;

        protected override void OnClick()
        {
            _controller.Attack();
        }
    }
}