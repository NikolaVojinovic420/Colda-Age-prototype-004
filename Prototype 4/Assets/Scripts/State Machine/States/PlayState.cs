using System;
using System.Collections;
using UnityEngine;

internal class PlayState : State
{
    public PlayState(StateMachine stateMachine) : base(stateMachine)
    {
    }
    public override IEnumerator OnEventResponse(EventResponse eventResponse)
    {
        _stateMachine.SetState(new ExecuteState(_stateMachine, eventResponse));
        yield break;
    }
    public override IEnumerator Engage(Unit unit)
    {
        unit.Move(_stateMachine.engaged);
        yield break;
    }
    public override IEnumerator Disengage(Unit unit)
    {
        unit.Move(_stateMachine.vigilant);
        yield break;
    }

}