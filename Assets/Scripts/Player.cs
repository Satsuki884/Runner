using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    public UnityEvent DieEvent = new();
    //public UnityEvent AliveEvent = new();

    [SerializeField] private float _speed = 5;
    [SerializeField] private CharacterController _characterController;

    private Animator _animator;
    private bool _isAlive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAlive) _characterController.Move(Vector3.right * _speed * Input.GetAxis("Horizontal") * Time.deltaTime);
    }

    public void Die()
    {
        if(_isAlive == false)
        {
            return;
        }
        
            Debug.Log("YOU DIE");
            _animator.SetTrigger("Die");
        _isAlive = false;
        DieEvent?.Invoke();
        
    }

    public void Live()
    {
        if (_isAlive == true)
        {
            return;
        }

        _animator.SetTrigger("Alive");
        _isAlive = true;
    }

    

}
