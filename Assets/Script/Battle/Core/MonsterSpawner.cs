using UnityEngine;
using CM.Monster;

namespace CM.Battle.Core
{
    public class MonsterSpawner : MonoBehaviour
    {
        [SerializeField] private Transform redSpawnPos;
        [SerializeField] private Transform blueSpawnPos;

        [SerializeField] private Monster.Monster monsterPrefab;

        public Monster.Monster Spawn(EBattleSide side, GameObject monster)
        {
            var spawnPos = GetSpawnPosBySide(side);
            var monsterParent = Instantiate(monsterPrefab, spawnPos);
            monsterParent.SpawnChildMonster(monster);
            return monsterParent;
        }

        private Transform GetSpawnPosBySide(EBattleSide side)
        {
            return side switch
            {
                EBattleSide.RED => redSpawnPos,
                EBattleSide.BLUE => blueSpawnPos,
                _ => null
            };
        }
    }
}