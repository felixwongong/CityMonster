using System.Collections;
using UnityEngine;

namespace cofydev.util.StateMachine
{
    public abstract class UnityStateMachine : MonoBehaviour, IStateMachine
    {
        private Coroutine currentContext;
        protected IStateContext curStateContext;

        public void GoToNextState(IStateContext context)
        {
            if (currentContext != null) StopCoroutine(currentContext);
            curStateContext = context;
            IEnumerator routine = curStateContext.StartContext(this);
            currentContext = StartCoroutine(routine);
        }
    }
}