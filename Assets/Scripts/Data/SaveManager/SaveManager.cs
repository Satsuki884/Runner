using System;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

namespace Runner
{
    public class SaveManager : MonoBehaviour
    {
        public static string FilePathToPlayerData;// = Path.Combine(Application.persistentDataPath, "PlayerData.json");
        public static string FilePathToCharactersData;// = Path.Combine(Application.persistentDataPath, "Characters.json");
        private void Awake()
        {
            FilePathToPlayerData = Path.Combine(Application.persistentDataPath, "PlayerData.json");
            Debug.Log(FilePathToPlayerData);
            FilePathToCharactersData = Path.Combine(Application.persistentDataPath, "Characters.json");
            // Debug.Log(FilePathToCharactersData);
        }

        private CharactersDataHolder _charactersHolder;
        [SerializeField] private PlayerDataSO _playerData;
        [SerializeField] private CharactersSO _characters;
        // [SerializeField] private List<CharacterDataSO> CharacterDataHolder;
        public CharactersSO Characters
        {
            get
            {
                if (_characters == null)
                {
                    _characters = LoadCharacters();
                }
                return _characters;
            }
        }

        // private PlayerDataWrapper _playerData;
        public PlayerDataWrapper PlayerData
        {
            get
            {
                // Debug.Log(_playerData.Coin);
                if (_playerData == null)
                {
                    _playerData.PlayerData = LoadPlayer();
                }
                return _playerData.PlayerData;
            }
            
        }

        public void SavePlayer(PlayerDataWrapper value)
        {
            Debug.Log("SavePlayer");
            if (!File.Exists(FilePathToPlayerData))
            {
                File.Create(FilePathToPlayerData).Dispose();
            }

            string json = JsonUtility.ToJson(value, true);

            File.WriteAllText(FilePathToPlayerData, json);
            _playerData.PlayerData = value;
        }

        public void SaveCharacters(CharactersSO value)
        {
            if (!File.Exists(FilePathToCharactersData))
            {
                File.Create(FilePathToCharactersData).Dispose();
            }

            string json = JsonUtility.ToJson(new CharactersDataHolder
            {
                UnlockedCharacters = value.UnlockedCharacters,
                LockedCharacters = value.LockedCharacters
            }, true);

            File.WriteAllText(FilePathToCharactersData, json);
            _characters = value;
        }

        private CharactersSO LoadCharacters()
        {
            if (!File.Exists(FilePathToCharactersData))
            {
                SaveCharacters(_characters);
            }
            string json = File.ReadAllText(FilePathToCharactersData);
            _charactersHolder = JsonUtility.FromJson<CharactersDataHolder>(json);
            return ConvertToCharactersSO();
        }

        private CharactersSO ConvertToCharactersSO()
        {
            CharactersSO characters = null;
            if (_charactersHolder != null)
            {
                characters = ScriptableObject.CreateInstance<CharactersSO>();
                characters.UnlockedCharacters = _charactersHolder.UnlockedCharacters;
                characters.LockedCharacters = _charactersHolder.LockedCharacters;
            }
            return characters;
        }

        private PlayerDataWrapper LoadPlayer()
        {
            PlayerDataWrapper playerData = null;
            if (!File.Exists(FilePathToPlayerData))
            {
                SavePlayer(_playerData.PlayerData);
            }
            string json = File.ReadAllText(FilePathToPlayerData);
            playerData = JsonUtility.FromJson<PlayerDataWrapper>(json);
            return playerData;
        }

    }

}