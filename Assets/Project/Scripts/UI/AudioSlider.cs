using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.Scripts.UI
{
    public class AudioSlider : MonoBehaviour
    {
        [Inject] private MusicManager _musicManager;
        [SerializeField] private Slider _slider;

        private void Update()
        {
            _musicManager.Volume.Value = _slider.value;
        }
    }
}