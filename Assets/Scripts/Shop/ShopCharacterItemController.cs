using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopCharacterItemController : MonoBehaviour
{
    // [SerializeField] private GameObject _charactersPrefab;
    [SerializeField] private GameObject _charactersParent;
    [SerializeField] private TMP_Text _characterName;
    [SerializeField] private Button _characterBuyButton;
    [SerializeField] private TMP_Text _characterSpeed;
    [SerializeField] private TMP_Text _characterCoin;
    [SerializeField] private TMP_Text _buyText;

    private void Start()
    {
        AddEventListeners();
    }
    public void AddEventListeners()
    {
        _characterBuyButton.onClick.RemoveAllListeners();
        _characterBuyButton.onClick.AddListener(BuyCharacter);
    }

    private void BuyCharacter()
    {
        Debug.Log("Buy Character");
    }

    public void SetCharacterData(CharacterDataSO characterData, GameObject CharacterPrefab, string buyText)
    {
        Instantiate(CharacterPrefab, _charactersParent.transform);
        _characterName.text = characterData.CharacterName;
        _characterSpeed.text = "x" + characterData.Speed.ToString();
        _characterCoin.text = "x" + characterData.Coin.ToString();
        _buyText.text = buyText;
    }
}