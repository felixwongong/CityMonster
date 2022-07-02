using System.Collections;

namespace cofydev.util.StateMachine
{
    public interface IStateContext
    {
        public IEnumerator StartContext(IStateMachine sm);
    }
}