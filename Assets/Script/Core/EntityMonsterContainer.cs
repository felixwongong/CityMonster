using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Core
{
    public class EntityMonsterContainer : MonoBehaviour
    {

        [SerializeField] private List<MonsterSnapshot> monsterStatusList;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);     
        }
        
        public List<MonsterSnapshot> GetEntityMonsterSnapshots()
        {
            return monsterStatusList;
        }
    }
}