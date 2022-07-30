using System;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace CM.Monster
{
    [CreateAssetMenu(fileName = "Create Monster Dictionary", menuName = "Character/Monster/Monster Dictionary", order = 0)]
    public class MonsterSODictionary : ScriptableObject
    {
        // STRUCT
        [Serializable]
        struct MonsterStruct
        {
            [SerializeField] internal string id;
            [SerializeField] internal MonsterSO monsterSo;
        }
        
        // VAL
        [SerializeField] private List<MonsterStruct> monsters;
        
        private Dictionary<string, MonsterSO> monsterSODictionary; 
        

        private void Awake()
        {
            monsterSODictionary = SetupMonsterDictionary();
        }

        private Dictionary<string, MonsterSO> SetupMonsterDictionary()
        {
            var dictionary = new Dictionary<string, MonsterSO>();
            
            foreach (var monster in monsters)
            {
                dictionary[monster.id] = monster.monsterSo;
            }

            return dictionary;
        }

        public GameObject GetMonster(string id, int level)
        {
            MonsterSO monsterSo = monsterSODictionary[id];
            return monsterSo.GetMonsterObject(level);
        }
    }
}