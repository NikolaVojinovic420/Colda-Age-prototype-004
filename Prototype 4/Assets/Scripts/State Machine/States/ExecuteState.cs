using System.Collections;

internal class ExecuteState : State
{
    EventResponse eventResponse;
    Effect effect;
    public ExecuteState(StateMachine stateMachine, EventResponse eResponse) : base(stateMachine)
    {
        eventResponse = eResponse;
        effect = eventResponse.GetComponent<Effect>();
    }
    public override IEnumerator Start()
    {
        //execute effect
        if (effect.loss)
            _stateMachine.SetState(new LossState(_stateMachine));
        if (effect.win)
            _stateMachine.SetState(new WinState(_stateMachine));
        //instantiate new card
        //exhaust/discard
        //move engaged to recovery
        _stateMachine.SetState(new DrawUnitState(_stateMachine));
        yield break;
    }
}