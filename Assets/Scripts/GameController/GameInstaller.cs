using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Runner
{
    public class GameInstaller : MonoBehaviour
    {
        private static GameInstaller _instance;
        public static GameInstaller Instance => _instance;
        // {
        //     get
        //     {
        //         if (_instance == null)
        //         {
        //             _instance = FindObjectOfType<GameInstaller>();
        //             DontDestroyOnLoad(_instance);
        //         }
        //         return _instance;
        //     }
        // }

        private void Awake()
        {
            if (_instance == null)
            {
                // _instance = this;
                _instance = FindObjectOfType<GameInstaller>();
                DontDestroyOnLoad(_instance);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        [SerializeField] private SaveManager _saveManager;
        public SaveManager SaveManager
        {
            get => _saveManager;
            set => _saveManager = value;
        }

        [SerializeField] private AudioManager _audioManager;
        public AudioManager AudioManager
        {
            get => _audioManager;
            set => _audioManager = value;
        }

        [SerializeField] private SceneController _sceneController;
        public SceneController SceneController
        {
            get => _sceneController;
            set => _sceneController = value;
        }
    }
}