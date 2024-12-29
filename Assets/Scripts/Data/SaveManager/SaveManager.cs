using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public CharacterDataSO CharacterData;
    public CharactersSO Characters;
    public PlayerDataSO PlayerData;
}


public class SaveManager : MonoBehaviour
{
    private string saveFilePath;

    [SerializeField] private CharactersSO _characters;
    [SerializeField] private PlayerDataSO _playerData;
    public CharactersSO Characters{
        get{
            LoadGame();
            return _characters;
        }
        set{
            _characters = value;
            SaveGame();
        }
    }
    public PlayerDataSO PlayerData{
        get{
            LoadGame();
            return _playerData;
        }
        set{
            _playerData = value;
            SaveGame();
        }
    }

    private void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "saveData.json");
        if (!File.Exists(saveFilePath))
        {
            SaveGame();
        }
    }


    private void SaveGame()
    {
        SaveData saveData = new SaveData
        {
            Characters = _characters,
            PlayerData = _playerData
        };

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Game Saved");
        LoadGame();
    }

    private void LoadGame()
    {
        if (!File.Exists(saveFilePath))
        {
            Debug.LogWarning("Save file not found");
            return;
        }

        string json = File.ReadAllText(saveFilePath);
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);

        _characters = saveData.Characters;
        _playerData = saveData.PlayerData;

        Debug.Log("Game Loaded");
    }
}

