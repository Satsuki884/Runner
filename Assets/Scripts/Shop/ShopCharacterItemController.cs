using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System;

namespace Runner
{
    public class ShopCharacterItemController : MonoBehaviour
    {
        // [SerializeField] private GameObject _charactersPrefab;
        [SerializeField] private GameObject _charactersParent;
        [SerializeField] private TMP_Text _characterName;
        [SerializeField] private Button _characterBuyButton;
        [SerializeField] private Button _characterUseButton;
        [SerializeField] private Button _characterUsedButton;
        [SerializeField] private TMP_Text _characterSpeed;
        [SerializeField] private TMP_Text _characterCoin;
        [SerializeField] private TMP_Text _buyText;
        private PlayerDataWrapper PlayerData;

        public void Start()
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

        private void SetBuyButton(string buyText)
        {
            _characterBuyButton.gameObject.SetActive(true);
            _buyText.text = buyText;
            _characterUseButton.gameObject.SetActive(false);
            _characterUsedButton.gameObject.SetActive(false);
        }

        private void SetUseButton()
        {
            _characterBuyButton.gameObject.SetActive(false);
            _characterUseButton.gameObject.SetActive(true);
            _characterUsedButton.gameObject.SetActive(false);
        }

        private void SetUsedButton()
        {
            _characterBuyButton.gameObject.SetActive(false);
            _characterUseButton.gameObject.SetActive(false);
            _characterUsedButton.gameObject.SetActive(true);
        }


        public void SetCharacterData(CharacterDataSO characterData, string buyText)
        {
            _characterName.text = characterData.CharacterName;
            _characterSpeed.text = "x" + characterData.Speed.ToString();
            _characterCoin.text = "x" + characterData.Coin.ToString();

            if (PlayerData == null)
            {
                PlayerData = GameInstaller.Instance.SaveManager.PlayerData;
            }

            if (characterData.Price.ToString() == buyText)
            {
                SetBuyButton(buyText);
                if (PlayerData.Coin <= characterData.Price)
                {
                    _characterBuyButton.interactable = false;
                }
            }
            else if (buyText == "Use")
            {
                if (PlayerData.CharacterPrefab == characterData.CharacterPrefab)
                {
                    SetUsedButton();
                    _characterUsedButton.interactable = false;
                }
                else
                {
                    SetUseButton();
                }
            }
        }
    }
}