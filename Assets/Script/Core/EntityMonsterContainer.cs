using System;
using System.Collections.Generic;
using UnityEngine;

namespace CM.Core
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