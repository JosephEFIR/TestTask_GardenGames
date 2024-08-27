using UnityEngine;

namespace Project.Scripts.Hero
{
    [RequireComponent(typeof(Animator))]
    public class UnitAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetTrigger(EAnimationType animType)
        {
            _animator.SetTrigger(animType.ToString());
        }

        public void SetMoveSpeed(float value)
        {
            _animator.SetFloat("Move" ,value);
        }

        public void SetAnimID(int value)
        {
            _animator.SetInteger("AnimationID", value);
        }
    }
}