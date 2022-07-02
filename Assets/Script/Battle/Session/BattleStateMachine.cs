using System;
using System.Collections.Generic;
using cofydev.util.StateMachine;
using UnityEditor.UI;
using UnityEngine;

namespace CM.Battle.Session
{
    public class BattleStateMachine : UnityStateMachine 
    {
        private void Awake()
        {
            curStateContext = gameObject.GetComponent<DialogueState>();
        }

        private void Start()
        {
            GoToNextState(curStateContext);
        }
    }
}