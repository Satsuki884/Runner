using UnityEngine;
namespace Runner
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 1)]
    public class PlayerDataSO : ScriptableObject
    {
        [SerializeField] private PlayerDataWrapper _playerDataWrapper;
        public PlayerDataWrapper PlayerData{
            get => _playerDataWrapper;
            set => _playerDataWrapper = value;
        }
    }

    [System.Serializable]
    public class PlayerDataWrapper
    {
        [SerializeField] private int _coin;
        [SerializeField] private int _record;
        [SerializeField] private CharacterDataSO _characterPrefab;

        public int Coin
        {
            get
            {
                return _coin;
            }
            set
            {
                _coin = value;
            }
        }

        public int Record
        {
            get
            {
                return _record;
            }
            set
            {
                if (value > _record)
                {
                    _record = value;
                }
            }
        }

        public CharacterDataSO CharacterPrefab
        {
            get
            {
                return _characterPrefab;
            }
            set
            {
                _characterPrefab = value;
            }
        }
    }

}