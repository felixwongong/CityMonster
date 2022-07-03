using UnityEngine;

namespace Script.Battle.Core
{
    public class GameMode : MonoBehaviour
    {
        public enum BattleState
        {
            START,
            IN_PROGRESS,
            END
        }

        private BattleState curBattleState = BattleState.START;

        public BattleState GetCurBattleState()
        {
            return curBattleState;
        }
    }
}