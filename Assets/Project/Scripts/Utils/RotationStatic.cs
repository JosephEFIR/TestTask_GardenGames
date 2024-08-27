using UnityEngine;

namespace Project.Scripts.Utils
{
    public class RotationStatic : MonoBehaviour
    {
        private void Update()
        {
            gameObject.transform.rotation = Quaternion.identity; //ну только так я смог заставить не крутится HealhBar
        }
    }
}