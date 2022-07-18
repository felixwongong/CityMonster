using System.Collections.Generic;
using UnityEngine;

namespace Script.Battle.Core
{
    public class BattleMonsterHandler : MonoBehaviour
    {
        #region DEBUG

        [SerializeField] private List<GameObject> redSideMonsters;
        [SerializeField] private List<GameObject> blueSideMonsters;

        private void Awake()
        {
            battleMonsters = new Dictionary<EBattleSide, List<GameObject>>
            {
                { EBattleSide.RED, redSideMonsters},
                { EBattleSide.BLUE, blueSideMonsters}
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