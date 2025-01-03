using System;
using System.IO;
using UnityEngine;
using Runner;

public class SaveManagerTests
{
    private SaveManager _saveManager;
    private string _playerDataPath;
    private string _charactersDataPath;

    public void SetUp()
    {
        GameObject gameObject = new GameObject();
        _saveManager = gameObject.AddComponent<SaveManager>();
        _playerDataPath = Path.Combine(Application.persistentDataPath, "PlayerData.json");
        _charactersDataPath = Path.Combine(Application.persistentDataPath, "Characters.json");
    }

    public void TearDown()
    {
        if (File.Exists(_playerDataPath))
        {
            File.Delete(_playerDataPath);
        }
        if (File.Exists(_charactersDataPath))
        {
            File.Delete(_charactersDataPath);
        }
    }

    public void SavePlayer_CreatesFileAndSavesData()
    {
        SetUp();
        var playerData = new PlayerDataWrapper { Coin = 100 };
        _saveManager.SavePlayer(playerData);

        if (!File.Exists(_playerDataPath))
        {
            throw new Exception("Player data file was not created.");
        }

        string json = File.ReadAllText(_playerDataPath);
        var loadedData = JsonUtility.FromJson<PlayerDataWrapper>(json);
        if (playerData.Coin != loadedData.Coin)
        {
            throw new Exception("Player data was not saved correctly.");
        }

        TearDown();
    }

    public void SaveCharacters_CreatesFileAndSavesData()
    {
        SetUp();
        var characters = ScriptableObject.CreateInstance<CharactersSO>();
        _saveManager.SaveCharacters(characters);

        if (!File.Exists(_charactersDataPath))
        {
            throw new Exception("Characters data file was not created.");
        }

        string json = File.ReadAllText(_charactersDataPath);
        var loadedCharacters = JsonUtility.FromJson<CharactersSO>(json);
        if (characters.unlockedCharacters.Count != loadedCharacters.unlockedCharacters.Count ||
            characters.lockedCharacters.Count != loadedCharacters.lockedCharacters.Count)
        {
            throw new Exception("Characters data was not saved correctly.");
        }

        TearDown();
    }

    public static void Main()
    {
        var tests = new SaveManagerTests();
        try
        {
            tests.SavePlayer_CreatesFileAndSavesData();
            Console.WriteLine("SavePlayer_CreatesFileAndSavesData passed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"SavePlayer_CreatesFileAndSavesData failed: {ex.Message}");
        }

        try
        {
            tests.SaveCharacters_CreatesFileAndSavesData();
            Console.WriteLine("SaveCharacters_CreatesFileAndSavesData passed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"SaveCharacters_CreatesFileAndSavesData failed: {ex.Message}");
        }
    }
}
