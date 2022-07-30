using System;
using System.Collections;
using CM.UI;
using cofydev.util.StateMachine;
using CM.Battle.Core;
using UnityEngine;

namespace CM.Battle.Session
{
    [RequireComponent(typeof(SpawnState))]
    public class DialogueState : MonoBehaviour, IStateContext
    {
        //REF
        [SerializeField] private DialogueUI dialogueUI;
        
        // CONFIG 
        [SerializeField] private float DialogueWaitTime = 3f;

        [SerializeField] private string BattleStartMsg;

        [SerializeField] private string BattleEndMsg;


        public IEnumerator StartContext(IStateMachine sm)
        {
            Debug.Log("Now in Dialogue State");
            
            dialogueUI.gameObject.SetActive(true);

            string msg = GetMsgByGameState(GameMode.curBattleState);
            
            yield return dialogueUI.SetDialogueText(msg, true);
            
            yield return new WaitForSeconds(DialogueWaitTime);
            
            dialogueUI.gameObject.SetActive(false);
            
            sm.GoToNextState(GetComponent<SpawnState>());
        }

        private string GetMsgByGameState(EBattleState battleState)
        {
            switch (battleState)
            {
                case EBattleState.START:
                    return BattleStartMsg;
                case EBattleState.END:
                    return BattleEndMsg;
                default:
                    throw new ArgumentOutOfRangeException(nameof(battleState), battleState, null);
            }

            Debug.LogWarning("There is no such battle state");
            return "There is no such battle state";
        }
    }
}