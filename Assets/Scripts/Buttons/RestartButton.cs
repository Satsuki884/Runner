using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Zenject;

public class RestartButton : MonoBehaviour
{

    [SerializeField] private TileGenerator _tileGenerator;
    [SerializeField] private Tile _tile;
    [SerializeField] private Player _player;
    [Inject] public GameController _gameManager{get; set;}
    [SerializeField] private UnityEngine.UI.Button _button;

    [SerializeField] private TextMeshProUGUI _coinsText;


    void Start()
    {
        if (_button != null)
        {
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(RestartLevel);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
