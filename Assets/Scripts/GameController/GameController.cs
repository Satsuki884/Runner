using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Zenject;

namespace Runner
{
    public class GameController : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _coinsText;
        [SerializeField] private TextMeshProUGUI _recordText;
        [SerializeField] private Player _player;
        [SerializeField] private TileGenerator _tileGenerator;
        [SerializeField] private Tile _tile;
        private int _coinsCount;
        public int CoinsCount => _coinsCount;

        private SaveManager _saveManager;

        [SerializeField] private UnityEngine.UI.Button button;


        void Start()
        {
            _saveManager = GameInstaller.Instance.SaveManager;
            _player.DieEvent.AddListener(LoseHandler);
            _recordText.text = _saveManager.PlayerData.Record.ToString();
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
            if (_coinsCount > _saveManager.PlayerData.Record)
            {
                _recordText.text = _coinsCount.ToString();
            }
        }


    }
}