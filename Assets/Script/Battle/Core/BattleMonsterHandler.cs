using System.Collections.Generic;
using Script.Core;
using Script.Monster;
using UnityEngine;

namespace Script.Battle.Core
{
    public class BattleMonsterHandler : MonoBehaviour
    {
        //CONFIG
        [SerializeField] private MonsterSODictionary monsterDictionary;

        //STATE
        private Dictionary<EBattleSide, List<GameObject>> battleMonsterPrefabs;
        private Dictionary<EBattleSide, List<Monster.Monster>> battleMonsterInstances;

        private void Awake()
        {
            battleMonsterPrefabs = new Dictionary<EBattleSide, List<GameObject>>();
            battleMonsterInstances = new Dictionary<EBattleSide, List<Monster.Monster>>();

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
                SetSideBattleMonster(EBattleSide.BLUE, monsterContainers[i + 1].GetEntityMonsterSnapshots());
            }
        }

        private void SetSideBattleMonster(EBattleSide side, List<MonsterSnapshot> monsterSnapshots)
        {
            foreach (var monsterSnapshot in monsterSnapshots)
            {
                if (!battleMonsterPrefabs.ContainsKey(side)) battleMonsterPrefabs[side] = new List<GameObject>();
                battleMonsterPrefabs[side]
                    .Add(monsterDictionary.GetMonster(monsterSnapshot.monsterId, monsterSnapshot.level));
            }
        }

        public void SpawnAllMonsterBySide(EBattleSide side)
        {
            var monsterSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<MonsterSpawner>();

            var monsterPrefabs = battleMonsterPrefabs[side];

            foreach (var monsterPrefab in monsterPrefabs)
            {
                if (!battleMonsterInstances.ContainsKey(side)) battleMonsterInstances[side] = new List<Monster.Monster>();
                battleMonsterInstances[side].Add(monsterSpawner.Spawn(side, monsterPrefab));
            }
        }

        public void SetMonstersInitPos()
        {
            for (int i = 0; i < battleMonsterInstances[EBattleSide.RED].Count; i++)
            {
                var monsterGO = battleMonsterInstances[EBattleSide.RED][i];
                var controller = monsterGO.GetComponent<Controller>();
                print(battleMonsterInstances[EBattleSide.BLUE][i]);
                controller.LookToTarget(battleMonsterInstances[EBattleSide.BLUE][i].gameObject);
            }
            
            for (int i = 0; i < battleMonsterInstances[EBattleSide.BLUE].Count; i++)
            {
                var monsterGO = battleMonsterInstances[EBattleSide.BLUE][i];
                var controller = monsterGO.GetComponent<Controller>();
                controller.LookToTarget(battleMonsterInstances[EBattleSide.RED][i].gameObject);
            }
        }
        #region DEBUG

        [SerializeField] private List<GameObject> redSideMonsters;
        [SerializeField] private List<GameObject> blueSideMonsters;

        private void SetupTestBattleMonsters()
        {
            battleMonsterPrefabs = new Dictionary<EBattleSide, List<GameObject>>
            {
                { EBattleSide.RED, redSideMonsters },
                { EBattleSide.BLUE, blueSideMonsters }
            };
        }

        #endregion
    }
}