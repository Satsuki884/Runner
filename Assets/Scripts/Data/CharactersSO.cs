using System;
using System.Collections.Generic;
using UnityEngine;
namespace Runner
{
    [CreateAssetMenu(fileName = "CharactersSO", menuName = "Data/CharactersSO", order = 1)]
    public class CharactersSO : ScriptableObject
    {
        [SerializeField] private List<CharacterDataSO> _unlockedCharacters;
        [SerializeField] private List<CharacterDataSO> _lockedCharacters;

        public List<CharacterDataSO> UnlockedCharacters
        {
            get => _unlockedCharacters;
            set => _unlockedCharacters = value;
        }

        public List<CharacterDataSO> LockedCharacters
        {
            get => _lockedCharacters;
            set => _lockedCharacters = value;
        }

    }

    [System.Serializable]
    public class CharactersDataHolder{
        public List<CharacterDataSO> UnlockedCharacters;
        public List<CharacterDataSO> LockedCharacters;
    }
}