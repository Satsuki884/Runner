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

    private SaveManager _saveManager;

    private Animator _animator;
    private bool _isAlive = true;

    private PlayerDataSO PlayerData{ get; set; }

    [SerializeField] private GameController _gameController;

    void Start()
    {
        _saveManager = GameInstaller.Instance.SaveManager;
        PlayerData = _saveManager.PlayerData;
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

        if (_gameController.CoinsCount > PlayerData.record)
        {
            PlayerData.record = _gameController.CoinsCount;
        }
        PlayerData.coin = _gameController.CoinsCount + PlayerData.coin;
        _saveManager.SavePlayer(PlayerData);
    }



}
