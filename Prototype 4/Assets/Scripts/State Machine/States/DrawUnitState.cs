using System.Collections;

internal class DrawUnitState : State
{
    public DrawUnitState(StateMachine stateMachine) : base(stateMachine) {}

    public override IEnumerator Start()
    {
        if (_stateMachine.preparing.IsEmpty())
            _stateMachine.ReshuffleUnits();

        _stateMachine.DrawUnit();

        _stateMachine.SetState(new DrawEventState(_stateMachine));

        yield break;
    }
}