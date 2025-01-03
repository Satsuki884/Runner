using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runner
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private GameController _gameController;
        private void Awake()
        {
            _gameController = FindObjectOfType<GameController>();
        }
        void Update()
        {
            transform.Rotate(0, _speed, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            _gameController.AddCoin();
            Destroy(gameObject);
        }
    }
}