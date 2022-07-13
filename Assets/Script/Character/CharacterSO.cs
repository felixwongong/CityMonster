using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Character
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Character/Character Object")]
    public class CharacterSO : ScriptableObject
    {
        [SerializeField] private string genericID;
        [SerializeField] private string genericName;
        [SerializeField] private List<CharacterFormSO> characterForms;

        [Serializable]
        public class CharacterFormSO
        {
            public int formLevel;
            public GameObject formCharacterPrefab;
        }
    }
}