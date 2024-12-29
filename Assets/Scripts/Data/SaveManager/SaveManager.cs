using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<CharacterDataSO> CharacterData;
    public CharactersSO Characters;
    public PlayerDataSO PlayerData;
}


public class SaveManager : MonoBehaviour
{
    public static string FilePathToPlayerData;// = Path.Combine(Application.persistentDataPath, "PlayerData.json");
    public static string FilePathToCharactersData;// = Path.Combine(Application.persistentDataPath, "Characters.json");
    private void Awake()
    {
        FilePathToPlayerData = Path.Combine(Application.persistentDataPath, "PlayerData.json");
        FilePathToCharactersData = Path.Combine(Application.persistentDataPath, "Characters.json");
    }

    [SerializeField] private CharactersSO _characters;
    [SerializeField] private PlayerDataSO _playerData;
    [SerializeField] private List<CharacterDataSO> _characterData;
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

    public PlayerDataSO PlayerData
    {
        get
        {
            if (_playerData == null)
            {
                _playerData = LoadPlayer();
            }
            return _playerData;
        }
    }

    public void SavePlayer(PlayerDataSO value)
    {
        Debug.Log("SavePlayer");
        if (!File.Exists(FilePathToPlayerData))
        {
            File.Create(FilePathToPlayerData).Dispose();
        }

        string json = JsonUtility.ToJson(new PlayerDataSO
        {
            coin = value.coin,
            record = value.record,
            characterPrefab = value.characterPrefab
        }, true);

        File.WriteAllText(FilePathToPlayerData, json);
        _playerData = value;
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
            characters = new CharactersSO();
            SaveCharacters(characters);
        }
        string json = File.ReadAllText(FilePathToCharactersData);
        characters = JsonUtility.FromJson<CharactersSO>(json);
        return characters;
    }

    private PlayerDataSO LoadPlayer()
    {
        PlayerDataSO playerData = null;
        if (!File.Exists(FilePathToPlayerData))
        {
            playerData = new PlayerDataSO();
            SavePlayer(playerData);
        }
        string json = File.ReadAllText(FilePathToPlayerData);
        playerData = JsonUtility.FromJson<PlayerDataSO>(json);
        return playerData;
    }

}

