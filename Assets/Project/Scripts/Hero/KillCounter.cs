using System;
using Project.Scripts.Configs;
using Project.Scripts.Factory;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Project.Scripts.Hero
{
    [RequireComponent(typeof(AudioSource))]
    public class KillCounter : MonoBehaviour
    {
        [Inject] private EnemyPool _enemyPool;
        [Inject] private AudioConfig _audioConfig;
        
        private AudioSource _audioSource;
        private AudioClip _firstClip;
        private AudioClip _secondClip;
        private CompositeDisposable _disposable = new();
        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            _firstClip = _audioConfig.AudioClips[EAudioClip.WaveKilledFirst];
            _secondClip = _audioConfig.AudioClips[EAudioClip.WaveKilledSecond];
            
            _enemyPool.EnemiesKilled.Subscribe(v =>
            {
                if (v % 3 == 0)
                {
                    _audioSource.clip = PlayRandomAudio();
                    _audioSource.Play();
                }
            }).AddTo(_disposable);
        }

        private AudioClip PlayRandomAudio()
        {
           int random = Random.Range(0,2);
           Debug.Log(random + " a");
           if (random == 1)
           {
               return _firstClip;
           }
           
           return _secondClip;
        }

        private void OnDestroy()
        {
            _disposable?.Clear();
        }
    }
}