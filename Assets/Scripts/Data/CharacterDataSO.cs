using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Data/CharacterDataSO", order = 1)]
public class CharacterDataSO : ScriptableObject
{
    [SerializeField] private string _characterName;
    [SerializeField] private GameObject _characterPrefab;
    public string characterName{
        get{
            return _characterName;
        }
        set{
            _characterName = value;
        }
    }
    public GameObject characterPrefab{ get; set; }
}