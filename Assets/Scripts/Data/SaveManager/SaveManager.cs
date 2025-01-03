using System;
using System.Collections.Generic;
using System.IO;
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

        [SerializeField] private CharactersSO _characters;
        [SerializeField] private PlayerDataSO _playerData;
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

            string json = JsonUtility.ToJson(new CharactersSO
            {
                unlockedCharacters = value.unlockedCharacters,
                lockedCharacters = value.lockedCharacters
            }, true);

            File.WriteAllText(FilePathToCharactersData, json);
            _characters = value;
        }

        private CharactersSO LoadCharacters()
        {
            CharactersSO characters = null;
            if (!File.Exists(FilePathToCharactersData))
            {
                SaveCharacters(_characters);
            }
            string json = File.ReadAllText(FilePathToCharactersData);
            characters = JsonUtility.FromJson<CharactersSO>(json);
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