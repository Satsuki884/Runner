using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RestartButton : MonoBehaviour
{

    [SerializeField] private TileGenerator _tileGenerator;
    [SerializeField] private Tile _tile;
    [SerializeField] private Player _player;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private UnityEngine.UI.Button button;

    [SerializeField] private TextMeshProUGUI _coinsText;


    void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(RestartLevel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartLevel()
    {
        /*button.gameObject.SetActive(false);
        _tileGenerator.SetEnablind(true);
        _tile.SetMoving(true);
        _player.Live();
        _gameManager.SetCoin();*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
