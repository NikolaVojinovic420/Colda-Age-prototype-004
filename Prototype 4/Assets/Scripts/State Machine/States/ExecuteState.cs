using System.Collections;

internal class ExecuteState : State
{
    EventResponse eventResponse;
    public ExecuteState(StateMachine stateMachine, EventResponse eResponse) : base(stateMachine)
    {
        eventResponse = eResponse;
    }
    public override IEnumerator Start()
    {
        //execute effect
        //win/lose
        //instantiate new card
        //exhaust/discard
        //move engaged to recovery
        _stateMachine.SetState(new DrawUnitState(_stateMachine));
        yield break;
    }
}