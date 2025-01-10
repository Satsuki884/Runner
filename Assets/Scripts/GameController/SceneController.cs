using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private string _menuScene = "Menu";
        public string MenuScene => _menuScene;
        [SerializeField] private string _gameScene = "Game";
        public string GameScene => _gameScene;

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        public void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        public void QuitApplication()
        {
            Application.Quit();
        }
    }
}