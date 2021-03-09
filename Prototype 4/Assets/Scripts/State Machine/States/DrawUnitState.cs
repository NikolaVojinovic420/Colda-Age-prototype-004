using System.Collections;

internal class DrawUnitState : State
{
    public DrawUnitState(StateMachine stateMachine) : base(stateMachine)
    {
    }
    public override IEnumerator Start()
    {
        //check reshuffle
        //draw one from preparing into vigilant
        //update aspect display
        _stateMachine.SetState(new NewEventState(_stateMachine));
        yield break;
    }
}