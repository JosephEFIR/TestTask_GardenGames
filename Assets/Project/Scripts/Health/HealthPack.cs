using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Scripts.Health
{
    public class HealthPack : MonoBehaviour
    {
        [LabelText("Здоровье которое нужно дать")]
        [SerializeField] private int _health;
        [SerializeField] private Material _material;

        private Vector3 _defaultPos = new Vector3(0, 1,0);

        private void Start()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, 1);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                HealthComponent healthComponent = other.gameObject.GetComponent<HealthComponent>();
                healthComponent.AddHealth(_health);
                Debug.Log("Healed " + _health);
                Destroy(gameObject);
            }
        }


        private void FixedUpdate()
        {
            if (_material.color.a == 1)
            {
                _material.DOColor(new Color(_material.color.r,_material.color.g, _material.color.b, 0 ), 2);
                transform.DORotate(new Vector3(0,180,0), 2);
                transform.DOMoveY(2, 2);
            }
            if (_material.color.a == 0)
            {
                _material.DOColor(new Color(_material.color.r,_material.color.g, _material.color.b, 1 ), 2);
                transform.DORotate(new Vector3(0,360,0), 2);
                transform.DOMoveY(_defaultPos.y, 2);
            }
            Debug.Log(_material.color.a);
        }
    }
}