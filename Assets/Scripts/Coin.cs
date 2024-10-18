using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _speed;
    void Update()
    {
        transform.Rotate(0, _speed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameManager>().AddCoin();
        Destroy(gameObject);
    }
}
