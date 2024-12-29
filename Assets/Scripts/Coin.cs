using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _speed;
    void Update()
    {
        transform.Rotate(0, _speed, 0);
    }

    private GameController _gameController;

    void Start()
    {
        _gameController = GameInstaller.Instance.GameController;
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameController.AddCoin();
        Destroy(gameObject);
    }
}
