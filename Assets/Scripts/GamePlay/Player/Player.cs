using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Player : MonoBehaviour
{

    public UnityEvent DieEvent = new();

    [SerializeField] private float _speed = 5;
    [SerializeField] private CharacterController _characterController;

    [Inject] public GameController _gameManager{ get; set;}
    [Inject] public SaveManager _saveManager{ get; set;}

    private Animator _animator;
    private bool _isAlive = true;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (_isAlive) _characterController.Move(Vector3.right * _speed * Input.GetAxis("Horizontal") * Time.deltaTime);
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

        _saveManager.PlayerData.coin = _gameManager.CoinsCount + _saveManager.PlayerData.coin;

        if (_saveManager.PlayerData.coin > _saveManager.PlayerData.record)
        {
            _saveManager.PlayerData.record = _saveManager.PlayerData.coin;
        }
    }



}
