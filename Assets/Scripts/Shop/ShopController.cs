using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System;

namespace Runner
{
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

        private float _itemWidth;
        // private float _itemSpacing = 0.5f;



        private void Start()
        {
            Characters = GameInstaller.Instance.SaveManager.Characters;
            AddEventListeners();
            CloseShop();
            CreateCharacterItems();

        }

        private string _use = "Use";

        private void CreateCharacterItems()
        {

            _itemWidth = _shopItemsContainer.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
            Destroy(_shopItemsContainer.GetChild(0).gameObject);
            _shopItemsContainer.DetachChildren();

            ShopCharacterItemController itemUI;
            float xOffset = 0f;

        

            foreach (var character in Characters.UnlockedCharacters)
            {
                itemUI = Instantiate(_characterItemPrefab, _shopItemsContainer.transform).GetComponent<ShopCharacterItemController>();

                itemUI.SetCharacterData(character, _use);

                RectTransform itemRect = itemUI.GetComponent<RectTransform>();
                itemRect.anchoredPosition = new Vector2(xOffset, 0);
                xOffset += _itemWidth;
            }

            foreach (var character in Characters.LockedCharacters)
            {
                itemUI = Instantiate(_characterItemPrefab, _shopItemsContainer.transform).GetComponent<ShopCharacterItemController>();

                itemUI.SetCharacterData(character, character.CharacterData.Price.ToString());

                RectTransform itemRect = itemUI.GetComponent<RectTransform>();
                itemRect.anchoredPosition = new Vector2(xOffset, 0);
                xOffset += _itemWidth;
            }

            _shopItemsContainer.GetComponent<RectTransform>().sizeDelta =
            new Vector2(xOffset - _itemWidth, _shopItemsContainer.GetComponent<RectTransform>().sizeDelta.y);
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
}