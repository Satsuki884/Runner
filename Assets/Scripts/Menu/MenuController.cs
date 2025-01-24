using System;
using UnityEngine;
using UnityEngine.UI;
using Analytics;

namespace Runner
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _exitButton;

        private SceneController _sceneController;

        private void Start()
        {
            _sceneController = GameInstaller.Instance.SceneController;
            _startButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
            _startButton.onClick.AddListener(StartGame);
            _exitButton.onClick.AddListener(ExitGame);
        }

        private void ExitGame()
        {
            _sceneController.QuitApplication();
            Debug.Log("Quit");
        }

        private void StartGame()
        {
            GameAnalytics.gameAnalytics.StartGameEvent();
            _sceneController.LoadScene(_sceneController.GameScene);
        }
    }
}