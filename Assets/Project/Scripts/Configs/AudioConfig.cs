using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Scripts.Configs
{

    public enum EAudioClip
    {
        None,
        Hit,
        GetDamage,
        Die,
        WaveKilledFirst,
        WaveKilledSecond,
    }
    
    [CreateAssetMenu(fileName = "AudioConfig",  menuName = "Configs/AudioConfig")]
    public class AudioConfig : SerializedScriptableObject
    {
        [SerializeField] private Dictionary<EAudioClip, AudioClip> _audioClips;

        public Dictionary<EAudioClip, AudioClip> AudioClips => _audioClips;
    }
}