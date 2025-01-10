using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Runner
{
    public class Player : MonoBehaviour
    {

        public UnityEvent DieEvent = new();

        [SerializeField] private float _speed = 5;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private string _characterName;
        public string CharacterName => _characterName;

        private SaveManager _saveManager;

        private Animator _animator;
        private bool _isAlive = true;

        private PlayerDataWrapper PlayerData { get; set; }

        private GameController _gameController;

        void Start()
        {
            _gameController = FindObjectOfType<GameController>();
            _saveManager = GameInstaller.Instance.SaveManager;
            PlayerData = _saveManager.PlayerData;
            _animator = GetComponent<Animator>();
            Debug.Log(_animator);
        }

        void Update()
        {
            if (_isAlive) _characterController.Move(Vector3.right * _speed * PlayerData.CharacterPrefab.CharacterData.Speed * Input.GetAxis("Horizontal") * Time.deltaTime);
        }

        public void Die()
        {
            if (_isAlive == false)
            {
                return;
            }

            Debug.Log("Player DIEd");
            _animator.SetTrigger("Die");
            _isAlive = false;
            DieEvent?.Invoke();
            Debug.Log(_gameController);
            Debug.Log(_gameController.CoinsCount);
            Debug.Log(PlayerData.Coin);

            if (_gameController.CoinsCount > PlayerData.Record)
            {
                PlayerData.Record = _gameController.CoinsCount;
            }
            PlayerData.Coin = _gameController.CoinsCount + PlayerData.Coin;
            Debug.Log(PlayerData.Coin);
            _saveManager.SavePlayer(PlayerData);
        }



    }
}