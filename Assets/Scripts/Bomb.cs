using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
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
