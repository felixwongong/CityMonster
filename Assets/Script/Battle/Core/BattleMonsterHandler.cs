using System.Collections.Generic;
using Script.Monster;
using Script.Core;
using UnityEngine;

namespace Script.Battle.Core
{
    public class BattleMonsterHandler : MonoBehaviour
    {
        //CONFIG
        [SerializeField] private MonsterSODictionary monsterDictionary;
        
        //STATE
        private Dictionary<EBattleSide, List<GameObject>> battleMonsters;

        private void Awake()
        {
            battleMonsters = new Dictionary<EBattleSide, List<GameObject>>();
            var monsterContainers = FindObjectsOfType<EntityMonsterContainer>();
            
            // DEBUG
            if (monsterContainers.Length < 2)
            {
                SetupTestBattleMonsters();
                return;
            }
            //

            for (var i = 0; i < monsterContainers.Length; i += 2)
            {
                SetSideBattleMonster(EBattleSide.RED, monsterContainers[i].GetEntityMonsterSnapshots());
                SetSideBattleMonster(EBattleSide.BLUE, monsterContainers[i+1].GetEntityMonsterSnapshots());
            }
        }

        public void SetSideBattleMonster(EBattleSide side, List<MonsterSnapshot> monsterSnapshots)
        {
            foreach (var monsterSnapshot in monsterSnapshots)
            {
                if (!battleMonsters.ContainsKey(side))
                {
                    battleMonsters[side] = new List<GameObject>();
                }
                battleMonsters[side].Add(monsterDictionary.GetMonster(monsterSnapshot.monsterId, monsterSnapshot.level));
            }
        }
        
        public void SpawnAllMonsterBySide(EBattleSide side)
        {
            var monsterSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<MonsterSpawner>();

            var monsterPrefabs = battleMonsters[side];

            foreach (var monsterPrefab in monsterPrefabs) monsterSpawner.Spawn(side, monsterPrefab);
        }

        #region DEBUG

        [SerializeField] private List<GameObject> redSideMonsters;
        [SerializeField] private List<GameObject> blueSideMonsters;

        private void SetupTestBattleMonsters()
        {
            battleMonsters = new Dictionary<EBattleSide, List<GameObject>>
            {
                { EBattleSide.RED, redSideMonsters },
                { EBattleSide.BLUE, blueSideMonsters }
            };
        }

        #endregion
    }
}