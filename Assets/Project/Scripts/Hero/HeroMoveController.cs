using System;
using Unity.Mathematics;
using UnityEngine;

namespace Project.Scripts.Hero
{
    [RequireComponent(typeof(UnitAnimator))]
    public class HeroMoveController : MonoBehaviour
    {
        [SerializeField] private FixedJoystick _joystick;
        
        private CharacterController _characterController;
        private Rigidbody _rigidbody;
        private UnitAnimator _animator;
        private int _speed = 1;

        private const string horizontalAxis = "Horizontal";
        private const string verticalAxis = "Vertical";

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<UnitAnimator>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            // #region PC_Controller
            //
            // Vector3 moveVector = new Vector3(Input.GetAxis(horizontalAxis), 0 , Input.GetAxis(verticalAxis));
            // _characterController.Move(moveVector * Time.deltaTime * _speed);
            // //gameObject.transform.rotation = Quaternion.LookRotation(_characterController.velocity); //TODO problem
            // #endregion

            #region MobileController
            _characterController.Move(new Vector3(_joystick.Horizontal * _speed, 0, _joystick.Vertical * _speed) * Time.deltaTime);

            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                Quaternion toRotation = Quaternion.LookRotation(_characterController.velocity, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
            }
            #endregion
            
            
            _animator.SetMoveSpeed(MathF.Abs(_characterController.velocity.magnitude));
        }
    }
}