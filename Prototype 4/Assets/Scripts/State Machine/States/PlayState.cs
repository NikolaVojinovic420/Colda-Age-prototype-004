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
    public override void Engage(Unit unit)
    {
        Debug.Log("Engaged");
        unit.Move(_stateMachine.engaged);
    }
    public override void Disengage(Unit unit) 
    {
        Debug.Log("Disengaged");
        unit.Move(_stateMachine.vigilant);
    }

}