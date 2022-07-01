using System;
using System.Collections.Generic;
using cofydev.util.StateMachine;
using UnityEngine;

namespace CM.Battle.Session
{
    public class BattleStateMachine : UnityStateMachine 
    {
        private void Awake()
        {
            curStateContext = gameObject.GetComponent<SpawnState>();
        }

        private void Start()
        {
            curStateContext.StartContext();
        }
    }
}