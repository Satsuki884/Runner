using System.Collections.Generic;
using UnityEngine;
namespace Runner
{
    [CreateAssetMenu(fileName = "CharactersSO", menuName = "Data/CharactersSO", order = 1)]
    public class CharactersSO : ScriptableObject
    {
        public List<CharacterDataSO> unlockedCharacters;
        public List<CharacterDataSO> lockedCharacters;
    }
}