using System.Collections;

internal class DrawUnitState : State
{
    public DrawUnitState(StateMachine stateMachine) : base(stateMachine) {}

    public override IEnumerator Start()
    {
        _stateMachine.ReshuffleIfNeededAndDrawUnit();

        _stateMachine.SetState(new DrawEventState(_stateMachine));

        yield break;
    }
}