using System;
using System.Collections;
using CM.UI;
using cofydev.util.StateMachine;
using Script.Battle.Core;
using UnityEngine;

namespace CM.Battle.Session
{
    public class DialogueState : MonoBehaviour, IStateContext
    {
        //REF
        private GameMode gameMode;
        [SerializeField] private DialogueUI dialogueUI;
        
        // CONFIG 
        [SerializeField] private float DialogueWaitTime = 3f;

        [SerializeField] private string BattleStartMsg;

        [SerializeField] private string BattleEndMsg;

        private void Awake()
        {
            gameMode = GameObject.FindWithTag("GameMode")?.GetComponent<GameMode>();
        }

        public IEnumerator StartContext(IStateMachine sm)
        {
            Debug.Log("Now in Dialogue State");
            
            string msg = GetMsgByGameState(gameMode.GetCurBattleState());
            dialogueUI.SetDialogueText(msg, true);
            
            yield return new WaitForSeconds(DialogueWaitTime);
            sm.GoToNextState(GetComponent<SpawnState>());
        }

        private string GetMsgByGameState(GameMode.BattleState battleState)
        {
            switch (battleState)
            {
                case GameMode.BattleState.START:
                    return BattleStartMsg;
                case GameMode.BattleState.END:
                    return BattleEndMsg;
            }

            Debug.LogWarning("There is no such battle state");
            return "There is no such battle state";
        }
    }
}