using System;
using System.Collections;
using UnityEngine;

internal class PlayState : State
{
    public PlayState(StateMachine stateMachine) : base(stateMachine) {}

    public override IEnumerator ResponseClicked(EventResponse eventResponse)
    {
        Debug.Log("caught OnEventResponse event");
        _stateMachine.SetState(new ExecuteState(_stateMachine, eventResponse));
        yield break;
    }
    public override IEnumerator UnitClicked(Unit unit)
    {
        Debug.Log(unit+ " UnitClicked (method call in play state)");

        if (unit.engaged)
            _stateMachine.engaged.transferUnit(_stateMachine.vigilant, unit);
        else
            _stateMachine.vigilant.transferUnit(_stateMachine.engaged, unit);

        unit.engaged = !unit.engaged;

        yield break;
    }
}