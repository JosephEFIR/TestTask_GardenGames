using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Common
{
    public enum ESceneType
    {
        Game,
        Menu,
        Tutorial,
    }
    public class SceneLoader
    {
        public void LoadScene(ESceneType sceneType)
        {
            switch (sceneType)
            {
                case ESceneType.Menu:
                    SceneManager.LoadScene(0);
                    SceneManager.UnloadScene(SceneManager.GetActiveScene());
                    break;
                case ESceneType.Game:
                    SceneManager.LoadScene(1);
                    SceneManager.UnloadScene(SceneManager.GetActiveScene());
                    break;
                case ESceneType.Tutorial:
                    SceneManager.LoadScene(2);
                    SceneManager.UnloadScene(SceneManager.GetActiveScene());
                    break;
                default:
                    Debug.LogError("Scene not found");
                    SceneManager.LoadScene(0);
                    break;
            }
        }
    }
}