using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    private static GameInstaller _instance;
    public static GameInstaller Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameInstaller is null.");
                // _instance = FindObjectOfType<GameInstaller>();
                // DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }

    [SerializeField] private GameController _gameController;
    public GameController GameController
    {
        get => _gameController;
        set => _gameController = value;
    }

    [SerializeField] private SaveManager _saveManager;
    public SaveManager SaveManager
    {
        get => _saveManager;
        set => _saveManager = value;
    }

    public static bool IsInitialized => _instance != null;

    public static GameInstaller GetInstance()
    {
        if (!IsInitialized)
        {
            throw new System.Exception("GameInstaller is not initialized.");
        }
        return _instance;
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject); // Предотвращение дублирования
        }
    }
}