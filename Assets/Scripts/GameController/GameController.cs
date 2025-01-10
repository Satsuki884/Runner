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
        private Player _player;
        [SerializeField] private TileGenerator _tileGenerator;
        [SerializeField] private Tile _tile;
        private int _coinsCount;
        public int CoinsCount => _coinsCount;

        private SaveManager _saveManager;
        private PlayerDataWrapper PlayerData { get; set; }

        [SerializeField] private UnityEngine.UI.Button button;


        void Start()
        {
            _saveManager = GameInstaller.Instance.SaveManager;
            PlayerData = _saveManager.PlayerData;
            _player = FindObjectOfType<Player>();
            if(_player != null && _player.CharacterName != PlayerData.CharacterPrefab.CharacterData.CharacterName)
            {
                Destroy(_player.gameObject);
                Instantiate(PlayerData.CharacterPrefab.CharacterData.CharacterPrefab );
                _player = FindObjectOfType<Player>();
                
            } else if(_player == null)
            {
                Instantiate(PlayerData.CharacterPrefab.CharacterData.CharacterPrefab);
                _player = FindObjectOfType<Player>();
            }
            
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
            _coinsText.text = Mathf.RoundToInt(_coinsCount * _saveManager.PlayerData.CharacterPrefab.CharacterData.Coin).ToString();
            if (_coinsCount > _saveManager.PlayerData.Record)
            {
                _recordText.text = _coinsCount.ToString();
            }
        }


    }
}