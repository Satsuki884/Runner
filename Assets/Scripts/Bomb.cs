using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TOU DIE!");
        if (other.TryGetComponent(out Player player))
        {
            Destroy(gameObject);
            player.Die();
        }
    }

}
