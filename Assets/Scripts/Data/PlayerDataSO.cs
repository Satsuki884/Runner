using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 1)]
public class PlayerDataSO : ScriptableObject
{
    [SerializeField] private int _coin;
    [SerializeField] private int _record;
    [SerializeField] private CharacterDataSO _characterPrefab;

    public int coin{
        get{
            return _coin;
        }
        set{
            _coin = value;
        }
    }

    public int record{
        get{
            return _record;
        }
        set{
            if(value > _record){
                _record = value;
            }
        }
    }

    public CharacterDataSO characterPrefab{
        get{
            return _characterPrefab;
        }
        set{
            _characterPrefab = value;
        }
    }
}