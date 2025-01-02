using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private Transform _shopItemsContainer;
    // [SerializeField] private Transform _shopMenu;
    [SerializeField] private Button _openShopButton;
    [SerializeField] private Button _closeShopButton;
    [SerializeField] private GameObject _characterItemPrefab;

    // [Header("Characters")]
    // // [SerializeField] private GameObject _charactersPrefab;
    // [SerializeField] private GameObject _charactersParent;
    // [SerializeField] private TMP_Text _characterName;
    // [SerializeField] private Button _characterBuyButton;
    // [SerializeField] private TMP_Text _characterSpeed;
    // [SerializeField] private TMP_Text _characterCoin;

    private CharactersSO Characters;

    private float _itemHeight;
    private float _itemSpacing = 0.5f;



    private void Start()
    {
        Characters = GameInstaller.Instance.SaveManager.Characters;
        AddEventListeners();
        CloseShop();
        CreateCharacterItems();
        
    }

    private void CreateCharacterItems()
    {

        _itemHeight = _shopItemsContainer.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;
        Destroy(_shopItemsContainer.GetChild(0).gameObject);
        _shopItemsContainer.DetachChildren();

        ShopCharacterItemController itemUI;

        foreach (var character in Characters.unlockedCharacters)
        {
            itemUI = Instantiate(_characterItemPrefab, _shopItemsContainer.transform).GetComponent<ShopCharacterItemController>();
            // Debug.Log(character.CharacterPrefab);

            itemUI.SetCharacterData(character, character.CharacterPrefab, "Use");
        }

        foreach (var character in Characters.lockedCharacters)
        {
            itemUI = Instantiate(_characterItemPrefab, _shopItemsContainer.transform).GetComponent<ShopCharacterItemController>();

            itemUI.SetCharacterData(character, character.CharacterPrefab, character.Price.ToString());
        }

        _shopItemsContainer.GetComponent<RectTransform>().sizeDelta =
                new Vector2(_shopItemsContainer.GetComponent<RectTransform>().sizeDelta.y,
                            (_itemHeight + _itemSpacing) * (Characters.unlockedCharacters.Count + Characters.lockedCharacters.Count - 2) + _itemSpacing);

    }

    public void AddEventListeners()
    {
        _openShopButton.onClick.RemoveAllListeners();
        _closeShopButton.onClick.RemoveAllListeners();
        _openShopButton.onClick.AddListener(OpenShop);
        _closeShopButton.onClick.AddListener(CloseShop);
    }

    private void OpenShop()
    {
        _shopPanel.SetActive(true);
    }

    private void CloseShop()
    {
        _shopPanel.SetActive(false);
    }
}