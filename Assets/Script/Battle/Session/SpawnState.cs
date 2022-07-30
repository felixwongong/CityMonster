using System;
using System.Collections;
using cofydev.util.StateMachine;
using CM.Battle.Core;
using UnityEngine;

namespace CM.Battle.Session
{
    [RequireComponent(typeof(ActionState))]
    public class SpawnState : MonoBehaviour, IStateContext
    {
        public IEnumerator StartContext(IStateMachine sm)
        {
            Debug.Log("Now in Spawn State");
            
            var monsterHandler = GameObject.FindGameObjectWithTag("BattleMonsterHandler").GetComponent<BattleMonsterHandler>();

            if (GameMode.curBattleState == EBattleState.START)
            {
                monsterHandler.SpawnAllMonsterBySide(EBattleSide.RED);
                monsterHandler.SpawnAllMonsterBySide(EBattleSide.BLUE);
                
                monsterHandler.SetMonstersInitPos();
            }
            
            sm.GoToNextState(GetComponent<ActionState>());
            yield break;
        }
    }
}