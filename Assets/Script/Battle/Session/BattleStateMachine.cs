using cofydev.util.StateMachine;

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