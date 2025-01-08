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
        private CoinController _coinController;
        private ShopController _shopController;


        private PlayerDataWrapper PlayerData;
        private CharactersSO Characters;
        private CharacterDataSO character;

        public void Start()
        {
            Characters = GameInstaller.Instance.SaveManager.Characters;
            _coinController = FindObjectOfType<CoinController>();
            _shopController = FindObjectOfType<ShopController>();
            AddEventListeners();
        }

        public void AddEventListeners()
        {
            _characterBuyButton.onClick.RemoveAllListeners();
            _characterBuyButton.onClick.AddListener(BuyCharacter);
            _characterUseButton.onClick.RemoveAllListeners();
            _characterUseButton.onClick.AddListener(UseCharacter);
        }

        private void UseCharacter()
        {
            Debug.Log("Use Character "  + _characterName.text);
            PlayerData.CharacterPrefab = character;
            GameInstaller.Instance.SaveManager.SavePlayer(PlayerData);
            _shopController.RefreshShop();
        }

        private void BuyCharacter()
        {
            Debug.Log("Buy Character " + _characterName.text);
            PlayerData.Coin -= character.CharacterData.Price;
            GameInstaller.Instance.SaveManager.SavePlayer(PlayerData);
            Characters.LockedCharacters.Remove(character);
            Characters.UnlockedCharacters.Add(character);
            GameInstaller.Instance.SaveManager.SaveCharacters(Characters);
            SetCharacterData(character, "Use");
            _coinController.Refresh();
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
            character = characterData;
            _characterName.text = characterData.CharacterData.CharacterName;
            _characterSpeed.text = "x" + characterData.CharacterData.Speed.ToString();
            _characterCoin.text = "x" + characterData.CharacterData.Coin.ToString();
            

            if (PlayerData == null)
            {
                PlayerData = GameInstaller.Instance.SaveManager.PlayerData;
                Debug.Log(PlayerData.Coin);
            }

            if (characterData.CharacterData.Price.ToString() == buyText)
            {
                SetBuyButton(buyText);
                if (PlayerData.Coin <= characterData.CharacterData.Price)
                {
                    _characterBuyButton.interactable = false;
                }
            }
            else if (buyText == "Use")
            {
                if (PlayerData.CharacterPrefab.CharacterData.CharacterName == characterData.CharacterData.CharacterName)
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