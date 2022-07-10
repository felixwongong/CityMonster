using System.Collections;
using cofydev.util.StateMachine;
using Script.Battle.Core;
using UnityEngine;

namespace CM.Battle.Session
{
    public class SpawnState : MonoBehaviour, IStateContext
    {
        public IEnumerator StartContext(IStateMachine sm)
        {
            var monsterHandler = GameObject.FindGameObjectWithTag("GameMode").GetComponent<BattleMonsterHandler>();

            if (GameMode.curBattleState == EBattleState.START)
            {
                monsterHandler.SpawnAllMonsterBySide(EBattleSide.RED);
                monsterHandler.SpawnAllMonsterBySide(EBattleSide.BLUE);
            }
            
            yield return null;
        }
    }
}