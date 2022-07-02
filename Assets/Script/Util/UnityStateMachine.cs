using System;
using System.Collections.Generic;
using UnityEngine;

namespace cofydev.util.StateMachine
{
    public abstract class UnityStateMachine : MonoBehaviour, IStateMachine
    {
        protected IStateContext curStateContext = null;
        private Coroutine currentContext;
        
        public void GoToNextState(IStateContext context)
        {
            if(currentContext != null) StopCoroutine(currentContext);
            curStateContext = context;
            currentContext = StartCoroutine(curStateContext.StartContext(this));
        }
    }
}