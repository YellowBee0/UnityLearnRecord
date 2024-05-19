public class StateMachine
{
    private BaseState curState;
    public void StateInit(BaseState _firstState)
    {
        curState = _firstState;
        curState.Enter();
    }
    public void ChangeState(BaseState _newState)
    {
        curState.Exit();
        curState = _newState;
        curState.Enter();
    }
    public void Update() => curState.Update();
}