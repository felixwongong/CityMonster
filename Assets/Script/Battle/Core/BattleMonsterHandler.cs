using System.Collections.Generic;
using UnityEngine;

namespace Script.Battle.Core
{
    public class BattleMonsterHandler : MonoBehaviour
    {
        #region DEBUG

        [SerializeField] private GameObject monster_1;
        [SerializeField] private GameObject monster_2;

        private void Awake()
        {
            battleMonsters = new Dictionary<EBattleSide, List<GameObject>>
            {
                { EBattleSide.RED, new List<GameObject> { monster_1 } },
                { EBattleSide.BLUE, new List<GameObject> { monster_2 } }
            };
        }

        #endregion


        private Dictionary<EBattleSide, List<GameObject>> battleMonsters;

        public void SpawnAllMonsterBySide(EBattleSide side)
        {
            var monsterSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<MonsterSpawner>();

            var monsterPrefabs = battleMonsters[side];
           
            foreach (var monsterPrefab in monsterPrefabs)
            {
                monsterSpawner.Spawn(side, monsterPrefab);
            }
        }
    }
}