using System;
using UnityEngine;
using UnityEngine.UI;
using Analytics;
using Ads;

namespace Runner
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Interstitial _interstitialAd;

        private SceneController _sceneController;

        private void Start()
        {
            _sceneController = GameInstaller.Instance.SceneController;
            _startButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
            _startButton.onClick.AddListener(StartGame);
            _exitButton.onClick.AddListener(ExitGame);

            _interstitialAd.LoadAd();
        }

        private void ExitGame()
        {
            _sceneController.QuitApplication();
            Debug.Log("Quit");
        }

        private void StartGame()
        {
            GameAnalytics.gameAnalytics.StartGameEvent();
            if (_interstitialAd != null)
            {
                _interstitialAd.OnAdFinished += LoadGameScene; // Подписываемся на событие
                _interstitialAd.ShowAd();
            }
            else
            {
                Debug.LogWarning("Interstitial Ad is not assigned.");
                LoadGameScene();
            }
        }

        private void LoadGameScene()
        {
            _interstitialAd.OnAdFinished -= LoadGameScene; // Отписываемся от события
            _sceneController.LoadScene(_sceneController.GameScene);
        }
    }
}