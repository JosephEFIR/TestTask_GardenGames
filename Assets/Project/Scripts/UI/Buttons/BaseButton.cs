using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public abstract class BaseButton : MonoBehaviour
    {
        private Button _button;
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(OnClick);
        }

        protected abstract void OnClick();
    }
}