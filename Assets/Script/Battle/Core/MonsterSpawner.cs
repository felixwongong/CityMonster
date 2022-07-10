using UnityEngine;

namespace Script.Battle.Core
{
    public class MonsterSpawner : MonoBehaviour
    {
        [SerializeField] private Transform redSpawnPos;
        [SerializeField] private Transform blueSpawnPos;

        public GameObject Spawn(EBattleSide side, GameObject monster)
        {
            var spawnPos = GetSpawnPosBySide(side);
            return Instantiate(monster, spawnPos);
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