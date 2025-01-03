using UnityEngine;
namespace Runner
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Data/CharacterDataSO", order = 1)]
    public class CharacterDataSO : ScriptableObject
    {
        [SerializeField] private string _characterName;
        [SerializeField] private GameObject _characterPrefab;
        public string CharacterName => _characterName;
        public GameObject CharacterPrefab { get; set; }

        [SerializeField] private int _price;
        public int Price => _price;

        [SerializeField] private float _speed;
        public float Speed => _speed;
        [SerializeField] private float _coin;
        public float Coin => _coin;
    }
}