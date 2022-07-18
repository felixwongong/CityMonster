using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Character
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Character/Monster Object")]
    public class MonsterSO : ScriptableObject
    {
        [SerializeField] private string genericID;
        [SerializeField] private string genericName;
        [SerializeField] private List<MonsterFormSO> characterForms;

        [Serializable]
        public class MonsterFormSO
        {
            public int formLevel;
            public GameObject formCharacterPrefab;
        }
    }
}