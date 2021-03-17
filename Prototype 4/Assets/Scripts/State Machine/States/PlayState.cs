using System;
using System.Collections;
using UnityEngine;

internal class PlayState : State
{
    public PlayState(StateMachine stateMachine) : base(stateMachine) {}

    public override IEnumerator ResponseClicked(Response eventResponse)
    {
        _stateMachine.SetState(new ExecuteState(_stateMachine, eventResponse));
        yield break;
    }
    public override IEnumerator UnitClicked(Unit unit)
    {
        if (unit.engaged)
            _stateMachine.engaged.TransferUnit(_stateMachine.vigilant, unit);
        else
            _stateMachine.vigilant.TransferUnit(_stateMachine.engaged, unit);

        unit.engaged = !unit.engaged;

        yield break;
    }
}
