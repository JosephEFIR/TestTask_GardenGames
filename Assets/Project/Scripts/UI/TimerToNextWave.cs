using System;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;
using EnemySpawner = Project.Scripts.Factory.EnemySpawner;

namespace Project.Scripts.UI
{
    public class TimerToNextWave : MonoBehaviour
    {
        [Inject] private EnemySpawner _enemySpawner;
        [SerializeField] private TextMeshProUGUI _textMeshPro;

        private CompositeDisposable _disposable = new();

        private void Start()
        {
            _enemySpawner.TimeToNextWave.Subscribe(v =>
            {
                _textMeshPro.text = v.ToString();
                if (v <= 0)
                {
                    _textMeshPro.text = String.Empty;
                }
            }).AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable?.Clear();
        }
    }
}