namespace cofydev.util.StateMachine
{
    public interface IStateMachine
    {
        public void GoToNextState(IStateContext context);
    }
}