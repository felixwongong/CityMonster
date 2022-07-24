using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Monster
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Character/Monster/Monster Object", order = 1)]
    public class MonsterSO : ScriptableObject
    {
        [SerializeField] private string genericName;
        [SerializeField] private List<GameObject> characterForms;

        public GameObject GetMonsterObject(int level)
        {
            return characterForms[level];
        }
    }
}