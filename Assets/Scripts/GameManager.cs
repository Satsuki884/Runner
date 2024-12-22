using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private Player _player;
    [SerializeField] private TileGenerator _tileGenerator;
    [SerializeField] private Tile _tile;
    private int _coinsCount;

    [SerializeField] private UnityEngine.UI.Button button;


    void Start()
    {
        _player.DieEvent.AddListener(LoseHandler);
    }
    private void LoseHandler()
    {
        Debug.Log("end");
        _tileGenerator.SetEnablind(false);
        button.gameObject.SetActive(true);

    }

    public void SetCoin()
    {
        _coinsCount = 0;
        _coinsText.text = _coinsCount.ToString();

    }

    public void AddCoin()
    {
        _coinsCount++;
        _coinsText.text = _coinsCount.ToString();
    }

    
}
