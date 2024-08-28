using System;
using UniRx;
using UnityEngine;

namespace Project.Scripts
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicManager : MonoBehaviour
    {
        private AudioSource _audioSource;

        public readonly ReactiveProperty<float> Volume = new();

        private CompositeDisposable _disposable = new();

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            Volume.Subscribe(v => _audioSource.volume = v).AddTo(_disposable);
            Volume.Value = 0.5F;
        }

        private void OnDestroy()
        {
            _disposable?.Clear();
        }
    }
}