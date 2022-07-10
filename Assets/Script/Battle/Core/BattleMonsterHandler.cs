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
            instanceBattleMonsters = new Dictionary<EBattleSide, List<GameObject>>
            {
                { EBattleSide.RED, new List<GameObject> { monster_1 } },
                { EBattleSide.BLUE, new List<GameObject> { monster_2 } }
            };
        }

        #endregion


        private Dictionary<EBattleSide, List<GameObject>> instanceBattleMonsters;

        public List<GameObject> GetSideMonsters(EBattleSide side)
        {
            return instanceBattleMonsters[side];
        }
    }
}