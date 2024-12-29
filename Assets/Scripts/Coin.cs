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

    [Inject] public GameController _gameManager{ get; set;}
    private void OnTriggerEnter(Collider other)
    {
        _gameManager.AddCoin();
        Destroy(gameObject);
    }
}
