public class BaseState
{
    protected StateMachine stateMachine;
    protected bool trigger;
    protected float stateTimer;
    public BaseState()
    {
        EventManager.ListenForEvent("AnimationTrigger", null, (_, _) => { AnimationFinish(); });
    }

    public virtual void Enter()
    {
        trigger = false;
    }

    public virtual void Exit()
    {

    }


    public virtual void Update()
    {

    }

    protected void AnimationFinish()
    {
        trigger = true;
    }

}
