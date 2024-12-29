using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Data/CharacterDataSO", order = 1)]
public class CharacterDataSO : ScriptableObject
{
    [SerializeField] private string _characterName;
    [SerializeField] private GameObject _characterPrefab;
    public string CharacterName => _characterName;
    public GameObject CharacterPrefab{ get; set; }

    [SerializeField] private int _price;
    public int Price => _price;
}